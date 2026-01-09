namespace Cafe.Domain.Pricing
{
    public class CuponPricing : IPricingStrategy
    {
        private readonly decimal _discountRate;

        public CuponPricing(decimal discountRate)
        {
            if (discountRate <= 0 || discountRate >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(discountRate), DomainConstants.DiscountOutOfRangeMessage);
            }
            _discountRate = discountRate;
        }

        public decimal ApplyPricing(decimal initialPrice)
        {
            var discount = initialPrice * _discountRate;
            var total = initialPrice - discount;

            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }
    }
}
