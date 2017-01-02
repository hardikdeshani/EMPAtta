using EMPAttLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserTaskDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            MasterPage mPage = this.Master;
            ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Task Details";
            if (!IsPostBack)
            {
                if (Request.QueryString["tt"] != null && Request.QueryString["ud"] != null)
                {
                    BindTask(Int64.Parse(Request.QueryString["tt"].ToString()), int.Parse(Request.QueryString["ud"].ToString()));
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