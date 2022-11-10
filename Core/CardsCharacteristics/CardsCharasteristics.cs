namespace Uno_V2.Core.CardsCharacteristics
{
    internal class CardsCharasteristics
    {
        public RegularCardInfo RegularInf;
        public SpecialCardsInfo SpecInf;
        public WildCardsInfo WildInf;
        public CardsCharasteristics()
        {
            RegularInf = new RegularCardInfo();
            SpecInf = new SpecialCardsInfo();
            WildInf = new WildCardsInfo();
        }
    }
}
