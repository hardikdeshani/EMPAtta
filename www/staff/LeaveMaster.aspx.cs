using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class staff_LeaveMaster : System.Web.UI.Page
{
    Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        else 
        { 
            Response.Redirect("Default.aspx"); 
        }
    }

    void BindData()
    {
        Int64 mEMPIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mEMPIDF);

        rData.DataSource = new Registration().Leave_Report(mEMPIDF);
        rData.DataBind();
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
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);

        Int32 mLeaveType = 0;
        Int32.TryParse(ddlLeaveType.SelectedValue, out mLeaveType);

        DateTime dtFromDate = new DateTime();
        dtFromDate = Convert.ToDateTime(Tools.GetDateFormatProper(tbFromDate.Text));

        DateTime dtToDate = new DateTime();
        if (!string.IsNullOrEmpty(tbToDate.Text))
        {
            dtToDate = Convert.ToDateTime(Tools.GetDateFormatProper(tbToDate.Text));
        }

        obj = new Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.Leave_Insert_Update(mUserIDF, tbRemarks.Text, mLeaveType, dtFromDate.ToString(), (mLeaveType == 1 ? dtFromDate.ToString() : dtToDate.ToString()));
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
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