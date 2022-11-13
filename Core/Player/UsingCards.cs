using System;

namespace Uno_V2.Core
{
    public partial class Player
    {
        private void AddCardToEnddeck(Card card)
        {
            PlayerDeck.Cards.Remove(card);
            endDeck.Cards.Add(card);
            endDeck.CardsAmount++;
            PlayerDeck.CardsAmount--;
        }
        private Card ApplyCardProperty(Card CurrentCard)
        {

            switch (CurrentCard.Suit)
            {
                case "+ 1":
                    {
                        AplyGiveCards(1);
                        Current.isFirstMove = true;
                    }
                    break;
                case "ChD":
                    {
                        SwitchPlayers();
                    }
                    break;
                case " S ":
                    {
                        Current.isFirstMove = true;
                    }
                    break;
                case "ChC":
                    {
                        CurrentCard.ChangeColor();
                    }
                    break;
                case "+ 2":
                    {
                        AplyGiveCards(2);
                        CurrentCard.ChangeColor();
                        Current.isFirstMove = true;

                    }
                    break;
            }
            if (CurrentCard.Suit != "ChD" && CurrentCard.Suit != "ChC" && CurrentCard.Type != Card.CardType.Regular)
            {
                Program.NextPlayer();
            }

            return CurrentCard;
        }

        private void AplyGiveCards(int amount)
        {
            Console.Write($"Следуйщий игрок берет карты: {amount} !!");
            Console.ReadLine();
            for (int i = 0; i < amount; i++)
            {
                Next.PlayerDeck.AddCardFrom(deck);
            }
        }

        private void SwitchPlayers()
        {
            Program.Reverse = Program.Reverse ? false : true;
        }
        

        private bool canBeat(Card toUse)
        {
            int LastIndex = endDeck.Cards.Count - 1;
            if (!isFirstMove)
            {
                return toUse.Suit == endDeck.Cards[LastIndex].Suit;
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
    }
}
