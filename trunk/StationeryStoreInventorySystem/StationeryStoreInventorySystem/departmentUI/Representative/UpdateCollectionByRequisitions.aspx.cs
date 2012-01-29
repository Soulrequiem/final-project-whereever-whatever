/***************************************************************************/
/*  File Name       : UpdateCollectionByRequisitions.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : UpdateCollectionByRequisitions
/*  Details         : Form for Update Collection By Requisitions
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class UpdateCollectionByRequisitions : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the UpdateCollectionByRequisitions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("CollectionID");
            //dt.Columns.Add("CollectionPoint");
            //dt.Columns.Add("CollectionDay");
            //dt.Columns.Add("CollectionDateTime");
            //dt.Columns.Add("CollectionStatus");
            //dt.Columns.Add("Status");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvCollectionList.DataSource = dt;
            //dgvCollectionList.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("RequisitionID");
            //dtt.Columns.Add("RequisitionDateTime");
            //dtt.Columns.Add("RequisitionBy");
            //dtt.Columns.Add("RequisitionStatus");
            //dtt.Columns.Add("ModifyRequisition");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            ////drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            ////drr[4] = "1ssdsfdf";
            //////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //dgvRequisitions.DataSource = dtt;
            //dgvRequisitions.DataBind();

            if (!IsPostBack)
            {
                FillCollectionDetails();
                FillItems();
                //FillCollectionDetails();
            }
        }

        /// <summary>
        /// Fills Collection Details to Datagrid
        /// </summary>
        /// <param name="dtCollectionDetails"></param>
        private void FillCollectionDetails(DataTable dtCollectionDetails)
        {
            try
            {
                dgvCollectionList.DataSource = dtCollectionDetails;
                dgvCollectionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills the Item Details to Label
        /// </summary>
        /// <param name="dtItemDetails"></param>
        private void FillItems(DataTable dtItem)
        {
            try
            {
                lblCollectionID.Text = "ID";
                lblDateTime.Text = "Date/Time";
                lblCollectionPoint.Text = "Point";
                //drdItemList.ValueField = "ID";
                //drdItemList.DataSource = dtDetails;
                //drdItemList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Items Details to Datagrid
        /// </summary>
        /// <param name="dtItemsDetails"></param>
        private void FillRequisitionDetails(DataTable dtCollectionDetails)
        {
            try
            {
                dgvRequisitions.DataSource = dtCollectionDetails;
                dgvRequisitions.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/