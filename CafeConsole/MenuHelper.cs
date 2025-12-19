using Cafe.Application.Orders;
using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;
using Cafe.Domain.Pricing;

namespace CafeConsole
{
    public static class MenuHelper
    {
        public static IBeverage ChooseBaseBeverage(IBeverageFactory beverageFactory)
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

        public static IBeverage ChooseAddOns(IBeverage beverage)
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

        public static IPricingStrategy ChoosePricingStrategy()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose one of he pricing options:");
                Console.WriteLine("1) Regular");
                Console.WriteLine("2) Happy Hour (-20%)");
                Console.WriteLine("3) Member (-10%)");
                Console.WriteLine("4) Coupon (custom % discount)");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return new RegularPricing();

                    case "2":
                        return new HappyHourPricing();
                    case "3":
                        return new MemberPricing();

                    case "4":
                        return CreateCouponPricing();

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static IPricingStrategy CreateCouponPricing()
        {
            Console.Write("Enter discount percentage (e.g. 15 for 15%): ");
            string? percentInput = Console.ReadLine();

            try
            {
                decimal percentage = Convert.ToDecimal(percentInput);

                if (percentage > 0 && percentage < 100)
                {
                    decimal rate = percentage / 100m;
                    return new CuponPricing(rate);
                }

                Console.WriteLine("Percentage must be between 0 and 100.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid percentage value.");
            }

            return new RegularPricing();
        }
        

        public static void PrintReceipt(OrderReceiptDto result)
        {
            Console.WriteLine($"Order {result.OrderId} @ {result.At:o}");
            Console.WriteLine($"Items: {result.Description}");
            Console.WriteLine($"Subtotal: {result.Subtotal:F2}");
            Console.WriteLine($"Pricing: {result.PricingStrategyName}");
            Console.WriteLine($"Total: {result.Total:F2}");
        }

    }
}
