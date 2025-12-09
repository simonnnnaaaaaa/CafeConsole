
namespace Cafe.Domain.Pricing
{
    public interface IPricingStrategy
    {
        decimal ApplyPricing(decimal initialPrice);
    }
}
