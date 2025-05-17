using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HuntToSurviveAI.Models;
using HuntToSurviveAI.Services;
using HuntToSurviveAI.Strategies;

namespace HuntToSurviveAI
{
    class Program
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 1234;
        private const string TEAM_NAME = "Talc_Islandais";
        private const int MAX_RESPONSE_TIME = 5000; // 5 secondes

        static async Task Main(string[] args)
        {
            Console.WriteLine("Démarrage de l'IA Hunt To Survive...");
            
            try
            {
                var gameClient = new GameClient(SERVER_IP, SERVER_PORT, TEAM_NAME);
                var gameState = new GameState();
                var strategyManager = new StrategyManager(gameState);
                
                await gameClient.ConnectAsync();
                Console.WriteLine("Connecté au serveur de jeu");

                while (true)
                {
                    var message = await gameClient.ReceiveMessageAsync();
                    if (string.IsNullOrEmpty(message)) continue;

                    var response = await strategyManager.ProcessMessage(message);
                    if (!string.IsNullOrEmpty(response))
                    {
                        await gameClient.SendMessageAsync(response);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }
    }
} 