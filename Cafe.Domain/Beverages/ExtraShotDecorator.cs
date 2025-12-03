using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Beverages
{
    public class ExtraShotDecorator : BeverageDecorator
    {
        private const decimal ExtraShotCost = 0.80m;

        public ExtraShotDecorator(IBeverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => _beverage.Cost() + ExtraShotCost;
        
        public override string Describe() => $"{_beverage.Describe()}, extra shot";
    }
}
