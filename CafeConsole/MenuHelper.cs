using Cafe.Application.Orders;
using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Observers;

namespace CafeConsole
{
    public static class MenuHelper
    {
        public static IBeverage ChooseBaseBeverage(IBeverageFactory beverageFactory)
        {
            while (true)
            {
                Console.WriteLine(ConsoleUiConstants.ChooseBaseBeveragePrompt
                    );
                Console.WriteLine(ConsoleUiConstants.Esspresso1);
                Console.WriteLine(ConsoleUiConstants.Tea2);
                Console.WriteLine(ConsoleUiConstants.HotChocolate3);
                Console.Write(ConsoleUiConstants.YourChoicePrompt);

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return beverageFactory.Create(ConsoleUiConstants.Espresso);

                    case "2":
                        return beverageFactory.Create(ConsoleUiConstants.Tea);

                    case "3":
                        return beverageFactory.Create(ConsoleUiConstants.HotChocolate);

                    default:
                        Console.WriteLine(ConsoleUiConstants.InvalidOption);
                        break;
                }
            }

        }

        public static IBeverage ChooseAddOns(IBeverage beverage)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(ConsoleUiConstants.AddOnsMenuTitle);
                Console.WriteLine(ConsoleUiConstants.Milk1);
                Console.WriteLine(ConsoleUiConstants.Syrup2);
                Console.WriteLine(ConsoleUiConstants.ExtraShot3);
                Console.WriteLine(ConsoleUiConstants.Done0);
                Console.Write(ConsoleUiConstants.YourChoicePrompt);

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        beverage = new MilkDecorator(beverage);
                        Console.WriteLine(ConsoleUiConstants.AddedMilk, beverage.Describe());
                        break;

                    case "2":   //De modificat cu siropuri concrete
                        Console.Write(ConsoleUiConstants.EnterSyrupFlavorPrompt);
                        string? flavor = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(flavor))
                        {
                            Console.WriteLine(ConsoleUiConstants.FlavorCannotBeEmpty);
                        }
                        else
                        {
                            beverage = new SyrupDecorator(beverage, flavor);
                            Console.WriteLine(string.Format(ConsoleUiConstants.AddedSyrup, flavor), beverage.Describe());
                        }
                        break;

                    case "3":
                        beverage = new ExtraShotDecorator(beverage);
                        Console.WriteLine(ConsoleUiConstants.AddedExtraShot, beverage.Describe());
                        break;

                    case "0":
                        Console.WriteLine(ConsoleUiConstants.FinishedAddOns, beverage.Describe());
                        return beverage;

                    default:
                        Console.WriteLine(ConsoleUiConstants.InvalidOption);
                        break;
                }
            }
        }

        public static IPricingStrategy ChoosePricingStrategy()
        {
            while (true)
            {
                Console.WriteLine(ConsoleUiConstants.ChoosePricingOption);
                Console.WriteLine(ConsoleUiConstants.RegularPricing1);
                Console.WriteLine(ConsoleUiConstants.HappyHourPricing2);
                Console.WriteLine(ConsoleUiConstants.MemberDiscountPricing3);
                Console.WriteLine(ConsoleUiConstants.CuponPricing4);

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
                        Console.WriteLine(ConsoleUiConstants.InvalidOption);
                        break;
                }
            }
        }

        private static IPricingStrategy CreateCouponPricing()
        {
            Console.Write(ConsoleUiConstants.EnterCuponDiscountPrompt);
            string? percentInput = Console.ReadLine();

            try
            {
                decimal percentage = Convert.ToDecimal(percentInput);

                if (percentage > 0 && percentage < 100)
                {
                    decimal rate = percentage / 100m;
                    return new CuponPricing(rate);
                }

                Console.WriteLine(ConsoleUiConstants.PercentageOutOfRange);
            }
            catch (Exception)
            {
                Console.WriteLine(ConsoleUiConstants.InvalidPercentage);
            }

            return new RegularPricing();
        }

        public static void PrintReceipt(OrderReceiptDto result)
        {
            Console.WriteLine(
                ConsoleUiConstants.ReceiptHeader,
                result.OrderId,
                result.At
            );

            Console.WriteLine(
                ConsoleUiConstants.ReceiptItems,
                result.Description
            );

            Console.WriteLine(
                ConsoleUiConstants.ReceiptSubtotal,
                result.Subtotal
            );

            Console.WriteLine(
                ConsoleUiConstants.ReceiptPricing,
                result.PricingStrategyName
            );

            Console.WriteLine(
                ConsoleUiConstants.ReceiptTotal,
                result.Total
            );
        }

        public static void PrintAnalytics(InMemoryOrderAnalytics analytics)
        {
            Console.WriteLine(ConsoleUiConstants.SessionAnalyticsHeader);
            Console.WriteLine(ConsoleUiConstants.TotalOrders, analytics.TotalOrders);
            Console.WriteLine(ConsoleUiConstants.TotalRevenue, analytics.TotalRevenue);
            Console.WriteLine(ConsoleUiConstants.PressAnyKeyToExit);
            Console.ReadKey();
        }

    }
}
