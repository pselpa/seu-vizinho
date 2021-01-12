using Xunit;
using Domain.Products;
using System;

namespace Tests
{
    public class ProductTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_return_false_when_name_is_invalid(string name)
        {
            var product = new Product(name, "Chave de fenda n° 2", "", "", "voltage", "frequency", 5, 50);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_return_false_when_description_is_invalid(string description)
        {
            var product = new Product("chave de fenda", description, "", "", "voltage", "frequency", 5, 50);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_return_false_when_voltage_is_invalid(string voltage)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", voltage, "frequency", 5, 50);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_return_false_when_frequency_is_invalid(string frequency)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "voltage", frequency, 5, 50);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public void Should_return_false_when_quantity_is_invalid(int quantity)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "voltage", "0", quantity, 50);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(null, null, 0)]
        [InlineData("", "", 0)]
        public void Should_return_true_when_nonobligatory_items_are_null_empty_or_zero(string brand, string model, int rentingPeriodLimit)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", brand, model, "voltage", "frequency", 5, rentingPeriodLimit);

            var productIsValid = product.Validate().isValid;

            Assert.True(productIsValid);
        
        }
    }
}
