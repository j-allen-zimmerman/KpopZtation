using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;
using Services.Factory;

namespace Services.Repository
{
    public class AlbumRepository
    {
        public static Database1Entities1 db = new Database1Entities1();
        public void AddAlbum(int AlbumID,int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            db.Albums.Add(AlbumFactory.createAlbum(AlbumID,ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription));
            db.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            Album album = db.Albums.Where(x => x.AlbumID == id).FirstOrDefault();

            db.Albums.Remove(album);
            db.SaveChanges();
        }

        public static Album GetOneItem(int idx)
        {
            return db.Albums.Where(x => x.AlbumID == idx).FirstOrDefault();
        }

        public static List<Album> GetAllItems()
        {
            return db.Albums.ToList();
        }

        public void EditAlbum(int id, int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            Album album = db.Albums.Where(x => x.AlbumID == id).FirstOrDefault();
            if (album == null) return;
            album.AlbumID = id;
            album.AlbumName = AlbumName;
            album.AlbumImage = AlbumImage;
            album.AlbumPrice = AlbumPrice;
            album.AlbumStock = AlbumStock;
            album.AlbumDescription = AlbumDescription;
            db.SaveChanges();
        }
    }
}