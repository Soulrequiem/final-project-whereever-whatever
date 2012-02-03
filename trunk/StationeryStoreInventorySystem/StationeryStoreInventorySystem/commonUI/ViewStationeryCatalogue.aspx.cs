/***************************************************************************/
/*  File Name       : ViewStationeryCatalogue.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ViewStationeryCatalogue
/*  Details         : Form for View Stationery Catalogue
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.commonController;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ViewStationeryCatalogue : System.Web.UI.Page
    {

        ViewStationeryCatalogueControl vsCtrl;

        private ViewStationeryCatalogueControl viewStationeryCatalogueControl;

        /// <summary>
        /// Loads the ViewStationeryCatalogue form
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                FillStationeryList(StationeryStoreInventorySystemController.Util.GetItemTable());
                FillItems();

                viewStationeryCatalogueControl = new ViewStationeryCatalogueControl();
                this.FillStationeryList(StationeryStoreInventorySystemController.Util.GetItemTable());
                //FillStationeryList();
                FillItems();

            }
            
        }

        private ViewStationeryCatalogueControl getControl()
        {
            if(vsCtrl == null)
                vsCtrl = new ViewStationeryCatalogueControl();
            return vsCtrl;
        }



        /// <summary>
        /// Fills data to datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillStationeryList(DataTable dt)
        {
            try
            {
                //string itemDescription = drdItemList.SelectedItem.Text;
                //vsCtrl = getControl();
                //DataTable dtStationery;
                //if (itemDescription==null)
                //{
                //    dtStationery = vsCtrl.AllItemList;
                //}else
                //    dtStationery=vsCtrl.ItemList(itemDescription);
                dgvStationeryList.DataSource = dt;
                dgvStationeryList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
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
                DataTable dtItems = StationeryStoreInventorySystemController.Util.GetItemTable();
                if (dtItems != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ItemNo";
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
        /// Fills changed item to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void drdItemList_SelectionChanged(object sender, 
        //    Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        String selectedItem = drdItemList.SelectedItem.Text;
        //        vsCtrl = getControl();
        //        DataTable dtStationery = vsCtrl.ItemList;
        //        dgvStationeryList.DataSource = dtStationery;
        //        dgvStationeryList.DataBind();
        //        //Pass to the controller get Datatable

        //        //Call FillStationeryList function according the item list
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteErrorLog(ex);
        //    }    
       
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string selectedItem = drdItemList.SelectedItem.Text;
                //vsCtrl = getControl();
                //DataTable dtStationery = vsCtrl.ItemList(selectedItem);
                FillStationeryList(StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.CurrentValue)); 
                //dgvStationeryList.DataSource = dtStationery;
                //dgvStationeryList.DataBind();
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/