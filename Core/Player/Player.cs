using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Uno_V2.Core
{
    [Serializable]
    public partial class Player : ISerializable
    {
        public string FileName { get; private set; }
        public Deck PlayerDeck { get; private set; }

        private Card EmptyCard;
        private List<Card> cardToUse;
        public bool isFirstMove = true;

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
            endDeck.AddCardFrom(deck, mustBeRegular: true);
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


        public void UseCards()
        {
            foreach (var card in cardToUse)
            {
                ApplyCardProperty(card);

            }
            cardToUse.Clear();
        }

        public bool cardsWereUsed()
        {
            return cardToUse != null;
        }

        public void GuessNumber()
        {
            NumberGuesser n = new NumberGuesser();
            if (!n.Guess())
            {
                for (int i = 0; i < 3; i++)
                {
                    Current.GivePlayerCards(false);
                }
                
            }
        }

        //---------Printers---------
        public static void PrintDecks(Player[] players)
        {
            Console.Clear();
            PrintDecksInactive();
            PrintEndDeck();
            PrintCurrentDeck();
        }

        //---------Choosing and using card---------

        public bool AddCardToUse()
        {
            if (cardToUse == null)
            {
                cardToUse = new List<Card>();
            }
            Card choosen;
            try
            {
                choosen = PlayerDeck.Cards[ChooseCard()];
                cardToUse.Add(choosen);
                isFirstMove = false;
                AddCardToEnddeck(choosen);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

        }

        //---------No appropriate cards---------

        public bool CanUseMove()
        {


            if (Current.hasApropriateCards())
            {
                return true;
            }
            else if (!isFirstMove)
            {
                return false;
            }
            else if (Current.GiveCardsUntilCanContinueOrSkip())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool lowCardsAmount()
        {
            return deck.lowCardsAmount();
        }

        public static void RefillDeck()
        {
            endDeck.RefillCardsDeck(deck);
        }
        //---------Load/Save---------
        public static void SaveAllToFile()
        {
            for (int i = 0; i < Program.PlayersAmount; i++)
            {
                Program.players[i].SaveToFile();
            }
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
        
    }
}
