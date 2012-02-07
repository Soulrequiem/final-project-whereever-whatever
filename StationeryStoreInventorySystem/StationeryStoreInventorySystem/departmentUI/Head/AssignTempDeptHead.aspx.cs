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
using StationeryStoreInventorySystemController;
using Infragistics.Web.UI.GridControls;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class AssignTempDeptHead : System.Web.UI.Page
    {
        private static readonly string sessionKey = "AssignTempDeptHead";
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
                FillEmployee();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, atdrCtrl);
            }
            else
            {
                atdrCtrl = (AssignTemporaryDepartmentHeadControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillHeadList();
        }

        /// <summary>
        /// Fills current head list
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillHeadList()
        {
            try
            {
                //atdrCtrl = GetControl();
                //DataTable dtHead = atdrCtrl.TemporaryDepartmentHead;
                DgvCurrentAuthorizedPerson.DataSource = Util.GetCurrentTemporaryHead();
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
                drdHeadEmployeeList.DataSource = Util.GetEmployeesByDepartments();
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
                    if (DgvTempDepteHeadSearchDetails.Behaviors.Selection.SelectedRows.Count > 0)
                    {
                        DataTable dt = Util.GetCurrentTemporaryHead();
                        if (dt!= null && dt.Rows.Count > 0)
                    {
                        lblStatusMessage.Text = "Please remove current head first.";
                        return;
                    }
                    //DataRow[] dr = dt.Select(" RepresentativeName = '" + DgvTempDepteHeadSearchDetails.Behaviors.Selection.SelectedRows[0].Items[1].ToString() + "'");
                    //if (dr.Length > 0)
                    //{
                    //    lblStatusMessage.Text = "Selected employee is already a representative";
                    //    return;
                    //}
                        foreach (GridRecord select in DgvTempDepteHeadSearchDetails.Behaviors.Selection.SelectedRows)
                            assign_employeeID = select.Items.GetValue(0).ToString();
                    atdrCtrl = GetControl();
                    atdrCtrl.SelectAssign(Convert.ToInt16(assign_employeeID));
                    DgvTempDepteHeadSearchDetails.ClearDataSource();                    
                    FillHeadList();
                    drdHeadEmployeeList.ClearSelection();
            }
            else
                lblStatusMessage.Text = "Please select the employee to assign.";
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (DgvCurrentAuthorizedPerson.Behaviors.Selection.SelectedRows.Count > 0)
            {
                foreach (GridRecord selectedRow in DgvCurrentAuthorizedPerson.Behaviors.Selection.SelectedRows)
                    remove_employeeID = selectedRow.Items.GetValue(0).ToString();
                atdrCtrl = GetControl();
                atdrCtrl.SelectRemove(Convert.ToInt16(remove_employeeID));
                FillHeadList();
            }
            else
                lblStatusMessage.Text = "Please select employee to remove.";
        }

        //protected void DgvTempDepteHeadSearchDetails_RowSelectionChanged(object sender, 
        //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    assign_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"];
        //}

        //protected void DgvCurrentAuthorizedPerson_RowSelectionChanged(object sender, 
        //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    remove_employeeID = e.CurrentSelectedRows[0].Attributes["EmployeeID"];
        //}

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(drdHeadEmployeeList.SelectedValue) != "")
                {
                    DgvTempDepteHeadSearchDetails.DataSource = Util.GetEmployeeDetails(drdHeadEmployeeList.CurrentValue);
                    DgvTempDepteHeadSearchDetails.DataBind();
                }
                else
                    lblStatusMessage.Text = "Choose one employee to assign.";
            }
            catch (Exception ex)
            {
                //print something
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/