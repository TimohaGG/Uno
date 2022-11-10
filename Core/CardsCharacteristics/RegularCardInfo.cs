using System;

namespace Uno_V2.Core.CardsCharacteristics
{
    public class RegularCardInfo : ICharacterisable
    {
        public ConsoleColor[] ColorVariants { get; }
        public string[] CardsSuits { get; }
        public int FirstCardNum { get; set; } = 0;
        public Card.CardType Type { get; } = Card.CardType.Regular;
        public const int ColorAmount = 4;
        public const int SuitAmount = 10;
        public RegularCardInfo()
        {
            ColorVariants = new ConsoleColor[ColorAmount]
            {
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Yellow
            };
            CardsSuits = new string[SuitAmount]
            {
                " 0 "," 1 "," 2 "," 3 "," 4 "," 5 ", " 6 "," 7 "," 8 "," 9 "
            };
        }
    }
}
