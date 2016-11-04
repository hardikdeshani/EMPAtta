using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class admin_DesignationMaster : System.Web.UI.Page
{
    EMPAttLogic.EMP.Designation obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Designation Master";

        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        obj = new EMPAttLogic.EMP.Designation();
        obj.DesignationName = tbDesignationName.Text;
        obj.IsActive = cbIsActive.Checked;
        obj.DesignationIDP = (!string.IsNullOrEmpty(hfID.Value) ? Int32.Parse(hfID.Value) : 0);

        MEMBERS.SQLReturnMessageNValue mRes = obj.AddUpdate();
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lMessage")).Visible = true;
        ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;

        BindData();
        ClearControls();
    }

    protected void rData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            if (e.CommandName == "cE")
            {
                DataTable dt = new EMPAttLogic.EMP.Designation().GetDesignation(Int32.Parse(e.CommandArgument.ToString()));
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
        rData.DataSource = new EMPAttLogic.EMP.Designation().GetDesignation(0);
        rData.DataBind();
    }

    public void ClearControls()
    {
        hfID.Value = tbDesignationName.Text = string.Empty;
        cbIsActive.Checked = false;
    }
}