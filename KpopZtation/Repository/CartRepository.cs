using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Factory;
using KpopZtation.Model;
namespace KpopZtation.Repository
{
    public class CartRepository
    {
        public static Database1Entities3 db = new Database1Entities3();

        public static void AddCart(int customerID, int albumID, int quantity)
        {
            db.Carts.Add(CartFactory.createCart(customerID, albumID, quantity));
            db.SaveChanges();
        }

        public static List<object> GetCart(int customerId)
        {
            var getCart = (from album in db.Albums
                           join cart in db.Carts on album.AlbumID equals cart.AlbumID
                           where cart.CustomerID == customerId
                           select new
                           {
                               
                               album.AlbumName,
                               album.AlbumImage,
                               album.AlbumPrice,
                               Quantity = cart.Qty,
                               album.AlbumID
                           }).ToList<object>();
            return getCart;
        }

        public static List<Cart> Carts(int customerId)
        {
            return db.Carts.Where(x => x.CustomerID == customerId).ToList();
        }

        public static void DeleteOneCart(int AlbumId)
        {
            Cart cart = db.Carts.Where(x => x.AlbumID == AlbumId).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void DeleteCart(int customerId)
        {
            db.Carts.RemoveRange(db.Carts.Where(x => x.CustomerID == customerId));
            db.SaveChanges();
        }

        public static void UpdateCart(int customerID, int albumID, int quantity)
        {
            Cart cart = db.Carts.Where(x => x.AlbumID == albumID).FirstOrDefault();
            if(cart == null)
            {
                AddCart(customerID, albumID, quantity);
            }
            else
            {
                cart.Qty = cart.Qty + quantity;
                db.SaveChanges();
            }
        }
    }
}