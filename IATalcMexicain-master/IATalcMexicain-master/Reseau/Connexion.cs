using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClientTM.Reseau
{
    public class Connexion
    {
        //Singleton interne
        private static Connexion instance;
        //Get du singleton
        private static Connexion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connexion();
                }
                return instance;
            }
        }


        private TcpClient client;
        /// <summary>Le flux entrant depuis le serveur</summary>
        private StreamReader fluxEntrant;
        /// <summary>Le flux sortant vers le serveur</summary>
        private StreamWriter fluxSortant;

        /// <summary>
        /// Constructeur naturel
        /// </summary>
        private Connexion()
        {
            client = new TcpClient();
           
            
        }

        /// <summary>
        /// Envoi d'un message au serveur
        /// </summary>
        /// <param name="message">Le message à envoyer</param>
        public static void EnvoyerMessage(string message)
        {
            Instance.fluxSortant.WriteLine(message);
            Instance.fluxSortant.Flush();
        }

        /// <summary>
        /// Réception d'un message du serveur
        /// </summary>
        /// <returns>Message reçu</returns>
        public static string RecevoirMessage()
        {
            return Instance.fluxEntrant.ReadLine();
        }

        //Ouvre la connexion
        public static void OuvrirConnexion()
        {
            if (instance != null) FermerConnexion();
            instance = new Connexion();
            instance.client.Connect("127.0.0.1", 1234);
            instance.fluxEntrant = new StreamReader(instance.client.GetStream());
            instance.fluxSortant = new StreamWriter(instance.client.GetStream());
        }

        //Ferme la connexion
        public static void FermerConnexion()
        {
            Instance.client.Close();
            instance = null;
        }

    }
}
