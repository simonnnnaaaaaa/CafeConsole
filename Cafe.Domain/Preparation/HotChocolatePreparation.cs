
namespace Cafe.Domain.Preparation
{
    public class HotChocolatePreparation : BeveragePreparationTemplate
    {
        protected override string Brew()
        {
            return "Mixing hot chocolate powder...";
        }
    }
}
