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

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class AssignTempDeptHead : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the AssignTempDeptHead form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("BoundCheckBoxField_0");
            //dt.Columns.Add("EmployeeID");
            //dt.Columns.Add("EmployeeName");
            //dt.Columns.Add("Designation");
            //dt.Columns.Add("JoiningDate");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //DgvCurrentAuthorizedPerson.DataSource = dt;
            //DgvCurrentAuthorizedPerson.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("BoundCheckBoxField_0");
            //dtt.Columns.Add("EmployeeID");
            //dtt.Columns.Add("EmployeeName");
            //dtt.Columns.Add("Designation");
            //dtt.Columns.Add("JoiningDate");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //DgvTempDepteHeadSearchDetails.DataSource = dtt;
            //DgvTempDepteHeadSearchDetails.DataBind();

            if (!IsPostBack)
            {
                //FillHeadList();
                //FillEmployee();
            }
        }

        /// <summary>
        /// Fills current head list
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillHeadList(DataTable dtHead)
        {
            try
            {
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
        private void FillEmployee(DataTable dtEmployee)
        {
            try
            {
                if (dtEmployee != null)
                {
                    drdHeadEmployeeList.TextField = "Employee";
                    drdHeadEmployeeList.ValueField = "Name";
                    drdHeadEmployeeList.DataSource = dtEmployee;
                    drdHeadEmployeeList.DataBind();
                }
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
                //Pass to the controller get Datatable
                //Call FillStationeryList function
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/