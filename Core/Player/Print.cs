
using System;

namespace Uno_V2.Core
{
    public partial class Player
    {
        private static void PrintDecksInactive()
        {
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                if (i != CurrentIndex)
                {
                    Console.Write(i);
                    Program.players[i].PrintCards(true);
                    Console.WriteLine();
                }

            }

        }
        private static void PrintEndDeck()
        {
            Console.SetCursorPosition(21, Console.CursorTop + 4);
            endDeck.Cards[endDeck.Cards.Count - 1].Print(21, Console.CursorTop);
            Console.SetCursorPosition(0, Console.CursorTop + 5);
        }

        private static void PrintCurrentDeck()
        {
            Console.Write(CurrentIndex);
            Current.PrintCards();
        }

        private void PrintCards(bool isEmpty = false)
        {
            int x = 0;
            int y = Console.CursorTop;
            for (int i = 0; i < PlayerDeck.CardsAmount; i++)
            {
                x = Console.CursorLeft;

                if (isEmpty)
                {
                    EmptyCard.Print(x, y);
                }
                else
                {
                    PlayerDeck.Cards[i].Print(x, y);
                }

                x += 7;
                Console.SetCursorPosition(x, y);
            }
            Console.SetCursorPosition(0, y + 3);

        }
    }
}
