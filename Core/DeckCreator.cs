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
        private ConsoleColor[] ColorVariants = new ConsoleColor[4]
        {
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Yellow
        };
        private ConsoleColor[] WildColor = new ConsoleColor[2]
        {
            ConsoleColor.Gray,
            ConsoleColor.Gray
        };
        private string[] CardsSuits = new string[10]
        {
            " 0 "," 1 "," 2 "," 3 "," 4 "," 5 ", " 6 "," 7 "," 8 "," 9 "
        };
        private string[] SpecialCardsSuits = new string[3]
        {
            "+ 1","ChD"," S "
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
            //dColoredCards();
            AddCards(CardsSuits,ColorVariants,0, Card.CardType.Regular);
            AddCards(SpecialCardsSuits, ColorVariants, 40, Card.CardType.Special);
            AddCards(WildCardSuits, WildColor, 52, Card.CardType.Wild);
            
            Reshuffle();
            return deck;
        }

        
        private void AddCards(string[] suits, ConsoleColor []colors, int CardNum, Card.CardType Type)
        {
            for (int colorN = 0; colorN < colors.Length; colorN++)
            {
                for (int suitN = 0; suitN < suits.Length;)
                {
                    deck[CardNum++] = new Card(suits[suitN++], colors[colorN], Type);
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
