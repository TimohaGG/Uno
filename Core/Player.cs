using System;
using System.Reflection;


namespace Uno_V2.Core
{
    [Serializable]
    public class Player : ISerializable
    {
        public string FileName { get; private set; } 
        public Deck PlayerDeck { get; private set; }

        private Card EmptyCard;
        private bool isFirstMove = true;

        public static int CurrentIndex = 0;
        public static int NextIndex = 1;
        public static Player Current;
        public static Player Next;
        

        private static Deck deck;
        private static Deck endDeck;

        //---------Creation---------
        static Player()
        {
            deck = new Deck(56);
            deck.CreateFirst();
            endDeck = new Deck(0);
            endDeck.AddCardFrom(deck,mustBeRegular:true);
        }

        static public void CreatePlayers()
        {
            string FileName;
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                FileName = "Player" + i + 1 + ".txt";
                Program.players[i] = new Player(FileName);
            }
        }

        public Player(string FileName)
        {
            this.FileName = FileName;
            PlayerDeck = new Deck(0);
            for (int i = 0; i < 7; i++)
            {
                PlayerDeck.AddCardFrom(deck);
            }
            EmptyCard = new Card();
        }

        //---------Using cards---------

        public void UseCard(int cardIndex)
        {
            
            if(PlayerDeck.Cards[cardIndex].Type != Card.CardType.Regular)
            {
                PlayerDeck.Cards[cardIndex] = ApplyCardProperty(PlayerDeck.Cards[cardIndex]);
            }
            endDeck.AddCardFrom(PlayerDeck, cardIndex);
            //isFirstMove = false;
        }

        private Card ApplyCardProperty(Card CurrentCard)
        {
           
            switch (CurrentCard.Suit)
            {
                case "+ 1":
                    {
                        AplyGiveCards(1);
                       // Program.NextPlayer();
                    }break;
                case "ChD":
                    {
                        SwitchPlayers();
                    }break;
                case " S ": {
                        Program.NextPlayer();
                    }break;
                case "ChC":
                    {
                        CurrentCard.ChangeColor();
                    }break;
                case "+ 2":
                    {
                        AplyGiveCards(2);
                        CurrentCard.ChangeColor();
                        //Program.NextPlayer();
                    }
                    break;
            }
            return CurrentCard;
        }

        private void AplyGiveCards(int amount)
        {
            Console.Write($"Следуйщий игрок берет карты: {amount} !!");
            Console.ReadLine();
            Program.NextPlayer();
            for (int i = 0; i < amount; i++)
            {
                Next.PlayerDeck.AddCardFrom(deck);
            }
        }

        private void SwitchPlayers()
        {
            Program.Reverse = Program.Reverse ? false : true;
        }

        //---------Printers---------
        public static void PrintDecks(Player[] players)
        {

            PrintDecksInactive();
            PrintEndDeck();
            PrintCurrentDeck();
        }


        private static void PrintDecksInactive() {
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                if (i != CurrentIndex)
                {
                    Console.Write(i);
                    Program.players[i].PrintCards(true);
                    Console.WriteLine();
                }

            }
           
        }
        private static void PrintEndDeck()
        {
            Console.SetCursorPosition(21, Console.CursorTop + 4);
            endDeck.Cards[endDeck.Cards.Count - 1].Print(21, Console.CursorTop);
            Console.SetCursorPosition(0, Console.CursorTop + 5);
        }

        static void PrintCurrentDeck()
        {
            Console.Write(CurrentIndex);
            Current.PrintCards();
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

        //---------Choosing and using card---------



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
            } while (!canBeat(PlayerDeck.Cards[marker.index]));
            return marker.index;
        }

        private void PrintChooser(ChoosingMarker pt)
        {
            Console.SetCursorPosition(pt.x, pt.y);
            pt.PrintMarker();
        }

        private bool TryMooving(ChoosingMarker pt ,ref ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.LeftArrow => MoveLeft(ref pt),
                ConsoleKey.RightArrow => MoveRight(ref pt),
                ConsoleKey.Enter => true,
                _ =>  false
            };
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

        private bool canBeat(Card toUse)
        {
            int LastIndex = endDeck.Cards.Count - 1;
            if (!isFirstMove && toUse.Suit == endDeck.Cards[LastIndex].Suit)
            {
                return true;
            }
            else
            {
                if (toUse.Suit == endDeck.Cards[LastIndex].Suit)
                {
                    return true;
                }
                else if (toUse.Color == endDeck.Cards[LastIndex].Color)
                {
                    return true;
                }
                else if (toUse.Color == ConsoleColor.Gray)
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

        public bool canContinue()
        {
            bool canContinue = Current.canStack();
            if (canContinue)
            {
                isFirstMove = false;
                Console.WriteLine("R - повторить ход");
                Console.WriteLine("N - следуйщий игрок");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.R: {
                            Console.Clear();
                            return true;
                        }
                    case ConsoleKey.N: {
                            Console.Clear();
                            return false;
                        }
                    default: {
                            Console.WriteLine("Повторите попытку");
                        }break;
                }
            }
            isFirstMove = true;
            Console.Clear();
            return false;
            
        }
        //---------No appropriate cards---------

        public bool CanUseMove()
        {
            if (!Current.hasApropriateCards())
            {
                if (!Current.GiveCardsUntilCanContinueOrSkip())
                {
                    
                    return false;
                }
            }
            return true;
        }

        private bool GiveCardsUntilCanContinueOrSkip()
        {
            int amountOfTakenCards = 0;
            do
            {
                Current.GivePlayerCards();
                PrintDecks(Program.players);
                amountOfTakenCards++;
                if (Current.hasApropriateCards())
                    return true;
            } while (amountOfTakenCards != 2);
            return false;
        }
        public void GivePlayerCards()
        {
            Console.WriteLine("Player is taking card");
            Console.ReadLine();
            Current.PlayerDeck.AddCardFrom(deck);
            Console.Clear();

        }
        public bool hasApropriateCards()
        {
            for (int i = 0; i < PlayerDeck.CardsAmount; i++)
            {
                if (canBeat(PlayerDeck.Cards[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool lowCardsAmount()
        {
            return deck.lowCardsAmount();
        }

        public static void RefillDeck()
        {
            endDeck.RefillCardsDeck(deck);
            
        }
        //---------Saveing/loading---------

        public static void SaveAllToFile()
        {
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                Program.players[i].SaveToFile();
            }
        }

        private void SaveToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            serialaizator.Serialize(FileName, this);
            serialaizator.Serialize(endDeck.FileName, endDeck);
            
        }

        
        public static void LoadFromFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                Program.players[i] = (Player)serialaizator.Deserialize(Program.players[i]);
            }

            Program.players[0].LoadToFile();
        }
        private void LoadToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            endDeck = (Deck)serialaizator.Deserialize(endDeck);
        }

       
    }
}
