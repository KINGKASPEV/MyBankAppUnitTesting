using DeroyalBank.Core;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DeroyalBankTesting.TransactionTest
{
    public class TransactionTests
    {
        [Fact]
        public void Transfer_Successful()
        {
            // Arrange
            var accountNumber = "123456";
            var recipientAccountNumber = "789012";
            var customerList = new Dictionary<string, Customer>
        {
            { accountNumber, new Customer("fname", "lname", "phone", "email", AccountType.Savings, "password", accountNumber, initialBalance: 1500.0) },
            { recipientAccountNumber, new Customer("recipient_fname", "recipient_lname", "recipient_phone", "recipient_email", AccountType.Savings, "recipient_password", recipientAccountNumber, initialBalance: 500.0) }
        };
            var transferManager = new Transactions(customerList, accountNumber);

            // Act
            var transferAmount = 500.0;
            var result = transferManager.Transfer(recipientAccountNumber, transferAmount);

            // Assert
            Assert.True(result); // Transfer should succeed
            Assert.Equal(1000.0, customerList[accountNumber].balance); // Sender's balance should be updated
            Assert.Equal(1000.0, customerList[recipientAccountNumber].balance); // Recipient's balance should be updated


        }
    }
}
