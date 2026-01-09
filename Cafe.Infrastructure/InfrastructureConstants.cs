
namespace Cafe.Infrastructure
{
    public class InfrastructureConstants
    {
        public const string RemoteAnalyticsApiFailed = "Remote analytics API failed (simulated).";
        public const string NullBeverageKey = "Beverage key must be provided.";

        public const string Espresso = "espresso";
        public const string Tea = "tea";
        public const string HotChocolate = "hot chocolate";

        public const string BeverageTypeNotRecognized = "Beverage type {0} is not recognized.";

        public const string OrderLogTemplate =
            "[Order LOG] {0} @ {1:o} |" +
            " Items: {2} |" +
            " Subtotal: {3:F2}, Total: {4:F2}";

    }
}
