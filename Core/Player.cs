using System;


namespace Uno_V2.Core
{
    [Serializable]
    public class Player : ISerializable
    {
        public string FileName { get; private set; } 
        public Deck PlayerDeck { get; private set; }
        private Card EmptyCard;

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
            
            PlayerDeck = new Deck(0);
            for (int i = 0; i < 7; i++)
            {
                PlayerDeck.AddCardFrom(deck);
            }
            
            EmptyCard = new Card();
            
        }

        

        internal void UseCard(int cardIndex)
        {
            
            if(PlayerDeck.Cards[cardIndex].Type != Card.CardType.Regular)
            {
                ApplyCardProperty(ref PlayerDeck.Cards[cardIndex]);
            }
            endDeck.AddCardFrom(PlayerDeck, cardIndex);
        }

        private void ApplyCardProperty(ref Card CurrentCard)
        {
            if (CurrentCard.Suit == "+ 1")
            {
                Next.PlayerDeck.AddCardFrom(deck);
                Console.Write("Следуйщий игрок берет 1 карту!!");
                Console.ReadLine();
                Program.NextPlayer();
            }
            else if (CurrentCard.Suit == "ChD")
            {
                SwitchPlayers();

            }
            else if (CurrentCard.Suit == " S ")
            {
                Program.NextPlayer();
            }
            else if (CurrentCard.Suit == "ChC")
            {
                CurrentCard.ChangeColor();
            }
            else if (CurrentCard.Suit == "+ 2")
            {
                Next.PlayerDeck.AddCardFrom(deck);
                Next.PlayerDeck.AddCardFrom(deck);
                Console.Write("Следуйщий игрок берет 2 карты!!");
                Console.ReadLine();
                Program.NextPlayer();
            }
        }

        private void SwitchPlayers()
        {
            Program.Reverse = Program.Reverse ? false : true;
        }

        public static void PrintDecks(Player[] players, int index)
        {
            
            for (int i = 0; i < players.Length; i++)
            {
                if (i != index)
                {
                    Console.Write(i);
                    players[i].PrintCards(true);
                    Console.WriteLine();
                }

            }
            
            PrintEndDeck();
            Console.Write(index);
            players[index].PrintCards();
        }

        private void PrintCards(bool isEmpty = false)
        {
            int x=0;
            int y = Console.CursorTop;
            for (int i = 0; i < PlayerDeck.CardsAmount; i++)
            {
                x = Console.CursorLeft;

                if (isEmpty)
                {
                    EmptyCard.Print(x,y);
                }
                else
                {
                    PlayerDeck.Cards[i].Print(x, y);
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
            } while (!CanBeat(PlayerDeck.Cards[marker.index]));
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
            if (pt.index + 1 < PlayerDeck.CardsAmount)
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

        public bool hasApropriateCards()
        {
            for (int i = 0; i < PlayerDeck.CardsAmount; i++)
            {
                if (CanBeat(PlayerDeck.Cards[i]))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool canStack()
        {
            for (int i = 0; i < PlayerDeck.CardsAmount; i++)
            {
                if (PlayerDeck.Cards[i].Suit == endDeck.Cards[endDeck.CardsAmount - 1].Suit)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static void SaveAllToFile(Player[] players)
        {
            for (int i = 0; i < PlayersAmount; i++)
            {
                players[i].SaveToFile();
            }
        }

        private void SaveToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            serialaizator.Serialize(FileName, this);
            serialaizator.Serialize(endDeck.FileName, endDeck);
            
        }

        
        public static void LoadFromFile(ref Player[] players)
        {
            Serialaizator serialaizator = new Serialaizator();
            for (int i = 0; i < PlayersAmount; i++)
            {
                players[i] = (Player)serialaizator.Deserialize(players[i]);
            }
            players[0].LoadToFile();
        }
        private void LoadToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            endDeck = (Deck)serialaizator.Deserialize(endDeck);
        }

        public void GiveCard()
        {
            Current.PlayerDeck.AddCardFrom(deck);
        }
    }
}
