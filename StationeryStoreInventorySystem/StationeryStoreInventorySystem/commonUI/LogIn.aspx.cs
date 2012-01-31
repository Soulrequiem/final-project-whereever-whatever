using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class LogIn : System.Web.UI.Page
    {
        LoginControl lgCtrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnSignIn.Attributes.Add("onclick", "return validate()");
            
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
           // ((MasterPage)(this.Page.Master)).ShowMenu();
           //// Master.FindControl("NavigationPanel").Visible = true;
           
           
           //Master.FindControl("NavigationPanel").Visible = true;
            lgCtrl = GetControl();
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (Constants.ACTION_STATUS.SUCCESS == lgCtrl.SelectLogin(txtUsername.Text, txtPassword.Text))
                {
                    Session["userName"] = txtUsername.Text.Trim();
                    Session["LoadFirstTime"] = true;
                    Response.Redirect("~/commonUI/RequisitionDetails.aspx");
                    
                }
                else
                    lblStatusMessage.Text = "Login failed.";
                
            }
            
        }
        private LoginControl GetControl()
        { 
            if (lgCtrl == null)
                lgCtrl = new LoginControl();
            return lgCtrl;
        }
    }

}