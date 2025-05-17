using System;
using System.Linq;
using System.Threading.Tasks;
using HuntToSurviveAI.Models;

namespace HuntToSurviveAI.Strategies
{
    public class StrategyManager
    {
        private readonly GameState _gameState;
        private readonly Random _random;
        private int _consecutivePasses;

        public StrategyManager(GameState gameState)
        {
            _gameState = gameState;
            _random = new Random();
            _consecutivePasses = 0;
        }

        public async Task<string> ProcessMessage(string message)
        {
            Console.WriteLine($"Message reçu: {message}");

            if (message.StartsWith("DEBUT_TOUR"))
            {
                var parts = message.Split('|');
                if (parts.Length >= 3)
                {
                    int turn = int.Parse(parts[1]);
                    int phase = int.Parse(parts[2]);
                    _gameState.UpdateTurn(turn, phase);
                    return await DecideAction();
                }
            }
            else if (message.StartsWith("JOUEURS"))
            {
                // Mise à jour des informations des joueurs
                return await DecideAction();
            }
            else if (message.StartsWith("MONSTRES"))
            {
                // Mise à jour des informations des monstres
                return await DecideAction();
            }

            return null;
        }

        private async Task<string> DecideAction()
        {
            // Phase de lune de sang
            if (_gameState.IsBloodMoonPhase)
            {
                return HandleBloodMoonPhase();
            }

            // Phase de jour
            if (_gameState.CurrentPhase <= 8)
            {
                return HandleDayPhase();
            }

            // Phase de nuit
            return HandleNightPhase();
        }

        private string HandleBloodMoonPhase()
        {
            // Priorité absolue à la survie pendant la lune de sang
            if (_gameState.ShouldDefend())
            {
                var defenseCards = _gameState.Hand.Where(c => c.Type == CardType.Defense).ToList();
                if (defenseCards.Any())
                {
                    var bestDefense = defenseCards.OrderByDescending(c => c.Value).First();
                    return $"UTILISER|DEFENSE|{bestDefense.Id}";
                }
            }

            // Si on a assez de défense, on peut attaquer
            if (_gameState.ShouldAttack())
            {
                var weakestMonster = _gameState.Monsters.OrderBy(m => m.Health).First();
                return $"ATTAQUER|{weakestMonster.Id}";
            }

            return "PASSER";
        }

        private string HandleDayPhase()
        {
            // Priorité aux expéditions 0-2 pour éviter les malus
            if (_gameState.CurrentPhase <= 2)
            {
                return $"PIOCHER|{_gameState.CurrentPhase}";
            }

            // Stratégie d'expédition optimale
            int optimalPhase = _gameState.GetOptimalExpeditionPhase();
            return $"PIOCHER|{optimalPhase}";
        }

        private string HandleNightPhase()
        {
            // Gestion des cartes avec multiplicateur
            if (_gameState.ShouldUseCardMultiplier())
            {
                var attackCards = _gameState.Hand.Where(c => c.Type == CardType.Attack).ToList();
                if (attackCards.Any())
                {
                    var bestAttack = attackCards.OrderByDescending(c => c.Value).First();
                    return $"UTILISER|ATTACK|{bestAttack.Id}";
                }
            }

            // Attaque de monstre si possible
            if (_gameState.ShouldAttack())
            {
                var weakestMonster = _gameState.Monsters.OrderBy(m => m.Health).First();
                return $"ATTAQUER|{weakestMonster.Id}";
            }

            // Utilisation de cartes malus sur le joueur le plus menaçant
            var mostThreateningPlayer = _gameState.GetMostThreateningPlayer();
            if (mostThreateningPlayer != null)
            {
                var malusCards = _gameState.Hand.Where(c => c.IsMalus).ToList();
                if (malusCards.Any())
                {
                    var bestMalus = malusCards.OrderByDescending(c => c.Value).First();
                    return $"UTILISER|MALUS|{bestMalus.Id}|{mostThreateningPlayer.Name}";
                }
            }

            // Expédition par défaut
            return $"PIOCHER|{_gameState.CurrentPhase}";
        }
    }
} 