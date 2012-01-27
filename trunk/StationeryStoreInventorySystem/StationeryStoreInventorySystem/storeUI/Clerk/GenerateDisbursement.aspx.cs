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
    public partial class GenerateDisbursement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ge
                FillGridView();
            }
        }

        private void FillGridView(DataTable dt)
        {
            DgvGenerateDisbursement.DataSource = dt;
            DgvGenerateDisbursement.DataBind();
        }
    }
}