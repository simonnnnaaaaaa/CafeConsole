namespace CafeConsole
{
    public class ConsoleUiConstants
    {
        public const string Remote = "Remote";
        public const string Fallback = "Fallback";
    
        public const string Proxy = "Proxy";

        public const string PreparingBeverage = "Preparing your beverage...";
        public const string BaseBeveragePreparationFinished = "Base beverage preparation finished!";
    
        public const string ChooseBaseBeveragePrompt = "Choose your base beverage:";
        public const string Esspresso1 = "1) Espresso";
        public const string Tea2 = "2) Tea";
        public const string HotChocolate3 = "3) Hot Chocolate";
        public const string YourChoicePrompt = "Your choice: ";
        public const string Espresso = "espresso";
        public const string Tea = "tea";
        public const string HotChocolate = "hot chocolate";
        public const string InvalidOption = "Invalid option. Please try again.\n";

        public const string AddOnsMenuTitle = "Add-ons menu (you can add multiple):";
        public const string Milk1 = "1) Milk (+0.40)";
        public const string Syrup2 = "2) Syrup (+0.50)";
        public const string ExtraShot3 = "3) Extra shot (+0.80)";
        public const string Done0 = "0) Done";

        public const string AddedMilk = "Added milk. Current drink: ";
        public const string EnterSyrupFlavorPrompt = "Enter syrup flavor (e.g. vanilla, caramel): ";
        public const string FlavorCannotBeEmpty = "Flavor cannot be empty. Syrup not added.";
        public const string AddedSyrup = "Added {0} syrup. Current drink: ";
        public const string AddedExtraShot = "Added extra shot. Current drink: ";
        public const string FinishedAddOns = "Finished add-ons. Final drink: ";

        public const string ChoosePricingOption = "Choose pricing one of the pricing options:";
        public const string RegularPricing1 = "1) Regular Pricing";
        public const string HappyHourPricing2 = "2) Happy Hour Pricing (-20%)";
        public const string MemberDiscountPricing3 = "3) Member Discount Pricing (-10%)";
        public const string CuponPricing4 = "4) Cupon Pricing (custon % discount)";
    
        public const string EnterCuponDiscountPrompt = "Enter cupon discount percentage (e.g. 15 for 15%): ";
        public const string PercentageOutOfRange = "Percentage must be between 0 and 100. Please try again.";
        public const string InvalidPercentage = "Invalid percentage value.";

        public const string ReceiptHeader = "Order {0} @ {1:o}";
        public const string ReceiptItems = "Items: {0}";
        public const string ReceiptSubtotal = "Subtotal: {0:F2}";
        public const string ReceiptPricing = "Pricing: {0}";
        public const string ReceiptTotal = "Total: {0:F2}";

        public const string SessionAnalyticsHeader = "\n=== Session analytics ===";
        public const string TotalOrders = "Total orders: ";
        public const string TotalRevenue = "Total revenue: {0:F2}";
        public const string PressAnyKeyToExit = "\nPress any key to exit...";

        public const string AnalyticsSending = "[Analytics:{0}] Sending OrderPlaced...";
        public const string AnalyticsSuccess = "[Analytics:{0}] Success";
        public const string AnalyticsFailed =  "[Analytics:{0}] Failed ({1})";
    }


}
