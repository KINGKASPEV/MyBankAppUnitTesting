using DeroyalBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.CreateAccountTest
{


    public class PasswordValidationTests
    {
        [Theory]
        [InlineData("P@ssw0", true)]      // Valid password with 6 characters
        [InlineData("P@sswo", true)]     // Password too short (less than 6 characters)
        [InlineData("Password1", false)]  // Missing special character
        [InlineData("P@ssword", true)]   // Missing a digit
        [InlineData("12345678@", true)]  // Missing letters
        [InlineData("Special!char$", true)] // Missing digits
        [InlineData("P@ssw0rd!", true)]    // Valid password with special characters
        public void IsValidPassword_ValidatesPassword(string password, bool expectedIsValid)
        {
            //var validationInstance = new CreateCustomerAccount(); // Replace with the actual class name
            bool isValid = CreateAccount.IsValidPassword(password);
            // Act
            //bool isValid = IsValidPassword(password);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }
    }

}