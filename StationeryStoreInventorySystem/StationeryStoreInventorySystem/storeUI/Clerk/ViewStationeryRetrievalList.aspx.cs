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
        private ViewStationeryRetrievalListControl vsrCtrl;
        private static readonly string sessionKey = "ViewStationeryRetrievalList";
        private string retrievalNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RetrievalNo"] == null)
                {
                    vsrCtrl = new ViewStationeryRetrievalListControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, vsrCtrl);
                    FillStationeryRetrivalList(vsrCtrl.RetrievalList);
                }
                else
                {
                    vsrCtrl = (ViewStationeryRetrievalListControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                    retrievalNo = Request.QueryString["retrievalNo"].ToString();
                    //
                }
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

        protected void DgvViewStationeryRetrievalList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("retrievalNo").FindControl("retrievalNo");
            link.NavigateUrl = "~/storeUI/Clerk/ManageStationeryRetrievalList.aspx?retrievalId=" + link.Text;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
