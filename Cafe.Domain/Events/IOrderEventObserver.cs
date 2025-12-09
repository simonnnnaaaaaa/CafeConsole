
namespace Cafe.Domain.Events
{
    public interface IOrderEventObserver
    {
        void OnOrderPlaced(OrderPlaced orderPlaced); 
    }
}
