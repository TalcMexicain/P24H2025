using System;

namespace HuntToSurviveAI.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
        public int Value { get; set; }
        public bool IsMalus { get; set; }
        public int ExpeditionNumber { get; set; }

        public Card(int id, string name, CardType type, int value, bool isMalus, int expeditionNumber)
        {
            Id = id;
            Name = name;
            Type = type;
            Value = value;
            IsMalus = isMalus;
            ExpeditionNumber = expeditionNumber;
        }
    }

    public enum CardType
    {
        Attack,
        Defense,
        Knowledge
    }
} 