using ClientTM.Reseau;
using ClientTM.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTM.Tries.Reals
{
    public class FirstTry: ITry
    {
        int nEquipe = 0;
        int nTour = 0; 
        List<Joueur> joueursList = new List<Joueur>();
        List<Route> routesList = new List<Route>();

        public FirstTry()
        {

        }

        public void Setup()
        {
            Connexion.EnvoyerMessage("TM"); // nom équipe

            string message = Connexion.RecevoirMessage(); // Oui votre equipe s'appelle nanana + nEquipe
            Console.WriteLine(message);

            string[] temp = message.Split('|');
            nEquipe = int.Parse(temp[1]); // On recup le nom de notre equipe


        }

        /// <summary>
        /// Reçoit un message du serveur et renvoie "OK"
        /// </summary>
        public void Executer()
        {

            string message1 = Connexion.RecevoirMessage();
            string[] temp1 = message1.Split('|');
            nTour = int.Parse(temp1[1]); // On recup le nom de notre equipe

            while (true)
            {


                Connexion.EnvoyerMessage("JOUEURS");

                string joueurs = Connexion.RecevoirMessage();
                Console.WriteLine(joueurs);
                string[] joueursSplit = joueurs.Split('|');
                foreach(string joueur in joueursSplit)
                {
                    string[] joueurInfo = joueur.Split(";");
                    Joueur joueur1 = new Joueur(int.Parse(joueurInfo[0]), int.Parse(joueurInfo[1]), int.Parse(joueurInfo[2]), joueurInfo[3], int.Parse(joueurInfo[4]), int.Parse(joueurInfo[5])); 
                    joueursList.Add(joueur1);
                }


                Connexion.EnvoyerMessage("ROUTES");

                string routes = Connexion.RecevoirMessage();
                Console.WriteLine(routes);
                string[] routesSplit = routes.Split('|');
                foreach (string route in routesSplit)
                {
                    string[] routeInfo = route.Split(";");
                    Route route1 = new Route(int.Parse(routeInfo[0]), int.Parse(routeInfo[1]), int.Parse(routeInfo[2]), int.Parse(routeInfo[3]), int.Parse(routeInfo[4]), bool.Parse(routeInfo[5]));
                    routesList.Add(route1);
                }
                foreach(Route route in routesList) { Console.WriteLine(route.NiveauBateau); }
                
                

                string message = Connexion.RecevoirMessage();

                if (message == "FIN") { break; } // Fin de partie

            }
        }

    }
}
