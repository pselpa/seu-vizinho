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
        [InlineData("F")]
        public void Should_return_false_when_name_is_invalid(string name)
        {
            var product = new Product(name, "Chave de fenda n° 2", "", "", "", "", "", 0, 0, 0, 0, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_return_false_when_description_is_invalid(string description)
        {
            var product = new Product("chave de fenda", description, "", "", "", "", "", 0, 0, 0, 0, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(null, null, null, null, null, 0, 0, 0, 0, 0)]
        [InlineData("", "", "", "", "", 0, 0, 0, 0, 0)]
        public void Should_return_true_when_nonobligatory_items_are_null_empty_or_zero(string accessories, string brand, string model, string voltage, string frequency, double pricePerHour, double pricePerDayByWeek, double pricePerDayByBiweekly, double pricePerDayByMonth, int rentingPeriodLimit)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", accessories, brand, model, voltage, frequency, pricePerHour, 0, pricePerDayByWeek, pricePerDayByBiweekly, pricePerDayByMonth, rentingPeriodLimit);

            var productIsValid = product.Validate().isValid;

            Assert.True(productIsValid);
        }
    }
}
