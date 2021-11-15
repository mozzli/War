using System;

namespace Wars.cards.Utilities
{
    public class CardName
    {
        public static string getCardName(Card card)
        {
            switch (card.number)
            {
                case 11: return $"Jack of {card.type}";
                case 12: return $"Queen of {card.type}"; 
                case 13: return $"King of {card.type}"; 
                case 14: return $"Ace of {card.type}"; 
                default: return $"{card.number} of {card.type}";
            }
        }
    }
}