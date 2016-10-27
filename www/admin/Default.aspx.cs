using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        MEMBERS.SQLReturnMessageNValue mRes = new EMPAttLogic.Admin.AdminLogin().ADMIN_AUTH(tbUserName.Text, tbPassword.Text);
        if (mRes.Outval > 0)
        {
            Session["AdminID"] = mRes.Outval.ToString();
            Session["AdminName"] = mRes.Outmsg.ToString();
            Response.Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<script>alert('User Name or Password Wrong !!')</script>");
            return;
        }
    }
}