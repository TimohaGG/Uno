using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core.CardsCharacteristics
{
    internal class WildCardsInfo : ICharacterisable
    {
        public ConsoleColor[] ColorVariants { get; }
        public string[] CardsSuits { get; }
        public int FirstCardNum { get; set; } = 52;
        public Card.CardType Type { get; } = Card.CardType.Wild;
        public const int ColorAmount = 2;
        public const int SuitAmount = 2;

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
