/***************************************************************************/
/*  File Name       : ApproveRequisition.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ApproveRequisition
/*  Details         : Form for Approve Requisition
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class ApproveRequisition : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the ApproveRequisition form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ApproveRequisitionCheckBox");
            //dt.Columns.Add("RequisitionID");
            //dt.Columns.Add("RequisitionDate/Time");
            //dt.Columns.Add("RequisitionBy");
            //dt.Columns.Add("RequisitionQty");
            //dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dr[4] = "1dsfdsfsdf";
            ////dr[5] = "iwojfowi";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dr[4] = "1dsfdsfsdf";
            ////dr[5] = "jfiwofj";
            //dt.Rows.Add(dr);

            //DgvRequisitionList.DataSource = dt;
            //DgvRequisitionList.DataBind();

            if (!IsPostBack)
            {
                //FillRequisitionList();
            }
        }

        /// <summary>
        /// Fill data to DataGrid
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillRequisitionList(DataTable dtApprove)
        {
            try
            {
                DgvRequisitionList.DataSource = dtApprove;
                DgvRequisitionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/