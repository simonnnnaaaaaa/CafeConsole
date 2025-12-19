
namespace Cafe.Domain.Beverages
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage Beverage { get; }

        public IBeverage InnerBeverage => Beverage;

        protected BeverageDecorator(IBeverage beverage)
        {
            Beverage = beverage ?? throw new ArgumentNullException(nameof(beverage));
        }

        public string Name => Beverage.Name;

        public abstract decimal Cost();

        public virtual string Describe() => Beverage.Describe();
    }
}
