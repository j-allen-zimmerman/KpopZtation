using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CustomersHandler
    {
        public static dynamic IsUniqueEmail(string email)
        {
            return CustomerRepository.IsUniqueEmail(email);
        }
        public static dynamic IsValidCredential(string email, string password)
        {
            return CustomerRepository.IsValidCredential(email, password);
        }
        public static void Register(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            CustomerRepository.Register(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole);
        }
        public static void Update(int idx, string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress)
        {
            CustomerRepository.Update(idx, CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress);
        }
        public static void DeleteCustomer (int idx)
        {
            CustomerRepository.DeleteCustomer(idx);
        }
    }
}