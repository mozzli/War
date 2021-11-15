using System;
using System.Collections.Generic;
using Wars.cards;

namespace Wars.players
{
    public class Player
    {
        public string name;
        public List<Card> playerHand;

        public Player(string PlayerName)
        {
            this.name = PlayerName;
            playerHand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            playerHand.Add(card);
        }
        
        public Card getCardFromTheTop()
        {
            Console.WriteLine("Draw card... [Press Enter]");
            Console.ReadLine();
            Card cardToAdd = playerHand[0];
            playerHand.RemoveAt(0);
            return cardToAdd;
        }

    }
}