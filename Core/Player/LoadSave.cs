namespace Uno_V2.Core
{
    public partial class Player
    {
        private void SaveToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            serialaizator.Serialize(FileName, this);
            serialaizator.Serialize(endDeck.FileName, endDeck);

        }

        private void LoadToFile()
        {
            Serialaizator serialaizator = new Serialaizator();
            endDeck = (Deck)serialaizator.Deserialize(endDeck);
        }
    }
}

