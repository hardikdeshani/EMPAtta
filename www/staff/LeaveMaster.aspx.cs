using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_LeaveMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Leave Master";
    }

    protected void lLogout_Click(object sender, EventArgs e)
    {

    }

    protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLeaveType.SelectedValue == "1")
        {
            trToDate.Visible = false;
            trFromDate.Visible = true;
        }
        else if (ddlLeaveType.SelectedValue == "2")
        {
            trFromDate.Visible = trToDate.Visible = true;
        }
    }
}