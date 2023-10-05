using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
namespace KpopZtation.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int customerID, int albumID, int quantity)
        {
            return new Cart
            {
                CustomerID = customerID,
                AlbumID = albumID,
                Qty = quantity
            };
        }
    }
}