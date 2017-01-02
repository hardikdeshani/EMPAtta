using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class admin_EmployeeMaster : System.Web.UI.Page
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

    protected void btSave_Click(object sender, EventArgs e)
    {
        obj = new Registration();
        obj.Name = tbName.Text;
        obj.Mobile = tbMobileNo.Text;
        obj.EmailID = tbEmailID.Text;
        obj.Password = new General().GetPassword(tbMobileNo.Text);
        obj.Address = tbAddress.Text;
        Int32 mDesignationIDF = 0;
        Int32.TryParse(ddlDesignation.SelectedValue, out mDesignationIDF);
        obj.DesignationIDF = mDesignationIDF;
        obj.IsActive = cbIsActive.Checked;
        obj.EMPIDP = (!string.IsNullOrEmpty(hfID.Value) ? Int64.Parse(hfID.Value) : 0);
        MEMBERS.SQLReturnMessageNValue mRes = obj.Employee_Insert_Update();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
        BindData();
        ClearControls();
    }

    public void BindData()
    {
        rData.DataSource = new Registration().GetEmployee(0);
        rData.DataBind();
    }

    public void BindDDL()
    {
        ddlDesignation.DataSource = new Designation().GetDesignation(0);
        ddlDesignation.DataTextField = "DesignationName";
        ddlDesignation.DataValueField = "DesignationIDP";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation --", "-1"));
    }

    protected void rData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            if (e.CommandName == "cE")
            {
                DataTable dt = new Registration().GetEmployee(Int64.Parse(e.CommandArgument.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbName.Text = dr["Name"].ToString();
                    tbMobileNo.Text = dr["Mobile"].ToString();
                    tbEmailID.Text = dr["EmailID"].ToString();
                    tbAddress.Text = dr["Address"].ToString();
                    ddlDesignation.SelectedValue = dr["DesignationIDF"].ToString();
                    cbIsActive.Checked = bool.Parse(dr["IsActive"].ToString());
                    hfID.Value = e.CommandArgument.ToString();
                }
            }
        }
    }

    public void ClearControls()
    {
        hfID.Value = tbName.Text = tbEmailID.Text = tbMobileNo.Text = tbAddress.Text = string.Empty;
        cbIsActive.Checked = false;
        ddlDesignation.ClearSelection();
    }
}

