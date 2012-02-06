using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemController;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class LogIn : System.Web.UI.Page
    {
        private static readonly string sessionKey = "LogIn";

        private LoginControl lgCtrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MasterPage.setCurrentPage(this);
                lgCtrl = GetControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, lgCtrl);
            }
            else
            {
                lgCtrl = (LoginControl) StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                if (lgCtrl == null)
                {
                    lgCtrl = GetControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, lgCtrl);
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
           // ((MasterPage)(this.Page.Master)).ShowMenu();
           //// Master.FindControl("NavigationPanel").Visible = true;
           
           
           //Master.FindControl("NavigationPanel").Visible = true;
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (Constants.ACTION_STATUS.SUCCESS == lgCtrl.SelectLogin(txtUsername.Text, txtPassword.Text))
                {
                    Session["userName"] = txtUsername.Text.Trim();
                    Session["LoadFirstTime"] = true;
                    removeSession();
                    int UserRole = Util.GetEmployeeRole();

                    if(UserRole == (int)Constants.EMPLOYEE_ROLE.EMPLOYEE)
                        Response.Redirect("~/departmentUI/Employee/CheckRequisition.aspx");
                    else if(UserRole == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE ||
                        UserRole == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE)
                        Response.Redirect("~/departmentUI/Representative/SubmitRequisitionsToStore.aspx");
                    else if(UserRole == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD ||
                        UserRole == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD)
                        Response.Redirect("~/departmentUI/Head/ApproveRequisition.aspx");
                    else if(UserRole == (int)Constants.EMPLOYEE_ROLE.STORE_CLERK)
                        Response.Redirect("~/storeUI/Clerk/ViewStationeryRetrievalList.aspx");
                    else if(UserRole == (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER ||
                        UserRole == (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR)
                        Response.Redirect("~/storeUI/SuperVisor_Manager/IssueAdjustmentVoucher.aspx");
                    else if(UserRole == (int)Constants.EMPLOYEE_ROLE.ADMIN)
                        Response.Redirect("~/commonUI/Report.aspx");
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

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }
    }

}