using Cafe.Domain.Factories;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Factories;

namespace CafeConsole.States
{
    internal class BuildingOrderState : IKioskState
    {
        public void Handle(KioskContext context)
        {
            //factory
            IBeverageFactory beverageFactory = new BeverageFactory();

            var beverage = MenuHelper.ChooseBaseBeverage(beverageFactory);
            beverage = MenuHelper.ChooseAddOns(beverage);

            //template
            PreparationHelper.SimulatePreparation(beverage);

            //strategy
            IPricingStrategy pricingStrategy = MenuHelper.ChoosePricingStrategy();

            context.Beverage = beverage;
            context.PricingStrategy = pricingStrategy;

            context.State = new PrintingState();
        }
    }
}