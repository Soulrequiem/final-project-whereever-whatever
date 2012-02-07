using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;
using Infragistics.Web.UI.GridControls;
using Infragistics.WebUI.Misc;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class ManageStationeryRetrievalList : System.Web.UI.Page
    {
        private static readonly string sessionKey = "ManageStationeryRetrievalList";
        private static readonly string fulfillPageSessionKey = "FulfillPage";
        private static readonly string unfulfillPageSessionKey = "UnfulfillPage";

        private ManageStationeryRetrievalListControl manageStationeryRetrievalListControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonUI.MasterPage.setCurrentPage(this);

                if (Request.QueryString["retrievalId"] != null)
                {
                    manageStationeryRetrievalListControl = new ManageStationeryRetrievalListControl(SystemStoreInventorySystemUtil.Converter.objToInt(Request.QueryString["retrievalId"]));

                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, manageStationeryRetrievalListControl);

                    Display();
                }
                // create a new retrieval list
                else if (StationeryStoreInventorySystemController.Util.GetSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey) != null)
                {
                    manageStationeryRetrievalListControl = new ManageStationeryRetrievalListControl(StationeryStoreInventorySystemController.Util.GetSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey));

                    StationeryStoreInventorySystemController.Util.RemoveSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey);

                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, manageStationeryRetrievalListControl);

                    Display();
                }
                else if (StationeryStoreInventorySystemController.Util.GetSession(sessionKey) != null)
                {
                    manageStationeryRetrievalListControl = (ManageStationeryRetrievalListControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

                    if (Request.QueryString["fulfilledpage"] != null)
                    {
                        StationeryStoreInventorySystemController.Util.PutSession(fulfillPageSessionKey, Request.QueryString["fulfilledpage"]);
                    }

                    if (Request.QueryString["unfulfilledpage"] != null)
                    {
                        StationeryStoreInventorySystemController.Util.PutSession(unfulfillPageSessionKey, Request.QueryString["unfulfilledpage"]);
                    }

                    Display();
                }
                else
                {
                    StationeryStoreInventorySystemController.Util.GoToPage("CreateStationeryRetrievalList.aspx");
                }
            }
            else
            {
                manageStationeryRetrievalListControl = (ManageStationeryRetrievalListControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
            StationeryStoreInventorySystemController.Util.RemoveSession(fulfillPageSessionKey);
            StationeryStoreInventorySystemController.Util.RemoveSession(unfulfillPageSessionKey);
        }

        private static readonly int COLUMN_DESCRIPTION = 0;
        private static readonly int COLUMN_BIN = 1;
        private static readonly int COLUMN_NEEDED_QTY = 2;
        private static readonly int COLUMN_ACTUAL_QTY = 3;
        private static readonly int COLUMN_TABLE = 4;

        private void Display()
        {
            lblRetrievalNo.Text = manageStationeryRetrievalListControl.RetrievalId;

            Dictionary<string, List<object>> retrievalList = manageStationeryRetrievalListControl.RetrievalList;

            int index = 0;
            int group = 0;
            int fulfillPage = SystemStoreInventorySystemUtil.Converter.objToInt(StationeryStoreInventorySystemController.Util.GetSession(fulfillPageSessionKey));
            int startingShowIndex = fulfillPage > 1 ? fulfillPage * ManageStationeryRetrievalListControl.totalRetrievalToSet : 0;
            foreach (string key in retrievalList.Keys)
            {
                if (index++ >= startingShowIndex && group < ManageStationeryRetrievalListControl.totalRetrievalToSet){
                    WebGroupBox webGroupBox = (WebGroupBox)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + (++group));

                    if (webGroupBox != null)
                    {
                        Label lblBin = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + group + "$lblFulfillBin" + group);
                        Label lblNeededQty = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + group + "$lblFulfillNeededQty" + group);
                        Label lblActualQty = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + group + "$lblFulfillActualQty" + group);
                        WebDataGrid webDataGrid = (WebDataGrid)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + group + "$FulfillWebDataGrid" + group);

                        if (lblBin != null && lblNeededQty != null && lblActualQty != null && webDataGrid != null)
                        {

                            webGroupBox.Visible = true;
                            webDataGrid.Visible = true;

                            DataTable dt = (DataTable)retrievalList[key][COLUMN_TABLE];

                            webGroupBox.Text = retrievalList[key][COLUMN_DESCRIPTION].ToString();

                            lblBin.Text = retrievalList[key][COLUMN_BIN].ToString();
                            lblNeededQty.Text = retrievalList[key][COLUMN_NEEDED_QTY].ToString();
                            lblActualQty.Text = retrievalList[key][COLUMN_ACTUAL_QTY].ToString();

                            webDataGrid.DataSource = dt;
                            webDataGrid.DataBind();
                        }
                    }
                }
            }

            if (retrievalList.Count() > ManageStationeryRetrievalListControl.totalRetrievalToSet)
            {
                HyperLink fulfilledLink;
                for (int i = 0; i < SystemStoreInventorySystemUtil.Converter.objToInt(Math.Ceiling((double)(retrievalList.Count() / ManageStationeryRetrievalListControl.totalRetrievalToSet))); i++)
                {
                    fulfilledLink = new HyperLink();
                    fulfilledLink.Attributes["style"] = "padding-left: 5px;";
                    if (i != fulfillPage - 1)
                    {
                        fulfilledLink.NavigateUrl = "~/storeUI/Clerk/ManageStationeryRetrievalList.aspx?fulfilledpage=" + (i + 1);
                    }
                    fulfilledLink.Text = (i + 1).ToString();
                    FulfilledPaginating.Controls.Add(fulfilledLink);
                   
                }
            }

            index = 0;
            group = 0;
            int unfulfillPage = SystemStoreInventorySystemUtil.Converter.objToInt(StationeryStoreInventorySystemController.Util.GetSession(unfulfillPageSessionKey));
            startingShowIndex = unfulfillPage > 1 ? unfulfillPage * ManageStationeryRetrievalListControl.totalRetrievalToSet : 0;
            Dictionary<string, List<object>> unfulfilledRetrievalList = manageStationeryRetrievalListControl.UnfulfilledRetrievalList;
            
            foreach (string key in unfulfilledRetrievalList.Keys)
            {
                if (index++ >= startingShowIndex && group < ManageStationeryRetrievalListControl.totalRetrievalToSet)
                {
                    WebGroupBox webGroupBox = (WebGroupBox)this.FindControl("ctl00$MainContent$WebGroupBox" + (++group));

                    if (webGroupBox != null)
                    {
                        Label lblBin = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + group + "$lblBin" + group);
                        Label lblNeededQty = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + group + "$lblNeededQty" + group);
                        Label lblActualQty = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + group + "$lblActualQty" + group);
                        WebDataGrid webDataGrid = (WebDataGrid)this.FindControl("ctl00$MainContent$WebGroupBox" + group + "$DgvManageStationeryRetrievalList" + group);

                        if (lblBin != null && lblNeededQty != null && lblActualQty != null && webDataGrid != null)
                        {

                            webGroupBox.Visible = true;
                            webDataGrid.Visible = true;

                            DataTable dt = (DataTable)unfulfilledRetrievalList[key][COLUMN_TABLE];

                            webGroupBox.Text = unfulfilledRetrievalList[key][COLUMN_DESCRIPTION].ToString();

                            lblBin.Text = unfulfilledRetrievalList[key][COLUMN_BIN].ToString();
                            lblNeededQty.Text = unfulfilledRetrievalList[key][COLUMN_NEEDED_QTY].ToString();
                            lblActualQty.Text = unfulfilledRetrievalList[key][COLUMN_ACTUAL_QTY].ToString();

                            webDataGrid.DataSource = dt;
                            webDataGrid.DataBind();
                        }
                    }
                }
            }

            if (unfulfilledRetrievalList.Count() > ManageStationeryRetrievalListControl.totalRetrievalToSet)
            {
                HyperLink unfulfilledLink;
                for (int i = 0; i < SystemStoreInventorySystemUtil.Converter.objToInt(Math.Ceiling((double)(unfulfilledRetrievalList.Count() / ManageStationeryRetrievalListControl.totalRetrievalToSet))); i++)
                {
                    unfulfilledLink = new HyperLink();
                    unfulfilledLink.Attributes["style"] = "padding-left: 5px;";
                    if (i != unfulfillPage - 1)
                    {
                        unfulfilledLink.NavigateUrl = "~/storeUI/Clerk/ManageStationeryRetrievalList.aspx?unfulfilledpage=" + (i + 1);
                    }
                    unfulfilledLink.Text = (i + 1).ToString();
                    UnfulfilledPaginating.Controls.Add(unfulfilledLink);

                }
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Equals(btnSet1))
            {
                //WebDataGrid webDataGrid = (WebDataGrid)this.FindControl("ctl00$MainContent$WebGroupBox1$DgvManageStationeryRetrievalList1");
                //RetrievalTable retrievalTable = 
                manageStationeryRetrievalListControl.SetBasedOnRequestSequence(((WebGroupBox)this.FindControl("ctl00$MainContent$WebGroupBox1")).Text, SystemStoreInventorySystemUtil.Converter.objToInt(((Label)this.FindControl("ctl00$MainContent$WebGroupBox1$lblActualQty1")).Text));
                StationeryStoreInventorySystemController.Util.GoToPage("ManageStationeryRetrievalList.aspx");
                //Display();
            }
            else if (((Button)sender).Equals(btnSet2))
            {
            }
            else if (((Button)sender).Equals(btnSet3))
            {
            }
            else if (((Button)sender).Equals(btnSet4))
            {
            }
            else if (((Button)sender).Equals(btnSet5))
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}