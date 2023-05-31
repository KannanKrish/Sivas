using System;
using System.Web.Security;

namespace Sivas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUser.Text, txtPass.Text))                
                FormsAuthentication.RedirectFromLoginPage(txtUser.Text, true);
        }
    }
}