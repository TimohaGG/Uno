using System;

namespace Uno_V2.Core.CardsCharacteristics
{
    internal interface ICharacterisable
    {
        ConsoleColor[] ColorVariants { get; }
        string[] CardsSuits { get; }
        int FirstCardNum { get; set; }
        Card.CardType Type { get; }

    }
}
