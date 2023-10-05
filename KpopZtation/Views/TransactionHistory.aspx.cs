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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || Session["Role"] == null || Session["Role"].Equals("Admin"))
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                int customerId = (int)Session["ID"];
                TableRepeater.DataSource = TransactionController.GetHeaderHistory(customerId);
                TableRepeater.DataBind();

            }
        }

        
        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string TranactionId = linkbtn.CommandArgument;
            Response.Redirect("~/Views/TransactionDetails.aspx?TransactionId=" + TranactionId);
        }
    }
}