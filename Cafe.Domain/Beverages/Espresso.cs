namespace Cafe.Domain.Beverages
{
    public class Espresso : IBeverage
    {
        public string Name => DomainConstants.Espresso;

        public decimal Cost() => DomainConstants.EspressoCost;

        public string Describe() => Name;
    }
}
