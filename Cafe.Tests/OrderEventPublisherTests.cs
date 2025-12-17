
using Cafe.Application.Events;
using Cafe.Domain.Events;
using Moq;

namespace Cafe.Tests
{
    public class OrderEventPublisherTests
    {
        [Fact]
        public void Test_PublishOrderPlaced_EventReceivedByObserver()
        {
            // Arrange
            var observerMock = new Mock<IOrderEventObserver>();

            var observers = new List<IOrderEventObserver>
            {
                observerMock.Object
            };

            var publisher = new OrderEventPublisher(observers);

            var orderPlaced = new OrderPlaced(
                Guid.NewGuid(),
                DateTimeOffset.UtcNow,
                "Test Order",
                Subtotal: 10m,
                Total: 8m);

            // Act
            publisher.PublishOrderPlaced(orderPlaced);

            // Assert
            observerMock.Verify(o => o.OnOrderPlaced(orderPlaced), Times.Once);

        }
    }
}
