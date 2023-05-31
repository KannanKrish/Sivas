namespace Sivas;

public partial class Login : Page
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