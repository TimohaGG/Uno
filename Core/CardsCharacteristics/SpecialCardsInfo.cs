using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core.CardsCharacteristics
{
    public class SpecialCardsInfo : ICharacterisable
    {
        public ConsoleColor[] ColorVariants { get; }
        public string[] CardsSuits { get; }
        public int FirstCardNum { get; set; } = 40;
        public Card.CardType Type { get; } = Card.CardType.Special;

        public const int ColorAmount=4;
        public const int SuitAmount = 3;
        
        public SpecialCardsInfo()
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
                 "+ 1","ChD"," S "
            };
        }
    }
}
