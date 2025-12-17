using Cafe.Domain.Events;
using Cafe.Infrastructure.Observers;

namespace Cafe.Tests
{
    public class InMemoryOrderAnalyticsTests
    {
        [Fact]
        public void Test_AccumulateOrderCountAndRevenue_OnOrderPlaced()
        {
            // Arrange
            var analytics = new InMemoryOrderAnalytics();

            var order1 = new OrderPlaced(
                Guid.NewGuid(),
                DateTimeOffset.UtcNow,
                TestConstants.Order1,
                Subtotal: 3.5m,
                Total: 3.5m);

            var order2 = new OrderPlaced(
                Guid.NewGuid(),
                DateTimeOffset.UtcNow,
                TestConstants.Order2,
                Subtotal: 2m,
                Total: 2m);

            // Act
            analytics.OnOrderPlaced(order1);
            analytics.OnOrderPlaced(order2);

            // Assert
            Assert.Equal(2, analytics.TotalOrders);
            Assert.Equal(5.5m, analytics.TotalRevenue);
        }
    }
}
