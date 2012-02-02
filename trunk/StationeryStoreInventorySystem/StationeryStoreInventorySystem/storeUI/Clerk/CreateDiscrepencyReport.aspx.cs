using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreateDiscrepencyReport : System.Web.UI.Page
    {
        private DataTable dtGridItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillItemsGridView();
                FillItems();
            }
        }

        private void FillDataTable()
        {
            if (dtGridItems == null)
            {
                dtGridItems = (DataTable)dgvItemList.DataSource;
            }
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
            String selectedItem = drdItemList.SelectedItem.Text;
            //Pass to the controller

        }
        /// <summary>
        /// Adds item in the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtGridItems = (DataTable)Session["DiscrepencyItems"];
            DataRow dr = dtGridItems.NewRow();
            dr[0] = false;
            dr[1] = lblItemNumber.Text;
            dr[2] = drdItemList.SelectedItem.Text;
            dr[3] = "Zakasss";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
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
    }
}