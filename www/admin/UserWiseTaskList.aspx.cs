using EMPAttLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserWiseTaskList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                BindDDL(); 
                BindTask(0, 0, "", "");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    void BindTask(Int64 TaskIDP, int UserIDF, string FromDate, string Todate)
    {
        rData.DataSource = new Registration().GetTask(TaskIDP, UserIDF, FromDate, Todate);
        rData.DataBind();
    }

    void BindDDL()
    {
        ddlEmployee.DataSource = new Registration().GetEmployee(0);
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EMPIDP";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindTask(0, int.Parse(ddlEmployee.SelectedValue), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty));
    }
}