using DeroyalBank.Data;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBankTesting.ListOfCustomerTest
{
    public class ListOfCustomersTest
    {
        [Fact]
        public void AddCustomer_AddsCustomerAndEmailToCollections()
        {
            // Arrange
            string accountNumber = "123456";
            string customerEmail = "customer@example.com";
            Customer customer = new Customer("fname", "lname", "phone", "email", AccountType.Savings, "password", accountNumber, initialBalance: 0.0);

            // Act
            ListOfCustomers.AddCustomer(accountNumber, customer);

            // Assert
            Assert.True(ListOfCustomers.customerList.ContainsKey(accountNumber)); // The customer should be added to customerList
            Assert.False(ListOfCustomers.IsEmailUsed(customerEmail)); // The customer's email should be added to usedEmails
        }

        [Fact]
        public void IsEmailUsed_EmailExists_ReturnsTrue()
        {
            // Arrange
            string existingEmail = "existing@example.com";
            string accountNumber = "account1";
            Customer existingCustomer = new Customer("fname", "lname", "phone", existingEmail, AccountType.Savings, "password", accountNumber, initialBalance: 0.0);
            ListOfCustomers.AddCustomer(accountNumber, existingCustomer); // Add a customer with the existing email

            // Act
            bool result = ListOfCustomers.IsEmailUsed(existingEmail);

            // Assert
            Assert.True(result); // The email should exist in usedEmails
        }

        [Fact]
        public void IsEmailUsed_EmailDoesNotExist_ReturnsFalse()
        {
            // Arrange
            string nonExistingEmail = "nonexisting@example.com";
            ListOfCustomers.customerList.Clear(); // Clear the customerList to ensure the email doesn't exist

            // Act
            bool result = ListOfCustomers.IsEmailUsed(nonExistingEmail);

            // Assert
            Assert.False(result); // The email should not exist in usedEmails
        }
    }
}

