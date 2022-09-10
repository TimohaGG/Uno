using Uno_V2.Core;
using System;
namespace Uno_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Player player = new Player();
            Player player1 = new Player();

            player.PrintCards();
            Console.SetCursorPosition(0, 10);
            player1.PrintCards();
            Console.ReadLine();
        }

    }
}
