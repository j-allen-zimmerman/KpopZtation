using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{

    public class CustomerRepository
    {


        public static Database1Entities3 db = new Database1Entities3();

        public static dynamic IsUniqueEmail(string email)
        {
            var users = db.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();

            return users;
            
        }

        public static dynamic IsValidCredential(string email, string password)
        {
            var members = db.Customers.Where(x => x.CustomerEmail == email && x.CustomerPassword == password).FirstOrDefault();

            return members;
        }
        public static void Register(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            db.Customers.Add(CustomerFactory.createUser(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole));
            db.SaveChanges();
        }

        public static Customer Login(string email, string password)
        {
            Customer customer = db.Customers.Where(x => x.CustomerEmail == email && x.CustomerPassword == password).FirstOrDefault();
            return customer;

        }
        public static void Update(int id, string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress)
        {
            Customer customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            customer.CustomerName = CustomerName;
            customer.CustomerEmail = CustomerEmail;
            customer.CustomerPassword = CustomerPassword;
            customer.CustomerGender = CustomerGender;
            customer.CustomerAddress = CustomerAddress;
            db.SaveChanges();
        }

        public static void DeleteCustomer(int idx) 
        { 
            Customer customer = db.Customers.Where(x => x.CustomerID == idx).FirstOrDefault();
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}