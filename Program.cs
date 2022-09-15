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
                player1.PrintCards();
               
                Player.PrintEndDeck();
                Console.SetCursorPosition(0, 14);
                player2.PrintCards();

                int index = player2.ChooseCard();

                
                
                ////Для каждого вида карт сделать отдельный класс реализовующий интрефейс IUseble
                
                
                  if (player2.Cards[index].Type != Card.CardType.Regular)
                  {
                      player2.ApplyCardProperty(player2.Cards[index], ref player1);
                  }


                Player.SwitchPlayers(player1, player2);
               
                Console.Clear();
            }
            
            Console.ReadLine();
        }

    }
}
