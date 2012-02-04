/***************************************************************************/
/*  File Name       : BlackListDepartment.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : BlackListDepartment
/*  Details         : Form for BlackList Department
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;


namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class BlackListDepartment : System.Web.UI.Page
    {
        private static readonly string sessionKey = "BlacklistDepartment";

        private BlacklistDepartmentControl bldCtrl;
        /// <summary>
        /// Loads the BlackListDepartment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Request.QueryString["department"] == null){
                    bldCtrl = new BlacklistDepartmentControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, bldCtrl);
                }
                else
                {
                    bldCtrl = (BlacklistDepartmentControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

                    if (bldCtrl.SelectLink(Request.QueryString["department"].ToString()) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                    {

                        // print success message
                    }
                    else
                    {
                        // print error message
                    }
                }
            }
            else
            {
                bldCtrl = (BlacklistDepartmentControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            
            FillDepartmentList();
        }

        private void FillDepartmentList()
        {
            try
            {
                DgvDepartmentList.DataSource = bldCtrl.DepartmentList;
                DgvDepartmentList.DataBind();
             }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void DgvDepartmentList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            try
            {
                HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("BlackUnblackList").FindControl("BlackUnblackList");
                link.NavigateUrl = "~/storeUI/SuperVisor_Manager/BlackListDepartment.aspx?department=" + e.Row.DataKey[0];
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }

        protected void DgvDepartmentList_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillDepartmentList();
        }

        protected void DgvDepartmentList_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillDepartmentList();
        }

    //    private BlacklistDepartmentControl GetControl()
    //    {
    //        if (bldCtrl == null)
    //            bldCtrl = new BlacklistDepartmentControl();
    //        return bldCtrl;
    //    }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/