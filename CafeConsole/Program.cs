using Cafe.Application.Events;
using Cafe.Application.Orders;
using Cafe.Domain.Events;
using Cafe.Infrastructure.Analytics;
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

            // remote analytics (proxy)
            IAnalyticsClient remoteClient = new FakeRemoteAnalyticsClient(failureRate: 0.30);
            remoteClient = new LoggingAnalyticsClient(remoteClient, ConsoleUiConstants.Remote);
            IAnalyticsClient fallbackClient = new NullAnalyticsClient();
            fallbackClient = new LoggingAnalyticsClient(fallbackClient, ConsoleUiConstants.Fallback);


            IAnalyticsClient analyticsProxy = new AnalyticsClientProxy(
                inner: remoteClient,
                fallback: fallbackClient,
                maxRetries: 3,
                baseDelayMs: 150
            );

            analyticsProxy = new LoggingAnalyticsClient(analyticsProxy, ConsoleUiConstants.Proxy);

            var remoteAnalyticsObserver = new RemoteAnalyticsObserver(analyticsProxy);

            var orderEventObservers = new List<IOrderEventObserver> { analytics, logger, remoteAnalyticsObserver };

            //publisher
            var eventPublisher = new OrderEventPublisher(orderEventObservers);

            //service
            IOrderService orderService = new OrderService(eventPublisher);

            //state
            var kiosk = new KioskContext(orderService, analytics);

            while (true)
            {
                kiosk.Run();
            }
        }
    }
}

