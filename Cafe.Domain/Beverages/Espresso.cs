
namespace Cafe.Domain.Beverages
{
    public class Espresso : IBeverage
    {
        private const decimal EspressoCost = 2.50m;
        public string Name => "Espresso";

        public decimal Cost() => EspressoCost;

        public string Describe() => Name;
    }
}
