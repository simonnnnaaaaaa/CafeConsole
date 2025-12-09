using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Observers
{
    public class InMemoryOrderAnalytics : IOrderEventObserver
    {
        public int TotalOrders { get; private set; }
        public decimal TotalRevenue { get; private set; }

        public void OnOrderPlaced(OrderPlaced orderPlaced)
        {
            if (orderPlaced is null)
            {
                throw new ArgumentNullException(nameof(orderPlaced));
            }

            TotalOrders++;
            TotalRevenue += orderPlaced.Total;
        }
    }
}
