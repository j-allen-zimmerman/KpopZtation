using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controller;
namespace KpopZtation.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Artist> artist = ArtistController.GetAllArtist();
            CardRepeater.DataSource = artist;
            CardRepeater.DataBind();

            if (Session["Role"] == null)
            {
                InsertArtistBtn.Visible = false;
            }
            else if (Session["Role"].Equals("Admin"))
            {
                InsertArtistBtn.Visible = true;

            }
            else
            {
                InsertArtistBtn.Visible = false;
            }
        }

        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string ArtistId = linkbtn.CommandArgument;
            Response.Redirect("~/Views/DetailArtist.aspx?ArtistId=" + ArtistId);
        }

        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertArtist.aspx");
        }


        protected void UpdateLinkBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string ArtistId = linkbtn.CommandArgument;
            Response.Redirect("~/Views/UpdateArtist.aspx?ArtistId=" + ArtistId);
        }

        protected void DeleteLinkBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string id = linkbtn.CommandArgument;
            int idx = int.Parse(id);
            ArtistController.deleteArtist(idx);
            Response.Redirect("~/Views/Home.aspx");
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