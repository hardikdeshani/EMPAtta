using System;
using EMPAttLogic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Login";
    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        MEMBERS.SQLReturnMessageNValue mRes = new AdminLogin().ADMIN_AUTH(tbUserName.Text, tbPassword.Text);
        if (mRes.Outval > 0)
        {
            new SessionClass().SetValue(SessionClass.SessionKey.UserID, mRes.Outval.ToString());
            new SessionClass().SetValue(SessionClass.SessionKey.UserName, mRes.Outmsg.ToString());
            Response.Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<script>alert('User Name or Password Wrong !!')</script>");
            return;
        }
    }
}