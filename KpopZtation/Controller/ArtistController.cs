using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;
namespace KpopZtation.Controller
{
    public class ArtistController
    {
        public static string AddArtist(string ArtistName, string ArtistImage, string extention, double fileSize)
        {
            string error = ArtistValidation(ArtistName, ArtistImage, extention, fileSize);
            if(error == "")
            {
                ArtistHandler.AddArtist(ArtistName, ArtistImage);
            }
            return error;
        }

        public static string ArtistValidation(string ArtistName, string ArtistImage, string extention, double fileSize)
        {
            int maxSize = 2; // 2 mb
            if (IsUnique(ArtistName) != null)
            {
                return "Artist name must be unique!";
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
        private static dynamic IsUnique(string ArtistName)
        {
            return ArtistHandler.IsUnique(ArtistName);
        }


        public static string UpdateArtist(int idx, string ArtistName, string ArtistImage, string extention, double fileSize)
        {
            string error = ArtistValidation(ArtistName, ArtistImage, extention , fileSize);
            
            if (error == "")
            {
                ArtistHandler.editArtist(idx, ArtistName, ArtistImage);
            }
            return error;
        }


        public static Artist getOneArtist(int idx)
        {
            return ArtistHandler.getOneArtist(idx);
        }

        public static List<Artist> GetAllArtist()
        {
            return ArtistHandler.GetAllArtist();
        }

        public static void deleteArtist(int idx)
        {
            ArtistHandler.DeleteArtist(idx);
        }
    }
}