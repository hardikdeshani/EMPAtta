using EMPAttLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_TaskDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["tt"] != null)
                {
                    BindTask(Int64.Parse(Request.QueryString["tt"].ToString()), int.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
                }
            }
        }
        else 
        { 
            Response.Redirect("Default.aspx"); 
        }
    }

    void BindTask(Int64 TaskIDP, int UserIDF)
    {
        rData.DataSource = new Registration().GetTask(TaskIDP, UserIDF, "", "");
        rData.DataBind();
    }
}