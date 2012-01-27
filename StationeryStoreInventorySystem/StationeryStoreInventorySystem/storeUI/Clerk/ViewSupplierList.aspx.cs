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
    public partial class ViewSupplierList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewSupplierListControl VSobj = new ViewSupplierListControl();
                DataTable dt = VSobj.GetAllSuppliers();
                FillSupplierList(dt);
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillSupplierList(DataTable dtSupplier)
        {
            try
            {
                if (dtSupplier != null)
                {
                    DgvSupplierList.DataSource = dtSupplier;
                    DgvSupplierList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}