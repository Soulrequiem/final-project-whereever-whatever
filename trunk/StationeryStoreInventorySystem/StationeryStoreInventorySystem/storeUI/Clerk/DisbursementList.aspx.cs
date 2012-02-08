using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StationeryStoreInventorySystemController.commonController;
using System.Data;

namespace StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class DisbursementList : System.Web.UI.Page
    {
        GenerateReportsControl grCtrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null != Request.QueryString["retrievalID"] &&
                    null != Request.QueryString["date"])
                {
                    grCtrl = new GenerateReportsControl();
                    DataTable dt = grCtrl.getDisbursment(Request.QueryString["date"].ToString(), Request.QueryString["retrievalID"].ToString());
                    if(dt != null && dt.Rows.Count > 0)
                    {
                        DgvDisbursementList.DataSource = dt;
                        DgvDisbursementList.DataBind();
                        lblDate.Text = Request.QueryString["date"].ToString();
                    }
                }
            }
        }
    }
}