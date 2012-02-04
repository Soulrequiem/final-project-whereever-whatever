/***************************************************************************/
/*  File Name       : ViewStockCard.cs
/*  Module Name     : UI
/*  Owner           : JinChengCheng
/*  class Name      : ViewStockCard
/*  Details         : UI representation of ViewStockCardUI 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class ViewStockCard : System.Web.UI.Page
    {
        string itemDescription;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillItems();
                if (Request.QueryString["ItemDescription"] != null)
                {
                   
                    drdItemList.TextField = Request.QueryString["ItemDescription"].ToString();
                    itemDescription = Request.QueryString["ItemDescription"].ToString();
                    SearchResult();
                }
            }
        }


        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            try
            {
                //DataTable dtItems = (DataTable)Session["Items"];
                DataTable dtItems = StationeryStoreInventorySystemController.Util.GetItemTable();
                if (dtItems != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ID";
                    drdItemList.DataSource = dtItems;
                    drdItemList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Selected item from item drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void drdItemList_SelectionChanged(object sender,
        //Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        //FillStockCardDetails(StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.CurrentValue));
        //        //String selectedItem = drdItemList.SelectedItem.Text;
        //        //ViewStockCardControl VSCobj = new ViewStockCardControl();
        //        //DataTable dt = VSCobj.GetStockCardDetails(selectedItem);
        //        //FillStockCardDetails(dt);
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.WriteErrorLog(ex);
        //    }

        //}

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillStockCardDetails(DataTable dt)
        {
            if (dt != null)
            {
                DgvStockCardList.DataSource = dt;
                DgvStockCardList.DataBind();
            }
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            itemDescription = drdItemList.SelectedItem.Text;
            SearchResult();
        }

        protected void SearchResult()
        {
            ViewStockCardControl vsCtrl = new ViewStockCardControl();
            //itemDescription=drdItemList.SelectedItem.Text;

            DataTable dtItem = StationeryStoreInventorySystemController.Util.GetItemListTable(itemDescription);
            if (dtItem != null)
            {
                lblItemNo.Text = dtItem.Rows[0][0].ToString();
                lblUOM.Text = dtItem.Rows[0][5].ToString();
            }

            FillStockCardDetails(vsCtrl.GetStockCardDetails(itemDescription));
            DataTable dt = vsCtrl.getSupplier();
            if (dt != null && dt.Rows.Count == 3)
            {
                lblSuplier1.Text = dt.Rows[0].ItemArray[0].ToString();
                lblSuplier2.Text = dt.Rows[1].ItemArray[0].ToString();
                lblSuplier3.Text = dt.Rows[2].ItemArray[0].ToString();
            }
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
