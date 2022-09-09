using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core
{
    public class DeckCreator
    {
        //----------fileds----------
        private Card[] deck;
        private int ColorNumber = 4;
        private ConsoleColor[] ColorVariants = new ConsoleColor[5]
        {
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Gray
        };
        private string[] CardsSuits = new string[13]
        {
            " 0 "," 1 "," 2 "," 3 "," 4 "," 5 ", " 6 "," 7 "," 8 "," 9 ","+ 1","ChD"," S "
        };
        private string[] WildCardSuits = new string[2]
        {
             "ChC","+ 2"
        };

        //----------constructor----------
        public DeckCreator(Card[] deck)
        {
            this.deck = deck;
        }

        //----------methods----------
        public Card[] CreateDeck()
        {
            AddColoredCards();
            AddWildCards();
            Reshuffle();
            return deck;
        }

        private void AddColoredCards()
        {
            for (int i = 0, cardN = 0, colorN = 0; i < ColorNumber; i++, colorN++)
            {
                for (int j = 0, suitN = 0; j < CardsSuits.Length; j++)
                {
                    deck[cardN++] = new Card(CardsSuits[suitN++], ColorVariants[colorN]);
                }
            }
        }

        private void AddWildCards()
        {
            for (int i = 0, cardN=52; i < 2; i++)
            {
                for (int j = 0, suitN = 0; j < WildCardSuits.Length; j++)
                {
                    deck[cardN++] = new Card(WildCardSuits[suitN++], ColorVariants[4]);
                }
            }
            
        }

        private void Reshuffle()
        {
            Random rand = new Random();
            Card tmp;
            int randValue;
            
            for (int i = 0; i < 55; i++)
            {
                randValue = rand.Next(0, 55);
                tmp = deck[i];
                deck[i] = deck[randValue];
                deck[randValue] = tmp;

            }
            
        }
    }
}
