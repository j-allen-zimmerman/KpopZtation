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
    public partial class Carts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID"] == null || Session["Role"].Equals("Admin"))
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                int customerId = (int)Session["ID"];

                TableRepeater.DataSource = CartController.getCart(customerId); ;
                TableRepeater.DataBind();
                
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            int customerId = (int)Session["ID"];
            List<Cart> transactions = CartController.Carts(customerId);
            if (transactions.Count == 0)
            {
                ErrorLbl.Text = "You dont have item in cart, cant Checkout!";
                //Response.Redirect("~/Views/Carts.aspx");
            }
            else
            {
                TransactionHeader headerID = TransactionController.CreateTrHeader(customerId, DateTime.Now);
                foreach (Cart cart in transactions)
                {
                    TransactionController.CreateTrDetail(headerID.TransactionID, cart.AlbumID, cart.Qty);
                    AlbumController.UpdateAlbumCart(cart.AlbumID, cart.Qty);
                }
                CartController.DeleteCart(customerId);
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void DeleteLinkBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string AlbumId = linkbtn.CommandArgument;
            int idx = int.Parse(AlbumId);
            CartController.DeleteOneCart(idx);
            Response.Redirect("~/Views/Carts.aspx");
        }
    }
}