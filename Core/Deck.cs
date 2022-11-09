using System;
using System.Collections.Generic;
using System.Linq;
using static Uno_V2.Core.Card;

namespace Uno_V2.Core
{
    [Serializable]
    public class Deck : ISerializable
    {
      
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

        public void RefillCardsDeck(Deck deck)
        {
            //deck.Cards.AddRange(Cards);
            Card lastCard = Cards.Last();
            Cards.Remove(lastCard);
            deck.Cards.AddRange(Cards);
            DeckCreator d = new DeckCreator(deck.Cards);
            d.Reshuffle();
            Cards.Clear();
            Cards.Add(lastCard);
            deck.CardsAmount = deck.Cards.Count;
            CardsAmount = Cards.Count;
        }

        public bool lowCardsAmount()
        {
            return CardsAmount <= 10;
        }

    }
}
