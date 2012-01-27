using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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