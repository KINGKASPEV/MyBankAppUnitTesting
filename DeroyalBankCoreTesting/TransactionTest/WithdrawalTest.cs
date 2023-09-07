using DeroyalBank.Core;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.TransactionTest
{
    public class WithdrawalTest
    {
        [Fact]
        public void Withdraw_WithInsufficientBalance_Fails()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>
    {
        { accountNumber, new Customer("fname", "lname", "phone", "email", AccountType.Savings, "password", accountNumber, initialBalance: 800.0) }
    };
            var accountManager = new Transactions(customerList, accountNumber);

            // Act
            var withdrawAmount = 1000.0; // Trying to withdraw more than the allowed limit
            var result = accountManager.Withdraw(withdrawAmount);

            // Assert
            Assert.False(result); // Withdraw should fail due to insufficient balance
            Assert.Equal(800.0, customerList[accountNumber].balance); // Balance should remain the same
        }

        [Fact]
        public void Withdraw_FromInvalidAccount_Fails()
        {
            // Arrange
            var accountNumber = "123456";
            var invalidAccountNumber = "789012";
            var customerList = new Dictionary<string, Customer>
    {
        { accountNumber, new Customer("fname", "lname", "phone", "email", AccountType.Savings, "password", accountNumber, initialBalance: 1500.0) }
    };
            var accountManager = new Transactions(customerList, invalidAccountNumber);

            // Act
            var withdrawAmount = 500.0;
            var result = accountManager.Withdraw(withdrawAmount);

            // Assert
            Assert.False(result); // Withdraw should fail due to invalid account
            Assert.Equal(1500.0, customerList[accountNumber].balance); // Balance of the valid account should remain the same
        }

    }
}
