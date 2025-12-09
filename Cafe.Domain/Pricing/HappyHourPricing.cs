
namespace Cafe.Domain.Pricing
{
    public class HappyHourPricing : IPricingStrategy
    {
        public decimal ApplyPricing(decimal initialPrice) => initialPrice * 0.8m;
    }
}
