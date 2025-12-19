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

        public override decimal Cost() => Beverage.Cost() + ExtraShotCost;
        
        public override string Describe() => $"{Beverage.Describe()}, extra shot";
    }
}
