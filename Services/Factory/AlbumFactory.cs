using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;
namespace Services.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(int AlbumID, int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            return new Album
            {
                AlbumID = AlbumID,
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