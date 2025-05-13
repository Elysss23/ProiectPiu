using System;
using System.Collections.ObjectModel;
using System.Windows;
using LibrarieModele;
using NivelStocareDate;

namespace window
{
    public partial class MainWindow : Window
    {
        private AdministrareClienti_FisierText adminClienti;
        private AdministrareMasini_FisierText adminMasini;

        // colecții Observable pentru legare (data‑binding)
        private ObservableCollection<Client> clientiCollection;
        private ObservableCollection<Masina> masiniCollection;

        public MainWindow()
        {
            InitializeComponent();

            // inițializări stocare
            adminClienti = new AdministrareClienti_FisierText("clienti.txt");
            adminMasini = new AdministrareMasini_FisierText("masini.txt");

            // populăm combo‑box‑urile
            cmbModel.ItemsSource = Enum.GetValues(typeof(Model_masina));
            cmbCombustibil.ItemsSource = Enum.GetValues(typeof(Tip_combustibil));
            cmbCuloare.ItemsSource = Enum.GetValues(typeof(Culoare_masina));

            // încărcăm datele din fișiere
            clientiCollection = new ObservableCollection<Client>(adminClienti.GetClienti());
            masiniCollection = new ObservableCollection<Masina>(adminMasini.GetMasini());

            // atribuim ItemsSource‑ul DataGrid‑urilor
            dgClienti.ItemsSource = clientiCollection;
            dgMasini.ItemsSource = masiniCollection;
        }

        private void BtnAdaugaClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new Client(0,
                                        txtNumeClient.Text.Trim(),
                                        txtEmail.Text.Trim(),
                                        txtCNP.Text.Trim(),
                                        txtTelefon.Text.Trim());

                adminClienti.AddClient(client);
                clientiCollection.Add(client);

                txtStatus.Text = $"Client «{client.nume}» adăugat cu succes.";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Eroare adăugare client: {ex.Message}";
            }
        }

        private void BtnAdaugaMasina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var masina = new Masina(
                    0,
                    (Model_masina)cmbModel.SelectedItem,
                    (Tip_combustibil)cmbCombustibil.SelectedItem,
                    int.Parse(txtAnFabricatie.Text.Trim()),
                    (Culoare_masina)cmbCuloare.SelectedItem
                );

                adminMasini.AddMasina(masina);
                masiniCollection.Add(masina);

                txtStatus.Text = $"Mașina «{masina.model}» adăugată cu succes.";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Eroare adăugare mașină: {ex.Message}";
            }
        }
    }
}
