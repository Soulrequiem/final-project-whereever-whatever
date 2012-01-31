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
        private ViewStationeryCatalogueControl viewStationeryCatalogueControl;

        /// <summary>
        /// Loads the ViewStationeryCatalogue form
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ItemNo");
            //dt.Columns.Add("Category");
            //dt.Columns.Add("ItemDescription");
            //dt.Columns.Add("UnitOfMeasure");            

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvStationeryList.DataSource = dt;
            //dgvStationeryList.DataBind();

            if (!IsPostBack)
            {
                viewStationeryCatalogueControl = new ViewStationeryCatalogueControl();
                this.FillStationeryList(viewStationeryCatalogueControl.ItemList);
                //FillStationeryList();
                //FillItems();
            }
            
        }

        /// <summary>
        /// Fills data to datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillStationeryList(DataTable dtStationery)
        {
            try
            {
                dgvStationeryList.DataSource = dtStationery;
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
                DataTable dtItems = (DataTable)Session["Items"];
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
        /// Fills changed item to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdItemList_SelectionChanged(object sender, 
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedItem = drdItemList.SelectedItem.Text;
                //Pass to the controller get Datatable
                //Call FillStationeryList function
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }           
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/