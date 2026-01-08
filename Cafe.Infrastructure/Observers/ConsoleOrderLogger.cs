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
               InfrastructureConstants.OrderLogTemplate,
               orderPlaced.OrderId,
               orderPlaced.At,
               orderPlaced.Description,
               orderPlaced.Subtotal,
               orderPlaced.Total
           );
        }
    }
}
