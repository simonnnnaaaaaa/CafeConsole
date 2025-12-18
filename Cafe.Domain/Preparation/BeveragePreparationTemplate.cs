
namespace Cafe.Domain.Preparation
{
    public abstract class BeveragePreparationTemplate
    {
        public IEnumerable<string> Prepare()
        {
            var steps = new List<string>();

            steps.Add(HeatWater());
            steps.Add(Brew());
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
    }
}
