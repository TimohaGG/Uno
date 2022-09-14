﻿using System;

namespace Uno_V2.Core
{
    [Serializable]
    public class Card : ISerializable
    {
        //----------fileds----------
        public string Suit { get; private set; }
        public ConsoleColor Color { get; private set; }

        public string FileName { get; } = "Card.txt";

        //----------constructor----------
        public Card()
        {
            
            Suit = "   ";
            Color = ConsoleColor.Gray;
        }

        public Card(string Suit, ConsoleColor Color)
        {
            this.Suit = Suit;
            this.Color = Color;
        }

        //----------methods----------
        public void Print(int x, int y)
        {
            
           
            Console.ForegroundColor = Color;

            Console.WriteLine("*****");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine($"*{Suit}*");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("*****");
            Console.SetCursorPosition(x, ++y);
            Console.ResetColor();
           
        }

        
    }
}
