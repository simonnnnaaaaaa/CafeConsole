using Cafe.Domain.Events;
using Cafe.Infrastructure.Analytics;

namespace CafeConsole;

public sealed class LoggingAnalyticsClient : IAnalyticsClient
{
    private readonly IAnalyticsClient _inner;
    private readonly string _name;

    public LoggingAnalyticsClient(IAnalyticsClient inner, string name)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void Track(OrderPlaced orderPlaced)
    {
        Console.WriteLine($"[Analytics:{_name}] Sending OrderPlaced...");

        try
        {
            _inner.Track(orderPlaced);
            Console.WriteLine($"[Analytics:{_name}] Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Analytics:{_name}] Failed ({ex.GetType().Name})");
            throw;
        }
    }
}
