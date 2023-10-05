using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class AlbumRepository
    {
        public static Database1Entities3 db = new Database1Entities3();
        public static void AddAlbum(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            db.Albums.Add(AlbumFactory.createAlbum(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription));
            db.SaveChanges();
        }

        public static void UpdateAlbumCart(int albumId, int quantity)
        {
            Album album = db.Albums.Where(x => x.AlbumID == albumId).FirstOrDefault();
            if (album == null)
            {
                return;
            }
            album.AlbumStock = album.AlbumStock - quantity;
            db.SaveChanges();
        }

        public static void DeleteAlbum(int id)
        {
            Album album = db.Albums.Where(x => x.AlbumID == id).FirstOrDefault();

            db.Albums.Remove(album);
            db.SaveChanges();
        }

        public static Album GetOneAlbum(int idx)
        {
            return db.Albums.Where(x => x.AlbumID == idx).FirstOrDefault();
        }

        public static List<Album> GetArtistAlbum(int idx)
        {
            return db.Albums.Where(x => x.ArtistID == idx).ToList();
        }
             
        public static List<Album> GetAllItems()
        {
            return db.Albums.ToList();
        }

        public static void EditAlbum(int AlbumId, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            Album album = db.Albums.Where(x => x.AlbumID == AlbumId).FirstOrDefault();
            album.AlbumName = AlbumName;
            album.AlbumImage = AlbumImage;
            album.AlbumPrice = AlbumPrice;
            album.AlbumStock = AlbumStock;
            album.AlbumDescription = AlbumDescription;
            db.SaveChanges();
           

            
        }
    }
}