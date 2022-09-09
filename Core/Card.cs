using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core
{
    public class Card
    {
        //----------fileds----------
        public bool isChoosen { get; private set; }
        public string Suit { get; private set; }
        public ConsoleColor Color { get; private set; }

        //----------constructor----------
        public Card()
        {
            isChoosen = false;
            Suit = "   ";
            Color = ConsoleColor.Gray;
        }

        public Card(string Suit, ConsoleColor Color)
        {
            this.Suit = Suit;
            this.Color = Color;
        }

        //----------methods----------
        public void Print()
        {
           
            Console.ForegroundColor = Color;

            Console.WriteLine("*****");
            Console.WriteLine($"*{Suit}*");
            Console.WriteLine("*****");

            Console.ResetColor();
        }
    }
}
