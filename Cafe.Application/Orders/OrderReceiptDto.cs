namespace Cafe.Application.Orders
{
    public class OrderReceiptDto
    {
        public Guid OrderId { get; }
        public DateTimeOffset At { get; }
        public string Description { get; }
        public decimal Subtotal { get; }
        public decimal Total { get; }
        public string PricingStrategyName { get; }

        public OrderReceiptDto(
            Guid orderId,
            DateTimeOffset at,
            string description,
            decimal subtotal,
            decimal total,
            string pricingStrategyName)
        {
            OrderId = orderId;
            At = at;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Subtotal = subtotal;
            Total = total;
            PricingStrategyName = pricingStrategyName ?? throw new ArgumentNullException(nameof(pricingStrategyName));
        }
    }
}
