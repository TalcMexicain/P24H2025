using ClientTM.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTM.Logic
{
    internal class Route
    {

        public int NiveauBateau { get; set; }
        public int ValeurAttaque {  get; set; }
        public int ValeurCoffre1 { get; set; }
        public int ValeurCoffre2 { get; set; }
        public int ValeurCoffre3 { get; set; }
        public Boolean PresenceMonstre { get; set; }

        public Route() { }

        public Route(int niveauBateau, int valeurAttaque, int valeurCoffre1, int valeurCoffre2, int valeurCoffre3, bool presenceMonstre)
        {
            this.NiveauBateau = niveauBateau;
            this.ValeurAttaque = valeurAttaque;
            this.ValeurCoffre1 = valeurCoffre1;
            this.ValeurCoffre2 = valeurCoffre2;
            this.ValeurCoffre3 = valeurCoffre3;
            this.PresenceMonstre = presenceMonstre;
        }
    }
}
