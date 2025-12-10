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

            //IBeverage beverage = beverageFactory.Create("espresso");
            //IPricingStrategy pricingStrategy = new RegularPricing();

            //var result = orderService.PlaceOrder(beverage, pricingStrategy);

            //Console.WriteLine($"Total orders: {analytics.TotalOrders}");
            //Console.WriteLine($"Total revenue: {analytics.TotalRevenue:F2}");

            var beverage = ChooseBaseBeverage(beverageFactory);

            IPricingStrategy pricingStrategy = new RegularPricing();
            var resultOrder = orderService.PlaceOrder(beverage, pricingStrategy);

            PrintReceipt(resultOrder);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        private static IBeverage ChooseBaseBeverage(IBeverageFactory beverageFactory)
        {
            while (true)
            {
                Console.WriteLine("Choose your base beverage:");
                Console.WriteLine("1) Espresso");
                Console.WriteLine("2) Tea");
                Console.WriteLine("3) Hot Chocolate");
                Console.Write("Your choice: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return beverageFactory.Create("espresso");

                    case "2":
                        return beverageFactory.Create("tea");

                    case "3":
                        return beverageFactory.Create("choc");

                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }

        }

        private static void PrintReceipt(OrderReceiptDto result)
        {
            Console.WriteLine();
            Console.WriteLine($"Order {result.OrderId} @ {result.At:o}");
            Console.WriteLine($"Items: {result.Description}");
            Console.WriteLine($"Subtotal: {result.Subtotal:F2}");
            Console.WriteLine($"Pricing: {result.PricingStrategyName}");
            Console.WriteLine($"Total: {result.Total:F2}");
        }

    }
}

