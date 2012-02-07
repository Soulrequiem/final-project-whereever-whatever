using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;
using SystemStoreInventorySystemUtil;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreateDiscrepencyReport : System.Web.UI.Page
    {
        private static readonly string sessionKey = "CreateDiscrepancy";
        private CreateDiscrepencyReportControl createDiscrepancyReportControl;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                createDiscrepancyReportControl = GetControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, createDiscrepancyReportControl);

                //FillItemsGridView();

                FillItems();
            }
            else
            {
                createDiscrepancyReportControl = (CreateDiscrepencyReportControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillItemsGridView();
        }

        public void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        private CreateDiscrepencyReportControl GetControl()
        {
            if (createDiscrepancyReportControl == null)
                createDiscrepancyReportControl = new CreateDiscrepencyReportControl();
            return createDiscrepancyReportControl;
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            DataTable dtItems = StationeryStoreInventorySystemController.Util.GetItemTable();
            if (dtItems != null)
            {
                drdItemList.TextField = "ItemDescription";
                drdItemList.ValueField = "ItemNo";
                drdItemList.DataSource = dtItems;
                drdItemList.DataBind();
            }
        }

        /// <summary>
        /// Adds item in the gridview
        /// CreatedBy Priyanka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            createDiscrepancyReportControl.SelectAdd(lblItemNumber.Text, Converter.objToInt(txtQuantity.Text), txtReason.Text);
            FillItemsGridView();

            drdItemList.CurrentValue = "";
            txtQuantity.Text = "";
            txtReason.Text = "";
            lblItemNumber.Text = "";
            lblItemPrice.Text = "";
        }
        

        private void FillItemsGridView()
        {
            dgvItemList.Rows.Clear();
            dgvItemList.DataSource = createDiscrepancyReportControl.DiscrepancyDetailList;
            dgvItemList.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)Session["DiscrepencyItems"];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    lblItemNumber.Text += dt.Rows[i].ItemArray[0].ToString();
            Constants.ACTION_STATUS status = createDiscrepancyReportControl.SelectCreate();
            if (status == Constants.ACTION_STATUS.SUCCESS)
            {
                btnAdd.Visible = false;
                btnApprove.Visible = false;
                btnDelete.Visible = false;
                btnGetItem.Visible = false;

                // add success message
            }
        }
        /// <summary>
        /// To remove the selected row
        /// createdBy Priyanka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int deletedItem = 0;
            for (int i = 0; i < dgvItemList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvItemList.Rows[i].Items.FindItemByKey("CreateDiscrepancyReportCheckBox").Value) == true)
                {
                    createDiscrepancyReportControl.SelectRemove(i - (deletedItem++));
                }
            }
            FillItemsGridView();
        }

        protected void dgvItemList_RowUpdated(object sender,
            Infragistics.Web.UI.GridControls.RowUpdatedEventArgs e)
        {
            lblItemPrice.Text = e.RowID.ToString();
        }

        protected void dgvItemList_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillItemsGridView();
        }

        protected void dgvItemList_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillItemsGridView();
        }
        
        /// <summary>
        /// Display the itemNo. & Item Price according to the item Reference
        /// createdby Priyanka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            string selectedItem = drdItemList.SelectedItem.Text;

            if (createDiscrepancyReportControl.SelectItemDescription(drdItemList.SelectedItem.Text) == Constants.ACTION_STATUS.SUCCESS)
            {
                lblItemNumber.Text = createDiscrepancyReportControl.ItemId;
                lblItemPrice.Text = createDiscrepancyReportControl.Cost.ToString();
            }
            else
            {
                // print error message
            }

        
        }
    }
}