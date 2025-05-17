using System;
using System.Collections.Generic;
using System.Linq;

namespace HuntToSurviveAI.Models
{
    public class GameState
    {
        public int CurrentTurn { get; private set; }
        public int CurrentPhase { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public List<Card> Hand { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public GameState()
        {
            Players = new List<Player>();
            Monsters = new List<Monster>();
            Hand = new List<Card>();
        }

        public void UpdateTurn(int turn, int phase)
        {
            CurrentTurn = turn;
            CurrentPhase = phase;
        }

        public void UpdatePlayers(List<Player> players)
        {
            Players = players;
            CurrentPlayer = players.FirstOrDefault(p => p.IsCurrentPlayer);
        }

        public void UpdateMonsters(List<Monster> monsters)
        {
            Monsters = monsters;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void RemoveCardFromHand(int cardId)
        {
            Hand.RemoveAll(c => c.Id == cardId);
        }

        public int CalculateCardMultiplier()
        {
            int cardCount = Hand.Count;
            if (cardCount <= 4) return 1;
            if (cardCount <= 8) return 2;
            return 3;
        }

        public bool IsBloodMoonPhase => CurrentPhase == 17;

        public int CalculateRedLadyThreat()
        {
            return CurrentTurn * 2; // La Dame en Rouge devient plus forte à chaque tour
        }

        public bool IsPlayerThreatened(Player player)
        {
            return player.Health < CalculateRedLadyThreat();
        }

        public Player GetMostThreateningPlayer()
        {
            return Players
                .Where(p => !p.IsCurrentPlayer)
                .OrderByDescending(p => p.Knowledge)
                .FirstOrDefault();
        }

        public bool ShouldDefend()
        {
            return CurrentPlayer.Health < 50 || IsBloodMoonPhase;
        }

        public bool ShouldAttack()
        {
            var weakestMonster = Monsters.OrderBy(m => m.Health).FirstOrDefault();
            return weakestMonster != null && weakestMonster.Health <= CurrentPlayer.Attack;
        }

        public int GetOptimalExpeditionPhase()
        {
            if (CurrentPhase <= 2) return CurrentPhase; // Safe phases
            if (ShouldDefend()) return 3; // Priorité défense
            if (CurrentPlayer.Knowledge < 500) return 4; // Priorité savoir en début de partie
            return CurrentPhase; // Phase actuelle par défaut
        }

        public bool ShouldUseCardMultiplier()
        {
            int multiplier = CalculateCardMultiplier();
            return multiplier > 1 && Hand.Count >= 5;
        }
    }
} 