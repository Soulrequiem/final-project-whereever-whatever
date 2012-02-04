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
        
        private DataTable dtGridItems;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                createDiscrepancyReportControl = GetControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, createDiscrepancyReportControl);

                FillItemsGridView();
                FillItems();
            }
            else
            {
                createDiscrepancyReportControl = (CreateDiscrepencyReportControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillItemsGridView();
        }
        private CreateDiscrepencyReportControl GetControl()
        {
            if (createDiscrepancyReportControl == null)
                createDiscrepancyReportControl = new CreateDiscrepencyReportControl();
            return createDiscrepancyReportControl;
        }

        private void FillDataTable()
        {
            //if (dtGridItems == null)
            //{
            //    dtGridItems = (DataTable)dgvItemList.DataSource;
            //}
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdItemList_SelectionChanged(object sender,
        Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string selectedItem = drdItemList.SelectedItem.Text;

            if (createDiscrepancyReportControl.SelectItemDescription(drdItemList.SelectedItem.Text) == Constants.ACTION_STATUS.SUCCESS)
            {
                lblItemNumber.Text = createDiscrepancyReportControl.ItemId;
            }
            else
            {
                // print error message
            }
            //Pass to the controller

        }
        /// <summary>
        /// Adds item in the gridview
        /// CreatedBy Priyanka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtGridItems = (DataTable)Session["DiscrepencyItems"];
            if (dtGridItems == null)
            {
                dtGridItems = new DataTable();

                foreach (string columnName in dgvItemList.Columns)
                {
                    dtGridItems.Columns.Add(columnName);
                }
            }

            DataRow dr = dtGridItems.NewRow();
            dr[0] = false;
            dr[1] = lblItemNumber.Text;
            dr[2] = drdItemList.SelectedItem.Text;
            dr[3] = txtQuantity.Text;
            dr[4] = lblItemPrice.Text;
            dr[5] = txtReason.Text;

            dtGridItems.Rows.Add(dr);
            Session["DiscrepencyItems"] = dtGridItems;
            FillItemsGridView();
        }
        

        private void FillItemsGridView()
        {
            dgvItemList.ClearDataSource();
            dgvItemList.DataSource = (DataTable)Session["DiscrepencyItems"];
            dgvItemList.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["DiscrepencyItems"];
            for (int i = 0; i < dt.Rows.Count; i++)
                lblItemNumber.Text += dt.Rows[i].ItemArray[0].ToString();
        }
        /// <summary>
        /// To remove the selected row
        /// createdBy Priyanka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // ArrayList productToDelete = new ArrayList();

            int deletedItem = 0;
            for (int i = 0; i < dgvItemList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvItemList.Rows[i].Items.FindItemByKey("CreateDiscrepancyReportCheckBox").Value) == true)
                {
                    createDiscrepancyReportControl.SelectRemove(i - (deletedItem++));
                    refresh();
                }
            }

           
            
        }
        private void refresh()
        {
            //selectedIndexList = new List<int>();
            dgvItemList.Rows.Clear();
            FillDataTable();
        }
        //private void prepareData()
        //{
        //    for (int i = 0; i < dgvItemList.Rows.Count; i++)
        //    {
        //        if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvItemList.Rows[i].Items.FindItemByKey("CreateDiscrepancyReportCheckBox").Value) == true)
        //        {
        //        }
        //    }


        //}

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