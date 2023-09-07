using DeroyalBank.Model;
using System.Collections.Generic;

namespace DeroyalBank.Data
{
    public class ListOfCustomers
    {
        public string Email { get; private set; }
        public static Dictionary<string, Customer> customerList = new Dictionary<string, Customer>();
        private static HashSet<string> usedEmails = new HashSet<string>();
        public static void AddCustomer(string accountNo,Customer customer)
        {
            customerList.Add(accountNo, customer);
            usedEmails.Add(customer.Email());
        }

        public static bool IsEmailUsed(string email)
        {
            return usedEmails.Contains(email);
        }
    }
}