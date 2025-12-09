
using Cafe.Domain.Beverages;
using Cafe.Domain.Pricing;

namespace Cafe.Application.Orders
{
    public interface IOrderService
    {
        OrderReceiptDto PlaceOrder(IBeverage beverage, IPricingStrategy pricingStrategy);
    }
}
