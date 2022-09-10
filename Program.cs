using Uno_V2.Core;

namespace Uno_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Create();
            //deck.Print();
            Serialaizator serialaizator = new Serialaizator();


            
            serialaizator.Serialize("deck.txt", deck);
            deck = (Deck)serialaizator.Deserialize( deck);
           
        }

    }
}
