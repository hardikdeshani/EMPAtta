using EMPAttLogic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_TaskMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                hfID.Value = "0";
                BindDDL();
                BindTask(0, int.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        Int32 mUserIDF = 0, mProjectIDF = 0, mWorkType = 0;
        Int32.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        Int32.TryParse(ddlProject.SelectedValue, out mProjectIDF);
        Int32.TryParse(ddlWorkType.SelectedValue, out mWorkType);
        MEMBERS.SQLReturnMessageNValue res = new Registration().TaskMaster_Insert_Update(int.Parse(hfID.Value), mUserIDF, tbTitle.Text, FCKeditor.Value, mProjectIDF, mWorkType);
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + res.Outmsg + "'); });</script>", false);
        BindTask(0, int.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
        ClearControl();
    }

    protected void rData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            if (e.CommandName == "cE")
            {
                Int32 mUserIDF = 0;
                Int32.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
                hfID.Value = e.CommandArgument.ToString();
                DataTable dtT = new Registration().GetTask(Int64.Parse(e.CommandArgument.ToString()), mUserIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty));
                if (dtT.Rows.Count > 0)
                {
                    tbTitle.Text = dtT.Rows[0]["TaskTitle"].ToString();
                    FCKeditor.Value = dtT.Rows[0]["TaskDesc"].ToString();
                    ddlProject.SelectedValue = dtT.Rows[0]["ProjectIDF"].ToString();
                    ddlWorkType.SelectedValue = dtT.Rows[0]["WorkTypeID"].ToString();
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindTask(0, int.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
    }

    void ClearControl()
    {
        FCKeditor.Value = tbTitle.Text = string.Empty; hfID.Value = "0";
        ddlProject.ClearSelection();
        ddlWorkType.ClearSelection();
    }

    void BindTask(Int64 TaskIDP, int UserIDF)
    {
        rData.DataSource = new Registration().GetTask(TaskIDP, UserIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty));
        rData.DataBind();
    }

    void BindDDL()
    {
        ddlProject.DataSource = new SqlHelper().GetDataUsingQuery("Select * from ProjectMaster where IsActive=1", new object[,] { });
        ddlProject.DataTextField = "ProjectName";
        ddlProject.DataValueField = "ProjectID";
        ddlProject.DataBind();
        ddlProject.Items.Insert(0, new ListItem("-- Select Project --", "0"));
    }
}