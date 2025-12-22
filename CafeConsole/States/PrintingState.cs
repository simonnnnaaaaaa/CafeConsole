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

            Console.WriteLine("=== Receipt ===");
            MenuHelper.PrintReceipt(resultOrder);
            Console.WriteLine("===============");

            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();

            context.State = new IdleState();
        }
    }
}