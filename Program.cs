using System;
using Uno_V2.Core;
namespace Uno_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player.PlayersAmount = 4;
            Player []players = new Player[Player.PlayersAmount];
            players[0] = new Player("Player1.txt");
            players[1] = new Player("Player2.txt");
            players[2] = new Player("Player2.txt");
            players[3] = new Player("Player3.txt");


            Player.Current = players[Player.CurrentIndex];
            Player.Next = players[Player.NextIndex];
            bool Reverse = false;

            while (true)
            {
                Player.Current = players[Player.CurrentIndex];

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
            if (Player.CurrentIndex + 1 < Player.PlayersAmount )
            {
                Player.CurrentIndex++;
            }
            else
            {
                Player.CurrentIndex = 0;
            }
            if (Player.NextIndex + 1 < Player.PlayersAmount)
            {
                Player.NextIndex++;
            }
            else
            {
                Player.NextIndex = 0;
            }
        }
    }
}
