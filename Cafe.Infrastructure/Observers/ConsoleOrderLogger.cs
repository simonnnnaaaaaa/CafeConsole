using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Observers
{
    public class ConsoleOrderLogger : IOrderEventObserver
    {
        public void OnOrderPlaced(OrderPlaced orderPlaced)
        {
            if(orderPlaced is null)
            {
                throw new ArgumentNullException(nameof(orderPlaced));
            }

            Console.WriteLine(
            $"[Order LOG] {orderPlaced.OrderId} @ {orderPlaced.At:o} | " +
            $"Items: {orderPlaced.Description} | " +
            $"Subtotal: {orderPlaced.Subtotal:F2}, Total: {orderPlaced.Total:F2}");
        }
    }
}
