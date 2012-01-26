using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
           // ((MasterPage)(this.Page.Master)).ShowMenu();
           //// Master.FindControl("NavigationPanel").Visible = true;
           
           
           //Master.FindControl("NavigationPanel").Visible = true;
            Session["userName"] = txtUsername.Text.Trim();
            Response.Redirect("~/commonUI/RequisitionDetails.aspx");
        }
    }

}