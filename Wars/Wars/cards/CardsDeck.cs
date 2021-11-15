using System;
using System.Collections.Generic;
using Wars.players;

namespace Wars.cards
{
    public class CardsDeck
    {
        Random rnd = new();
        public List<Card> deck;

        public CardsDeck()
        {
            deck = new List<Card>();
        }

        public void ShuffleDeck()
        {
            for (int type = 1; type <= 4; type++)
            {
                for (int number = 2; number <= 14; number++)
                {
                    switch (type)
                    {
                        case 1:
                        {
                            deck.Add(new Card("Clubs", number));
                            break;
                        }
                        case 2:
                            deck.Add(new Card("Diamonds", number));
                            break;
                        case 3:
                            deck.Add(new Card("Hearts", number));
                            break;
                        case 4:
                            deck.Add(new Card("Spades", number));
                            break;
                    }
                }
            }
        }

        public void DealTheCards(Player player, CPU cpu)
        {
            for (int i = 0; i < 26; i++)
            {
                int randNumber = rnd.Next(deck.Count);
                player.AddCard(deck[randNumber]);
                deck.RemoveAt(randNumber);
            }

            for (int i = 0; i < 26; i++)
            {
                int randNumber = rnd.Next(deck.Count);
                cpu.AddCpuCard(deck[randNumber]);
                deck.RemoveAt(randNumber);
            }

            Console.WriteLine("Card has been drawn\n");
        }
    }
}