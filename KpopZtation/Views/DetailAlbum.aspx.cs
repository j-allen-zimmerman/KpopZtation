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
    public partial class DetailAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AlbumId = Request.QueryString["AlbumId"];
            int idx = int.Parse(AlbumId);
            Album album = AlbumController.GetOneAlbum(idx);
            AlbumNameLbl.Text = album.AlbumName;
            AlbumPriceLbl.Text = "Price: " + album.AlbumPrice.ToString();
            AlbumDescLbl.Text = "Description: " + album.AlbumDescription;
            AlbumStockLbl.Text = "Stock: " + album.AlbumStock.ToString();
            string path = "../Assets/Albums/";
            AlbumImage.ImageUrl = path + album.AlbumImage;

            if (album == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            if(Session["Role"] == null )
            {
                QuantityLbl.Visible = false;
                QuantityTxt.Visible = false;
                AddToCartBtn.Visible = false;

                PlusBtn.Visible = false;
                MinusBtn.Visible = false;
            }
            
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(QuantityTxt.Text);
            string AlbumId = Request.QueryString["AlbumId"];
            int idx = int.Parse(AlbumId);
            int customerID = (int)Session["ID"];

            if (Session["ID"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                string error = CartController.UpdateCart(customerID, idx, quantity);
                if(error == "")
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
                else
                {
                    ErrorTxt.Text = error;
                }     
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            string AlbumId = Request.QueryString["AlbumId"];
            Response.Redirect("~/Views/UpdateAlbum.aspx?AlbumId=" + AlbumId + "&ArtistId=" + ArtistId);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string AlbumId = Request.QueryString["AlbumId"];
            int idx = int.Parse(AlbumId);
            AlbumController.DeleteAlbum(idx);
            string ArtistId = Request.QueryString["ArtistId"];
            Response.Redirect("~/Views/DetailArtist.aspx?id=" + ArtistId);
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            string ArtistId = Request.QueryString["ArtistId"];
            Response.Redirect("~/Views/InsertAlbum.aspx?ArtistId=" + ArtistId);
        }
    }
}