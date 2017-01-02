using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class admin_LeaveReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {

                BindDDL();
                BindData();
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    public void BindData()
    {
        Int64 mEMPIDF = 0;
        Int64.TryParse(ddlEmployee.SelectedValue, out mEMPIDF);

        DataTable dt = new Registration().Leave_Report(mEMPIDF);
        rData.DataSource = dt;
        rData.DataBind();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindData();
    }

    public void BindDDL()
    {
        ddlEmployee.DataSource = new Registration().GetEmployee(0);
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EMPIDP";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }
}