namespace Cafe.Domain.Beverages
{
    public class Tea : IBeverage
    {
        public string Name => DomainConstants.Tea;

        public decimal Cost() => DomainConstants.TeaCost;

        public string Describe() => Name;
    }
}
