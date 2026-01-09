
namespace Cafe.Domain.Beverages
{
    public class ExtraShotDecorator : BeverageDecorator
    {

        public ExtraShotDecorator(IBeverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => Beverage.Cost() + DomainConstants.ExtraShotCost;
        
        public override string Describe() => string.Format(DomainConstants.ExtraShot, Beverage.Describe());

    }
}
