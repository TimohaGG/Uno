using System;


namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
        public Card[] Cards { get; private set; }

        public string FileName { get; } = "Deck.txt";

        public int CardsAmount;
        public Deck(int Size)
        {
            this.CardsAmount = Size;
            Cards = new Card[Size];
            
        }

        public void CreateFirst()
        {
            DeckCreator deckCreator = new DeckCreator(Cards);
            Cards = deckCreator.CreateDeck();
        }

        public void DeleteCards(int number)
        {
            Card[] tmp = new Card[CardsAmount-number];
            Array.Copy(Cards, number, tmp,0 ,tmp.Length);
            //for (int i = number-1,j = 0; i < Size - number; i++, j++)
            //{
            //    tmp[j] = Cards[i];
            //}
            Cards = tmp;
            CardsAmount-=number;
        }

        public void AddCardFrom (Deck deck)
        {
            int NewSize = CardsAmount + 1;
            Deck NewDeck = new Deck(NewSize);
            for (int i = 0; i < CardsAmount; i++)
            {
                NewDeck.Cards[i] = Cards[i];
            }
            NewDeck.Cards[CardsAmount] = deck.Cards[0];
            deck.DeleteCards(1);
           
            Cards = NewDeck.Cards;
            CardsAmount = NewDeck.CardsAmount;
            
        }
       

    }
}
