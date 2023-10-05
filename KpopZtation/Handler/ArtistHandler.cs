using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Model;
namespace KpopZtation.Handler
{
    public class ArtistHandler
    {
        public static void AddArtist(string ArtistName, string ArtistImage)
        {
            ArtistRepository.AddArtist(ArtistName, ArtistImage);
        }

        public static dynamic IsUnique(string ArtistName)
        {
            return ArtistRepository.IsUnique(ArtistName);
        }

        public static Artist getOneArtist(int idx)
        {
            return ArtistRepository.GetOneArtist(idx);
        }
        public static void editArtist(int idx, string artistName, string artistImage)
        {
            ArtistRepository.EditArtist(idx, artistName, artistImage);
        }

        public static List<Artist> GetAllArtist()
        {
            return ArtistRepository.GetAllArtist();
        }

        public static void DeleteArtist(int idx)
        {
            ArtistRepository.DeleteArtist(idx);
        }
    }
}