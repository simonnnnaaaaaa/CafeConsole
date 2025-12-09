using Cafe.Application.Events;
using Cafe.Application.Orders;
using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Factories;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Factories;
using Cafe.Infrastructure.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    internal static class Program
    {

        static void Main(string[] args)
        {
            //factory
            IBeverageFactory beverageFactory = new BeverageFactory();

            //observers
            var analytics = new InMemoryOrderAnalytics();
            var logger = new ConsoleOrderLogger();

            var orderEventObservers = new List<IOrderEventObserver> { analytics, logger };

            //publisher
            var eventPublisher = new OrderEventPublisher(orderEventObservers);

            //service
            IOrderService orderService = new OrderService(eventPublisher);

            //////////////////////////////////////////////////////////////

            IBeverage beverage = beverageFactory.Create("espresso");
            IPricingStrategy pricingStrategy = new RegularPricing();

            var result = orderService.PlaceOrder(beverage, pricingStrategy);

            Console.WriteLine($"Total orders: {analytics.TotalOrders}");
            Console.WriteLine($"Total revenue: {analytics.TotalRevenue:F2}");

        }
    }
}
