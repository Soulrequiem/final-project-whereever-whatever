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
        CheckRequisitionControl rqCtrl = null;
        private RequisitionDetailsControl aprCtrl;

        private CheckRequisitionControl getControl()
        {
            if (rqCtrl == null)
                rqCtrl = new CheckRequisitionControl();
            return rqCtrl;
        }

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
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Visible = true;
                    lblRemarks.Visible = false;
                    txtaRemarks.Visible = false;
                    lnkback.Visible = true;
                    lnkback.NavigateUrl = "~/departmentUI/Representative/UpdateCollectionByRequisitions.aspx";
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
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode");
            dt.Columns.Add("RequiredQty");
            dt.Columns.Add("deliveredQty");
            for (int i = 0; i < DgvRequisitionDetails.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = DgvRequisitionDetails.Rows[i].Items[0].Text;
                dr[1] = DgvRequisitionDetails.Rows[i].Items[2].Text;
                dr[2] = "0";
                dt.Rows.Add(dr);
            }
            getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.APPROVED, txtaRemarks.Text, dt);
            gotoApprovePage();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            getApprRejectControl().Setstatus(lblRequisitionID.Text, Constants.REQUISITION_STATUS.REJECTED, txtaRemarks.Text, null);
            gotoApprovePage();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void received_textChanged(object sender, EventArgs e)
        {
            string s = string.Empty;
        }

        private void gotoApprovePage()
        {
            Response.Redirect("~/departmentUI/Head/ApproveRequisition.aspx");
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/