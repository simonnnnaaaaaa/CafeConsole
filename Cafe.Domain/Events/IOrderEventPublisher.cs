
namespace Cafe.Domain.Events
{
    public interface IOrderEventPublisher
    {
        void PublishOrderPlaced(OrderPlaced orderPlaced);
    }
}
