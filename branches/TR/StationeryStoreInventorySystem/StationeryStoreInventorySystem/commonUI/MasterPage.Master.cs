using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"].ToString() == "emp")
                {
                    SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptEmpSiteMapProvider"];
                }
                else if (Session["userName"].ToString() == "head")
                {
                    SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptHeadMapProvider"];
                }
                else if (Session["userName"].ToString() == "rep")
                {
                    SSISSiteMapDataSource.Provider = SiteMap.Providers["DeptRepSiteMapProvider"];
                }
                else if (Session["userName"].ToString() == "clerk")
                {
                    SSISSiteMapDataSource.Provider = SiteMap.Providers["StoreClerkSiteMapProvider"];
                }
                else if (Session["userName"].ToString() == "super")
                {
                    SSISSiteMapDataSource.Provider = SiteMap.Providers["StoreManagerSiteMapProvider"];
                }
                NavigationBar.DataSource = null;
                NavigationBar.DataSource = SSISSiteMapDataSource;
                NavigationBar.DataBind();
            }
        }
        public void ShowMenu()
        {
            //this.NavigationPanel.Visible = true;
        }
    }
}