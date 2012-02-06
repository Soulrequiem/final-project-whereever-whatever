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


namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class GenerateDisbursement : System.Web.UI.Page
    {
        private static readonly string sessionKey = "GenerateDisbursement";

        private GenerateDisbursementControl generateDisbursementControl;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                generateDisbursementControl = new GenerateDisbursementControl();
                //GenerateDisbursementControl GDobj = new GenerateDisbursementControl();
                //DataTable dt = GDobj.GetDisbursementList();
                FillDisbursementList(generateDisbursementControl.RetrievalList);

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
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
