using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("/admin/Default.aspx");
                return;
            }
            lName.Text = Session["AdminName"].ToString();
        }
    }

    protected void lLogout_Click(object sender, EventArgs e)
    {
        Session["AdminName"] = null;
        Session["AdminID"] = null;
        Response.Redirect("/admin/Default.aspx");
        return;
    }
}
