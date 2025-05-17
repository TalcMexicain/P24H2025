using ClientTM.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTM.Tries.Reals
{
    public class SecondTry : ITry
    {
        int nEquipe = 0;
        int nTour = 0;

        public SecondTry()
        {

        }

        public void Setup()
        {
            Connexion.EnvoyerMessage("MT"); // nom équipe

            string message = Connexion.RecevoirMessage(); // Oui votre equipe s'appelle nanana + nEquipe
            Console.WriteLine(message);

            string[] temp = message.Split('|');
            nEquipe = int.Parse(temp[1]); // On recup le nom de notre equipe

            string message1 = Connexion.RecevoirMessage();
            string[] temp1 = message1.Split('|');
            nTour = int.Parse(temp1[1]); // On recup le nom de notre equipe
        }

        /// <summary>
        /// Reçoit un message du serveur et renvoie "OK"
        /// </summary>
        public void Executer()
        {


        }

    }
}
