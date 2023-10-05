using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;

namespace KpopZtation.Views
{
    public partial class InsertArtist : System.Web.UI.Page
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
            if (ArtistFileUpload.HasFile)
            {

                string artistName = ArtistTxt.Text;
                string artistImage = ArtistFileUpload.FileName;
                string extention = Path.GetExtension(artistImage);
                HttpPostedFile file = ArtistFileUpload.PostedFile;
                double fileSize = file.ContentLength / 1048576;
                string error = ArtistController.AddArtist(artistName, artistImage, extention, fileSize);
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
                ErrorTxt.Text = "Please input artist name or upload file!";
            }
        }


        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}