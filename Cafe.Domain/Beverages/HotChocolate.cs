
namespace Cafe.Domain.Beverages
{
    public class HotChocolate : IBeverage
    {
        private const decimal HotChocolateCost = 3.00m;
        public string Name => "Hot Chocolate";
        public decimal Cost() => HotChocolateCost;

        public string Describe() => Name;
    }
}
