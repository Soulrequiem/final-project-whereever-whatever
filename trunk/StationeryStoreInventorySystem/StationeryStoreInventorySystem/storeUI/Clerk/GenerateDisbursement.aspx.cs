/***************************************************************************/
/*  File Name       : GenerateDisbursement.cs
/*  Module Name     : UI
/*  Owner           : JinChengCheng
/*  class Name      : GenerateDisbursement
/*  Details         : UI representation of GenerateDisbursementUI 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;
using Infragistics.Web.UI.GridControls;


namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class GenerateDisbursement : System.Web.UI.Page
    {
        private static readonly string sessionKey = "GenerateDisbursement";

        private GenerateDisbursementControl generateDisbursementControl;

        private string disbursement;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                generateDisbursementControl = new GenerateDisbursementControl();
                //GenerateDisbursementControl GDobj = new GenerateDisbursementControl();
                //DataTable dt = GDobj.GetDisbursementList();
                FillDisbursementList(generateDisbursementControl.RetrievalList);
                //FillCollectionList(generateDisbursementControl.CollectionPointList);

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, generateDisbursementControl);
            }
            else
            {
                generateDisbursementControl = (GenerateDisbursementControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

            }
        }

        /// <summary>
        ///     Show disbursement list
        ///     Created By:JinChengCheng
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="dtDisbursementList"></param>
        /// <returns>The return type of this method is datatable.</returns>
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

        ///// <summary>
        ///// Fills Collection list to DataGrid
        ///// </summary>
        ///// <param name="dtCollection"></param>
        //private void FillCollectionList(DataTable dtCollection)
        //{
        //    try
        //    {
        //        if (dtCollection != null)
        //        {
        //            //drdCollectionPoint.TextField = "CollectionPoint";
        //            //drdCollectionPoint.ValueField = "CollectionID";
        //            //drdCollectionPoint.DataSource = dtCollection;
        //            //drdCollectionPoint.DataBind();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.WriteErrorLog(e);
        //    }
        //}

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (DgvGenerateDisbursement.Behaviors.Selection.SelectedRows.Count > 0)
                foreach (GridRecord selectedRow in DgvGenerateDisbursement.Behaviors.Selection.SelectedRows)
                    disbursement = selectedRow.DataKey[0].ToString();

            if (disbursement != String.Empty || disbursement == null)
            {
                GenerateDisbursementPanel.Visible = true;
                RetrievalPanel.Visible = false;

                lblRetrievalNo.Text = disbursement;
            }
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/
