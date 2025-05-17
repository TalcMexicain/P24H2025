using System;

namespace HuntToSurviveAI.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Knowledge { get; set; }
        public bool IsCurrentPlayer { get; set; }
        public bool IsAlive => Health > 0;
        public string Id => Name;

        public Player(string name)
        {
            Name = name;
            Health = 100;
            Attack = 0;
            Defense = 0;
            Knowledge = 0;
            IsCurrentPlayer = false;
        }

        public void UpdateStats(int health, int attack, int defense, int knowledge)
        {
            Health = health;
            Attack = attack;
            Defense = defense;
            Knowledge = knowledge;
        }
    }
} 