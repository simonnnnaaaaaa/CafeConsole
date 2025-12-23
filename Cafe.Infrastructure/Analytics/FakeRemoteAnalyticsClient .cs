using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Analytics
{
    public sealed class FakeRemoteAnalyticsClient : IAnalyticsClient
    {
        //in realitate ar face HTTP request, aici doar simulam o instabilitate

        private readonly Random _random = new();
        private readonly double _failureRate;

        public FakeRemoteAnalyticsClient(double failureRate = 0.30)
        {
            if (failureRate < 0 || failureRate > 1)
                throw new ArgumentOutOfRangeException(nameof(failureRate));

            _failureRate = failureRate;
        }

        public void Track(OrderPlaced orderPlaced)
        {
            if (_random.NextDouble() < _failureRate)
            {
                throw new InvalidOperationException("Remote analytics API failed (simulated).");
            }
        }
    }
}
