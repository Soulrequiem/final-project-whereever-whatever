/***************************************************************************/
/*  File Name       : AssignDeptRespresentative.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : AssignDeptRespresentative
/*  Details         : Form for Assign Department Representative
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
    public partial class AssignDeptRespresentative : System.Web.UI.Page
    {
        AssignDepartmentRepresentativeControl adrCtrl;
        String remove_employeeID;
        String assign_employeeID;
        /// <summary>
        /// Loads the AssignDeptRespresentative form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRepresentativeList();
                FillEmployee();
            }
        }

        /// <summary>
        /// Fills current representative list
        /// </summary>
        /// <param name="dtApprove"></param>
       private void FillRepresentativeList()
        {
            try
            {
                adrCtrl = GetControl();
                DataTable dt = adrCtrl.DepartmentRepresentative;
                DgvCurrentDeptRepresentative.DataSource = dt;
                DgvCurrentDeptRepresentative.DataBind();
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
                   //adrCtrl = new AssignDepartmentRepresentativeControl();
                   //adrCtrl.
                   drdRepEmployeeList.TextField = "Employee";
                   drdRepEmployeeList.ValueField = "Name";
                   drdRepEmployeeList.DataSource = null;// dtEmployee;
                   drdRepEmployeeList.DataBind();
               //}
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
       protected void drdRepEmployeeList_SelectionChanged(object sender,
           Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedEmployee = drdRepEmployeeList.SelectedItem.Text;
                adrCtrl = new AssignDepartmentRepresentativeControl();
                DataTable dtEmployees = adrCtrl.SelectEmployeeName(selectedEmployee);
                DgvRepSearchDetails.DataSource = dtEmployees;
                DgvRepSearchDetails.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

       protected void btnRemove_Click(object sender, EventArgs e)
       {
           adrCtrl = GetControl();
           adrCtrl.SelectRemove(Convert.ToInt16(remove_employeeID));
       }

       protected void btnAssign_Click(object sender, EventArgs e)
       {
           adrCtrl = new AssignDepartmentRepresentativeControl();
           adrCtrl.SelectAssign(Convert.ToInt16(assign_employeeID));
       }

       protected void DgvCurrentDeptRepresentative_RowSelectionChanged(object sender, 
           Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
       {
           remove_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
       }

       protected void DgvRepSearchDetails_RowSelectionChanged(object sender,
         Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
       {
           assign_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
       }

       private AssignDepartmentRepresentativeControl GetControl()
       {
           if (adrCtrl == null)
               adrCtrl = new AssignDepartmentRepresentativeControl();
           return adrCtrl;
       }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/