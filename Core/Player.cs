using System;


namespace Uno_V2.Core
{
    [Serializable]
    public class Player : ISerializable
    {
        public string FileName { get; private set; } 

        public Card[] Cards;
        private Card EmptyCard;
        private int CardsAmount = 0;
        private static Deck deck;
        private static Deck endDeck;
        public static int CurrentIndex = 0;
        public static int NextIndex = 1;
        public static Player Current;
        public static Player Next;
        public static int PlayersAmount;
        static Player()
        {
            deck = new Deck(56);
            deck.CreateFirst();
            endDeck = new Deck(0);
            endDeck.AddCardFrom(deck);
        }
        public Player(string Filename)
        {
            this.FileName = Filename;
            Cards = new Card[CardsAmount];
            GiveCardsFromDeckToPlayer(7);
            EmptyCard = new Card();
            
        }

        internal void UseCard(int cardIndex)
        {
            
            if(Cards[cardIndex].Type == Card.CardType.Regular)
            {

            }
            else
            {
                ApplyCardProperty(Cards[cardIndex]);
            }
            
        }

        private void ApplyCardProperty(Card CurrentCard)
        {
            if (CurrentCard.Suit == "+ 1")
            {
                Next.GiveCardsFromDeckToPlayer(1);
                Console.Write("Следуйщий игрок берет 1 карту!!");
                Console.ReadLine();
                Program.NextPlayer();
            }
            else if (CurrentCard.Suit == "ChD")
            {
                //SwitchPlayers(this,enemy);

            }
            else if (CurrentCard.Suit == " S ")
            {
                Program.NextPlayer();
            }
            else if (CurrentCard.Suit == "ChC")
            {

            }
            else if (CurrentCard.Suit == "+ 2")
            {
                Next.GiveCardsFromDeckToPlayer(2);
                Console.Write("Следуйщий игрок берет 2 карты!!");
                Console.ReadLine();
                Program.NextPlayer();
            }
        }
        private void GiveCardsFromDeckToPlayer(int amount)
        {
            Card[] cardsTmp = new Card[CardsAmount+amount];
            Array.Copy(Cards, cardsTmp, Cards.Length);
            
            for (int i = CardsAmount, j=0; i < CardsAmount + amount; i++,j++)
            {
                cardsTmp[i] = deck.Cards[j];
            }
            Cards = cardsTmp;
            CardsAmount += amount;
            deck.DeleteCards(amount);
        }
        public static void PrintDecks(Player[] players, int index)
        {
            
            for (int i = 0; i < players.Length; i++)
            {
                if (i != index)
                {
                    Console.Write(i);
                    players[i].PrintCards();
                    Console.WriteLine();
                }

            }
            
            Player.PrintEndDeck();
            Console.Write(index);
            players[index].PrintCards();
        }

        private void PrintCards(bool isEmpty = false)
        {
            int x=0;
            int y = Console.CursorTop;
            for (int i = 0; i < CardsAmount; i++)
            {
                x = Console.CursorLeft;

                if (isEmpty)
                {
                    EmptyCard.Print(x,y);
                }
                else
                {
                    Cards[i].Print(x, y);
                }
                
                x += 7;
                Console.SetCursorPosition(x, y);
            }
            Console.SetCursorPosition(0,y+3);
            
        }

        private static void PrintEndDeck()
        {
            Console.SetCursorPosition(21, Console.CursorTop + 4);
            endDeck.Cards[endDeck.Cards.Length-1].Print(21, Console.CursorTop);
            Console.SetCursorPosition(0, Console.CursorTop + 5);
        }
        
        

        public int ChooseCard()
        {
            
            ChoosingMarker marker = new ChoosingMarker();
            ConsoleKey key;
            do
            {
                PrintChooser(marker);
                do
                {
                    key = Console.ReadKey().Key;
                    if (!TryMooving(marker, ref key))
                    {
                        marker.SetConsolePosition();
                    }

                } while (key != ConsoleKey.Enter);
            } while (!CanBeat(Cards[marker.index]));
            return marker.index;
        }

        private void PrintChooser(ChoosingMarker pt)
        {
            Console.SetCursorPosition(pt.x, pt.y);
            pt.PrintMarker();
        }

        private bool TryMooving(ChoosingMarker pt ,ref ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        return MoveLeft(ref pt);
                    }
                    
                case ConsoleKey.RightArrow:
                    {
                        return MoveRight(ref pt);
                    }

                case ConsoleKey.Enter:
                    {
                        return true;
                    }
                default:
                    {
                        pt.SetConsolePosition();
                        return false;
                    }
                    
            }
        }

        private bool MoveLeft(ref ChoosingMarker pt)
        {
            if (pt.index - 1 >= 0)
            {
                DeleteOldSelection();
                pt.MoveXLeft();
                pt.index--;
                
                PrintChooser(pt);
                return true;
            }
            return false;
        }

        private bool MoveRight(ref ChoosingMarker pt)
        {
            if (pt.index + 1 < CardsAmount)
            {
                DeleteOldSelection();
                pt.MoveXRight();
                pt.index++;
                
                PrintChooser(pt);
                return true;
            }
            return false;
        }

        private void DeleteOldSelection()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.SetCursorPosition(x - 2, y);
            Console.Write(" ");
        }
        
        

        private bool CanBeat(Card toUse)
        {
            int LastIndex = endDeck.Cards.Length - 1;
            
            if (toUse.Suit == endDeck.Cards[LastIndex].Suit)
            {
                return true;
            }
            else if(toUse.Color == endDeck.Cards[LastIndex].Color)
            {
                return true;
            }
            else if(toUse.Color == ConsoleColor.Gray) {
                return true;
            }
            return false;
        }

       

    }
}
