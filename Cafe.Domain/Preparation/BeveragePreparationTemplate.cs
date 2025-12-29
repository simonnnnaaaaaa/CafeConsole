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
            return PreparationConstants.HeatWaterStep;
        }

        protected abstract string Brew();

        protected virtual string Pour()
        {
            return PreparationConstants.PourBeverageStep;
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
                        steps.Add(PreparationConstants.AddMilkStep);
                        break;

                    case SyrupDecorator syrupDecorator:
                        steps.Add(string.Format(PreparationConstants.AddSyerupStep, syrupDecorator.Flavor));
                        break;

                    case BeverageDecorator otherDecorator:
                        steps.Add(PreparationConstants.ExtraEspressoShotStep);
                        break;
                }

                currentBeverage = decorator.InnerBeverage;
            }

            return steps;
        }
    }
}
