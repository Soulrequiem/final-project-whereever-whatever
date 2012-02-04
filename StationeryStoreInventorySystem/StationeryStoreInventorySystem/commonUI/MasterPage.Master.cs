using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.WebUI;
using StationeryStoreInventorySystemController;
using SystemStoreInventorySystemUtil;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private static string currentPageSessionKey = "CurrentPage";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblLoggedinTime.Text = "Log-in Time: " + SystemStoreInventorySystemUtil.Converter.dateTimeToString(SystemStoreInventorySystemUtil.Converter.DATE_CONVERTER.DATETIME, DateTime.Now);
                if (StationeryStoreInventorySystemController.Util.EmployeeName() != null)
                {
                    lblUserName.Text = "Welcome, " + StationeryStoreInventorySystemController.Util.EmployeeName();
                }
                LoadNavigationMenu();
                //removeAllSession(); // remove all session stored (open a new page)
            }
        }

        public static void setCurrentPage(System.Web.UI.Page currentPage)
        {
            StationeryStoreInventorySystemController.Util.PutSession(currentPageSessionKey, currentPage);
        }

        //private void removeAllSession()
        //{
        //    System.Web.UI.Page currentPage = (System.Web.UI.Page)StationeryStoreInventorySystemController.Util.GetSession(currentPageSessionKey);
            
        //    //if (currentPage.GetType() != typeof(LogIn)) LogIn.removeSession();
        //    if (!(currentPage is departmentUI.Head.ApproveRequisition)) departmentUI.Head.ApproveRequisition.removeSession();
        //}

        /// <summary>
        /// Loads the navigation as per user level
        /// </summary>
        private void LoadNavigationMenu()
        {
            if (Session["userName"] != null)
            {
                if (Util.GetEmployeeRole() == (int) Constants.EMPLOYEE_ROLE.EMPLOYEE)
                {
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptEmpSiteMapProvider"];
                    NavigationBar.Groups[0].Visible = true;
                    NavigationBar.Groups[1].Visible = false;
                    NavigationBar.Groups[2].Visible = false;
                    NavigationBar.Groups[3].Visible = false;
                    NavigationBar.Groups[4].Visible = false;
                    SetDefaultMenuSelection(3, 0);
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD ||
                    Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD )
                {
                    NavigationBar.Groups[0].Visible = true;
                    NavigationBar.Groups[1].Visible = true;
                    NavigationBar.Groups[2].Visible = true;
                    NavigationBar.Groups[3].Visible = false;
                    NavigationBar.Groups[4].Visible = false;
                    SetDefaultMenuSelection(0, 2);
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptHeadMapProvider"];
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE ||
                    Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE)
                {
                    NavigationBar.Groups[0].Visible = true;
                    NavigationBar.Groups[1].Visible = true;
                    NavigationBar.Groups[2].Visible = false;
                    NavigationBar.Groups[3].Visible = false;
                    NavigationBar.Groups[4].Visible = false;
                    SetDefaultMenuSelection(0, 1);
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptRepSiteMapProvider"];
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.STORE_CLERK)
                {
                    NavigationBar.Groups[0].Visible = false;
                    NavigationBar.Groups[1].Visible = false;
                    NavigationBar.Groups[2].Visible = false;
                    NavigationBar.Groups[3].Visible = true;
                    NavigationBar.Groups[4].Visible = false;
                    SetDefaultMenuSelection(7, 3);
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["StoreClerkSiteMapProvider"];
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR)
                {
                    NavigationBar.Groups[0].Visible = false;
                    NavigationBar.Groups[1].Visible = false;
                    NavigationBar.Groups[2].Visible = false;
                    NavigationBar.Groups[3].Visible = true;
                    NavigationBar.Groups[4].Text = "Supervisor";
                    NavigationBar.Groups[4].Visible = true;
                    SetDefaultMenuSelection(2, 4);
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["StoreManagerSiteMapProvider"];
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER)
                {
                    NavigationBar.Groups[0].Visible = false;
                    NavigationBar.Groups[1].Visible = false;
                    NavigationBar.Groups[2].Visible = false;
                    NavigationBar.Groups[3].Visible = true;
                    NavigationBar.Groups[4].Text = "Manager";
                    NavigationBar.Groups[4].Visible = true;
                    SetDefaultMenuSelection(2, 4);
                    //SSISSiteMapDataSource.Provider = SiteMap.Providers["StoreManagerSiteMapProvider"];
                }
                else if (Util.GetEmployeeRole() == (int)Constants.EMPLOYEE_ROLE.ADMIN)                
                {
                    NavigationBar.Groups[0].Visible = true;
                    NavigationBar.Groups[1].Visible = true;
                    NavigationBar.Groups[2].Visible = true;
                    NavigationBar.Groups[3].Visible = true;
                    NavigationBar.Groups[4].Visible = true;
                    //NavigationBar.Groups[5].Visible = true;
                    SetDefaultMenuSelection(2, 4);
                }
            }
            //NavigationBar.DataSource = null;
            //NavigationBar.DataSource = SSISSiteMapDataSource;
            //NavigationBar.DataBind();
        }
        /// <summary>
        /// Sets the default selection
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="GroupIndex"></param>
        private void SetDefaultMenuSelection(int Index, int GroupIndex)
        {
            if((bool)Session["LoadFirstTime"] == true)
            {
                Session["SelectedIndex"] = Index;
                Session["SelectedGroup"] = GroupIndex;
                Session["LoadFirstTime"] = false;
            }
        }
        
        /// <summary>
        /// Reders the Webexplorerbar menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NavigationBar_PreRender(object sender, EventArgs e)
        {
            LoadNavigationMenu();
            bool[] state = (bool[])(Session["WebExplorerState"]);
            //bool[] VisibleState = (bool[])(Session["VisibleState"]);

            if (state != null)
            {
                for (int i = 0; i < NavigationBar.Groups.Count; i++)
                {
                    NavigationBar.Groups[i].Expanded = state[i];
                    //NavigationBar.Groups[i].Visible = VisibleState[i];
                }
            }

            if (Session["SelectedIndex"] != null && NavigationBar.Groups.Count > 0)
            {
                int selIndex = (int)Session["SelectedIndex"];
                int selGroup = (int)Session["SelectedGroup"];
                NavigationBar.Groups[selGroup].Items[selIndex].Selected = true;
            }
        }

        /// <summary>
        /// Handles Item selected menu event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NavigationBar_ItemSelected(object sender,
            Infragistics.Web.UI.NavigationControls.ExplorerBarItemSelectedEventArgs e)
        {
            if (e.IsExplorerBarGroup() != true)
            {
                Session["SelectedGroup"] = e.NewSelectedItem.ParentItem.Index;
                Session["SelectedIndex"] = e.NewSelectedItem.Index;
            }

            int cnt = NavigationBar.Groups.Count;
            string redirectURL = e.NewSelectedItem.Value.ToString();

            bool[] state = new bool[cnt];
            //bool[] VisibleState = new bool[cnt];

            for (int i = 0; i < cnt; i++)
            {
                state[i] = NavigationBar.Groups[i].Expanded;
                //VisibleState[i] = NavigationBar.Groups[i].Visible;
            }

            Session["WebExplorerState"] = state;
            //Session["VisibleState"] = VisibleState;
            if (redirectURL != "")
                Response.Redirect(redirectURL);
        }
    }
}