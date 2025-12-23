using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Analytics
{
    //intermediarul
    public sealed class AnalyticsClientProxy : IAnalyticsClient
    {
        private readonly IAnalyticsClient _inner; //remote ul
        private readonly IAnalyticsClient _fallback; //planul B

        private readonly int _maxRetries;
        private readonly int _baseDelayMs;

        public AnalyticsClientProxy(
            IAnalyticsClient inner,
            IAnalyticsClient fallback,
            int maxRetries = 3,
            int baseDelayMs = 150)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _fallback = fallback ?? throw new ArgumentNullException(nameof(fallback));

            if (maxRetries < 0) throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (baseDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(baseDelayMs));

            _maxRetries = maxRetries;
            _baseDelayMs = baseDelayMs;
        }

        public void Track(OrderPlaced orderPlaced)
        {
            if (orderPlaced is null)
                throw new ArgumentNullException(nameof(orderPlaced));

            for (int attempt = 1; attempt <= _maxRetries + 1; attempt++)
            {
                try
                {
                    _inner.Track(orderPlaced);
                    return; //succes
                }
                catch
                {
                    // last attempt failed -> fallback
                    if (attempt == _maxRetries + 1)
                    {
                        _fallback.Track(orderPlaced);
                        return;
                    }

                    // simple exponential-ish backoff: 150ms, 300ms, 450ms...
                    Thread.Sleep(_baseDelayMs * attempt);
                }
            }
        }
    }
}