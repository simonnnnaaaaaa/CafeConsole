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
                throw new ArgumentException(InfrastructureConstants.NullBeverageKey, nameof(beverageType));
            }

            return beverageType.ToLower() switch
            {
                InfrastructureConstants.Espresso => new Espresso(),
                InfrastructureConstants.Tea => new Tea(),
                InfrastructureConstants.HotChocolate => new HotChocolate(),
                _ => throw new ArgumentException(string.Format(InfrastructureConstants.BeverageTypeNotRecognized, beverageType))
            };
        }
    }
}
