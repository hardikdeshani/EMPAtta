using EMPAttLogic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_YourTimeDurationReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();

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

    public void BindData()
    {
        Int64 mEMPIDF = 0;
        Int64.TryParse(new SessionClass().GetValue(SessionClass.SessionKey.UserID), out mEMPIDF);

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