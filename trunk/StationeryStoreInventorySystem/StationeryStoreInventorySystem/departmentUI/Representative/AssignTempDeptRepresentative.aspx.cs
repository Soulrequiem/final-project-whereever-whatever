/***************************************************************************/
/*  File Name       : AssignTempDeptHead.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : AssignTempDeptHead
/*  Details         : Form for Assign Temporary Deptment Representative
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;
using StationeryStoreInventorySystemController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class AssignTempDeptHead : System.Web.UI.Page
    {
        AssignTemporaryDepartmentRepresentativeControl atdrCtrl;
        String remove_employeeID;
        String assign_employeeID;
        /// <summary>
        /// Loads the AssignTempDeptHead form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEmployee();
            }
            FillCurrentRepresentativeList();
        }

        /// <summary>
        /// Fills current Representative list
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillCurrentRepresentativeList()
        {
            try
            {
                //atdrCtrl = GetControl();
                //DataTable dtRepresentative = atdrCtrl.TemporaryDepartmentRepresentative;
                DgvCurrentAuthorizedPersonRep.DataSource = Util.GetCurrentTemporaryRepresentative();
                DgvCurrentAuthorizedPersonRep.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Employee name
        /// </summary>
        private void FillEmployee()
        {
            try
            {

                drdEmployeeList.DataSource = Util.GetEmployeesByDepartments();
                drdEmployeeList.DataBind();
                
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills selected changed employee to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdEmployeeList_SelectionChanged(object sender,
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedEmployee = drdEmployeeList.SelectedItem.Text;
                atdrCtrl = GetControl();
                DataTable dt = atdrCtrl.SelectEmployeeName(selectedEmployee);
                DgvTempDepteHeadSearchDetails.DataSource = dt;
                DgvTempDepteHeadSearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private AssignTemporaryDepartmentRepresentativeControl GetControl()
        {
            if (atdrCtrl == null)
                atdrCtrl = new AssignTemporaryDepartmentRepresentativeControl();
            return atdrCtrl;
        }

        protected void DgvCurrentAuthorizedPersonRep_RowSelectionChanged(object sender,
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            //remove_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
        }

        protected void DgvTempDepteHeadSearchDetails_RowSelectionChanged(object sender,
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            assign_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            atdrCtrl = GetControl();
            //atdrCtrl.SelectRemove(Convert.ToInt16(remove_employeeID));
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            atdrCtrl = GetControl();
            atdrCtrl.SelectAssign(Convert.ToInt16(assign_employeeID));
        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            DgvTempDepteHeadSearchDetails.DataSource = Util.GetEmployeeDetails(drdEmployeeList.CurrentValue);
            DgvTempDepteHeadSearchDetails.DataBind();
        }

        protected void DgvTempDepteHeadSearchDetails_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillCurrentRepresentativeList();
        }

        protected void DgvTempDepteHeadSearchDetails_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillCurrentRepresentativeList();
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/