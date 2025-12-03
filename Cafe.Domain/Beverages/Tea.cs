
namespace Cafe.Domain.Beverages
{
    internal class Tea : IBeverage
    {
        public string Name => "Tea";

        public decimal Cost() => 2.00m;

        public string Describe() => Name;
    }
}
