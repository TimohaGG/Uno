using System;

namespace Uno_V2
{
    public class ChoosingMarker
    {
        public int index;
        public int x { get; private set; }
        public int y { get; private set; }
        private char sym = '^';
        public ChoosingMarker()
        {
            index = 0;
            x = 2;
            y = Console.CursorTop;
        }

        public void SetConsolePosition()
        {
            Console.SetCursorPosition(x + 1, y);
        }

        public void PrintMarker()
        {
            Console.Write(sym);
        }

        public void MoveXLeft()
        {
            x -= 7;
        }
        public void MoveXRight()
        {
            x += 7;
        }
    }
}
