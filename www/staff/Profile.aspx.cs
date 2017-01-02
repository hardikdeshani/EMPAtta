using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class staff_Profile : System.Web.UI.Page
{
    Registration obj;

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
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);
        DataTable dt = new Registration().GetEmployee(mUserIDF);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            tbName.Text = dr["Name"].ToString();
            tbMobileNo.Text = dr["Mobile"].ToString();
            tbEmailID.Text = dr["EmailID"].ToString();
            tbAddress.Text = dr["Address"].ToString();
            ddlDesignation.SelectedValue = dr["DesignationIDF"].ToString();
            tbPassword.Text = dr["Password"].ToString();
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        Int64 mUserIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mUserIDF);

        obj = new Registration();
        obj.Name = tbName.Text;
        obj.Mobile = tbMobileNo.Text;
        obj.EmailID = tbEmailID.Text;
        obj.Password = new General().GetPassword(tbMobileNo.Text);
        obj.Address = tbAddress.Text;
        Int32 mDesignationIDF = 0;
        Int32.TryParse(ddlDesignation.SelectedValue, out mDesignationIDF);
        obj.DesignationIDF = mDesignationIDF;
        obj.IsActive = true;
        obj.EMPIDP = mUserIDF;
        MEMBERS.SQLReturnMessageNValue mRes = obj.Employee_Insert_Update();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
    }

    public void BindDDL()
    {
        ddlDesignation.DataSource = new Designation().GetDesignation(0);
        ddlDesignation.DataTextField = "DesignationName";
        ddlDesignation.DataValueField = "DesignationIDP";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation --", "-1"));
    }
}