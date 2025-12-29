namespace Cafe.Domain.Beverages
{
    public class SyrupDecorator : BeverageDecorator
    {
        public string Flavor { get; }

        public SyrupDecorator(IBeverage beverage, string flavor) : base(beverage)
        {
            Flavor = flavor ?? throw new ArgumentNullException(nameof(flavor));
        }

        public override decimal Cost() => Beverage.Cost() + DomainConstants.SyrupCost;

        public override string Describe() => string.Format(DomainConstants.Syrup, Beverage.Describe, Flavor);
    }
}
