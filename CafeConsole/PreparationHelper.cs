using Cafe.Domain.Beverages;
using Cafe.Domain.Preparation;

namespace CafeConsole
{
    public class PreparationHelper
    {
        public static void SimulatePreparation(IBeverage beverage)
        {
            var preparation = BeveragePreparationFactory.Create(beverage);

            if (preparation is null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Preparing your beverage...");
            Thread.Sleep(400);

            foreach (var step in preparation.Prepare(beverage))
            {
                Console.WriteLine(step);
                Thread.Sleep(400);
            }

            Console.WriteLine("Base beverage preparation finished!");
            Thread.Sleep(400);
            Console.WriteLine();
        }
    }
}
