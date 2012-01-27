/***************************************************************************/
/*  File Name       : RequisitionDetails.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : RequisitionDetails
/*  Details         : Form for Requisition Details
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class RequisitionDetails : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the RequisitionDetails form
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ItemNo");
            //dt.Columns.Add("ItemDescription");
            //dt.Columns.Add("RequiredQty");
           

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dt.Rows.Add(dr);

            //DgvRequisitionDetails.DataSource = dt;
            //DgvRequisitionDetails.DataBind();

            if (!IsPostBack)
            {
                //FillRequisitionDetailsList();
                //FillDetails();
            }

        }

        /// <summary>
        /// Fill Data of Labels
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillRequsitionDetils(DataTable dtDetails)
        {
            try
            {
                if (dtDetails != null)
                {
                    lblRequisitionDate.Text = "Date";
                    lblRequisitionID.Text = "ID";
                    lblDeptCode.Text = "Department Code";
                    LblDeptName.Text = "Department Name";
                    LblDeptName.Text = "Employee Name";
                    lblEmployeeNumber.Text = "Employee Number";
                    lblEmpEmailAddress.Text = "Employee EmailAddress";
                    //drdItemList.ValueField = "ID";
                    //drdItemList.DataSource = dtDetails;
                    //drdItemList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fill data to DataGrid
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillRequisitionDetailsList(DataTable dtRequisition)
        {
            try
            {
                DgvRequisitionDetails.DataSource = dtRequisition;
                DgvRequisitionDetails.DataBind();
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