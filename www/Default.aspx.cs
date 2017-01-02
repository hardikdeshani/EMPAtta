using System;
using EMPAttLogic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        MEMBERS.SQLReturnMessageNValue mRes = new Registration().Customer_AUTH(tbUserName.Text, tbPassword.Text);
        if (mRes.Outval > 0)
        {
            new SessionClass().SetValue(SessionClass.SessionKey.UserID, mRes.Outval.ToString());
            new SessionClass().SetValue(SessionClass.SessionKey.UserName, mRes.Outmsg.ToString());
            Response.Redirect("Customer/Home.aspx");
        }
        else
        {
            Response.Write("<script>alert('User Name or Password Wrong !!');</script>");
            return;
        }
    }
}