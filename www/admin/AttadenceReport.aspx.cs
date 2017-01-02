using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMPAttLogic;
using System.Web.UI.HtmlControls;

public partial class admin_AttadenceReport : System.Web.UI.Page
{
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
        Int64 mEMPIDF = 0;
        Int64.TryParse(ddlEmployee.SelectedValue, out mEMPIDF);
        rData.DataSource = new Registration().Attadeance_Report(mEMPIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty), int.Parse(ddlEntryType.SelectedValue));
        rData.DataBind();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindData();
    }

    public void BindDDL()
    {
        ddlEmployee.DataSource = new Registration().GetEmployee(0);
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EMPIDP";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }

    protected void rData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlTableRow tTR = (HtmlTableRow)e.Item.FindControl("tTR");
            string IsLate = DataBinder.Eval(e.Item.DataItem, "IsLate").ToString();
            if (IsLate == "1")
            {
                tTR.Style.Add("background", "red");
                tTR.Style.Add("color", "white"); tTR.Style.Add("font-weight", "bold");
            }
        }
    }
}