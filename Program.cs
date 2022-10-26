using System;
using Uno_V2.Core;
using static Uno_V2.Core.Player;
namespace Uno_V2
{

    internal class Program
    {
        public static bool Reverse = false;
        static void Main(string[] args)
        {

            PlayersAmount = 2;
            Player []players = new Player[PlayersAmount];

            CreatePlayers(players);

            //Player.SaveAllToFile(players);

            //Player.LoadFromFile(ref players);
            
            //Player.PrintDecks(players, Player.CurrentIndex);
            while (true)
            {
                do
                {
                    Current = players[CurrentIndex];
                    Next = players[NextIndex];
                    PrintDecks(players);
                    int amountOfTakenCards = 0;

                    while (!Current.hasApropriateCards())
                    {
                        if (amountOfTakenCards == 2)
                        {
                            Console.WriteLine("Все!");
                            Console.ReadLine();
                            break;

                        }
                        Current.GivePlayerCards();
                        PrintDecks(players);
                        Console.ReadLine();
                        amountOfTakenCards++;

                    }

                    if(amountOfTakenCards == 2)
                    {
                        break;
                    }
                    int CardIndex = Current.ChooseCard();
                    Current.UseCard(CardIndex);

                    Console.WriteLine("N - следуйщий игрок");
                    bool canContinue = Current.canStack();
                    if (canContinue)
                    {
                        Console.WriteLine("R - повторить ход");
                    }

                    ConsoleKey key = Console.ReadKey().Key;
                    if(key == ConsoleKey.N)
                    {
                        break;
                    }
                    else if(canContinue && key == ConsoleKey.R)
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                NextPlayer();
               
                Console.Clear();
            }
            
            Console.ReadLine();
        }

        public static void NextPlayer()
        {
            if (!Reverse)
            {
                CurrentIndex = CurrentIndex + 1 < PlayersAmount ? CurrentIndex+1 : 0;
                NextIndex = NextIndex+1 < PlayersAmount ? NextIndex+1 : 0;

            }
            else
            {
                CurrentIndex = CurrentIndex - 1 >= 0 ? CurrentIndex -= 1 : PlayersAmount - 1;
                NextIndex = NextIndex - 1 >= 0? NextIndex -= 1 : PlayersAmount - 1;
            }
            Current.ResetFirstMoove();
        }
    }
}
