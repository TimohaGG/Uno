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
            


            Player.Current = players[Player.CurrentIndex];
            Player.Next = players[Player.NextIndex];
            

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
                if (Player.CurrentIndex + 1 < Player.PlayersAmount)
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
            else
            {
                if (Player.CurrentIndex - 1 >=0)
                {
                    Player.CurrentIndex--;
                }
                else
                {
                    Player.CurrentIndex = Player.PlayersAmount-1;
                }
                if (Player.NextIndex - 1 >=0)
                {
                    Player.NextIndex--;
                }
                else
                {
                    Player.NextIndex = Player.PlayersAmount - 1; ;
                }
            }
            
        }
    }
}
