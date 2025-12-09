
using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;

namespace Cafe.Infrastructure.Factories
{
    public class BeverageFactory : IBeverageFactory
    {
        public IBeverage Create(string beverageType)
        {
            if (string.IsNullOrWhiteSpace(beverageType))
            {
                throw new ArgumentException("Beverage key must be provided.", nameof(beverageType));
            }

            return beverageType.ToLower() switch
            {
                "espresso" => new Espresso(),
                "tea" => new Tea(),
                "hot chocolate" => new HotChocolate(),
                _ => throw new ArgumentException($"Beverage type '{beverageType}' is not recognized.")
            };
        }
    }
}
