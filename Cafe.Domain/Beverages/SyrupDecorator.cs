using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Beverages
{
    public class SyrupDecorator : BeverageDecorator
    {
        private const decimal SyrupCost = 0.50m;

        public string Flavor { get; }

        public SyrupDecorator(IBeverage beverage, string flavor) : base(beverage)
        {
            Flavor = flavor ?? throw new ArgumentNullException(nameof(flavor));
        }

        public override decimal Cost() => Beverage.Cost() + SyrupCost;

        public override string Describe() => $"{Beverage.Describe()}, {Flavor} syrup";
    }
}
