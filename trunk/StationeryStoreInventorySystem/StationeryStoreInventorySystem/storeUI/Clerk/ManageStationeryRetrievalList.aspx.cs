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

        private ManageStationeryRetrievalListControl manageStationeryRetrievalListControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonUI.MasterPage.setCurrentPage(this);

                // create a new retrieval list
                if (StationeryStoreInventorySystemController.Util.GetSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey) != null)
                {
                    manageStationeryRetrievalListControl = new ManageStationeryRetrievalListControl(StationeryStoreInventorySystemController.Util.GetSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey));

                    //StationeryStoreInventorySystemController.Util.RemoveSession(CreateStationeryRetrievalList.createNewRetrievalListSessionKey);

                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, manageStationeryRetrievalListControl);

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
            foreach (string key in retrievalList.Keys)
            {
                WebGroupBox webGroupBox = (WebGroupBox)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + (++index));

                if (webGroupBox != null)
                {
                    Label lblBin = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + index + "$lblFulfillBin" + index);
                    Label lblNeededQty = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + index + "$lblFulfillNeededQty" + index);
                    Label lblActualQty = (Label)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + index + "$lblFulfillActualQty" + index);
                    WebDataGrid webDataGrid = (WebDataGrid)this.FindControl("ctl00$MainContent$FulfillWebGroupBox" + index + "$FulfillWebDataGrid" + index);

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

            HyperLink fulfilledLink;
            for (int i = 0; i < SystemStoreInventorySystemUtil.Converter.objToInt(Math.Ceiling((double)(retrievalList.Count() / ManageStationeryRetrievalListControl.totalRetrievalToSet))); i++)
            {
                fulfilledLink = new HyperLink();
                fulfilledLink.Attributes["style"] = "padding-left: 5px;";
                fulfilledLink.NavigateUrl = "~/storeUI/Clerk/ManageStationeryRetrievalList.aspx?fulfilledpage=" + (i + 1);
                fulfilledLink.Text = (i + 1).ToString();
                FulfilledPaginating.Controls.Add(fulfilledLink);
            }

            index = 0;
            Dictionary<string, List<object>> unfulfilledRetrievalList = manageStationeryRetrievalListControl.UnfulfilledRetrievalList;
            
            foreach (string key in unfulfilledRetrievalList.Keys)
            {
                WebGroupBox webGroupBox = (WebGroupBox)this.FindControl("ctl00$MainContent$WebGroupBox" + (++index));

                if (webGroupBox != null)
                {
                    Label lblBin = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + index + "$lblBin" + index);
                    Label lblNeededQty = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + index + "$lblNeededQty" + index);
                    Label lblActualQty = (Label)this.FindControl("ctl00$MainContent$WebGroupBox" + index + "$lblActualQty" + index);
                    WebDataGrid webDataGrid = (WebDataGrid)this.FindControl("ctl00$MainContent$WebGroupBox" + index + "$DgvManageStationeryRetrievalList" + index);

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

            HyperLink unfulfilledLink;
            for (int i = 0; i < SystemStoreInventorySystemUtil.Converter.objToInt(Math.Ceiling((double)(unfulfilledRetrievalList.Count() / ManageStationeryRetrievalListControl.totalRetrievalToSet))); i++)
            {
                unfulfilledLink = new HyperLink();
                unfulfilledLink.Attributes["style"] = "padding-left: 5px;";
                unfulfilledLink.NavigateUrl = "~/storeUI/Clerk/ManageStationeryRetrievalList.aspx?unfulfilledpage=" + (i + 1);
                unfulfilledLink.Text = (i + 1).ToString();
                UnfulfilledPaginating.Controls.Add(unfulfilledLink);
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

        }
    }
}