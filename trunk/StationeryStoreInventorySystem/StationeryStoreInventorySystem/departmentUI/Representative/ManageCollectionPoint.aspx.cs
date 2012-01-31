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
        ManageCollectionPointControl mngColPntCtrl;
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
                
            //DataTable dt = new DataTable();
            ////dt.Columns.Add("EmployeeID");
            //dt.Columns.Add("CollectionID");
            //dt.Columns.Add("CollectionPoint");
            //dt.Columns.Add("CollectionTime");
            ////dt.Columns.Add("JoiningDate");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1vdvd";
            //dr[1] = "1dvd";
            //dr[2] = "1dvdv";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1dafd";
            //dr[1] = "1vdv";
            //dr[2] = "1vdvd";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvCollections.DataSource = dt;
            //dgvCollections.DataBind();

            if (!IsPostBack)
            {
                FillCollectionList(GetCurrentCollectionPoint());
                FillCollectionPoints(GetMcpControl().AllCollectionPoint);
            }
        }

        private DataTable GetCurrentCollectionPoint()
        {
            DataTable dtColLst = GetMcpControl().CurentCollectionPoint;
            return dtColLst;
        }

        /// <summary>
        /// Fills Collection list to DataGrid
        /// </summary>
        /// <param name="dtCollection"></param>
        private void FillCollectionList(DataTable dtCollection)
        {
            try
            {
                dgvCollections.DataSource = dtCollection;
                dgvCollections.DataBind();
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
                    drdCollectionList.TextField = "text";
                    drdCollectionList.ValueField = "value";
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
       
        protected void drdCollectionList_SelectionChanged(object sender, 
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
           try
            {
               //Get Selected ID
               int collectionPointId = Convert.ToInt16(e.NewSelection.ToString());

               //Save it into DB
               GetMcpControl().SelectSave(collectionPointId);

               //Cleare datasource
               dgvCollections.ClearDataSource();

               //Fill current collection point
               FillCollectionPoints(GetCurrentCollectionPoint());
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