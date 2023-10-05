using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controller;
using System.IO;

namespace KpopZtation.Views
{
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].Equals("Customer"))
            {
                Response.Redirect("~/Views/Login.aspx");
            }

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string AlbumName = Albumtxt.Text;
            string AlbumDesc = AlbumDescTxt.Text;
            int AlbumStock = int.Parse(AlbumStockTxt.Text);
            int AlbumPrice = int.Parse(AlbumPriceTxt.Text);

            string AlbumId = Request.QueryString["AlbumId"];
            string ArtistId = Request.QueryString["ArtistId"];

            int idx = int.Parse(AlbumId);

            Album album = AlbumController.GetOneAlbum(idx);
            if (AlbumFileUpload.HasFile)
            {
                string AlbumImage = AlbumFileUpload.FileName;
                string extention = Path.GetExtension(AlbumImage);
                HttpPostedFile file = AlbumFileUpload.PostedFile;
                double fileSize = file.ContentLength / 1048576;
                string error = AlbumController.EditAlbum(idx, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDesc, extention, fileSize);
                if (error == "")
                {
                    AlbumFileUpload.SaveAs(Server.MapPath("~") + "/Assets/Albums/" + AlbumFileUpload.FileName);
                    Response.Redirect("~/Views/DetailArtist.aspx?ArtistId=" + ArtistId);

                }
                else
                {
                    ErrorTxt.Text = error;
                }
            }
            else
            {
                string error = AlbumController.EditAlbum(idx, AlbumName, album.AlbumImage, AlbumPrice, AlbumStock, AlbumDesc, ".png", 1.5);
                if(error == "")
                {
                    Response.Redirect("~/Views/DetailArtist.aspx?ArtistId=" + ArtistId);
                }
                else
                {
                    ErrorTxt.Text = error;

                }
                
            }
            
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            string AlbumId = Request.QueryString["AlbumId"];
            Response.Redirect("~/Views/DetailAlbum.aspx?AlbumId=" + AlbumId + "&ArtistId=" + ArtistId);
        }
    }
}