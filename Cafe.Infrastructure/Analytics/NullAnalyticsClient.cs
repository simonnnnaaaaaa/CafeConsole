using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Analytics
{
    public sealed class NullAnalyticsClient : IAnalyticsClient
    {
        //plan B cand remote ul nu merge
        public void Track(OrderPlaced orderPlaced)
        {
            
            /* Analytics is a non-critical side effect.
            Null Object to ensure that failures 
            in the remote analytics service do not impact the core ordering flow.*/
        }
    }
}
