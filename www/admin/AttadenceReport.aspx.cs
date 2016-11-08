using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class admin_AttadenceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Attadence Report";

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

        DataTable dt = new EMPAttLogic.EMP.Registration().Attadeance_Report(mEMPIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty));
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