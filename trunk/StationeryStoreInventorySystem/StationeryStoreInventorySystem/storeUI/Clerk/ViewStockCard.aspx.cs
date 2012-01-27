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
                FillItems();
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
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

        /// <summary>
        /// Selected item from item drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdItemList_SelectionChanged(object sender,
        Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedItem = drdItemList.SelectedItem.Text;
                ViewStockCardControl VSCobj = new ViewStockCardControl();
                DataTable dt = VSCobj.GetStockCardDetails(selectedItem);
                FillStockCardDetails(dt);
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }

        }

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
    }
}