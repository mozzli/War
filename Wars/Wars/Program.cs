using System;
using Wars;
using Wars.cards;
using Wars.players;

string playerName;
Console.Write("Player name:");
playerName = Console.ReadLine();
CardsDeck cardsDeck = new();
Player player = new(playerName);
CPU cpu = new();
cardsDeck.ShuffleDeck();
cardsDeck.DealTheCards(player, cpu);
Arena arena = new Arena(player, cpu);
arena.BattleStart();