using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Pricing;

namespace Cafe.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderEventPublisher _eventPublisher;

        public OrderService(IOrderEventPublisher eventpublisher)
        {
            _eventPublisher = eventpublisher ?? throw new ArgumentNullException(nameof(eventpublisher));
        }

        public OrderReceiptDto PlaceOrder(IBeverage beverage, IPricingStrategy pricingStrategy)
        {
            if(beverage is null)
            {
                throw new ArgumentNullException(nameof(beverage));
            }

            if(pricingStrategy is null)
            {
                throw new ArgumentNullException(nameof(pricingStrategy));
            }

            var orderId = Guid.NewGuid();
            var timestamp = DateTimeOffset.UtcNow;
            var description = beverage.Describe();
            var subtotal = beverage.Cost();
            var total = Math.Round(pricingStrategy.ApplyPricing(subtotal), 2, MidpointRounding.AwayFromZero);

            var orderPlaced = new OrderPlaced(
            OrderId: orderId,
            At: timestamp,
            Description: description,
            Subtotal: subtotal,
            Total: total);

            _eventPublisher.PublishOrderPlaced(orderPlaced);

            var pricingStrategyName = pricingStrategy.GetType().Name;

            return new OrderReceiptDto(
                orderId: orderId,
                at: timestamp,
                description: description,
                subtotal: subtotal,
                total: total,
                pricingStrategyName: pricingStrategyName);

        }
    }
}
