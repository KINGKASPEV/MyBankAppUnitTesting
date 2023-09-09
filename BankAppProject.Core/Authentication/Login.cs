using DeroyalBank.Data;
using DeroyalBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeroyalBank.Core
{
    public class Login
    {
        public static void LoginUser()
        {
            Console.WriteLine("Enter your Account Number: ");
            string accountNo = Console.ReadLine();

            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            if (accountNo == null || password == null)
            {
                Console.WriteLine("All fields are required. Try again");
                return;

            }
            else
            {
                bool found = CheckLogin(accountNo, password);

                if (found)
                {
                    Logged.loggedAccount = accountNo;
                    Console.WriteLine("Login successful!");
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Invalid login Details. Try again");
                    Welcome.WelcomeCustomer();
                }
            }

        }

        public static bool CheckLogin(string accountNo, string password)
        {
            foreach (var item in ListOfCustomers.customerList)
            {
                if (item.Key == accountNo)
                {
                    Customer customer = item.Value;
                    string passwd = customer.GetPassword();

                    if (password == passwd)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
