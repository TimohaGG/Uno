using Uno_V2.Core;
using System;
namespace Uno_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Player player1 = new Player();
            Player player2 = new Player();
            while (true)
            {
                player1.PrintCards(true);
               
                Player.PrintEndDeck();
                Console.SetCursorPosition(0, 14);
                player2.PrintCards();

                int index = player2.ChooseCard();

                player2.TryUseCard(index);
                (player1,player2) = (player2,player1);
               
                Console.Clear();
            }
            
            Console.ReadLine();
        }

    }
}
