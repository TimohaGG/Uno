using System;
using System.Collections.Generic;
using Uno_V2.Core.CardsCharacteristics;

namespace Uno_V2.Core
{
    public class DeckCreator
    {
        //----------fileds----------
        private List<Card> deck;

        CardsCharasteristics charasteristics;

        public DeckCreator(List<Card> deck)
        {
            this.deck = deck;
            charasteristics = new CardsCharasteristics();
        }

        //----------methods----------
        public List<Card> CreateDeck()
        {

            AddCards(charasteristics.RegularInf);
            AddCards(charasteristics.SpecInf);
            AddCards(charasteristics.WildInf);

            Reshuffle();
            return deck;
        }


        private void AddCards(ICharacterisable chrctr)
        {
            int ColorsAmount = chrctr.ColorVariants.Length;
            int SuitsAmount = chrctr.CardsSuits.Length;
            string[] CardsSuits = chrctr.CardsSuits;
            var Colors = chrctr.ColorVariants;
            var Type = chrctr.Type;

            for (int colorN = 0; colorN < ColorsAmount; colorN++)
            {
                for (int suitN = 0; suitN < SuitsAmount; suitN++)
                {
                    deck[chrctr.FirstCardNum++] =
                        new Card(CardsSuits[suitN], Colors[colorN], Type);
                }
            }
        }

        public void Reshuffle()
        {
            Random rand = new Random();
            Card tmp;
            int randValue;

            for (int i = 0; i < deck.Count; i++)
            {
                randValue = rand.Next(0, deck.Count);
                tmp = deck[i];
                deck[i] = deck[randValue];
                deck[randValue] = tmp;

            }

        }
    }
}
