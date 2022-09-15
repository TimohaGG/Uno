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
            Array.Copy(Cards, number, tmp,0 ,tmp.Length);
            //for (int i = number-1,j = 0; i < Size - number; i++, j++)
            //{
            //    tmp[j] = Cards[i];
            //}
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
