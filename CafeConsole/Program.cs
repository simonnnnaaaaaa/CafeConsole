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
            beverage = ChooseAddOns(beverage);

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
                        return beverageFactory.Create("hot chocolate");

                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }

        }

        private static IBeverage ChooseAddOns(IBeverage beverage)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Add-ons menu (you can add multiple):");
                Console.WriteLine("1) Milk (+0.40)");
                Console.WriteLine("2) Syrup (+0.50)");
                Console.WriteLine("3) Extra shot (+0.80)");
                Console.WriteLine("0) Done");
                Console.Write("Your choice: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        beverage = new MilkDecorator(beverage);
                        Console.WriteLine($"Added milk. Current drink: {beverage.Describe()}");
                        break;

                    case "2":   //De modificat cu siropuri concrete
                        Console.Write("Enter syrup flavor (e.g. vanilla, caramel): ");
                        string? flavor = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(flavor))
                        {
                            Console.WriteLine("Flavor cannot be empty. Syrup not added.");
                        }
                        else
                        {
                            beverage = new SyrupDecorator(beverage, flavor);
                            Console.WriteLine($"Added {flavor} syrup. Current drink: {beverage.Describe()}");
                        }
                        break;

                    case "3":
                        beverage = new ExtraShotDecorator(beverage);
                        Console.WriteLine($"Added extra shot. Current drink: {beverage.Describe()}");
                        break;

                    case "0":
                        Console.WriteLine($"Finished add-ons. Final drink: {beverage.Describe()}");
                        return beverage;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
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

