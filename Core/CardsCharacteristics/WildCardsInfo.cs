using System;

namespace Uno_V2.Core.CardsCharacteristics
{
    internal class WildCardsInfo : ICharacterisable
    {
        public ConsoleColor[] ColorVariants { get; }
        public string[] CardsSuits { get; }
        public int FirstCardNum { get; set; } = 52;
        public Card.CardType Type { get; } = Card.CardType.Wild;
        private const int ColorAmount = 2;
        private const int SuitAmount = 2;

        public WildCardsInfo()
        {
            ColorVariants = new ConsoleColor[ColorAmount]
            {
               ConsoleColor.Gray,
               ConsoleColor.Gray
            };
            CardsSuits = new string[SuitAmount]
            {
                "ChC","+ 2"
            };
        }
    }
}
