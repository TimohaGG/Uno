using System;
using Uno_V2.Core;
namespace Uno_V2
{

    internal class Program
    {
        public static bool Reverse = false;
        static void Main(string[] args)
        {

            Player.PlayersAmount = 4;
            Player []players = new Player[Player.PlayersAmount];
            string FileName;
            for (int i = 0; i < Player.PlayersAmount; i++)
            {
                FileName = "Player" + i+1 + ".txt";
                players[i] = new Player(FileName);
            }
            

            while (true)
            {
                Player.Current = players[Player.CurrentIndex];
                Player.Next = players[Player.NextIndex];
                Player.PrintDecks(players, Player.CurrentIndex);

                int CardIndex = Player.Current.ChooseCard();

                Player.Current.UseCard(CardIndex);

                NextPlayer();
               
                Console.Clear();
            }
            
            Console.ReadLine();
        }

        public static void NextPlayer()
        {
            if (!Reverse)
            {
                Player.CurrentIndex = Player.CurrentIndex + 1 < Player.PlayersAmount ? Player.CurrentIndex+1 : 0;
                Player.NextIndex = Player.NextIndex+1 < Player.PlayersAmount ? Player.NextIndex+1 : 0;
            }
            else
            {
                Player.CurrentIndex = Player.CurrentIndex - 1 >= 0 ? Player.CurrentIndex -= 1 : Player.PlayersAmount - 1;
                Player.NextIndex = Player.NextIndex - 1 >= 0? Player.NextIndex -= 1 : Player.PlayersAmount - 1;
            }
            
        }
    }
}
