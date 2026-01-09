namespace CafeConsole.States
{
    internal class IdleState : IKioskState
    {
        public void Handle(KioskContext context)
        {
            Console.Clear();
            Console.WriteLine(StateConstants.CafeConsoleHeader);
            Console.WriteLine(StateConstants.NewOreder1);
            Console.WriteLine(StateConstants.Exit0);
            Console.Write(StateConstants.YourChoice);

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
                    Console.WriteLine(StateConstants.InvalidOption);
                    Thread.Sleep(1000);
                    break;
            }
        }

      
    }
}