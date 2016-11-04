using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Data;

public partial class staff_Profile : System.Web.UI.Page
{
    EMPAttLogic.EMP.Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "User Profile";
        if (!IsPostBack)
        {
            BindDDL();
            BindData();
        }
    }

    public void BindData()
    {
        if (Session["UserIDF"] != null)
        {
            Int64 mUserIDF = 0;
            Int64.TryParse(Session["UserIDF"].ToString(), out mUserIDF);
            DataTable dt = new EMPAttLogic.EMP.Registration().GetEmployee(mUserIDF);
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
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        if (Session["UserIDF"] != null)
        {
            Int64 mUserIDF = 0;
            Int64.TryParse(Session["UserIDF"].ToString(), out mUserIDF);

            obj = new EMPAttLogic.EMP.Registration();
            obj.Name = tbName.Text;
            obj.Mobile = tbMobileNo.Text;
            obj.EmailID = tbEmailID.Text;
            obj.Password = new EMPAttLogic.Common.General().GetPassword(tbMobileNo.Text);
            obj.Address = tbAddress.Text;
            Int32 mDesignationIDF = 0;
            Int32.TryParse(ddlDesignation.SelectedValue, out mDesignationIDF);
            obj.DesignationIDF = mDesignationIDF;
            obj.IsActive = true;
            obj.EMPIDP = mUserIDF;
            MEMBERS.SQLReturnMessageNValue mRes = obj.AddUpdate();

            MasterPage mPage = this.Master;
            ((Label)mPage.FindControl("lMessage")).Visible = true;
            ((Label)mPage.FindControl("lMessage")).Text = mRes.Outmsg;
        }
    }

    public void BindDDL()
    {
        ddlDesignation.DataSource = new EMPAttLogic.EMP.Designation().GetDesignation(0);
        ddlDesignation.DataTextField = "DesignationName";
        ddlDesignation.DataValueField = "DesignationIDP";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation --", "-1"));
    }
}