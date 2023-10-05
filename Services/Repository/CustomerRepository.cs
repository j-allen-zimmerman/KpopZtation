using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;
using Services.Factory;
using Newtonsoft.Json;
namespace Services.Repository
{

    public class CustomerRepository
    {
        

        public static Database1Entities1 db = new Database1Entities1();

        public static dynamic IsUniqueEmail(string email)
        {
            //var users = db.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();

            //return users;
            return null;
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
    }
}