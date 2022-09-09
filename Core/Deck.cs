using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_V2.Core
{
    public class Deck
    {
        public Card[] card { get; private set; }
        private int Size=56;
        public Deck()
        {
            card = new Card[Size];
        }

        public void Create()
        {
            DeckCreator deckCreator = new DeckCreator(card);
            card = deckCreator.CreateDeck();
        }

        public void Print() {
            for (int i = 0; i < Size; i++)
            {
                card[i].Print();
            }
        }

    }
}
