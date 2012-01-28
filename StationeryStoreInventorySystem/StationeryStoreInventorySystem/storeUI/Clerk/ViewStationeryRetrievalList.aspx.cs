/***************************************************************************/
/*  File Name       : ViewStationeryRetrievalList.cs
/*  Module Name     : UI
/*  Owner           : JinChengCheng
/*  class Name      : ViewStationeryRetrievalList
/*  Details         : UI representation of ViewStationeryRetrievalListUI 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class ViewStationeryRetrievalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewStationeryRetrievalListControl VSRLobj=new ViewStationeryRetrievalListControl();
                //DataTable dt=VSRLobj.
                //FillStationeryRetrivalList(dt);
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("RetrievalNo");
            //dt.Columns.Add("RetrievalDate/Time");
            //dt.Columns.Add("RetrievedBy");
            //dt.Columns.Add("NeededQty");
            //dt.Columns.Add("ActualQty");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dr[4] = "1dsfdsfsdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1we2we12321";
            //dr[2] = "1213sadsad";
            //dr[3] = "1ssdsfdf";
            //dr[4] = "1dsfdsfsdf";
            //dt.Rows.Add(dr);

            //DgvViewStationeryRetrievalList.DataSource = dt;
            //DgvViewStationeryRetrievalList.DataBind();

        }

        public void FillStationeryRetrivalList(DataTable dtStationeryRetrivalList)
        {
            try
            {
                if (dtStationeryRetrivalList != null)
                {
                    DgvViewStationeryRetrievalList.DataSource = dtStationeryRetrivalList;
                    DgvViewStationeryRetrievalList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
