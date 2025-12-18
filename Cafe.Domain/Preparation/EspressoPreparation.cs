
namespace Cafe.Domain.Preparation
{
    public class EspressoPreparation : BeveragePreparationTemplate
    {
        protected override string Brew()
        {
            return "Extracting espresso shot...";
        }
    
    }
}
