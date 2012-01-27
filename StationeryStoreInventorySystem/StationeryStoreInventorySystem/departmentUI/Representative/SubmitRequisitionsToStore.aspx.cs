/***************************************************************************/
/*  File Name       : SubmitRequisitionsToStore.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : SubmitRequisitionsToStore
/*  Details         : Form for Submit Requisitions To Store
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class SubmitRequisitionsToStore : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the SubmitRequisitionsToStore form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            ////dt.Columns.Add("EmployeeID");
            //dt.Columns.Add("RequisitionID");
            //dt.Columns.Add("RequisitionDateTime");
            //dt.Columns.Add("RequisitionBy");
            //dt.Columns.Add("RequisitionStatus");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1vdvd";
            //dr[1] = "1dvd";
            //dr[2] = "1dvdv";
            //dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1dafd";
            //dr[1] = "1vdv";
            //dr[2] = "1vdvd";
            //dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvRequisitions.DataSource = dt;
            //dgvRequisitions.DataBind();

            if (!IsPostBack)
            {
                //FillRequisitionList();
                //FillRequsitionData();
            }
        }

        /// <summary>
        /// Fill Data of Labels
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillRequsitionData(DataTable dtData)
        {
            try
            {
                if (dtData != null)
                {
                    lblCollectionID.Text = "ID";
                    lblCollectionPoint.Text = "Point";
                    //lblDeptCode.Text = "Department Code";
                    //LblDeptName.Text = "Department Name";
                    //LblDeptName.Text = "Employee Name";
                    //lblEmployeeNumber.Text = "Employee Number";
                    //lblEmpEmailAddress.Text = "Employee EmailAddress";
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
        /// Fills Requisition list to DataGrid
        /// </summary>
        /// <param name="dtCollection"></param>
        private void FillRequisitionList(DataTable dtRequisition)
        {
            try
            {
                dgvRequisitions.DataSource = dtRequisition;
                dgvRequisitions.DataBind();
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