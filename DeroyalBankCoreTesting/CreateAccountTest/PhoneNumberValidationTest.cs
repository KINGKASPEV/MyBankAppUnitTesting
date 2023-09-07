using DeroyalBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.CreateAccountTest
{
    public class phonenumbervalidationtest
    {

        [Theory]
        [InlineData("12345678901", true)]
        [InlineData("123-456-7890", false)] // hyphens are not allowed
        [InlineData("1234", false)]         // phone number must have exactly 11 digits
        [InlineData("abcdefghijk", false)]  // non-digit characters are not allowed
        [InlineData("1234567890a", false)]  // non-digit characters are not allowed
        [InlineData("123456789012", false)] // phone number must have exactly 11 digits
        public void isvalidphonenumber_validatesphonenumber(string phonenumber, bool expectedisvalid)
        {
            // arrange

            // act
            bool isvalid = CreateAccount.IsValidPhoneNumber(phonenumber);

            // assert
            Assert.Equal(expectedisvalid, isvalid);
        }

    }
}
