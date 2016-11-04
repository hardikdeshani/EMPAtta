using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class admin_LeaveReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Leave Report";

        if (!IsPostBack)
        {
            BindDDL();
            BindData();
        }
    }

    public void BindData()
    {
        Int64 mEMPIDF = 0;
        Int64.TryParse(ddlEmployee.SelectedValue, out mEMPIDF);

        DataTable dt = new EMPAttLogic.EMP.Registration().Leave_Report(mEMPIDF);
        rData.DataSource = dt;
        rData.DataBind();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindData();
    }

    public void BindDDL()
    {
        ddlEmployee.DataSource = new EMPAttLogic.EMP.Registration().GetEmployee(0);
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EMPIDP";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }
}