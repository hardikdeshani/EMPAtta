using EMPAttLogic;
using System;

public partial class staff_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
            {
                Response.Redirect("/staff/Dashboard.aspx");
                return;
            }
        }
    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        MEMBERS.SQLReturnMessageNValue mRes = new Registration().EMP_AUTH(tbUserName.Text, tbPassword.Text);
        if (mRes.Outval > 0)
        {
            new SessionClass().SetValue(SessionClass.SessionKey.UserID, mRes.Outval.ToString());
            new SessionClass().SetValue(SessionClass.SessionKey.UserName, mRes.Outmsg.ToString());
            Response.Redirect("/staff/Dashboard.aspx");
        }
        else
        {
            Response.Write("<script>alert('User Name or Password Wrong !!');</script>");
            return;
        }
    }
}