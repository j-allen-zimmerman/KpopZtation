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
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null || Session["Role"].Equals("Customer"))
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
                string id = Request.QueryString["ArtistId"];
                int idx = int.Parse(id);
                Artist artist = ArtistController.getOneArtist(idx);

                if (artist == null)
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
                else
                {
                    ArtistTxt.Text = artist.ArtistName;
                }
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string artistName = ArtistTxt.Text;
            string artistImage = ArtistFileUpload.FileName;
            string extention = Path.GetExtension(artistImage);
            string id = Request.QueryString["ArtistId"];
            int idx = int.Parse(id);
            if (ArtistFileUpload.HasFile)
            {
                HttpPostedFile file = ArtistFileUpload.PostedFile;
                double fileSize = file.ContentLength / 1048576;
                string error = ArtistController.UpdateArtist(idx, artistName, artistImage, extention, fileSize);
                if (error == "")
                {
                    ArtistFileUpload.SaveAs(Server.MapPath("~") + "/Assets/Artists/" + ArtistFileUpload.FileName);
                    Response.Redirect("~/Views/Home.aspx");
                }
                else
                {
                    ErrorTxt.Text = error;
                }
            }
            else
            {
                string error = ArtistController.UpdateArtist(idx, artistName, artistImage, ".png", 1.5);
                if (error == "")
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
            }

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}