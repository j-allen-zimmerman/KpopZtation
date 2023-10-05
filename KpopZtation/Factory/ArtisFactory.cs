using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;


namespace KpopZtation.Factory
{
    public class ArtistFactory
    {
        public static Artist createArtist(string artistname, string artistimage)
        {
            return new Artist
            {
                ArtistName = artistname,
                ArtistImage = artistimage,
            };
        }
    }
}