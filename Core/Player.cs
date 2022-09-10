using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Uno_V2.Core
{
    [Serializable]
    public class Player : ISerializable
    {
        public string FileName { get; private set; } = "Player.txt";

        static public Deck Deck;

        public Card[] Cards;
        private int CardsAmount = 7;

        static Player()
        {
            Deck = new Deck();
        }
        public Player()
        {
            Cards = new Card[CardsAmount];
            GiveCardsFromDeck(CardsAmount);
        }

        public void GiveCardsFromDeck(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Cards[i] = Deck.Cards[i];
            }
            Deck.DeleteCards(amount);
        }

        public void PrintCards()
        {
            int x=0;
            int y = Console.CursorTop;
            for (int i = 0; i < CardsAmount; i++)
            {
                x = Console.CursorLeft;
                
                Cards[i].Print(x,y);
                x += 7;

                Console.SetCursorPosition(x, y);
            }
            Console.SetCursorPosition(0,y+3);
            
        }

    }
}
