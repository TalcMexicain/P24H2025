using ClientTM.Tries;
using ClientTM.Tries.Reals;
using ClientTM.Reseau;
using System;
using System.Net.Sockets;

namespace ClientTM
{
    class Program
    {
        static void Main(string[] args)
        {
            Connexion.OuvrirConnexion();

            string setup = Connexion.RecevoirMessage();
            Console.WriteLine(setup);

            FirstTry firstTry = new FirstTry();
            firstTry.Setup();
            firstTry.Executer();

            Connexion.FermerConnexion(); // On ferme la connexion

        }
    }
}
