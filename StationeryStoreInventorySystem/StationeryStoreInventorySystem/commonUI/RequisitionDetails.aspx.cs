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
using StationeryStoreInventorySystemController.commonController;
using StationeryStoreInventorySystemController.departmentController;
using SystemStoreInventorySystemUtil;


namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class RequisitionDetails : System.Web.UI.Page
    {
        private RequisitionDetailsControl aprCtrl;

        private RequisitionDetailsControl getApprRejectControl()
        {
            if (aprCtrl == null)
                aprCtrl = new RequisitionDetailsControl();
            return aprCtrl;
        }

        /// <summary>
        /// Loads the RequisitionDetails form
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqID = Request.QueryString["ReqID"].ToString();
            if (!IsPostBack)
            {
                int roleID = Util.GetEmployeeRole();
                if ((int)Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD == roleID ||
                    (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD == roleID)
                {
                    CheckBox1.Visible = false;
                    DgvRequisitionDetails.Columns[3].Hidden = true;
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                    btnSave.Visible = false;
                    lblRemarks.Visible = true;
                    txtaRemarks.Visible = true;
                    lnkback.Visible = true;
                    lnkback.NavigateUrl = "~/departmentUI/Head/ApproveRequisition.aspx";
                    lnkback.Text = "Back to Approve/Reject Requisitions";
                }
                else if ((int)Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE == roleID ||
                    (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE == roleID)
                {
                    CheckBox1.Visible = true;
                    DgvRequisitionDetails.Columns[3].Hidden = false;
                    DgvRequisitionDetails.Behaviors.EditingCore.Behaviors.CellEditing.ColumnSettings[2].ReadOnly = true;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Visible = true;
                    lblRemarks.Visible = false;
                    txtaRemarks.Visible = false;
                    lnkback.Visible = true;
                    lnkback.NavigateUrl = "~/departmentUI/Representative/UpdateCollectionByRequisitions.aspx?CollectionIdIndex='"+Session["CollectionIdIndex"].ToString();
                    lnkback.Text = "Back to Update collections by Requisitions";
                }
                FillRequsitionDetils(reqID);
                //FillDetails();
            }

        }

        /// <summary>
        /// Fill Data of Labels
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillRequsitionDetils(string reqID)
        {
            try
            {
                if (Constants.ACTION_STATUS.SUCCESS == getApprRejectControl().SelectRequisitionID(reqID))
                {
                    DataTable dtReqDetails = getApprRejectControl().RequisitionDetail;
                    DataTable dtDetails = getApprRejectControl().getRequisition(reqID);
                    if (dtDetails != null && dtDetails.Rows.Count > 0)
                    {
                        //lblRequisitionDate.Text = dtDetails.Rows[0]["requisitionDate/Time"].ToString();
                        lblRequisitionID.Text = dtDetails.Rows[0]["requisitionId"].ToString();
                        lblDeptCode.Text = dtDetails.Rows[0]["deptCode"].ToString();
                        LblDeptName.Text = dtDetails.Rows[0]["deptName"].ToString();
                        lblEmployeeName.Text = dtDetails.Rows[0]["empName"].ToString();
                        lblEmployeeNumber.Text = dtDetails.Rows[0]["empNumber"].ToString();
                        lblEmpEmailAddress.Text = dtDetails.Rows[0]["empEmail"].ToString();

                        FillRequisitionDetailsList(dtReqDetails);
                    }
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
            if (ValidateScreen())
            {
                getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.APPROVED, txtaRemarks.Text, getItemQuantities());
                gotoApprovePage();
            }
        }

        private DataTable getItemQuantities()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode");
            dt.Columns.Add("RequiredQty");
            dt.Columns.Add("deliveredQty");
            for (int i = 0; i < DgvRequisitionDetails.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = DgvRequisitionDetails.Rows[i].Items[0].Text;
                dr[1] = DgvRequisitionDetails.Rows[i].Items[2].Text;
                dr[2] = DgvRequisitionDetails.Rows[i].Items[3].Text;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (txtaRemarks.Text != string.Empty)
            {
                getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.REJECTED, txtaRemarks.Text, null);
                gotoApprovePage();
            }
            else
                lblStatusMessage.Text = "Please enter remarks.";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                if (CheckBox1.Checked)
                    getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.COMPLETE, string.Empty, getItemQuantities());
                else
                    getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.SUBMITTED, string.Empty, getItemQuantities());

                gotoUpdateCollectionsByRequisitionsPage();
            }
        }

        private bool ValidateScreen()
        {
            int isNumber = 0;
            bool isQuantityMatched = false;
            for (int i = 0; i < DgvRequisitionDetails.Rows.Count; i++)
            {
                if(int.TryParse(DgvRequisitionDetails.Rows[i].Items[2].Text, out isNumber) == false ||
                   int.TryParse(DgvRequisitionDetails.Rows[i].Items[3].Text, out isNumber) == false )
                {
                    lblStatusMessage.Text = "Invalid quantity.";
                    return false;
                }
                else if (Convert.ToInt16(DgvRequisitionDetails.Rows[i].Items[2].Text) <
                    Convert.ToInt16(DgvRequisitionDetails.Rows[i].Items[3].Text))
                {
                    lblStatusMessage.Text = "Delivered quantity can not be greater than required quantity.";
                    return false;
                }
                else if (Convert.ToInt16(DgvRequisitionDetails.Rows[i].Items[3].Text) < 0 ||
                    Convert.ToInt16(DgvRequisitionDetails.Rows[i].Items[2].Text) < 0)
                {
                    lblStatusMessage.Text = "Invalid quantity.";
                    return false;
                }
                else if (DgvRequisitionDetails.Rows[i].Items[2].Text == DgvRequisitionDetails.Rows[i].Items[3].Text)
                    isQuantityMatched = true;
                else
                    isQuantityMatched = false;
            }
            if (CheckBox1.Checked && !isQuantityMatched)
            {
                lblStatusMessage.Text = "Delivered quantity is still not matched with the required quantity. Requisition can not be completed.";
                return false;
            }
            else if (!CheckBox1.Checked && isQuantityMatched)
            {
                lblStatusMessage.Text = "Please check 'Complete Requisition'.";
                return false;
            }
            return true;
        }

        private void gotoApprovePage()
        {
            Response.Redirect("~/departmentUI/Head/ApproveRequisition.aspx");
        }

        private void gotoUpdateCollectionsByRequisitionsPage()
        {
            Response.Redirect("~/departmentUI/Representative/UpdateCollectionByRequisitions.aspx");
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/