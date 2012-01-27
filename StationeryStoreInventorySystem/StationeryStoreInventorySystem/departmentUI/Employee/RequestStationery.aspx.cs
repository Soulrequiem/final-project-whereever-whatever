/***************************************************************************/
/*  File Name       : RequestStationery.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : RequestStationery
/*  Details         : Form for Request Stationery
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the RequestStationery form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ItemNo");
            //dt.Columns.Add("ItemDescription");
            ////dt.Columns.Add("AddToTable");
            ////dt.Columns.Add("status");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            ////dr[2] = "1";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            ////dr[2] = "1";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvStationeryList.DataSource = dt;
            //dgvStationeryList.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("RequestStationeryCheckBox");
            //dtt.Columns.Add("ItemNo");
            //dtt.Columns.Add("ItemDescription");
            //dtt.Columns.Add("RequiredQty");
            ////dt.Columns.Add("status");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //dgvStationeryDetailsList.DataSource = dtt;
            //dgvStationeryDetailsList.DataBind();

            if (!IsPostBack)
            {
                //FillDetails();
            }
        }

        /// <summary>
        /// Fills Details to Label
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillDetails(DataTable dtDetails)
        {
            try
            {
                if (dtDetails != null)
                {
                    lblRequisitionDate.Text = "Date";
                    lblRequisitionID.Text = "ID";
                    lblDepartmentCode.Text = "Department Code";
                    lblDepartmentName.Text = "Department Name";
                    lblEmployeeName.Text = "Employee Name";
                    lblEmployeeID.Text = "Employee Number";
                    lblEmployeeEmailID.Text = "Employee Email ID";
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            try
            {
                DataTable dtItems = (DataTable)Session["Items"];
                if (dtItems != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ID";
                    drdItemList.DataSource = dtItems;
                    drdItemList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Stationery Items to Datagrid
        /// </summary>
        /// <param name="dtStationeryItem"></param>
        private void FillItemList(DataTable dtStationeryItem)
        {
            try
            {
                dgvStationeryDetailsList.DataSource = dtStationeryItem;
                dgvStationeryDetailsList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills the change Items to Datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdItemList_SelectionChanged(object sender,
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedItem = drdItemList.SelectedItem.Text;
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