using Cafe.Domain.Events;

namespace Cafe.Application.Events
{
    public class OrderEventPublisher : IOrderEventPublisher
    {

        private readonly List<IOrderEventObserver> _observers;

        public OrderEventPublisher(List<IOrderEventObserver> observers)
        {
            _observers = observers ?? throw new ArgumentNullException(nameof(observers));
        }


        public void PublishOrderPlaced(OrderPlaced orderPlaced)
        {
            if (orderPlaced != null)
            {
                foreach (var observer in _observers)
                {
                    observer.OnOrderPlaced(orderPlaced);
                }
            }
        }
    }
}
