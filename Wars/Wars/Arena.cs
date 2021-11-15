using System;
using System.Collections.Generic;
using Wars.cards;
using Wars.cards.Utilities;
using Wars.players;

namespace Wars
{
    public class Arena
    {
        private Player player;
        private CPU cpu;
        private Card cpuCard;
        private Card playerCard;
        private bool gameOn;
        private Random rand = new();
        private int tieCount = 0;
        private int roundNumber = 0;

        public Arena(Player player, CPU cpu)
        {
            this.player = player;
            this.cpu = cpu;
            gameOn = true;
        }

        public void BattleStart()
        {
            while (gameOn)
            {
                cpuCard = cpu.getCard();
                Console.WriteLine("CPU drew " + CardName.getCardName(cpuCard));
                playerCard = player.getCardFromTheTop();
                Console.WriteLine($"{player.name} drew " + CardName.getCardName(playerCard));
                Battle();
                Console.WriteLine(CardAmountCheck());
                WinCheck();
                TieCheck();
                RoundCheck();
                if (gameOn)
                {
                    Console.WriteLine("Next Round!\n----------------------------\n");
                }
            }
        }

        private void Battle()
        {
            if (playerCard.number == cpuCard.number)
            {
                Console.WriteLine("Its a Draw!\n");
                if (WinCheckDraw())
                {
                    ItsADraw(playerCard, cpuCard);
                }
            }
            else if (playerCard.number > cpuCard.number)
            {
                Console.WriteLine($"\n{player.name} won!\n");
                switch (rand.Next(1))
                {
                    case 0:
                        player.AddCard(playerCard);
                        player.AddCard(cpuCard);
                        break;
                    case 1:
                        player.AddCard(cpuCard);
                        player.AddCard(playerCard);
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("\nCPU won!\n");
                switch (rand.Next(1))
                {
                    case 0:
                        cpu.AddCpuCard(playerCard);
                        cpu.AddCpuCard(cpuCard);
                        break;
                    case 1:
                        cpu.AddCpuCard(cpuCard);
                        cpu.AddCpuCard(playerCard);
                        break;
                }
            }
        }

        private void ItsADraw(Card playerCard, Card cpuCard)
        {
            bool drawOn = true;
            List<Card> bank = new List<Card>();

            WinCheckDraw();
            bank.Add(playerCard);
            bank.Add(cpuCard);
            Console.Write("Players put cards to the bank\n");
            while (drawOn)
            {
                if (!WinCheckDraw())
                {
                    break;
                }
                bank.Add(player.getCardFromTheTop());
                bank.Add(cpu.getCard());
                if (!WinCheckDraw())
                {
                    break;
                }
                Console.WriteLine("Player draws card");
                Card playerDrawCard = player.getCardFromTheTop();
                Card cpuDrawCard = cpu.getCard();
                bank.Add(playerDrawCard);
                bank.Add(cpuDrawCard);
                Console.WriteLine($"{player.name} drew " + CardName.getCardName(playerDrawCard) + "\n");
                Console.WriteLine("CPU drew " + CardName.getCardName(cpuDrawCard) + "\n");
                if (playerDrawCard.number == cpuDrawCard.number)
                {
                    Console.WriteLine("It's a draw again!\n");
                }
                else if (playerDrawCard.number > cpuDrawCard.number)
                {
                    Console.WriteLine($"{player.name} won! He gets:\n");
                    foreach (Card card in bank)
                    {
                        player.AddCard(card);
                        Console.WriteLine(CardName.getCardName(card));
                    }

                    drawOn = false;
                }
                else
                {
                    Console.WriteLine("CPU won! His robotic hand gets:\n");
                    foreach (Card card in bank)
                    {
                        cpu.AddCpuCard(card);
                        Console.WriteLine(CardName.getCardName(card));
                    }

                    drawOn = false;
                }
            }
        }

        private void WinCheck()
        {
            if (player.playerHand.Count == 0)
            {
                Console.WriteLine($"{player.name} has no cards! CPU player wins!");
                Console.WriteLine("Game Over");
                gameOn = false;
            }
            else if (cpu.cpuRoboticHand.Count == 0)
            {
                Console.WriteLine($"CPU has no cards! {player.name} wins!");
                Console.WriteLine("Game Over");
                gameOn = false;
            }
        }

        private bool WinCheckDraw()
        {
            if (player.playerHand.Count == 0 || cpu.cpuRoboticHand.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string CardAmountCheck()
        {
            return
                $"{player.name} has {player.playerHand.Count} cards.\nCPU has {cpu.cpuRoboticHand.Count} cards. \n";
        }

        private void TieCheck()
        {
            if ((player.playerHand.Count == 26) 
                || (player.playerHand.Count == 25) 
                || player.playerHand.Count == 27)
            {
                tieCount++;
            }
            else
            {
                tieCount = 0;
            }

            if (tieCount == 100)
            {
                gameOn = false;
                Console.Write("Its a tie!!\nGame Over");
            }
        }

        private void RoundCheck()
        {
            roundNumber++;
            if (roundNumber == 1500)
            {
                gameOn = false;
                Console.WriteLine("1500 turns Passed! It's a draw!!\nGame Over");
            }
        }
    }
}