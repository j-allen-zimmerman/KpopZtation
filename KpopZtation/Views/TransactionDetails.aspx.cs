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
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || Session["Role"] == null || Session["Role"].Equals("Admin"))
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                string transactionId = Request.QueryString["TransactionId"];
                int idx = int.Parse(transactionId);
                TableRepeater.DataSource = TransactionController.GeteDetailHistory(idx);
                TableRepeater.DataBind();
            }
        }
    }
}