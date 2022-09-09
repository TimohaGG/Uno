using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core
{
    public class Card
    {
        public bool isChoosen { get; private set; }
        public string Suit { get; private set; }
        public ConsoleColor Color { get; private set; }

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
       

    }
}
