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
        BlacklistDepartmentControl bldCtrl;
        /// <summary>
        /// Loads the BlackListDepartment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillDepartmentList();
            }
        }

        private void FillDepartmentList()
        {
            try
            {
                //bldCtrl = GetControl();
                //DataTable dtDepartment = bldCtrl.
                //DgvDepartmentList.DataSource = dtDepartment;
                //DgvDepartmentList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private BlacklistDepartmentControl GetControl()
        {
            if (bldCtrl == null)
                bldCtrl = new BlacklistDepartmentControl();
            return bldCtrl;
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/