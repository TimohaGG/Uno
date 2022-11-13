
using System;

namespace Uno_V2.Core
{
    public partial class Player
    {
        private int ChooseCard()
        {

            ChoosingMarker marker = new ChoosingMarker();
            ConsoleKey key;
            do
            {
                marker.Print();
                do
                {
                    key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Escape && isFirstMove == false)
                    {
                        return -1;
                    }
                    if (!TryMooving(marker, ref key))
                    {
                        marker.SetConsolePosition();
                    }

                } while (key != ConsoleKey.Enter);
            } while (!canBeat(PlayerDeck.Cards[marker.index]));
            return marker.index;
        }

        private bool TryMooving(ChoosingMarker pt, ref ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.LeftArrow => MoveLeft(ref pt),
                ConsoleKey.RightArrow => MoveRight(ref pt),
                ConsoleKey.Enter => true,
                ConsoleKey.Escape => false,
                _ => false
            };
        }

        private bool MoveLeft(ref ChoosingMarker pt)
        {
            if (pt.index - 1 >= 0)
            {
                DeleteOldSelection();
                pt.MoveXLeft();
                pt.index--;
                pt.Print();
                return true;
            }
            return false;
        }

        private bool MoveRight(ref ChoosingMarker pt)
        {
            if (pt.index + 1 < PlayerDeck.CardsAmount)
            {
                DeleteOldSelection();
                pt.MoveXRight();
                pt.index++;
                pt.Print();
                return true;
            }
            return false;
        }
        private void DeleteOldSelection()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.SetCursorPosition(x - 2, y);
            Console.Write(" ");
        }
    }
}
