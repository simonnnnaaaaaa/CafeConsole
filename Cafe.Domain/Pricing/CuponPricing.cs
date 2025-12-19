using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Pricing
{
    public class CuponPricing : IPricingStrategy
    {
        private readonly decimal _discountRate;

        public CuponPricing(decimal discountRate)
        {
            if (discountRate <= 0 || discountRate >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(discountRate),
                    "Discount rate must be between 0 and 1 (exclusive).");
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
