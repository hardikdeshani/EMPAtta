using EMPAttLogic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_frmClientMaster : System.Web.UI.Page
{
    Registration obj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(new SessionClass().GetValue(SessionClass.SessionKey.UserID)))
        {
            if (!IsPostBack)
            {
                BindProjectList();
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
        Int32 mClientType = 0;
        Int32.TryParse(ddlClientType.SelectedValue, out mClientType);

        obj = new Registration();
        obj.Name = tbName.Text;
        obj.Mobile = tbMobileNo.Text;
        obj.EmailID = tbEmailID.Text;
        obj.Password = new General().GetPassword(tbMobileNo.Text);
        obj.Address = tbAddress.Text;
        string Projects = string.Empty;
        for (int i = 0; i < chbProjectList.Items.Count; i++)
        {
            if (chbProjectList.Items[i].Selected)
            {
                Projects = (string.IsNullOrWhiteSpace(Projects) ? chbProjectList.Items[i].Value : Projects + "," + chbProjectList.Items[i].Value);
            }
        }
        obj.ProjectsName = Projects;
        obj.WebsiteUrl = tbWebSiteUrl.Text;
        obj.IsActive = cbIsActive.Checked;
        obj.CustomerID = (!string.IsNullOrEmpty(hfID.Value) ? Int64.Parse(hfID.Value) : 0);
        obj.ClientType = mClientType;
        MEMBERS.SQLReturnMessageNValue mRes = obj.Customer_Insert_Update();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), "Notification", "<script>$(document).ready(function () { sweetAlert('" + mRes.Outmsg + "'); });</script>", false);
        BindData();
        ClearControls();
    }

    public void BindData()
    {
        rData.DataSource = new Registration().GetCustomers(0);
        rData.DataBind();
    }

    public void BindProjectList()
    {
        chbProjectList.DataSource = new SqlHelper().GetDataUsingQuery("Select * from ProjectMaster where IsActive=1", new object[,] { });
        chbProjectList.DataBind();
    }

    protected void rData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            if (e.CommandName == "cE")
            {
                DataTable dt = new Registration().GetCustomers(Int64.Parse(e.CommandArgument.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbName.Text = dr["Name"].ToString();
                    tbMobileNo.Text = dr["Mobile"].ToString();
                    tbEmailID.Text = dr["EmailID"].ToString();
                    tbAddress.Text = dr["Address"].ToString();
                    tbWebSiteUrl.Text = dr["WebsiteUrl"].ToString();
                    for (int i = 0; i < dr["ProjectsName"].ToString().Split(',').Length; i++)
                    {
                        for (int j = 0; j < chbProjectList.Items.Count; j++)
                        {
                            if (dr["ProjectsName"].ToString().Split(',')[i] == chbProjectList.Items[j].Value)
                            { chbProjectList.Items[j].Selected = true; }
                        }
                    }
                    cbIsActive.Checked = dr["IsActive"].ToString() == "1" ? true : false;
                    hfID.Value = e.CommandArgument.ToString();
                }
            }
        }
    }

    public void ClearControls()
    {
        hfID.Value = tbName.Text = tbEmailID.Text = tbMobileNo.Text = tbAddress.Text = tbWebSiteUrl.Text = string.Empty;
        cbIsActive.Checked = false; chbProjectList.ClearSelection();
    }

    protected void rData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblProjectName = (Label)e.Item.FindControl("lblProjectName");
            string[] Pro = DataBinder.Eval(e.Item.DataItem, "ProjectsName").ToString().Split(',');
            for (int k = 0; k < Pro.Length; k++)
            {
                DataTable dtP = new SqlHelper().GetDataUsingQuery("Select * from ProjectMaster where ProjectID=@ProjectID", new object[,] { { "ProjectID", Pro[k].ToString() } });
                if (dtP.Rows.Count > 0)
                {
                    lblProjectName.Text = (string.IsNullOrWhiteSpace(lblProjectName.Text) ? dtP.Rows[0]["ProjectName"].ToString() : lblProjectName.Text + "<br/>" + dtP.Rows[0]["ProjectName"].ToString());
                }
            }
        }
    }
}