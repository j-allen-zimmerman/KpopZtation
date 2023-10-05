using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Repository;


namespace KpopZtation.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    Response.Redirect("../Home.aspx", false);
                }
                else if (Request.Cookies["customer_cookie"] != null)
                {
                    EmailTxt.Text = Request.Cookies["customer_cookie"]["Email"];
                    PasswordTxt.Attributes["value"] = Request.Cookies["customer_cookie"]["Password"];
                }
            }
        }



        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            bool rememberCheck = RememberCheckBox.Checked;

            Customer customer = CustomerRepository.Login(email, password);


            if (customer != null)
            {
                if (rememberCheck)
                {
                    HttpCookie cookie = new HttpCookie("customer_cookie");
                    cookie.Value = customer.CustomerID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }
                Session["User"] = customer;
                Session["Role"] = customer.CustomerRole;
                Session["Email"] = customer.CustomerEmail;
                Session["Password"] = customer.CustomerPassword;
                Session["ID"] = customer.CustomerID;


                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                ErrorLbl.Text = "Invalid Credential";
                ErrorLbl.Visible = true;
            }
        }
    }
}