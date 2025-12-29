namespace Cafe.Domain.Pricing
{
    public class MemberPricing : IPricingStrategy
    {
        public decimal ApplyPricing(decimal initialPrice) => initialPrice * DomainConstants.MemberDiscountRate;
    }
}
