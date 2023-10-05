using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;
using Services.Factory;

namespace Services.Repository
{
    public class ArtistRepository
    {

        public static Database1Entities1 db = new Database1Entities1();

        public void AddArtist(string ArtistName, string ArtistImage)
        {
            db.Artists.Add(ArtistFactory.createArtist(ArtistName, ArtistImage));
            db.SaveChanges();
        }

        public void DeleteArtist(int id)
        {
            Artist artis = db.Artists.Where(x => x.ArtistID == id).FirstOrDefault();

            db.Artists.Remove(artis);
            db.SaveChanges();
        }

        public void EditArtist(int id, string ArtistName, string ArtistImage)
        {
            Artist artis = db.Artists.Where(x => x.ArtistID == id).FirstOrDefault();

            artis.ArtistName = ArtistName;
            artis.ArtistImage = ArtistImage;
            db.SaveChanges();
        }
    }
}