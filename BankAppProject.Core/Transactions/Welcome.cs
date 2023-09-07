using System;
using DeroyalBank.Core;
using DeroyalBank.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace DeroyalBank.Core
{
    public class Welcome
    {
        public static void WelcomeCustomer()
        {
            while (true)
            {

                Console.WriteLine("****************************************************");
                Console.WriteLine("         WELCOME TO DEROYALS BANK               ");
                Console.WriteLine("****************************************************");
                Console.WriteLine("We're here to help you manage your finances.");
                Console.WriteLine("Choose an option from the menu below:");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------------------------------");

                string input = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        CreateAccount.CreateCustomerAccount();
                        break;
                    case "2":
                        Login.LoginUser();
                        HandleLoggedInUser();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using our banking system. Have a great day!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void HandleLoggedInUser()
        {
            if (Logged.loggedAccount != null)
            {
                Transactions transactions = new Transactions(ListOfCustomers.customerList, Logged.loggedAccount);
                while (true)
                {

                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Welcome, " + ListOfCustomers.customerList[Logged.loggedAccount].GetFirstname());
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Transfer");
                    Console.WriteLine("4. Check Balance");
                    Console.WriteLine("5. Print Account Statement");
                    Console.WriteLine("6. Create Another Account");
                    Console.WriteLine("7. Logout");
                    Console.WriteLine("----------------------------------------------------");

                    string input = Console.ReadLine();
                    Console.WriteLine();

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Enter the amount you want to deposit:");
                            if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
                            {
                                transactions.Deposit(depositAmount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please enter a valid amount.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Enter the amount you want to withdraw:");
                            if (double.TryParse(Console.ReadLine(), out double withdrawAmount) && withdrawAmount > 0)
                            {
                                transactions.Withdraw(withdrawAmount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please enter a valid amount.");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Enter the amount you want to transfer:");
                            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                            {
                                Console.WriteLine("Enter recipient's account number: ");
                                string recipientAccountNumber = Console.ReadLine();
                                transactions.Transfer(recipientAccountNumber, amount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please enter a valid amount.");
                            }
                            break;
                        case "4":
                            transactions.CheckBalance();
                            break;
                        case "5":
                            transactions.GetStatementOfAccount();
                            break;
                        case "6":
                            CreateAccount.CreateCustomerAccount();
                            break;
                        case "7":
                            transactions.Logout();
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }

                    Console.WriteLine();
                }
            }

            else
            {
                Console.WriteLine("You are not logged in.");
            }
           
        }
    }
}
