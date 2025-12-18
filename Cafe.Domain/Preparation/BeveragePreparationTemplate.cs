
using Cafe.Domain.Beverages;

namespace Cafe.Domain.Preparation
{
    public abstract class BeveragePreparationTemplate
    {
        public IEnumerable<string> Prepare(IBeverage beverage)
        {
            var steps = new List<string>();

            steps.Add(HeatWater());
            steps.Add(Brew());

            steps.AddRange(AddOnSteps(beverage));

            steps.Add(Pour());

            var garnishStep = Garnish();
            if (!string.IsNullOrWhiteSpace(garnishStep))
            {
                steps.Add(garnishStep);
            }

            return steps;
        }

        protected virtual string HeatWater()
        {
            return "Heating water...";
        }

        protected abstract string Brew();

        protected virtual string Pour()
        {
            return "Pouring beverage into cup...";
        }

        protected virtual string? Garnish()
        {
            // optional
            return null;
        }

        protected virtual IEnumerable<string> AddOnSteps(IBeverage beverage)
        {
            var steps = new List<string>();

            var currentBeverage = beverage;

            while (currentBeverage is BeverageDecorator decorator)
            {
                switch (currentBeverage)
                {
                    case MilkDecorator milkDecorator:
                        steps.Add("Adding milk...");
                        break;

                    case SyrupDecorator syrupDecorator:
                        steps.Add($"Adding {syrupDecorator.Flavor} syrup...");
                        break;

                    case BeverageDecorator otherDecorator:
                        steps.Add("Pulling extra espresso shot...");
                        break;
                }

                currentBeverage = decorator.InnerBeverage;
            }

            return steps;
        }
    }
}
