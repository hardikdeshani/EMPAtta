using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;

public partial class staff_Dashboard : System.Web.UI.Page
{
    EMPAttLogic.EMP.Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Clock In / Clock Out";
    }

    protected void btClockIn_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(Session["UserIDF"].ToString(), out mUserIDF);
        obj = new EMPAttLogic.EMP.Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.ClockInOut_Insert_Update(mUserIDF, tbRemarksIn.Text, 1);

        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lMessage")).Visible = true;
        ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;
        ClearControls();
    }

    protected void btClockOut_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(Session["UserIDF"].ToString(), out mUserIDF);
        obj = new EMPAttLogic.EMP.Registration();
        MEMBERS.SQLReturnMessageNValue mRes = obj.ClockInOut_Insert_Update(mUserIDF, tbRemarksOut.Text, 2);

        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lMessage")).Visible = true;
        ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;
        ClearControls();
    }

    public void ClearControls()
    {
        tbRemarksIn.Text = tbRemarksOut.Text = string.Empty;
    }
}