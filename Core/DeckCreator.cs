using System;

using Uno_V2.Core.CardsCharacteristics;

namespace Uno_V2.Core
{
    public class DeckCreator
    {
        //----------fileds----------
        private Card[] deck;
        private int ColorNumber = 4;

        CardsCharasteristics charasteristics;
        
        public DeckCreator(Card[] deck)
        {
            this.deck = deck;
            charasteristics = new CardsCharasteristics();
        }

        //----------methods----------
        public Card[] CreateDeck()
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

        private void Reshuffle()
        {
            Random rand = new Random();
            Card tmp;
            int randValue;
            
            for (int i = 0; i < deck.Length; i++)
            {
                randValue = rand.Next(0, deck.Length);
                tmp = deck[i];
                deck[i] = deck[randValue];
                deck[randValue] = tmp;

            }
            
        }
    }
}
