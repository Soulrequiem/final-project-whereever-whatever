/***************************************************************************/
/*  File Name       : CheckRequisition.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : CheckRequisition
/*  Details         : Form for Check Requisition
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
    public partial class CheckRequisition : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the CheckRequisition form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("CheckRequisitionCheckBox");
            //dt.Columns.Add("RequisitionID");
            //dt.Columns.Add("RequisitionDate/Time");
            //dt.Columns.Add("status");
            //dt.Columns.Add("RemainingQty");
            //dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1we2we12321";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1we2we12321";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
           
            //dt.Rows.Add(dr);

            //dgvRequisitionList.DataSource = dt;
            //dgvRequisitionList.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("ItemNo");
            //dtt.Columns.Add("ItemDescription");
            //dtt.Columns.Add("RequiredQty");
            //dtt.Columns.Add("ReceivedQty");
            //dtt.Columns.Add("RemainingQty");
            ////dtt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            ////drr[4] = "1ssdsfdf";

            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";

            //dtt.Rows.Add(drr);

            //dgvRequisitionDetails.DataSource = dtt;
            //dgvRequisitionDetails.DataBind();

            if (!IsPostBack)
            {
                //FillRequisitionList();
            }
        }

        /// <summary>
        /// Fills Requisition to Datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillRequisitionList(DataTable dtRequisition)
        {
            try
            {
                dgvRequisitionList.DataSource = dtRequisition;
                dgvRequisitionList.DataBind();
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
        private void FillRequisitions()
        {
            try
            {
                DataTable dtItems = (DataTable)Session["Items"];
                if (dtItems != null)
                {
                    drdRequisitionList.TextField = "Requisitions";
                    drdRequisitionList.ValueField = "ID";
                    drdRequisitionList.DataSource = dtItems;
                    drdRequisitionList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Requisition Details to Datagrid
        /// </summary>
        /// <param name="dtDeatilsRequisition"></param>
        private void FillRequisitionDetails(DataTable dtDeatilsRequisition)
        {
            try
            {
                dgvRequisitionDetails.DataSource = dtDeatilsRequisition;
                dgvRequisitionDetails.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills the changed data into Datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdRequisitionList_SelectionChanged(object sender,
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedRequisition = drdRequisitionList.SelectedItem.Text;
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