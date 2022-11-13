using System;

namespace Uno_V2.Core
{
    public partial class Player
    {
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
        private void GivePlayerCards(bool isLoggable = true)
        {
            if (isLoggable)
            {
                Console.WriteLine("Player is taking card");
                Console.ReadLine();
            }
            Current.PlayerDeck.AddCardFrom(deck);
            //Console.Clear();

        }
        private bool hasApropriateCards()
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
    }
}
