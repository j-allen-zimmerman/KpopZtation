using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.Views
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                RegisterBtn.Visible = false;
                LoginBtn.Visible = false;
                LogoutBtn.Visible = true;
                ManagePanel.Visible = true;

                if (Session["Role"].Equals("Admin"))
                {
                    HyperLink3.Visible = true;
                    HyperLink5.Visible = false;
                    HyperLink7.Visible = false;
                }
                else
                {
                    HyperLink7.Visible = true;
                    HyperLink3.Visible = false;
                    HyperLink5.Visible = true;
                }
            }
            else
            {
                RegisterBtn.Visible = true;
                LoginBtn.Visible = true;
                LogoutBtn.Visible = false;
                ManagePanel.Visible = false;
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
            
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
            
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            //Session.Remove("User");
            if (Request.Cookies["customer_cookie"] != null)
            {
                HttpCookie userCookie = new HttpCookie("customer_cookie");
                Request.Cookies["customer_cookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }
            Session.Abandon();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}