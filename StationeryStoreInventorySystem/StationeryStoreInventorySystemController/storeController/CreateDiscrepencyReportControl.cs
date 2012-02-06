﻿/***************************************************************************/
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
        private IItemPriceBroker itemPriceBroker;
        
        private Employee currentEmployee;
        private Discrepancy discrepancy;
        private Item item;
        private ItemPrice itemprice;
        
        //private System.Data.Objects.DataClasses.EntityCollection<DiscrepancyDetail> discrepancyDetailList;

        private DataTable dt;
        private DataRow dr;

        private DataColumn[] dataColumn;
        private List<DiscrepancyDetail> ddList;

        public CreateDiscrepencyReportControl()
        {
            ddList = new List<DiscrepancyDetail>();
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
            InventoryEntities inventory = new InventoryEntities();

            discrepancyBroker = new DiscrepancyBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            item = new Item();
            itemPriceBroker = new ItemPriceBroker(inventory);
            itemprice = new ItemPrice();
            

            discrepancy = new Discrepancy();
            discrepancy.Id = discrepancyBroker.GetDiscrepancyId();
            discrepancy.CreatedDate = DateTime.Now;
            discrepancy.CreatedBy = Util.GetEmployee(new EmployeeBroker(inventory));
            discrepancy.Status = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);
           // discrepancyDetailList = new System.Data.Objects.DataClasses.EntityCollection<DiscrepancyDetail>();


        }
        /// <summary>
        /// createdBy priyanka
        /// </summary>


        public Item Item { get { return item; } }
        public string ItemId { get { return item.Id; } }
        public decimal Cost { get { return item.Cost; } }

        //public ItemPrice ItemPrice { get { return itemprice; } }
       


        public DataTable DiscrepancyDetailList
        {
            get 
            {
                dt = new DataTable();

                dt.Columns.AddRange(dataColumn);

                foreach (DiscrepancyDetail temp in ddList)
                {
                    dr = dt.NewRow();
                    dr["DiscrepancyDetailId"] = temp.Id;
                    dr["ItemNo"] = temp.Item.Id;
                    dr["ItemDescription"] = temp.Item.Description;
                    dr["Quantity"] = temp.Qty;
                    dr["Price"] = temp.Item.Cost;
                    dr["Reason"] = temp.Remarks;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
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
        public Constants.ACTION_STATUS SelectItemDescription(string itemDescription)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

            item = Util.GetItem(itemBroker, itemDescription);

            if (item != null)
            {
                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }

            return selectStatus;
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
        public Constants.ACTION_STATUS SelectAdd(string itemId, int qty, string reason)
        {

            Item item = new Item();
            item.Id = itemId;
            item = itemBroker.GetItem(item);

            if (item != null && reason != String.Empty)
            {
                DiscrepancyDetail dd = new DiscrepancyDetail();
                dd.Id = discrepancyBroker.GetDiscrepancyDetailId();
                dd.Discrepancy = discrepancy;
                dd.Item = item;
                int amount = qty * (int)item.Cost;
                if (amount >= 250)
                {
                    dd.DiscrepancyType = Converter.objToInt(Constants.DISCREPANCY_TYPE.MANAGER);
                }
                else
                {
                    dd.DiscrepancyType = Converter.objToInt(Constants.DISCREPANCY_TYPE.SUPERVISOR);
                }
                dd.Qty = qty;
                dd.Remarks = reason;
                dd.Status = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);
                ddList.Add(dd);
             
                //int discrepancyType = Converter.objToInt(Constants.DISCREPANCY_TYPE.UNKNOWN);
                //if (qty > 0)
                //{
                //    discrepancyType = Converter.objToInt(Constants.DISCREPANCY_TYPE.ADD);
                //}
                //else
                //{
                //    discrepancyType = Converter.objToInt(Constants.DISCREPANCY_TYPE.REDUCE);
                //}

                //    DiscrepancyDetail discrepancyDetail = null;// new DiscrepancyDetail(discrepancyBroker.GetDiscrepancyDetailId(), discrepancy, item, discrepancyType, qty, reason);

                //    if (!discrepancyDetailList.Contains(discrepancyDetail))
                //    {
                //        discrepancyDetailList.Add(discrepancyDetail);
                //        addStatus = Constants.ACTION_STATUS.SUCCESS;
                //    }
                //    else
                //    {
                //        addStatus = Constants.ACTION_STATUS.FAIL;
                //    }
                //}
                //else
                //{
                //    addStatus = Constants.ACTION_STATUS.FAIL;
                //}

                

            }
            return Constants.ACTION_STATUS.SUCCESS;
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
        public Constants.ACTION_STATUS SelectRemove(int index)
        {
            Constants.ACTION_STATUS removeStatus = Constants.ACTION_STATUS.UNKNOWN;

            if (ddList.Count >= index)
            {
                DiscrepancyDetail discrepancyDetail = ddList.ElementAt(index - 1);

                ddList.Remove(discrepancyDetail);
                removeStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                removeStatus = Constants.ACTION_STATUS.FAIL;
            }
            
            return removeStatus;
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
            
           

            foreach (DiscrepancyDetail discrepancyDetail in ddList)
            {
                discrepancy.DiscrepancyDetails.Add(discrepancyDetail);
            }
            
            
            if (discrepancyBroker.Insert(discrepancy) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;

            return status;
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/
