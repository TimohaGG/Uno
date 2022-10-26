using System;
using System.Collections.Generic;
using System.Linq;
using static Uno_V2.Core.Card;

namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
        //public Card[] Cards { get; private set; }
        public List<Card> Cards { get; private set; }

        public string FileName { get; } = "Deck.txt";

        public int CardsAmount;
        public Deck(int Size)
        {
            this.CardsAmount = Size;
            Cards = new List<Card>();
            for (int i = 0; i < Size; i++)
            {
                Cards.Add(new Card());
            }      
        }

        public void CreateFirst()
        {
            DeckCreator deckCreator = new DeckCreator(Cards);
            Cards = deckCreator.CreateDeck();
        }

        public void DeleteCards(int cardIndex)
        {
            Cards.RemoveAt(cardIndex);
            CardsAmount--;
        }

        public void AddCardFrom (Deck deck, int CardIndex = 0, bool mustBeRegular = false)
        {
            if (mustBeRegular)
            {
                while (deck.Cards[CardIndex].Type!= CardType.Regular)
                {
                    CardIndex++;
                }
            }
            Cards.Add(deck.Cards[CardIndex]);
            deck.DeleteCards(CardIndex);
            CardsAmount++;
        }
       

    }
}
