using DeroyalBank.Core;
using DeroyalBank.Data;
using DeroyalBank.Model;

namespace DeroyalBankTesting.LoginTest
{
    public class LoginTests
    {
        [Theory]
        [InlineData("1234567890", "P@ssword", true)]
        [InlineData("1234567890", "P@word", false)]
        [InlineData("0233467890", "P@ssword", false)]
        [InlineData("0234567890", "P@yggfg", false)]
        [InlineData("0234567890", "p@yggfg", false)]
        [InlineData("0234567890", "pkyggfg", false)]
        public void TestLoginUser_ValidCredentials_Success(string accountNos, string password, bool expected)
        {
            // Arrange
            Customer customer = new Customer("Ifeanyi", "Okeke", "08160417161", "ifeanyi@gmail.com", AccountType.Savings, "P@ssword", "1234567890");
            if (!ListOfCustomers.customerList.ContainsKey("1234567890"))
            {
                ListOfCustomers.AddCustomer("1234567890", customer);
            }

            // Act
            bool actual = Login.CheckLogin(accountNos, password);



            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
