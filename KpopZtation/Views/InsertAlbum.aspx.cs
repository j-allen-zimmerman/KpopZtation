using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;


namespace KpopZtation.Views
{
    public partial class InsertAlbum : System.Web.UI.Page
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
            if (AlbumFileUpload.HasFile)
            {
                string AlbumName = Albumtxt.Text;
                string AlbumDesc = AlbumDescTxt.Text;
                int AlbumStock = int.Parse(AlbumStockTxt.Text);
                int AlbumPrice = int.Parse(AlbumPriceTxt.Text);
                string AlbumImage = AlbumFileUpload.FileName;
                string extention = Path.GetExtension(AlbumImage);
                HttpPostedFile file = AlbumFileUpload.PostedFile;
                double fileSize = file.ContentLength / 1048576;
                string ArtistId = Request.QueryString["ArtistId"];
                int idx = int.Parse(ArtistId);
                string error = AlbumController.AddAlbum(idx, AlbumName, AlbumDesc, AlbumPrice, AlbumStock, AlbumImage, extention, fileSize);
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
                ErrorTxt.Text = "All form must be filled!";
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            Response.Redirect("~/Views/DetailArtist.aspx?ArtistId=" + ArtistId);
        }
    }
}