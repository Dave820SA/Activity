﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace GrantActivity.AspNetForms
{
    public partial class aspnetgeneric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Rpts/") + "simple.rpt");
            CrystalReportViewer1.ReportSource = rd;
        }
    }
}