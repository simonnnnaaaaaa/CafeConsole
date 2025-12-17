using Cafe.Domain.Beverages;
using Cafe.Infrastructure.Factories;

namespace Cafe.Tests
{
    public class BeverageFactoryTests
    {
        [Fact]
        public void Test_BeverageFactory_CreatesEspresso()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act
            IBeverage beverage = factory.Create(TestConstants.Espresso);

            // Assert
            Assert.IsType<Espresso>(beverage);
        }

        [Fact]
        public void Test_BeverageFactory_CreatesTea()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act
            IBeverage beverage = factory.Create(TestConstants.Tea);
            
            // Assert
            Assert.IsType<Tea>(beverage);
        }

        [Fact]
        public void Test_BeverageFactory_CreatesHotChocolate()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act
            IBeverage beverage = factory.Create(TestConstants.HotChocolate);

            // Assert
            Assert.IsType<HotChocolate>(beverage);
        }

        [Fact]
        public void Create_InvalidBeverageType_ThrowsException()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => factory.Create(TestConstants.UnknownBeverage));
        }
    }
}
