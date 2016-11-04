using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class admin_EmployeeMaster : System.Web.UI.Page
{
    EMPAttLogic.EMP.Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Employee Master";

        if (!IsPostBack)
        {
            BindDDL();
            BindData();
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        obj = new EMPAttLogic.EMP.Registration();
        obj.Name = tbName.Text;
        obj.Mobile = tbMobileNo.Text;
        obj.EmailID = tbEmailID.Text;
        obj.Password = new EMPAttLogic.Common.General().GetPassword(tbMobileNo.Text);
        obj.Address = tbAddress.Text;
        Int32 mDesignationIDF = 0;
        Int32.TryParse(ddlDesignation.SelectedValue, out mDesignationIDF);
        obj.DesignationIDF = mDesignationIDF;
        obj.IsActive = cbIsActive.Checked;
        obj.EMPIDP = (!string.IsNullOrEmpty(hfID.Value) ? Int64.Parse(hfID.Value) : 0);
        MEMBERS.SQLReturnMessageNValue mRes = obj.AddUpdate();

        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lMessage")).Visible = true;
        ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;

        BindData();
        ClearControls();
    }

    public void BindData()
    {
        rData.DataSource = new EMPAttLogic.EMP.Registration().GetEmployee(0);
        rData.DataBind();
    }

    public void BindDDL()
    {
        ddlDesignation.DataSource = new EMPAttLogic.EMP.Designation().GetDesignation(0);
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
                DataTable dt = new EMPAttLogic.EMP.Registration().GetEmployee(Int64.Parse(e.CommandArgument.ToString()));
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

