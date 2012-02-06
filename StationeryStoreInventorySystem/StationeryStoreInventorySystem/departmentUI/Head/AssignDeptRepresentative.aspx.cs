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
using StationeryStoreInventorySystemController;
using Infragistics.Web.UI.GridControls;


namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class AssignDeptRespresentative : System.Web.UI.Page
    {
        private static readonly string sessionKey = "AssignDeptRepresentative";
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
                FillEmployee();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, adrCtrl);
            }
            else
            {
                adrCtrl = (AssignDepartmentRepresentativeControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillRepresentativeList();
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        /// <summary>
        /// Fills current representative list
        /// </summary>
        /// <param name="dtApprove"></param>
       private void FillRepresentativeList()
        {
            try
            {
                //adrCtrl = GetControl();
                //DataTable dt = adrCtrl.DepartmentRepresentative;
                DgvCurrentDeptRepresentative.DataSource = Util.GetCurrentRepresentative();
                DgvCurrentDeptRepresentative.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

       /// <summary>
       /// Fills Employee name to drop down
       /// </summary>
       private void FillEmployee()
       {
           try
           {
               drdRepEmployeeList.DataSource = Util.GetEmployeesByDepartments();
               drdRepEmployeeList.DataBind();          
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
           if (DgvCurrentDeptRepresentative.Behaviors.Selection.SelectedRows.Count > 0)
               foreach (GridRecord selectedRow in DgvCurrentDeptRepresentative.Behaviors.Selection.SelectedRows)
                   remove_employeeID = selectedRow.Items.GetValue(0).ToString();
           adrCtrl = GetControl();
           adrCtrl.SelectRemove(Convert.ToInt16(remove_employeeID));
           DgvCurrentDeptRepresentative.ClearDataSource();
       }

       protected void btnAssign_Click(object sender, EventArgs e)
       {
           if (DgvRepSearchDetails.Behaviors.Selection.SelectedRows.Count > 0)
               foreach (GridRecord select in DgvRepSearchDetails.Behaviors.Selection.SelectedRows)
                   assign_employeeID = select.Items.GetValue(0).ToString();
           adrCtrl = new AssignDepartmentRepresentativeControl();
           adrCtrl.SelectAssign(Convert.ToInt16(assign_employeeID));
           DgvRepSearchDetails.ClearDataSource();
           FillRepresentativeList();
       }

       //protected void DgvCurrentDeptRepresentative_RowSelectionChanged(object sender, 
       //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
       //{
       //    remove_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
       //}

       //protected void DgvRepSearchDetails_RowSelectionChanged(object sender,
       //  Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
       //{
       //    assign_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"].ToString();
       //}

       private AssignDepartmentRepresentativeControl GetControl()
       {
           if (adrCtrl == null)
               adrCtrl = new AssignDepartmentRepresentativeControl();
           return adrCtrl;
       }

       protected void btnEmployee_Click(object sender, EventArgs e)
       {
           DgvRepSearchDetails.DataSource = Util.GetEmployeeDetails(drdRepEmployeeList.CurrentValue);
           DgvRepSearchDetails.DataBind();
       }

       protected void DgvRepSearchDetails_DataFiltering(object sender,
           Infragistics.Web.UI.GridControls.FilteringEventArgs e)
       {
           FillRepresentativeList();
       }

       protected void DgvRepSearchDetails_PageIndexChanged(object sender,
           Infragistics.Web.UI.GridControls.PagingEventArgs e)
       {
           FillRepresentativeList();
       }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/