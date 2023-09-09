using System;
using System.Text.RegularExpressions;
using DeroyalBank.Data;
using DeroyalBank.Model;

namespace DeroyalBank.Core
{
    public class CreateAccount
    {
        public static void CreateCustomerAccount()
        {

            string firstname = GetValidName("Enter your Firstname: ");
            string lastname = GetValidName("Enter your Lastname: ");
            Console.Clear();

            string phoneNumber = GetValidPhoneNumber();
            Console.Clear();

            string email = GetValidEmail();
            Console.Clear();

            string password = GetValidPassword();
            Console.Clear();

            Console.WriteLine("What type of account do you want?\nPress S for Savings and C for Current: ");
            string acctype = Console.ReadLine()?.Trim().ToUpper();
            Console.Clear();

            AccountType accountType;

                switch (acctype)
                {
                    case "S":
                        accountType = AccountType.Savings;
                        break;
                    case "C":
                        accountType = AccountType.Current;
                        break;
                    default:
                        Console.WriteLine("Invalid account type. Please select S for Savings or C for Current.");
                        return;
                }
            
            string accountNumber = Transactions.GenerateNewAccountNumber();
            if (ListOfCustomers.IsEmailUsed(email))
            {
                Console.WriteLine("Sorry, the provided email address is already in use. Please try again.");
                return;
            }
            Customer customer = new Customer(firstname, lastname, phoneNumber, email, accountType, password, accountNumber);

            ListOfCustomers.AddCustomer(accountNumber, customer);
            Console.WriteLine("Account created successfully.\nWelcome to the bank of the moment.\nWe are here to serve you," + firstname + ". \nYour account number is :" + accountNumber);

            string GetValidEmail()
            {
                string email1;
                while (true)
                {
                    Console.WriteLine("Enter your Email: ");
                    email1 = Console.ReadLine();

                    if (IsValidEmail(email1))
                    {
                        return email1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid email format. Please enter a valid email.");
                    }
                }
            }

            string GetValidPassword()
            {
                string password1;
                while (true)
                {
                    Console.WriteLine("Enter your Password: ");
                    password1 = Console.ReadLine();

                    if (IsValidPassword(password1))
                    {
                        return password1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid password format. Please enter a password with at least 6 characters including at least one special character (@, #, $, %, ^, &, !).");
                    }
                }
            }

            bool IsValidPassword(string password1)
            {

                string pattern = @"^(?=.*[A-Za-z0-9])(?=.*[@#$%^&!]).{6,}$";
                return Regex.IsMatch(password1, pattern);
            }
            string GetValidName(string prompt)
            {
                string name;
                while (true)
                {
                    Console.WriteLine(prompt);
                    name = Console.ReadLine();

                    if (IsValidName(name))
                    {
                        return name;
                    }
                    else
                    {
                        Console.WriteLine("Invalid name format. Name should not start with a digit or a lowercase letter.");
                    }
                }
            }

            bool IsValidName(string name)
            {

                string pattern = @"^[A-Z][A-Za-z]*$";
                return Regex.IsMatch(name, pattern);
            }
            string GetValidPhoneNumber()
            {

                while (true)
                {
                    Console.WriteLine("Enter your Phone Number: ");
                    phoneNumber = Console.ReadLine();

                    if (IsValidPhoneNumber(phoneNumber))
                    {
                        return phoneNumber;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number format!. Phone number should not include alphabetic characters\nInput should not be more or less than 11.");
                    }
                }
            }

            
        }
        public static bool IsValidName(string name)
        {

            string pattern = @"^[A-Z][A-Za-z]*$";
            return Regex.IsMatch(name, pattern);
        }
        public static bool IsValidEmail(string email1)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email1, pattern);
        }
        public static bool IsValidPassword(string password1)
        {
            string pattern = @"^(?=.*[A-Za-z0-9])(?=.*[@#$%^&!]).{6,}$";
            return Regex.IsMatch(password1, pattern);
        }
        public static bool IsValidPhoneNumber(string phoneNumber1)
        {
            string pattern = @"^\d{11}$";
            return Regex.IsMatch(phoneNumber1, pattern);
        }
    }
}




