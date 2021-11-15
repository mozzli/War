using System.Collections.Generic;
using Wars.cards;

namespace Wars.players
{
    public class CPU
    {
        public List<Card> cpuRoboticHand;

        public CPU()
        {
            cpuRoboticHand = new List<Card>();
        }

        public void AddCpuCard(Card card)
        {
            cpuRoboticHand.Add(card);
        }
        public Card getCard()
        {
            Card cardToAdd = cpuRoboticHand[0];
            cpuRoboticHand.RemoveAt(0);
            return cardToAdd;
        }
        
    }
    
}