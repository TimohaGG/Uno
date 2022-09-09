using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core
{
    public class Deck
    {
        private Card[] card;
        private int Size=56;
        public Deck()
        {
            card = new Card[Size];
        }

        public void CreateDeck()
        {
            DeckCreator deckCreator = new DeckCreator(card);
            card = deckCreator.CreateDeck();
        }
    }
}
