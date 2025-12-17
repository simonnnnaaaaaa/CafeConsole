using Cafe.Domain.Beverages;

namespace Cafe.Tests
{
    public class BeverageDecoratorTests
    {
        [Fact]
        public void Test_BeverageDecorator()
        {
            // Arrange
            IBeverage beverage = new Espresso();

            beverage = new MilkDecorator(beverage);
            beverage = new ExtraShotDecorator(beverage);

            // Act
            var cost = beverage.Cost();
            var description = beverage.Describe();

            // Assert
            Assert.Equal(3.70m, cost); 
            Assert.Contains(TestConstants.Milk, description, StringComparison.OrdinalIgnoreCase);
            Assert.Contains(TestConstants.ExtraShot, description, StringComparison.OrdinalIgnoreCase);
        }
    }
}
