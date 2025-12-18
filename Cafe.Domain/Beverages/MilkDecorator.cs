using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Beverages
{
    public class MilkDecorator : BeverageDecorator
    {

        private const decimal MilkCost = 0.40m;

        public MilkDecorator(IBeverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => Beverage.Cost() + MilkCost;

        public override string Describe() => $"{Beverage.Describe()}, milk";
    }
}
