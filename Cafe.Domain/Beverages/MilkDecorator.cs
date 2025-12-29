namespace Cafe.Domain.Beverages
{
    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => Beverage.Cost() + DomainConstants.MilkCost;

        public override string Describe() => string.Format(DomainConstants.Milk, Beverage.Describe());
    }
}
