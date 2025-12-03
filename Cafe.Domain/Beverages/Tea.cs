
namespace Cafe.Domain.Beverages
{
    internal class Tea : IBeverage
    {
        private const decimal TeaCost = 2.00m;
        public string Name => "Tea";

        public decimal Cost() => TeaCost;

        public string Describe() => Name;
    }
}
