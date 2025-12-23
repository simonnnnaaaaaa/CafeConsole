using Cafe.Application.Orders;
using Cafe.Domain.Beverages;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Observers;

namespace CafeConsole.States
{
    public class KioskContext
    {
        public IKioskState State { get; set; }

        public IBeverage Beverage { get; set; }
        public IPricingStrategy PricingStrategy { get; set; }
        public OrderReceiptDto OrderResult { get; set; }

        public IOrderService OrderService { get; }

        public InMemoryOrderAnalytics Analytics { get; }

        public KioskContext(IOrderService orderService, InMemoryOrderAnalytics analytics)
        {
            OrderService = orderService;
            Analytics = analytics;
            State = new IdleState();
        }

        public void Run()
        {
            State.Handle(this);
        }
    }
}