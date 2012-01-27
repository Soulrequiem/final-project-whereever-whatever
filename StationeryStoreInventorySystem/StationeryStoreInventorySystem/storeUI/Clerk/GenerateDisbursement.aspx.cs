﻿using System;
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
                //GenerateDisbursementControl GDobj = new GenerateDisbursementControl();
                //DataTable dt = GDobj.GetDisbursementList();
                //FillDisbursementList();
            }
        }

        private void FillDisbursementList(DataTable dtDisbursementList)
        {
            try
            {
                if (dtDisbursementList != null)
                    DgvGenerateDisbursement.DataSource = dtDisbursementList;
                DgvGenerateDisbursement.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}