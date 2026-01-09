namespace Cafe.Domain.Beverages
{
    public class HotChocolate : IBeverage
    {
        public string Name => DomainConstants.HotChocolate;
        public decimal Cost() => DomainConstants.HotChocolateCost;

        public string Describe() => Name;
    }
}
