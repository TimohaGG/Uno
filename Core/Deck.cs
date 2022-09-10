using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
        public Card[] cards { get; private set; }

        public string name { get; } = "Deck.txt";

        private int Size=56;
        public Deck()
        {
            cards = new Card[Size];
        }

        public void Create()
        {
            DeckCreator deckCreator = new DeckCreator(cards);
            cards = deckCreator.CreateDeck();
        }

        
        //public void Print() {

        //    for (int i = 0; i < Size; i++)
        //    {
        //        card[i].Print();

        //    }
        //}

    }
}
