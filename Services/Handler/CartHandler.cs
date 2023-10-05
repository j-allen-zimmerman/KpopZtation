using System;
using System.Collections.Generic;
using System.Linq;
using Services.Repository;
using System.Web;
using Services.Model;

namespace Services.Handler
{
    public class CartHandler
    {
        public static void AddCart(int customerID, int albumID, int quantity)
        {
            CartRepository.AddCart(customerID, albumID, quantity);
        }

        public static dynamic GetCart(int customerId)
        {
            return CartRepository.GetCart(customerId);
        }

        public static List<Cart> Carts(int customerId)
        {
            return CartRepository.Carts(customerId);
        }

        public static void DeleteCart(int customerId)
        {
            CartRepository.DeleteCart(customerId);
        }
    }
}