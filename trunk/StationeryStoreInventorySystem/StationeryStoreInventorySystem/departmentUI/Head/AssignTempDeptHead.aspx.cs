/***************************************************************************/
/*  File Name       : AssignTempDeptHead.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : AssignTempDeptHead
/*  Details         : Form for Assign Department Head
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class AssignTempDeptHead : System.Web.UI.Page
    {
        AssignTemporaryDepartmentHeadControl atdrCtrl;
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
                FillHeadList();
                //FillEmployee();
            }
        }

        /// <summary>
        /// Fills current head list
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillHeadList()
        {
            try
            {
                atdrCtrl = GetControl();
                DataTable dtHead = atdrCtrl.TemporaryDepartmentHead;
                DgvCurrentAuthorizedPerson.DataSource = dtHead;
                DgvCurrentAuthorizedPerson.DataBind();
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
                //if (dtEmployee != null)
               
                   //To be done
                   //adrCtrl = new AssignDepartmentRepresentativeControl();
                   //adrCtrl.
                    drdHeadEmployeeList.TextField = "Employee";
                    drdHeadEmployeeList.ValueField = "Name";
                    drdHeadEmployeeList.DataSource = null; //dtEmployee;
                    drdHeadEmployeeList.DataBind();
               
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
        protected void drdHeadEmployeeList_SelectionChanged(object sender,
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedEmployee = drdHeadEmployeeList.SelectedItem.Text;
                atdrCtrl = GetControl();
                DataTable dt = atdrCtrl.SelectEmployeeName(selectedEmployee);
                DgvTempDepteHeadSearchDetails.DataSource = dt;
                DgvTempDepteHeadSearchDetails.DataBind();
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private AssignTemporaryDepartmentHeadControl GetControl()
        {
            if (atdrCtrl == null)
                atdrCtrl = new AssignTemporaryDepartmentHeadControl();
            return atdrCtrl;
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            atdrCtrl = GetControl();
            atdrCtrl.SelectAssign(Convert.ToInt16(assign_employeeID));
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            atdrCtrl = GetControl();
            atdrCtrl.SelectRemove(Convert.ToInt16(remove_employeeID));
        }

        protected void DgvTempDepteHeadSearchDetails_RowSelectionChanged(object sender, 
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            assign_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"];
        }

        protected void DgvCurrentAuthorizedPerson_RowSelectionChanged(object sender, 
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            remove_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"];
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/