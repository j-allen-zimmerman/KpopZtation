using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Model;
namespace KpopZtation.Handler
{
    public class AlbumHandler
    {
        public static void AddAlbum(int ArtistId, string AlbumName, string AlbumDesc, int AlbumPrice, int AlbumStock, string AlbumImage)
        {
            AlbumRepository.AddAlbum(ArtistId, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDesc);
            
        }

        public static List<Album> GetArtistAlbum(int idx)
        {
            return AlbumRepository.GetArtistAlbum(idx);
        }

        public static Album GetOneAlbum(int idx)
        {
            return AlbumRepository.GetOneAlbum(idx);
        }

        public static void DeleteAlbum(int idx)
        {
            AlbumRepository.DeleteAlbum(idx);
        }

        public static void EditAlbum(int AlbumId, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            AlbumRepository.EditAlbum(AlbumId, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
        }
        public static void UpdateAlbumCart(int albumId, int quantity)
        {
            AlbumRepository.UpdateAlbumCart(albumId, quantity);
        }
    }
}