
namespace Cafe.Domain.Beverages
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;

        protected BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage ?? throw new ArgumentNullException(nameof(beverage));
        }

        public string Name => _beverage.Name;

        public abstract decimal Cost();

        public virtual string Describe() => _beverage.Describe();
    }
}
