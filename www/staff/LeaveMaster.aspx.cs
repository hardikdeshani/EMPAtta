using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class staff_LeaveMaster : System.Web.UI.Page
{
    EMPAttLogic.EMP.Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Leave Master";
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

    protected void btSave_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(Session["UserIDF"].ToString(), out mUserIDF);

        Int32 mLeaveType = 0;
        Int32.TryParse(ddlLeaveType.SelectedValue, out mLeaveType);

        DateTime dtFromDate = new DateTime();
        dtFromDate = Convert.ToDateTime(Tools.GetDateFormatProper(tbFromDate.Text));

        DateTime dtToDate = new DateTime();
        if (!string.IsNullOrEmpty(tbToDate.Text))
        {
            dtToDate = Convert.ToDateTime(Tools.GetDateFormatProper(tbToDate.Text));
        }

        obj = new EMPAttLogic.EMP.Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.Leave_Insert_Update(mUserIDF, tbRemarks.Text, mLeaveType, dtFromDate.ToString(), (mLeaveType == 1 ? dtFromDate.ToString() : dtToDate.ToString()));

        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lMessage")).Visible = true;
        ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;
        ClearControls();
    }

    public void ClearControls()
    {
        tbRemarks.Text = string.Empty;
        ddlLeaveType.ClearSelection();
        tbFromDate.Text = tbToDate.Text = string.Empty;
        trFromDate.Visible = false;
        trToDate.Visible = false;
    }
}