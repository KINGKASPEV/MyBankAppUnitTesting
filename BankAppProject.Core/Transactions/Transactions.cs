using DeroyalBank.Data;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBank.Core
{
    public class Transactions
    {
        //string accountNumber = Logged.loggedAccount;
        private Dictionary<string, Customer> customerList = ListOfCustomers.customerList;
        private string note;
        private string accountNumber;

        public Transactions(Dictionary<string, Customer> customerList, string accountNumber)
        {
            this.customerList = customerList;
            this.accountNumber = accountNumber;
        }

        public bool Deposit(double amount)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                Console.WriteLine("Please login first");
                return false;
            }
            if (amount <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a valid amount greater than zero.");
                return false;
            }

            if (customerList.TryGetValue(accountNumber, out Customer customer))
            {
                customer.Deposit(amount);
                Console.WriteLine("Deposit Successfully.");
                return true;
            }

            return false;
        }
        public bool Withdraw(double withdrawAmount)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                Console.WriteLine("Please login first");
                return false;
            }

            if (accountNumber != Logged.loggedAccount)
            {
                Console.WriteLine("You are not logged into this account.");
                return false;
            }

            if (customerList.TryGetValue(accountNumber, out Customer customer))
            {
                if (customer.GetAccountType() == AccountType.Savings)
                {
                    if (customer.balance - withdrawAmount < 1000)
                    {
                        Console.WriteLine("Insufficient balance. You cannot withdraw below 1000 Naira for a Savings account.");
                        return false;
                    }
                }

                customer.Withdraw(withdrawAmount);
                Console.WriteLine("Withdrawal Successful.\nThank you for Banking with us!");
                return true;
            }

            return false;
        }
        public bool Transfer(string recipientAccountNumber, double amount)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                Console.WriteLine("Please login first");
                return false;
            }

            if (!customerList.TryGetValue(accountNumber, out Customer senderCustomer))
            {
                Console.WriteLine("Sender's account not found.");
                return false;
            }

            if (!customerList.TryGetValue(recipientAccountNumber, out Customer recipientCustomer))
            {
                Console.WriteLine("Recipient's account not found.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount.");
                return false;
            }

            if (senderCustomer.balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return false;
            }

            senderCustomer.Withdraw(amount);
            recipientCustomer.Deposit(amount);
            Console.WriteLine("Transfer Successful.\nThank you for banking with us!");
            return true;
        }
        public void CheckBalance()
        {
            if (accountNumber == "" || accountNumber == null)
            {
                Console.WriteLine("Please login first");
                Login.LoginUser();
            }
            else
            {
                foreach (var item in customerList)
                {
                    if (item.Key == accountNumber)
                    {
                        Customer customer = item.Value;
                        Console.WriteLine($"Your balance is: #{customer.balance.ToString("N2")}");
                        break;
                    }
                }
            }
        }
        public void GetStatementOfAccount()
        {
            if (accountNumber == "" || accountNumber == null)
            {
                Console.WriteLine("Please login first");
                Login.LoginUser();
            }
            else
            {
                Console.WriteLine("||===================||===============================||==========================||=====================||==========||");
                Console.WriteLine("|| FULL NAME         || ACCOUNT NUMBER                || ACCOUNT TYPE             || AMOUNT BAL(#)       || NOTE     ||");
                Console.WriteLine("||===================||===============================||==========================||=====================||==========||");

                foreach (var item in customerList)
                {
                    if (item.Key == accountNumber)
                    {
                        Customer customer = item.Value;
                        Console.WriteLine($"|| {customer.GetFirstname()} {customer.GetLastname(),-13} || {customer.GetAccountNumber(),-29} || {customer.GetAccountType(),-24} || {customer.balance.ToString("N2"),-19} || {GetNote(),-8} ||");
                        Console.WriteLine("||===================================================================================================================||");
                        break;
                    }
                }
            }
        }

        public string GetNote()
        {
            return note;
        }
        public void Logout()
        {
            if (accountNumber == "" || accountNumber == null)
            {
                Console.WriteLine("You are not logged in.");
            }
            else
            {
                accountNumber = "";
                Console.WriteLine("Logged out successfully.");
            }
        }
        public static string GenerateNewAccountNumber()
        {
            Random random = new Random();
            return GenerateRandomNumber(random, 10).ToString("D10");
        }

        static long GenerateRandomNumber(Random random, int digits)
        {
            long min = (long)Math.Pow(10, digits - 1);
            long max = (long)Math.Pow(10, digits) - 1;

            return random.Next((int)min, (int)max);
        }
        public double GetCustomerBalance()
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new InvalidOperationException("Please login first");
            }

            if (customerList.TryGetValue(accountNumber, out Customer customer))
            {
                return customer.balance;
            }

            throw new InvalidOperationException("Customer not found");
        }
    }
}