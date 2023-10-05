using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class DetailArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string artistid = Request.QueryString["ArtistId"];
                int idx = int.Parse(artistid);

                Artist artist = ArtistController.getOneArtist(idx);
                ArtistNameTxt.Text = artist.ArtistName;
                string path = "../Assets/Artists/";
                ArtistImage.ImageUrl = path + artist.ArtistImage;
                List<Album> album = AlbumController.GetArtistAlbum(idx);
                CardRepeater.DataSource = album;
                CardRepeater.DataBind();

                if (artist == null)
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
                if (Session["Role"] == null)
                {

                    InsertAlbumBtn.Visible = false;

                }
                else if (Session["Role"].Equals("Admin"))
                {

                    InsertAlbumBtn.Visible = true;
                }
                else
                {

                    InsertAlbumBtn.Visible = false;
                }
            }
        }

        protected void OpenAlbumDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string AlbumId = linkbtn.CommandArgument;
            string ArtistId = Request.QueryString["ArtistId"];

            Response.Redirect("~/Views/DetailAlbum.aspx?AlbumId=" + AlbumId + "&ArtistId=" + ArtistId);
        }

        protected void UpdateLinkBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            LinkButton linkbtn = (LinkButton)sender;
            string AlbumId = linkbtn.CommandArgument;
            Response.Redirect("~/Views/UpdateAlbum.aspx?AlbumId=" + AlbumId + "&ArtistId=" + ArtistId);

        }

        protected void DeleteLinkBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string AlbumId = linkbtn.CommandArgument;
            int idx = int.Parse(AlbumId);
            AlbumController.DeleteAlbum(idx);

            string ArtistId = Request.QueryString["ArtistId"];
            Response.Redirect("~/Views/DetailArtist.aspx?ArtistId=" + ArtistId);
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            Response.Redirect("~/Views/InsertAlbum.aspx?ArtistId=" + ArtistId);
        }

        protected void CardRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    if (Session["Role"] == null || Session["Role"].Equals("Customer"))
                    {
                
                        LinkButton UpdateBtn = (LinkButton)e.Item.FindControl("UpdateLinkBtn"); // Replace with your button ID
                        LinkButton DeleteBtn = (LinkButton)e.Item.FindControl("DeleteLinkBtn");
                        UpdateBtn.Visible = false;
                        DeleteBtn.Visible = false;

                    }
                }
        }
    }
}