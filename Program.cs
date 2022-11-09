using System;
using Uno_V2.Core;
using static Uno_V2.Core.Player;
namespace Uno_V2
{

    internal class Program
    {
        public static bool Reverse = false;
        public static int PlayersAmount;
        public static Player[] players { get; private set; }

        static void Main(string[] args)
        {

            PlayersAmount = 2;
            players = new Player[PlayersAmount];

            CreatePlayers();

            //Player.SaveAllToFile(players);

            Player.LoadFromFile();

            //Player.PrintDecks(players, Player.CurrentIndex);

            do
            {
                Current = players[CurrentIndex];
                Next = players[NextIndex];
                PrintDecks(players);

                if (lowCardsAmount())
                {
                    RefillDeck();
                }

                if (Current.CanUseMove())
                {

                    Current.UseCard(Current.ChooseCard());
                   
                    //if (!Current.canContinue())
                    //{
                    //    NextPlayer();
                    //    continue;
                    //}
                }
                else
                {
                    Current.isFirstMove = true;
                    Console.WriteLine("Вы исчерпали свои попытки!");
                    NextPlayer();
                    Console.ReadLine();
                   
                }
                

            } while (true);
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
           // Current.ResetFirstMoove();
        }
    }
}
