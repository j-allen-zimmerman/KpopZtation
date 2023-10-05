using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Model;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CartHandler
    {
        public static void AddCart(int customerID, int albumID, int quantity)
        {

            CartRepository.AddCart(customerID, albumID, quantity);
           

        }

        public static List<object> GetCart(int customerId)
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

        public static void DeleteOneCart(int AlbumId)
        {
            CartRepository.DeleteOneCart(AlbumId);
        }
        public static void UpdateCart(int CustomerId, int AlbumId, int Quantity)
        {
            CartRepository.UpdateCart(CustomerId, AlbumId, Quantity);
        }
    }
}