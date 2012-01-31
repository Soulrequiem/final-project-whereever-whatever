using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;

namespace StationeryStoreInventorySystem
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            StationeryStoreInventorySystemController.Util.GetItemTable(); // prepare items
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["WebExplorerState"] = new bool[5]{true,true,true,true,true};
            Session["SelectedIndex"] = 0;
            Session["SelectedGroup"] = 0;
            //Session["VisibleState"] = new bool[5] { true, true, true, true, true };
            String userName = string.Empty;
            Session["DiscrepencyItems"] = new DataTable();
            DataTable dtGridItems = (DataTable)Session["DiscrepencyItems"];
            dtGridItems.Columns.Add("CreateDiscrepancyReportCheckBox");
            dtGridItems.Columns.Add("ItemNo");
            dtGridItems.Columns.Add("ItemDescription");
            dtGridItems.Columns.Add("Quantity");
            dtGridItems.Columns.Add("Price");
            dtGridItems.Columns.Add("Reason");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}