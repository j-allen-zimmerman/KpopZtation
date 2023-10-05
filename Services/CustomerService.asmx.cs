//using Services.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
namespace Services
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> CreateMember(string email, string password, string name)
        {
            List<string> messages = new List<string>();
            messages.Add("");
            messages.Add("");
            messages.Add("");
            if (IsUniqueEmail(email) != null || !email.Contains("@") || email.Contains("@.") || email.Contains(".@") || !email.Contains("."))
            {
                messages[0] = "Email must be unique and using a correct email format";
            }

            if (password.Length < 3 || password.Length > 20)
            {
                messages[1] = "Password minimal length is 3 characters and 20 characters is the maximal";
            }

            if (name.Length < 3 || name.Length > 20 || !IsAlphabet(name))
            {
                messages[2] = "Name minimal length is 3 characters and 20 characters is the maximal and must be letter";
            }

            if (messages[0] == "" && messages[1] == "" && messages[2] == "")
            {
                //UserHandler.Register(email, password, name);
                return new List<string>();
            }
            return messages;
        }
        [WebMethod]
        public bool IsAlphabet(string s)
        {
            s = s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'a' || s[i] > 'z') && s[i] != ' ') return false;
            }
            return true;
        }
        [WebMethod]
        public string LoginUser(string email, string password, bool remember)
        {
            if (!email.Contains("@")
                || email.Contains("@.") || email.Contains(".@")
                || !email.Contains("."))
            {
                return "Email must using a correct email format";
            }

            if (password.Length < 3 || password.Length > 20)
            {
                return "Password must more than 3 characters and less than 20 characters";
            }

            var user = IsValidCredential(email, password);
            if (user == null)
            {
                return "Credential is not valid";
            }

            return null;
        }
        [WebMethod]
        public dynamic IsUniqueEmail(string email)
        {
            //return UserHandler.IsUniqueEmail(email);
            return null;
        }
        [WebMethod]
        public string IsValidCredential(string email, string password)
        {
            //string json = JsonConvert.SerializeObject(UserHandler.IsValidCredential(email, password));
            //return json;

            return null;
        }

    }
}
