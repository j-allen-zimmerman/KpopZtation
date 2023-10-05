using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class CartController
    {
        public static List<object> getCart(int customerId)
        {
            return CartHandler.GetCart(customerId);
        }

        public static string UpdateCart(int customerID, int albumID, int quantity)
        {
            Album album = AlbumController.GetOneAlbum(albumID);
            if(quantity <= album.AlbumStock && quantity > 0)
            {
                CartHandler.UpdateCart(customerID, albumID, quantity);
                return "";
            }
        
             return "Quantity must be filled and no more than stock";
        }
        public static void DeleteOneCart(int AlbumId)
        {
            CartHandler.DeleteOneCart(AlbumId);
        }

        public static void DeleteCart(int CustomerId)
        {
            CartHandler.DeleteCart(CustomerId);
        }

        public static List<Cart> Carts(int customerId)
        {
            return CartHandler.Carts(customerId);
        }  
    }
}