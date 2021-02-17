using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectnewgadi
{
    public partial class LoReUpForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("LoReUpForm.aspx");
                }
            }
            if (Session["user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void Loginbot_Click(object sender, EventArgs e)
        {
            string username = UsernameL.Text;
            string password = PasswordL.Text;
            LoReUp newuser = LoReUp.Login(username, password);
            if (newuser != null)
            {
                Session["user"] = newuser;
                Response.Redirect("HomePage.aspx");
                ResultLabel.Text = "Loged";
            }
            else
            {
                ResultLabel.Text = "Wrong username or password";
            }
        }

        protected void Registerbot_Click(object sender, EventArgs e)
        {
            string username = UsernameR.Text;
            string password = PasswordR.Text;
            if (LoReUp.IfUserExit(username) == false)
            {
                LoReUp.Register(username, password);
                ResultLabel.Text = "Registered successfully";
            }
            else
            {
                ResultLabel.Text = "User Already exist";
            }
        }
    }
}