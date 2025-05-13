﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    class AdministareMasini_Memorie
    {
        private const int NR_MAX_MASINI = 50;
        private Masina[] masini;
        private int nrMasini;
        public AdministareMasini_Memorie()
        {
            masini = new Masina[NR_MAX_MASINI];
            nrMasini = 0;
        }
        // Adaugă o mașină în memorie
        public void AddMasina(Masina masina)
        {
            if (nrMasini < NR_MAX_MASINI)
            {
                masini[nrMasini] = masina;
                nrMasini++;
            }
            else
            {
                Console.WriteLine("Numărul maxim de mașini a fost atins!");
            }
        }
        // Obține lista de mașini din memorie
        public Masina[] GetMasini(out int nrMasini)
        {
            nrMasini = this.nrMasini;
            return masini;
        }
    }
}
