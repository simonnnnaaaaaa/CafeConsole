
namespace Cafe.Domain.Preparation
{
    public class TeaPreparation : BeveragePreparationTemplate
    {
        protected override string Brew()
        {
            return PreparationConstants.SteepTeaBagStep;
        }

        protected override string Garnish()
        {
            return PreparationConstants.GarnishTeaStep;
        }
    }
}
