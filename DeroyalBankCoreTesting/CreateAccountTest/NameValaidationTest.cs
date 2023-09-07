using DeroyalBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.CreateAccountTest
{

    public class NameValidationTests
    {
        [Theory]
        [InlineData("John", true)]
        [InlineData("Mary-Ann", false)] // Hyphens are not allowed
        [InlineData("123Name", false)]  // Names cannot start with a digit
        [InlineData("Jane Doe", false)] // Spaces are not allowed
        [InlineData("joe", false)]      // Names must start with an uppercase letter
        [InlineData("A", true)]         // Single uppercase letter is valid
        public void IsValidName_ValidatesName(string name, bool expectedIsValid)
        {
            //Arrange
            //var instantEmail = new CreateAccount();
            // Act
            bool isValid = CreateAccount.IsValidName(name);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }

    }

}
