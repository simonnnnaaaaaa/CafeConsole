
namespace Cafe.Domain.Beverages
{
    public class Tea : IBeverage
    {
        private const decimal TeaCost = 2.00m;
        public string Name => "Tea";

        public decimal Cost() => TeaCost;

        public string Describe() => Name;
    }
}
