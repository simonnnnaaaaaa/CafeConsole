using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Pricing
{
    public class MemberPricing : IPricingStrategy
    {
        public decimal ApplyPricing(decimal initialPrice) => initialPrice * 0.9m;
    }
}
