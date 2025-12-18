
using Cafe.Domain.Beverages;

namespace Cafe.Domain.Preparation
{
    public static class BeveragePreparationFactory
    {
        public static BeveragePreparationTemplate Create(IBeverage beverage)
        {
            if (beverage is null)
            {
                return null;
            }

            var baseBeverage = UnwrapBaseBeverage(beverage);

            return baseBeverage switch
            {
                Espresso => new EspressoPreparation(),
                Tea => new TeaPreparation(),
                HotChocolate => new HotChocolatePreparation(),
                _ => null
            };
        }

        private static IBeverage UnwrapBaseBeverage(IBeverage beverage)
        {
            var current = beverage;

            while (current is BeverageDecorator decorator)
            {
                current = decorator.InnerBeverage;
            }

            return current;
        }
    }
}
