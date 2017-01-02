using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_CustomerMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                lName.InnerText = new SessionClass().GetValue(SessionClass.SessionKey.UserName);
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void lLogout_Click(object sender, EventArgs e)
    {
        new SessionClass().ClearCache();
        Response.Redirect("Default.aspx");
    }
}
