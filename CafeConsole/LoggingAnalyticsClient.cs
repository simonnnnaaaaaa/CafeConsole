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
        Console.WriteLine(ConsoleUiConstants.AnalyticsSending, _name);

        try
        {
            _inner.Track(orderPlaced);
            Console.WriteLine( ConsoleUiConstants.AnalyticsSuccess, _name);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ConsoleUiConstants.AnalyticsFailed, _name, ex.GetType().Name);
            throw;
        }
    }
}
