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

            bool running = true;


            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Cafe Console ===");
                Console.WriteLine();

                var beverage = MenuHelper.ChooseBaseBeverage(beverageFactory);
                beverage = MenuHelper.ChooseAddOns(beverage);

                IPricingStrategy pricingStrategy = MenuHelper.ChoosePricingStrategy();
                var resultOrder = orderService.PlaceOrder(beverage, pricingStrategy);

                Console.WriteLine("=== Receipt ===");
                PrintReceipt(resultOrder);
                Console.WriteLine("===============");

                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("1) Place another order");
                Console.WriteLine("0) Exit");
                Console.Write("Your choice: ");

                var next = Console.ReadLine();

                switch (next)
                {
                    case "1":
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Returning to main menu...");
                        // short pause so user can read the message
                        Thread.Sleep(1000);
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("=== Session analytics ===");
            Console.WriteLine($"Total orders: {analytics.TotalOrders}");
            Console.WriteLine($"Total revenue: {analytics.TotalRevenue:F2}");


            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

       
       

       

        private static void PrintReceipt(OrderReceiptDto result)
        {
            Console.WriteLine($"Order {result.OrderId} @ {result.At:o}");
            Console.WriteLine($"Items: {result.Description}");
            Console.WriteLine($"Subtotal: {result.Subtotal:F2}");
            Console.WriteLine($"Pricing: {result.PricingStrategyName}");
            Console.WriteLine($"Total: {result.Total:F2}");
        }

    }
}

