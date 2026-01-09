namespace Cafe.Domain.Pricing
{
    public class RegularPricing : IPricingStrategy
    {
        public decimal ApplyPricing(decimal initialPrice) => initialPrice;
    }
}
