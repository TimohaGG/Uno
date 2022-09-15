using System;


namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
        public Card[] Cards { get; private set; }

        public string FileName { get; } = "Deck.txt";

        private int Size;
        public Deck(int Size)
        {
            this.Size = Size;
            Cards = new Card[Size];
            
        }

        public void CreateFirst()
        {
            DeckCreator deckCreator = new DeckCreator(Cards);
            Cards = deckCreator.CreateDeck();
        }

        public void DeleteCards(int number)
        {
            Card[] tmp = new Card[Size-number];
            Array.Copy(Cards, 1, tmp,0 ,tmp.Length);
            
            Cards = tmp;
            Size-=number;
        }

        public void AddCardFrom (Deck deck)
        {
            Cards[Size - 1] = deck.Cards[0];
            deck.DeleteCards(1);
        }
       

    }
}
