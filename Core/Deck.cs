using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
        public Card[] Cards { get; private set; }

        public string FileName { get; } = "Deck.txt";

        private int Size=56;
        public Deck()
        {
            Cards = new Card[Size];
            Create();
        }

        private void Create()
        {
            DeckCreator deckCreator = new DeckCreator(Cards);
            Cards = deckCreator.CreateDeck();
        }

        public void DeleteCards(int number)
        {
            Card[] tmp = new Card[Size-number];
            for (int i = number-1, j=0; i < Size-1; i++, j++)
            {
                tmp[j] = Cards[i];
            }
            Cards = tmp;
            Size-=number;
        }
        
       

    }
}
