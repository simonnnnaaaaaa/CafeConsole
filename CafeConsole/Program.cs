using Cafe.Application.Events;
using Cafe.Application.Orders;
using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Factories;
using Cafe.Domain.Preparation;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Factories;
using Cafe.Infrastructure.Observers;
using CafeConsole.States;


namespace CafeConsole
{
    internal static class Program
    {

        static void Main(string[] args)
        {
            
            //observers
            var analytics = new InMemoryOrderAnalytics();
            var logger = new ConsoleOrderLogger();

            var orderEventObservers = new List<IOrderEventObserver> { analytics, logger };

            //publisher
            var eventPublisher = new OrderEventPublisher(orderEventObservers);

            //service
            IOrderService orderService = new OrderService(eventPublisher);

            //state
            var kiosk = new KioskContext(orderService, analytics);

            //////////////////////////////////////////////////////////////

            while (true)
            {
                kiosk.Run();
            }
        }

        

    }
}

