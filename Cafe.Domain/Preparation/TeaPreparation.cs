
namespace Cafe.Domain.Preparation
{
    public class TeaPreparation : BeveragePreparationTemplate
    {
        protected override string Brew()
        {
            return "Steeping tea bag...";
        }

        protected override string Garnish()
        {
            return "Adding lemon and honey...";
        }
    }
}
