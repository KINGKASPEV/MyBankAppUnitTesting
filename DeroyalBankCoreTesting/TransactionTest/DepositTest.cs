using DeroyalBank.Core;
using Xunit;
using System.Collections.Generic;
using DeroyalBank.Model;
using System.Numerics;
using System.Xml.Linq;

namespace DeroyalBankTesting.TransactionTest
{
    

    public class TransactionTest
    {
   
        [Fact]
        public void Deposit_WithValidAccount_DepositsAmount()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>
            {
                { accountNumber, new Customer( "fname",  "lname", "phone",  "email",  AccountType.Savings, "password",  accountNumber,  initialBalance: 0.0) }
        };
            var transactions = new Transactions(customerList, accountNumber);
            double initialBalance = customerList[accountNumber].balance;

            // Act
            var depositAmount = 100.0;
            var result = transactions.Deposit(depositAmount);
            double finalBalance = customerList[accountNumber].balance;

            // Assert
            Assert.True(result); // Deposit should succeed
            Assert.Equal(initialBalance + depositAmount, finalBalance, precision: 2); // Balance should be updated correctly

        }

        [Fact]
        public void Deposit_WithInvalidAccount_ReturnsFalse()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>();
            var transactions = new Transactions(customerList, accountNumber);

            // Act
            var depositAmount = 100.0;
            var result = transactions.Deposit(depositAmount);

            // Assert
            Assert.False(result); // Deposit should fail
        }

        [Fact]
        public void Deposit_WithNegativeAmount_ReturnsFalse()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>
        {
            { accountNumber, new Customer("fname",  "lname", "phone",  "email",  AccountType.Savings, "password",  accountNumber,  initialBalance: 0.0) }
        };
            var transactions = new Transactions(customerList, accountNumber);

            // Act
            var depositAmount = -50.0;
            var result = transactions.Deposit(depositAmount);

            // Assert
            Assert.False(result); // Deposit should fail
        }
    }

}

