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
        ViewStationeryRetrievalListControl vsrCtrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vsrCtrl = new ViewStationeryRetrievalListControl();
                DataTable dt = vsrCtrl.GetStationeryRetrievalList();
                FillStationeryRetrivalList(dt);
            }
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
