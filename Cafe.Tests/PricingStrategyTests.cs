
using Cafe.Domain.Pricing;

namespace Cafe.Tests
{
    public class PricingStrategyTests
    {
        [Fact]
        public void Test_RegularPricingStrategy()
        {
            // Arrange
            var strategy = new RegularPricing();
            var subtotal = 10m;

            // Act
            var result = strategy.ApplyPricing(subtotal); 
        
            //Assert
            Assert.Equal(10m, result);
        }

        [Fact]
        public void Test_HappyHourPricingStrategy()
        {
            // Arrange
            var strategy = new HappyHourPricing();
            var subtotal = 10m;
            // Act
            var result = strategy.ApplyPricing(subtotal); 
        
            //Assert
            Assert.Equal(8m, result); 
        }

    }
}
