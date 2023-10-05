using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Factory;
using Services.Model;
namespace Services.Repository
{
    public class CartRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static void AddCart(int customerID, int albumID, int quantity)
        {
            db.Carts.Add(CartFactory.createCart(customerID, albumID, quantity));
            db.SaveChanges();
        }
        public static dynamic GetCart(int customerId)
        {
            return db.Carts.Join(db.Albums,
                cart => cart.AlbumID,
                album => album.AlbumID,
                (cart, album) => new
                {
                    CustomerID = cart.CustomerID,
                    AlbumID = album.AlbumID,
                    ItemName = album.AlbumName,
                    ItemDescription = album.AlbumDescription,
                    ItemPrice = album.AlbumPrice,
                    Quantity = cart.Qty
                }).Where(u => u.CustomerID == customerId).ToList();
        } 

        public static List<Cart> Carts(int customerId)
        {
            return db.Carts.Where(x => x.CustomerID == customerId).ToList();
        }

        public static void DeleteCart(int customerId)
        {
            db.Carts.RemoveRange(db.Carts.Where(x => x.CustomerID == customerId));
            db.SaveChanges();
        }
    }
}