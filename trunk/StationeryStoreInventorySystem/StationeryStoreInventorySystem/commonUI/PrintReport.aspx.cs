using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class PrintReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["pdf"] == "yes")
            {
                Response.ContentType = "application/pdf";
                Response.WriteFile(Session["pdfFileName"].ToString());
            }
            else if (this.Request.QueryString["excel"] == "no")
            {
                Response.ContentType = "application/excel";
                Response.WriteFile(Session["pdfFileName"].ToString());
            }
        }
    }
}