using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Analytics
{
    public interface IAnalyticsClient
    {
        void Track(OrderPlaced orderPlaced); 
    }
}
