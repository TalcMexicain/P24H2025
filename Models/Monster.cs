using System;

namespace HuntToSurviveAI.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int KnowledgeReward { get; set; }

        public Monster(int id, string name, int health, int attack, int defense, int knowledgeReward)
        {
            Id = id;
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            KnowledgeReward = knowledgeReward;
        }

        public bool IsAlive => Health > 0;

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }
    }
} 