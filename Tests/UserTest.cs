using Xunit;
using Domain.Users;
using System;

namespace Tests
{
    public class UserTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1234")]
        [InlineData(" Rafael")]
        [InlineData("Rafael ")]
        [InlineData("Rafael  ")]
        [InlineData("Rafael I")]
        [InlineData("Rafael 0")]
        [InlineData("Rafael --")]
        [InlineData("R4fael Rodrigues")]
        [InlineData("Rafael Rodrigues Fernande$")]
        [InlineData("Raf@el Rodrigues")]
        public void Should_return_false_when_name_is_invalid(string name)
        {
            var user = new User(name, "084.538.989-01","fulano@gmail.com", UserProfile.Admin, "password");

            var userIsValid = user.Validate().isValid;

            Assert.False(userIsValid);
        }

        [Theory]
        [InlineData("Maria Pereira")]
        [InlineData("Fernando Fernandes da Silva")]
        [InlineData("Ana Sá")]
        [InlineData("Frederico Pereira Guimarães da Cunha Mourão Albuquerque")]
        public void Should_return_true_when_name_is_valid(string name)
        {
            // Dado / Setup            
            var user = new User(name, "493.107.310-79","fulano@gmail.com", UserProfile.Admin, "password");

            // When / Ação
            var userIsValid = user.Validate().isValid;

            // Deve / Asserções
            Assert.True(userIsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("000.000.000-00")]
        [InlineData("000.000.000-01")]
        [InlineData("100.000.000-00")]
        [InlineData("999.999.999-99")]
        [InlineData("000.368.560-00")]
        [InlineData("640.3685606")]
        [InlineData("640.368.560-6")]
        [InlineData("640.368.560-6a")]
        [InlineData("640.368.560-061")]
        public void Should_return_false_when_CPF_is_invalid(string cpf)
        {
            // Dado / Setup
            var user = new User("Maria Pereira", cpf, "fulano@gmail.com", UserProfile.Admin, "password");

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("493.107.310-79")]
        [InlineData("700.651.710-98")]
        [InlineData("104.632.250-82")]
        [InlineData("830.374.420-85")]
        [InlineData("110.792.660-20")]
        public void Should_return_true_when_CPF_is_valid(string cpf)
        {
            // Dado / Setup
            var user = new User("Maria Pereira", cpf, "maria@gmail.com", UserProfile.Client, "password");

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("maria")]
        [InlineData("maria.pereira")]
        [InlineData("maria.pereira@")]
        [InlineData("maria.pereiracom")]
        [InlineData("maria.pereira.com")]
        [InlineData("maria.pereira@.com")]
        [InlineData("maria.pereira@com")]
        public void Should_return_false_when_email_is_invalid(string email)
        {
            // Dado / Setup
            var user = new User("Maria Pereira", "493.107.310-79", email, UserProfile.Client, "password");

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("maria@gmail.com")]
        [InlineData("maria.pereira@gmail.com")]
        [InlineData("maria_123@hotmail.com")]
        [InlineData("mariapereira@yahoo.com")]
        [InlineData("pereira.maria@terra.com.br")]
        public void Should_return_true_when_email_is_valid(string email)
        {
            // Dado / Setup
            var user = new User("Maria Pereira", "493.107.310-79", email, UserProfile.Client, "password");

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.True(isValid);
        }
    }
}
