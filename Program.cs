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

            player1.PrintCards(true);
            Console.SetCursorPosition(0, 6);
            Console.SetCursorPosition(0, 14);
            player2.PrintCards();
            Console.ReadLine();
        }

    }
}
