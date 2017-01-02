using System;

public partial class staff_Staff : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
            {
                lName.InnerText = new SessionClass().GetValue(SessionClass.SessionKey.UserName);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void lLogout_Click(object sender, EventArgs e)
    {
        new SessionClass().ClearCache();
        Response.Redirect("Default.aspx");
    }
}
