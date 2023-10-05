using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;

namespace KpopZtation.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            string username = UsernameTxt.Text;
            string address = AddressTxt.Text;
            bool checkGenderMale = MaleRB.Checked;
            bool checkGenderFemale = FemaleRB.Checked;

            List<string> message = CustomerController.ValidateRegister(username, email, checkGenderMale, checkGenderFemale, address, password);
            if (message.Count > 0)
            {
                if (message[0] != "")
                {
                    UsernameLbl.Visible = true;
                    UsernameLbl.Text = message[0];
                }
                if (message[1] != "")
                {
                    EmailLbl.Visible = true;
                    EmailLbl.Text = message[1];
                }
                if (message[2] != "")
                {
                    GenderLbl.Visible = true;
                    GenderLbl.Text = message[2];
                }
                if (message[3] != "")
                {
                    AddressLbl.Visible = true;
                    AddressLbl.Text = message[3];
                }
                if (message[4] != "")
                {
                    PasswordLbl.Visible = true;
                    PasswordLbl.Text = message[4];
                }
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }

        }

        protected void FemaleRB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}