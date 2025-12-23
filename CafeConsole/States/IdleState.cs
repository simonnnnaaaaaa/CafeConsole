using Cafe.Infrastructure.Observers;

namespace CafeConsole.States
{
    internal class IdleState : IKioskState
    {
        public void Handle(KioskContext context)
        {
            Console.Clear();
            Console.WriteLine("=== Cafe Console ===");
            Console.WriteLine("1) New order");
            Console.WriteLine("0) Exit");
            Console.Write("Your choice: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    context.State = new BuildingOrderState();
                    break;

                case "0":
                    MenuHelper.PrintAnalytics(context.Analytics);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Thread.Sleep(1000);
                    break;
            }
        }

      
    }
}