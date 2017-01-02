using EMPAttLogic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_TimeDurationReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();

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

    public void BindDDL()
    {
        ddlEmployee.DataSource = new Registration().GetEmployee(0);
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EMPIDP";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
    }


    public void BindData()
    {
        Int64 mEMPIDF = 0;
        Int64.TryParse(ddlEmployee.SelectedValue, out mEMPIDF);

        ds = new Registration().GetTimeDuration(mEMPIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty));
        if (ds.Tables.Count > 1)
        {
            rData.DataSource = ds.Tables[0];
            rData.DataBind();
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void rData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlTableRow tTR = (HtmlTableRow)e.Item.FindControl("tTR");
            string tCheck = DataBinder.Eval(e.Item.DataItem, "tCheck").ToString();
            if (tCheck == "1")
            {
                tTR.Style.Add("background", "red");
                tTR.Style.Add("color", "white"); tTR.Style.Add("font-weight", "bold");
            }
            else if (tCheck == "2")
            { tTR.Style.Add("background", "green"); tTR.Style.Add("color", "white"); tTR.Style.Add("font-weight", "bold"); }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblTotal = (Label)e.Item.FindControl("lblTotal");
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblTotal.Text = "Total Time : " + ds.Tables[1].Rows[0]["GrandTotal"].ToString();
            }
        }
    }
}