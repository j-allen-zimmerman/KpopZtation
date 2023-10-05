using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
namespace KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            return new Album
            {
                ArtistID = ArtistID,
                AlbumName = AlbumName,
                AlbumImage = AlbumImage,
                AlbumPrice = AlbumPrice,
                AlbumStock = AlbumStock,
                AlbumDescription = AlbumDescription
            };
        }
    }
}