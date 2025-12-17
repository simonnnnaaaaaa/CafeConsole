using Cafe.Domain.Beverages;
using Cafe.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IBeverage beverage = factory.Create("Espresso");

            // Assert
            Assert.IsType<Espresso>(beverage);
        }

        [Fact]
        public void Test_BeverageFactory_CreatesTea()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act
            IBeverage beverage = factory.Create("Tea");
            
            // Assert
            Assert.IsType<Tea>(beverage);
        }

        [Fact]
        public void Test_BeverageFactory_CreatesHotChocolate()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act
            IBeverage beverage = factory.Create("Hot Chocolate");

            // Assert
            Assert.IsType<HotChocolate>(beverage);
        }

        [Fact]
        public void Create_InvalidBeverageType_ThrowsException()
        {
            // Arrange
            var factory = new BeverageFactory();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => factory.Create("unknown"));
        }
    }
}
