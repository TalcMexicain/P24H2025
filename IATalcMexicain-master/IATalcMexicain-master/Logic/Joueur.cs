using ClientTM.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTM.Logic
{
    internal class Joueur
    {

        public int Score { get; set; }
        public int ValeurAttaque { get; set; }
        public int Vie { get; set; }
        public string Activite { get; set; }
        public int NbCoffres { get; set; }
        public int ValeurButins { get; set; }

        public Joueur() { }

        public Joueur(int score, int valeurAttaque, int vie, string activite, int nbCoffres, int valeurButins)
        {
            this.Score = score;
            this.ValeurAttaque = valeurAttaque;
            this.Vie = vie;
            this.Activite = activite;
            this.NbCoffres = nbCoffres;
            this.ValeurButins = valeurButins;
        }
    }


}
