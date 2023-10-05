using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Handler;
namespace Services.Controller
{
    public class CustomerController
    {
        public static List<string> ValidateRegister(string username, string email,bool checkRadioMale, bool checkRadioFemale ,string address, string password)
        {
            string gender = null;
            List<string> messages = new List<string>();
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");

            if (username.Length < 5 || username.Length > 50)
            {
                messages[0] = "Username must be filled between 5 and 50 characters";
                if (string.IsNullOrEmpty(username))
                {
                    messages[0] = "Username must be filled"; 
                }
            }

            if (IsUniqueEmail(email) != null)
            {
                messages[1] = "Email must be filled and cannot be used twice";
                
                if (string.IsNullOrEmpty(email))
                {
                    messages[1] = "Email must be filled";
          
                }
            }

            if (checkRadioFemale == false && checkRadioMale == false)
            {
                messages[2] = "Gender must be selected";
            }
            else if(checkRadioMale == true)
            {
                gender = "Male";
            }
            else if(checkRadioFemale)
            {
                gender = "Female";
            }


            if (address.EndsWith("Street") == false)
            {
                messages[3] = "Address must ends with \"Street\" and must be filled";

                if (string.IsNullOrEmpty(address))
                {
                    messages[3] = "Address must be filled";
                }
            }

            if (string.IsNullOrEmpty(password))
            {
                messages[4] = "Password must be filled";
            }
            else if (!IsAlphaNumeric(password))
            {
                messages[4] = "Password must be alphanumeric";

            }

            if (messages[0] == "" && messages[1] == "" && messages[2] == "" && messages[3] == "" && messages[4] == "")
            {
                CustomersHandler.Register(username,email,password,gender,address,"Customer");
                return new List<string>();
            }
            return messages;
        }



        public static dynamic IsUniqueEmail(string email)
        {
            return CustomersHandler.IsUniqueEmail(email);
        }

        public static bool IsAlphaNumeric(string s)
        {
            s = s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if (!(s[i] >= 'a' && s[i] <= 'z') && !(s[i] >= '0' && s[i] <= '9')) return false;
            }
            return true;
        }
    }
}