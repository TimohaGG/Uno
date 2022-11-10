using System;

namespace Uno_V2.Core
{
    [Serializable]
    public class Card : ISerializable
    {
        //----------fileds----------
        public string Suit { get; private set; }
        public ConsoleColor Color { get; private set; }

        public string FileName { get; } = "Card.txt";

        public CardType Type { get; private set; }
        public enum CardType
        {
            Regular,
            Special,
            Wild
        }

        //----------constructor----------
        public Card()
        {
            Suit = "   ";
            Color = ConsoleColor.Gray;
        }

        public Card(string Suit, ConsoleColor Color, CardType Type)
        {
            this.Suit = Suit;
            this.Color = Color;
            this.Type = Type;
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

        internal void ChangeColor()
        {
            Console.WriteLine("Выберите цвет");
            Console.WriteLine("1. Синий");
            Console.WriteLine("2. Зеленый");
            Console.WriteLine("3. Красный");
            Console.WriteLine("4. Желтый");
            int choise;

            do
            {
                choise = int.Parse(Console.ReadLine());
            } while (choise < 0 || choise > 4);

            switch (choise)
            {
                case 1:
                    {
                        Color = ConsoleColor.Blue;
                    }
                    break;
                case 2:
                    {
                        Color = ConsoleColor.Green;
                    }
                    break;
                case 3:
                    {
                        Color = ConsoleColor.Red;
                    }
                    break;
                case 4:
                    {
                        Color = ConsoleColor.Yellow;
                    }
                    break;
            }

        }
    }
}
