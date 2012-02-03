/***************************************************************************/
/*  File Name       : ManageCollectionPoint.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ManageCollectionPoint
/*  Details         : Form for Manage Collection Point
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class ManageCollectionPoint : System.Web.UI.Page
    {
        private static readonly string sessionKey = "ManageCollectionPoint";

        private ManageCollectionPointControl mngColPntCtrl;
        
        private ManageCollectionPointControl GetMcpControl()
        {
            if (mngColPntCtrl == null)
                mngColPntCtrl = new ManageCollectionPointControl();
            return mngColPntCtrl;
        }
        /// <summary>
        /// Loads the ManageCollectionPoint form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonUI.MasterPage.setCurrentPage(this);

                mngColPntCtrl = new ManageCollectionPointControl();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, mngColPntCtrl);

                FillCollectionList(mngColPntCtrl.CurrentCollectionPoint);
                FillCollectionPoints(mngColPntCtrl.AllCollectionPoint);
            }
            else
            {
                mngColPntCtrl = (ManageCollectionPointControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        /// <summary>
        /// Fills Collection list to DataGrid
        /// </summary>
        /// <param name="dtCollection"></param>
        private void FillCollectionList(DataTable dtCollection)
        {
            try
            {
                if (dtCollection != null)
                {
                    dgvCollections.ClearDataSource();

                    dgvCollections.DataSource = dtCollection;
                    dgvCollections.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills collection point drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillCollectionPoints(DataTable dtPoint)
        {
            try
            {
                if (dtPoint != null)
                {
                    drdCollectionList.Items.Clear();

                    drdCollectionList.TextField = "CollectionPoint";
                    drdCollectionList.ValueField = "CollectionID";
                    drdCollectionList.DataSource = dtPoint;
                    drdCollectionList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills changed data to Datagrid
        /// </summary>
        /// <param name="sender"></param>   
        /// <param name="e"></param>
       
        //protected void drdCollectionList_SelectionChanged(object sender, 
        //    Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //   try
        //    {
        //       //Save it into DB
        //       mngColPntCtrl.SelectSave(SystemStoreInventorySystemUtil.Converter.objToInt(e.NewSelection));

        //       //Cleare datasource
        //       dgvCollections.ClearDataSource();

        //       //Fill current collection point
        //       FillCollectionPoints(mngColPntCtrl.CurrentCollectionPoint);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteErrorLog(ex);
        //    }           
            
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (mngColPntCtrl.SelectSave(SystemStoreInventorySystemUtil.Converter.objToInt(drdCollectionList.SelectedItem.Value)) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                FillCollectionList(mngColPntCtrl.CurrentCollectionPoint);
                // print success message
            }
            else
            {
                // print error message
            }
        }
              
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/