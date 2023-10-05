using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class ArtistRepository
    {

        public static Database1Entities3 db = new Database1Entities3();

        public static dynamic IsUnique(String ArtistName)
        {
            var Artist = db.Artists.Where(x => x.ArtistName == ArtistName).FirstOrDefault();
            return Artist;
        }
        public static void AddArtist(string ArtistName, string ArtistImage)
        {
            db.Artists.Add(ArtistFactory.createArtist(ArtistName, ArtistImage));
            db.SaveChanges();
        }

        public static void DeleteArtist(int id)
        {
            Artist artis = db.Artists.Where(x => x.ArtistID == id).FirstOrDefault();

            db.Artists.Remove(artis);
            db.SaveChanges();
        }

        public static void EditArtist(int id, string ArtistName, string ArtistImage)
        {
            Artist artis = db.Artists.Where(x => x.ArtistID == id).FirstOrDefault();

            artis.ArtistName = ArtistName;
            artis.ArtistImage = ArtistImage;
            db.SaveChanges();
        }
        public static Artist GetOneArtist(int idx)
        {
            return db.Artists.Where(x => x.ArtistID == idx).FirstOrDefault();
        }
        public static List<Artist> GetAllArtist()
        {
            return db.Artists.ToList();
        }
    }
}