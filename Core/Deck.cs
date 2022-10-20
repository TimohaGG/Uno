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

        public void DeleteCards(int cardIndex)
        {
            Card[] tmp = new Card[CardsAmount-1];
            for (int i = 0; i < CardsAmount; i++)
            {
                if (i < cardIndex)
                    tmp[i] = Cards[i];
                else if (i > cardIndex)
                    tmp[i - 1] = Cards[i];
            }
            Cards = tmp;
            CardsAmount--;
        }

        public void AddCardFrom (Deck deck, int CardIndex = 0)
        {
            int NewSize = CardsAmount + 1;
            Deck NewDeck = new Deck(NewSize);
            for (int i = 0; i < CardsAmount; i++)
            {
                NewDeck.Cards[i] = Cards[i];
            }
            NewDeck.Cards[CardsAmount] = deck.Cards[CardIndex];
            deck.DeleteCards(CardIndex);//
           
            Cards = NewDeck.Cards;
            CardsAmount = NewDeck.CardsAmount;
            
        }
       

    }
}
