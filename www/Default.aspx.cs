using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        MEMBERS.SQLReturnMessageNValue mRes = new EMPAttLogic.EMP.Registration().EMP_AUTH(tbUserName.Text, tbPassword.Text);
        if (mRes.Outval > 0)
        {
            Session["UserIDF"] = mRes.Outval.ToString();
            Response.Redirect("staff/Dashboard.aspx");
        }
        else
        {
            Response.Write("<script>alert('User Name or Password Wrong !!');</script>");
            return;
        }
    }
}