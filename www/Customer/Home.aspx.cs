using EMPAttLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                BindDDL();
                BindTicketNo();
                BindTask(0, Int64.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
                hfID.Value = "0";
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    void BindTicketNo()
    {
        Guid guid = Guid.NewGuid();
        hfGUID.Value = tbTicketNo.Text = guid.ToString();
    }

    void BindTask(Int64 TaskIDP, Int64 CustomerID)
    {
        rData.DataSource = new Registration().GetCustomerTask(TaskIDP, CustomerID);
        rData.DataBind();
    }

    void ClearControl()
    {
        FCKeditor.Value = string.Empty; hfID.Value = "0";
        ddlTitle.ClearSelection();
    }

    protected void btAddTask_Click(object sender, EventArgs e)
    {
        int mCustomerID = 0, mTitleIDF = 0;
        Int32.TryParse(ddlTitle.SelectedValue, out mTitleIDF);
        int.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mCustomerID);
        MEMBERS.SQLReturnMessageNValue res = new Registration().CustomerTaskMaster_Insert_Update(int.Parse(hfID.Value), hfGUID.Value, mCustomerID, mTitleIDF, FCKeditor.Value, 1, 0);
        BindTicketNo();
        BindTask(0, Int64.Parse(new SessionClass().GetValue(SessionClass.SessionKey.UserID)));
        ClearControl();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + res.Outmsg + "'); });</script>", false);
    }

    void BindDDL()
    {
        ddlTitle.DataSource = new SqlHelper().GetDataUsingQuery("Select * from TitleMaster Where IsActive=1", new object[,] { });
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("---Select Title---", "0"));
    }
}