using EMPAttLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class staff_YourAttandenceReport : System.Web.UI.Page
{
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

        rData.DataSource = new Registration().Attadeance_Report(mEMPIDF, (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbFromDate.Text) : string.Empty), (!string.IsNullOrEmpty(tbFromDate.Text) ? Tools.GetDateFormatProper(tbToDate.Text) : string.Empty), 0);
        rData.DataBind();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        BindData();
    }
}