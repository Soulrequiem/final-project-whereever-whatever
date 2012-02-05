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
using StationeryStoreInventorySystemController;


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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["PrintData"] = new DataTable();
            Util.PutSession("ReportType", "Stationery");
            Util.PutSession("RequisitionID", lblRequisitionID.Text);
            Util.PutSession("DeptName", LblDeptName.Text);
            Util.PutSession("DeptCode" , lblDeptCode.Text);
            Util.PutSession("EmployeeName" , lblEmployeeName.Text);
            Util.PutSession("EmployeeNumber", lblEmployeeNumber.Text);
            Util.PutSession("Email", lblEmpEmailAddress.Text);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Myscript", "<script language='javascript'> " +
                   "window.open('../commonUI/PrintView.aspx');</script>");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/