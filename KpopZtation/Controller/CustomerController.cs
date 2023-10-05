using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
namespace KpopZtation.Controller
{
    public class CustomerController
    {
        public static List<string> ValidateRegister(string username, string email,bool checkRadioMale, bool checkRadioFemale ,string address, string password)
        {
          
            List<string> messages = validate(username, email, checkRadioFemale, checkRadioMale, address, password);
            

            if (messages[0] == "" && messages[1] == "" && messages[2] == "" && messages[3] == "" && messages[4] == "")
            {
                CustomersHandler.Register(username,email,password,messages[5],address,"Customer");
                return new List<string>();
            }
            return messages;
        }

        public static List<string> ValidateUpdate(string username, string email, bool checkRadioMale, bool checkRadioFemale, string address, string password,int idx)
        {
           
            List<string> messages = validate(username, email, checkRadioFemale, checkRadioMale, address, password);
            if (messages[0] == "" && messages[1] == "" && messages[2] == "" && messages[3] == "" && messages[4] == "")
            {
                CustomersHandler.Update(idx, username, email, password, messages[5], address);
                return new List<string>();
            }
            return messages;
        }


        public static List<string> validate(string username, string email, bool checkRadioFemale, bool checkRadioMale, string address, string password)
        {
            List<string> messages = new List<string>();
            messages.Add("");
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
            else if (checkRadioMale == true)
            {
                messages[5] = "Male";
            }
            else if (checkRadioFemale)
            {
                messages[5] = "Female";
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

        public static void DeleteCustomer(int idx)
        {
            CustomersHandler.DeleteCustomer(idx);
        }
    }
}