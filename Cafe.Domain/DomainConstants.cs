namespace Cafe.Domain
{
    public class DomainConstants
    {
        public const decimal MemberDiscountRate = 0.9m;
        public const decimal HappyHourDiscountRate = 0.8m;
        public const decimal TeaCost = 2.00m;
        public const decimal SyrupCost = 0.50m;
        public const decimal MilkCost = 0.40m;
        public const decimal HotChocolateCost = 3.00m;
        public const decimal ExtraShotCost = 0.80m;
        public const decimal EspressoCost = 2.50m;


        public const string Espresso = "Espresso";
        public const string ExtraShot = "{0}, extra Shot";
        public const string HotChocolate = "Hot Chocolate";
        public const string Milk = "{0}, milk";
        public const string Syrup = "{0}, {1} syrup";
        public const string Tea = "Tea";

        public const string DiscountOutOfRangeMessage = "Discount rate must be between 0 and 1 (exclusive).";
    }
}
