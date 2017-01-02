using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class admin_DesignationMaster : System.Web.UI.Page
{
    Designation obj;

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

    protected void btSave_Click(object sender, EventArgs e)
    {
        obj = new Designation();
        obj.DesignationName = tbDesignationName.Text;
        obj.IsActive = cbIsActive.Checked;
        obj.DesignationIDP = (!string.IsNullOrEmpty(hfID.Value) ? Int32.Parse(hfID.Value) : 0);

        MEMBERS.SQLReturnMessageNValue mRes = obj.Designation_Insert_update();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
        BindData();
        ClearControls();
    }

    protected void rData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            if (e.CommandName == "cE")
            {
                DataTable dt = new Designation().GetDesignation(Int32.Parse(e.CommandArgument.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbDesignationName.Text = dr["DesignationName"].ToString();
                    cbIsActive.Checked = bool.Parse(dr["IsActive"].ToString());
                    hfID.Value = e.CommandArgument.ToString();
                }
            }
        }
    }

    public void BindData()
    {
        rData.DataSource = new Designation().GetDesignation(0);
        rData.DataBind();
    }

    public void ClearControls()
    {
        hfID.Value = tbDesignationName.Text = string.Empty;
        cbIsActive.Checked = false;
    }
}