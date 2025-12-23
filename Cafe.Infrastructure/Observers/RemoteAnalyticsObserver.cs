using Cafe.Domain.Events;
using Cafe.Infrastructure.Analytics;

namespace Cafe.Infrastructure.Observers;

public sealed class RemoteAnalyticsObserver : IOrderEventObserver
{
    //NU face analytics, ci doar: „trimite evenimentul catre un analytics client”
    //conecteaza proxy ul la sistemul de events (Observer)

    private readonly IAnalyticsClient _analyticsClient;

    public RemoteAnalyticsObserver(IAnalyticsClient analyticsClient)
    {
        _analyticsClient = analyticsClient ?? throw new ArgumentNullException(nameof(analyticsClient));
    }

    public void OnOrderPlaced(OrderPlaced orderPlaced)
    {
        if (orderPlaced is null)
            throw new ArgumentNullException(nameof(orderPlaced));

        _analyticsClient.Track(orderPlaced);
    }
}
