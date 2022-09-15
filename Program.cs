using Uno_V2.Core;
using System;
namespace Uno_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Player player1 = new Player("Player1.txt");
            Player player2 = new Player("Player2.txt");
            while (true)
            {
                player1.PrintCards(true);
               
                Player.PrintEndDeck();
                Console.SetCursorPosition(0, 14);
                player2.PrintCards();

                int index = player2.ChooseCard();
                //TODO Добавить проверку если CurrentCard != Regular применить свойство СurrentCard
                //Для каждого вида карт сделать отдельный класс реализовующий интрефейс IUseble
                if (player2.TryUseCard(index))
                {
                    if (player2.Cards[index].Type != Card.CardType.Regular)
                    {
                        player2.ApplyCardProperty(player2.Cards[index], player1);
                    }
                }
                (player1,player2) = (player2,player1);
               
                Console.Clear();
            }
            
            Console.ReadLine();
        }

    }
}
