using DeroyalBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.LoggedTests
{
    public class LoggedTest
    {
        [Fact]
        public void SetAndGetLoggedAccount()
        {
            // Arrange
            string accountNumber = "123456";

            // Act
            Logged.loggedAccount = accountNumber;
            string retrievedAccountNumber = Logged.loggedAccount;

            // Assert
            Assert.Equal(accountNumber, retrievedAccountNumber);
        }
    }

}
