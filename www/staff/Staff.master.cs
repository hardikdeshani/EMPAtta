using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_Staff : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        lName.Text = Session["UserName"].ToString();
    }

    protected void lLogout_Click(object sender, EventArgs e)
    {
        Session["UserIDF"] = Session["UserName"] = null;
        Response.Redirect("/Default.aspx");
    }
}
