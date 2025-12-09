
namespace Cafe.Domain.Events
{
    public sealed record OrderPlaced(
        Guid OrderId,
        DateTimeOffset At,
        string Description,
        decimal Subtotal,
        decimal Total
    );   ///MAI VEZI DESPRE RECORDS


}
