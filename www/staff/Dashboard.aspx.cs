using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;
using System.Web;

public partial class staff_Dashboard : System.Web.UI.Page
{
    Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                GetCurrentStatus();
                GetCurrentTime();
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    public void GetCurrentTime()
    {
        obj = new Registration();
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        MEMBERS.SQLReturnMessageNValue mRes = obj.EmployeeCurrentTime(mUserIDF);
        lTotalTime.Text = mRes.Outmsg.ToString();
    }

    void GetCurrentStatus()
    {
        obj = new Registration();
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        DataTable dt = new SqlHelper().GetDataUsingQuery("SELECT TOP 1 EntryType FROM AttandenceMaster WHERE EMPIDF=@EMPIDF AND CONVERT(VARCHAR(10),ClockInOutDate,120)=CONVERT(VARCHAR(10),GETDATE(),120) ORDER BY AttIDP DESC", new object[,] { { "EMPIDF", mUserIDF } });
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["EntryType"].ToString() == "1")
            {
                fcIN.Visible = false;
                fcOUT.Visible = true;
            }
            else
            {
                fcIN.Visible = true;
                fcOUT.Visible = false;
            }
        }
        else
        {
            fcIN.Visible = true;
            fcOUT.Visible = false;
        }
    }

    protected void btClockIn_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        obj = new Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.ClockInOut_Insert_Update(mUserIDF, tbRemarksIn.Text, 1, Tools.IPAddress());
        if (mRes.Outval == 3)
        {
            string Msg = "UserName : " + new SessionClass().GetValue(SessionClass.SessionKey.UserName) + "<br/>" + "Clock In Time : " + DateTime.Now + "<br/>";
            int k = new General().SendEmail(Msg, new SessionClass().GetValue(SessionClass.SessionKey.UserName));
        }
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
        GetCurrentStatus();
        ClearControls();
    }

    protected void btClockOut_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        obj = new Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.ClockInOut_Insert_Update(mUserIDF, tbRemarksOut.Text, 2, Tools.IPAddress());
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
        GetCurrentStatus();
        ClearControls();
    }

    public void ClearControls()
    {
        tbRemarksIn.Text = tbRemarksOut.Text = string.Empty;
    }
}