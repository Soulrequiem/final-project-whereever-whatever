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

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class AssignDeptRespresentative : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the AssignDeptRespresentative form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("BoundCheckBoxField_0");
            //dt.Columns.Add("RepresentativeID");
            //dt.Columns.Add("RepresentativeName");
            //dt.Columns.Add("Actual/Temporary");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //DgvCurrentDeptRepresentative.DataSource = dt;
            //DgvCurrentDeptRepresentative.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("BoundCheckBoxField_0");
            //dtt.Columns.Add("EmployeeID");
            //dtt.Columns.Add("EmployeeName");
            ////dtt.Columns.Add("Designation");
            ////dtt.Columns.Add("JoiningDate");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //DgvRepSearchDetails.DataSource = dtt;
            //DgvRepSearchDetails.DataBind();

            if (!IsPostBack)
            {
                //FillRepresentativeList();
                //FillEmployee();
            }
        }

        /// <summary>
        /// Fills current representative list
        /// </summary>
        /// <param name="dtApprove"></param>
       private void FillRepresentativeList(DataTable dtRep)
        {
            try
            {
                DgvCurrentDeptRepresentative.DataSource = dtRep;
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
        private void FillEmployee(DataTable dtEmployee)
       {
           try
           {
               if (dtEmployee != null)
               {
                   drdRepEmployeeList.TextField = "Employee";
                   drdRepEmployeeList.ValueField = "Name";
                   drdRepEmployeeList.DataSource = dtEmployee;
                   drdRepEmployeeList.DataBind();
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
       protected void drdRepEmployeeList_SelectionChanged(object sender,
           Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedEmployee = drdRepEmployeeList.SelectedItem.Text;
                //Pass to the controller get Datatable
                //Call FillStationeryList function
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/