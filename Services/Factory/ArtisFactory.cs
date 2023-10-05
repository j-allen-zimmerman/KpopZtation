using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;


namespace Services.Factory
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