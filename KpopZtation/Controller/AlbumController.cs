using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;
namespace KpopZtation.Controller
{
    public class AlbumController
    {
        public static string AlbumValidate(string AlbumName, string AlbumDesc, int AlbumPrice, int AlbumStock, string extention, double fileSize)
        {
            int maxSize = 2; // 2 mb
            if (AlbumName.Length > 50 || AlbumName.Length == 0)
            {
                return "Must be filled and smaller than 50 characters.";
            }else if(AlbumDesc.Length > 255 || AlbumDesc.Length == 0)
            {
                return "Must be filled and smaller than 255 characters.";
            }else if (AlbumPrice < 100000 || AlbumPrice > 1000000)
            {
                return "Must be filled and between 100000 and 1000000";
            }else if (AlbumStock <= 0)
            {
                return "Must be filled and more than 0";
            }
            else if (!((extention.ToLower() == ".png") || (extention.ToLower() == ".jpg") || (extention.ToLower() == ".jpeg") || (extention.ToLower() == ".jfif")))
            {
                return "File extension must be .png, .jpg, .jpeg, or .jfif";
            }
            else if (fileSize > maxSize)
            {
                return "File size can't be more than 2 MB";
            }
            return "";
        }


        public static string AddAlbum(int ArtistId, string AlbumName, string AlbumDesc, int AlbumPrice, int AlbumStock, string AlbumImage, string extention, double fileSize)
        {
            string error = AlbumValidate(AlbumName,AlbumDesc, AlbumPrice, AlbumStock, extention, fileSize);
            if (error == "")
            {
                AlbumHandler.AddAlbum(ArtistId, AlbumName, AlbumDesc, AlbumPrice, AlbumStock, AlbumImage);
            }
            return error;
        }

        public static List<Album> GetArtistAlbum(int idx)
        {
            return AlbumHandler.GetArtistAlbum(idx);
        }

        public static Album GetOneAlbum(int idx)
        {
            return AlbumHandler.GetOneAlbum(idx);

        }

        public static void DeleteAlbum(int idx)
        {
            AlbumHandler.DeleteAlbum(idx);
        }

        public static string EditAlbum(int AlbumId, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription, string extention, double fileSize)
        {
            string error = AlbumValidate(AlbumName, AlbumDescription, AlbumPrice, AlbumStock, extention, fileSize);
            if( error == "")
            {
                AlbumHandler.EditAlbum(AlbumId, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
            }
            return error;       
        }
        public static void UpdateAlbumCart(int albumId, int quantity)
        {
            AlbumHandler.UpdateAlbumCart(albumId, quantity);
        }
    }
}