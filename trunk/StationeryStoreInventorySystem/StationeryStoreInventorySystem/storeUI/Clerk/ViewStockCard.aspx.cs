﻿/***************************************************************************/
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillStockCardDetails(StationeryStoreInventorySystemController.Util.GetItemTable());
                FillItems();
                ViewStockCardControl viewStockCardControl = new ViewStockCardControl();
                                
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
            ViewStockCardControl vsCtrl = new ViewStockCardControl();

            DataTable dtItem = StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.SelectedItem.Text);
            if (dtItem != null)
            {
                lblItemNo.Text = dtItem.Rows[0][0].ToString();
                lblUOM.Text = dtItem.Rows[0][5].ToString();
            }

            FillStockCardDetails(vsCtrl.GetStockCardDetails(drdItemList.SelectedItem.Text));
            DataTable dt = vsCtrl.getSupplier();
            if (dt != null && dt.Rows.Count == 3)
            {
                lblSuplier1.Text = dt.Rows[0].ItemArray[0].ToString();
                lblSuplier2.Text = dt.Rows[1].ItemArray[0].ToString();
                lblSuplier3.Text = dt.Rows[2].ItemArray[0].ToString();
            }

        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    FillStockCardDetails(StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.CurrentValue)); 
        //}
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
