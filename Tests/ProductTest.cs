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
        [InlineData(-5)]
        [InlineData(-20.50)]
        [InlineData(-200)]
        public void Should_return_false_when_pricePerHour_is_invalid(double pricePerHour)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", pricePerHour, 0, 0, 0, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(-20.50)]
        [InlineData(-200)]
        public void Should_return_false_when_pricePerDay_is_invalid(double pricePerDay)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", 0, pricePerDay, 0, 0, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-20.50)]
        [InlineData(-200)]
        public void Should_return_false_when_pricePerDayByWeek_is_invalid(double pricePerDayByWeek)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", 0, 0, pricePerDayByWeek, 0, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-20.50)]
        [InlineData(-200)]
        public void Should_return_false_when_pricePerDayByBiweekly_is_invalid(double pricePerDayByBiweekly)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", 0, 0, 0, pricePerDayByBiweekly, 0, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-20.50)]
        [InlineData(-200)]
        public void Should_return_false_when_pricePerDayByMonth_is_invalid(double pricePerDayByMonth)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", 0, 0, 0, 0, pricePerDayByMonth, 0);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-200)]
        public void Should_return_false_when_rentingPeriodLimit_is_invalid(int rentingPeriodLimit)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", 0, 0, 0, 0, 0, rentingPeriodLimit);

            var productIsValid = product.Validate().isValid;

            Assert.False(productIsValid);
        }

        [Theory]
        [InlineData(0, 10.50, 0, 0, 0, 0)] // ARRUMAR A VALIDAÇÃO PARA PREÇO POR DIA SER MAIOR QUE ZERO
        [InlineData(5.10, 30.50, 25.30, 21.35, 19.45, 30)]
        public void Should_return_true_when_values_are_zero_or_above(double pricePerHour, double pricePerDay, double pricePerDayByWeek, double pricePerDayByBiweekly, double pricePerDayByMonth, int rentingPeriodLimit)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", "", "", "", "", "", pricePerHour, pricePerDay, pricePerDayByWeek, pricePerDayByBiweekly, pricePerDayByMonth, rentingPeriodLimit);

            var productIsValid = product.Validate().isValid;

            Assert.True(productIsValid);
        }


        [Theory]
        [InlineData(null, null, null, null, null, 0, 0, 0, 0, 0)]
        [InlineData("", "", "", "", "", 0, 0, 0, 0, 0)]
        public void Should_return_true_when_nonobligatory_items_are_null_empty_or_zero(string accessories, string brand, string model, string voltage, string frequency, double pricePerHour, double pricePerDayByWeek, double pricePerDayByBiweekly, double pricePerDayByMonth, int rentingPeriodLimit)
        {
            var product = new Product("chave de fenda", "Chave de fenda n° 2", accessories, brand, model, voltage, frequency, pricePerHour, 5, pricePerDayByWeek, pricePerDayByBiweekly, pricePerDayByMonth, rentingPeriodLimit);

            var productIsValid = product.Validate().isValid;

            Assert.True(productIsValid);
        }
    }
}
