﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EmployeeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage mPage = this.Master;
        ((Label)mPage.FindControl("lTitle")).Text = this.Page.Title = "Employee Master";
    }
}