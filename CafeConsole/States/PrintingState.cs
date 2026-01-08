namespace CafeConsole.States
{
    internal class PrintingState : IKioskState
    {
        public void Handle(KioskContext context)
        {
            //place the order
            var resultOrder = context.OrderService.PlaceOrder(
                context.Beverage!,
                context.PricingStrategy!
            );

            context.OrderResult = resultOrder;

            Console.WriteLine(StateConstants.ReceiptHeader);
            MenuHelper.PrintReceipt(resultOrder);
            Console.WriteLine(StateConstants.ReceiptFooter);
            Console.WriteLine(StateConstants.PressAnyKeyToReturnToMenu);
            Console.ReadKey();

            context.State = new IdleState();
        }
    }
}