/***************************************************************************/
/*  File Name       : CreateDiscrepencyReportControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : CreateDiscrepencyReportControl
/*  Details         : Controller representation of CreateDiscrepencyReport 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class CreateDiscrepencyReportControl
    {
        private IItemBroker itemBroker;
        private IDiscrepancyBroker discrepancyBroker;
        
        private Employee currentEmployee;
        private Discrepancy discrepancy;
        
        private System.Data.Objects.DataClasses.EntityCollection<DiscrepancyDetail> discrepancyDetailList;

        private DataTable dt;
        private DataRow dr;

        public CreateDiscrepencyReportControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
            InventoryEntities inventory = new InventoryEntities();

            discrepancyBroker = new DiscrepancyBroker(inventory);
            itemBroker = new ItemBroker(inventory);

            discrepancy = new Discrepancy();
            discrepancyDetailList = new System.Data.Objects.DataClasses.EntityCollection<DiscrepancyDetail>();
        }

        /// <summary>
        ///     Show the item according the item description entered
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <returns>The return value of this method is resultItem.</returns>
        public Item SelectItemDescription(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            Item resultItem = itemBroker.GetItem(item);
            return resultItem;
        }

       
        //public Constants.ACTION_STATUS SelectAdd(DiscrepancyDetail discrepancyDetail)
        //{
        //    Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
        //    discrepancyDetailList.Add(discrepancyDetail);
        //    status = Constants.ACTION_STATUS.SUCCESS;
        //    return status;
        //}


        /// <summary>
        ///     Show the added item in the table
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="discrepancyDetail"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectAdd(DiscrepancyDetail discrepancyDetail)
        {
            dt = new DataTable();
            //discrepancy = new Discrepancy();
           
            discrepancyDetailList.Add(discrepancyDetail);
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["price"] = temp.Item.Cost;
                dr["reason"] = temp.Remarks;
                dt.Rows.Add(dr);
            }
            return dt;

        }

        //public Constants.ACTION_STATUS SelectRemove(DiscrepancyDetail discrepancyDetail)
        //{
        //    Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
        //    discrepancyDetailList.Remove(discrepancyDetail);
        //    status = Constants.ACTION_STATUS.SUCCESS;
        //    return status;
        //}

        /// <summary>
        ///     Refresh the discrepancy list after remove one
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="discrepancyDetail"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectRemove(DiscrepancyDetail discrepancyDetail)
        {
            dt = new DataTable();
            
            //discrepancyDetailList = new List<DiscrepancyDetail>();
            discrepancyDetailList.Remove(discrepancyDetail);
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["price"] = temp.Item.Cost;
                dr["reason"] = temp.Remarks;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        ///     Create discrepancy
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is status.</returns>
        public Constants.ACTION_STATUS SelectCreate()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            
            discrepancy.DiscrepancyDetails = discrepancyDetailList;
            Constants.DB_STATUS dbStatus = discrepancyBroker.Insert(discrepancy);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
