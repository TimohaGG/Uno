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
        public string FileName { get; } = "Player.txt";

        public Card[] Cards;
        private Card EmptyCard;
        private int CardsAmount = 7;
        private static Deck deck;
        private static Deck endDeck;

        static Player()
        {
            deck = new Deck(56);
            deck.CreateFirst();
            endDeck = new Deck(1);
            endDeck.AddCardFrom(deck);
        }
        public Player()
        {
            Cards = new Card[CardsAmount];
            GiveCardsFromDeckToPlayer(CardsAmount);
            EmptyCard = new Card();
            
        }

        private void GiveCardsFromDeckToPlayer(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Cards[i] = deck.Cards[i];
            }
            deck.DeleteCards(amount);
        }

        public void PrintCards(bool isEmpty = false)
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

        public static void PrintEndDeck()
        {
            Console.SetCursorPosition(21, 7);
            endDeck.Cards[endDeck.Cards.Length - 1].Print(21,7);
        }
        
        public int ChooseCard()
        {
            
            ChoosingMarker marker = new ChoosingMarker();
            ConsoleKey key;

            PrintChooser(marker);
            while (true)
            {
                key = Console.ReadKey().Key;
                if (!TryMooving(marker, ref key))
                {
                    marker.SetConsolePosition();
                }
               
                    else if (key == ConsoleKey.Enter)
                    {
                        
                        return marker.index;
                    }
                       
            }

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
        
        public bool TryUseCard(int index)
        {
            if (CanBeat(Cards[index]))
            {
                Console.WriteLine("Can beat!!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Can not beat!!!");
                Console.ReadLine();
            }
            return false;
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
