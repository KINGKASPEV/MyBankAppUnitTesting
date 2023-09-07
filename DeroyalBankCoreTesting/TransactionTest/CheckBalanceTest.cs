using DeroyalBank.Core;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.TransactionTest
{
    public class CheckBalanceTest
    {
        [Fact]
        public void GetCustomerBalance_WithValidAccount_ReturnsBalance()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>
        {
            { accountNumber, new Customer("fname", "lname", "phone", "email", AccountType.Savings, "password", accountNumber, initialBalance: 1500.0) }
        };
            var customerManager = new Transactions(customerList, accountNumber);

            // Act
            var balance = customerManager.GetCustomerBalance();

            // Assert
            Assert.Equal(1500.0, balance); // Balance should match the initial balance
        }

        [Fact]
        public void GetCustomerBalance_WithInvalidAccount_ThrowsException()
        {
            // Arrange
            var accountNumber = "123456";
            var customerList = new Dictionary<string, Customer>();
            var customerManager = new Transactions(customerList, accountNumber);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => customerManager.GetCustomerBalance());
        }
    }
}
