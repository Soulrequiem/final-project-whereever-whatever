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
        private InventoryEntities inventory;

        private IItemBroker itemBroker;
        private IDiscrepancyBroker discrepancyBroker;
        private IItemPriceBroker itemPriceBroker;
        
        private Employee currentEmployee;
        private Discrepancy discrepancy;
        private Item item;
        private ItemPrice itemprice;

        private List<DiscrepancyDetail> discrepancyDetails;
        
        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "DiscrepancyDetailId", "ItemNo", "ItemDescription", "Quantity", "Price", "Reason" };

        private DataColumn[] dataColumn;
        
        public CreateDiscrepencyReportControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            inventory = new InventoryEntities();

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

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]),
                                            new DataColumn(columnName[4]),
                                            new DataColumn(columnName[5]) };
        }
        /// <summary>
        /// createdBy priyanka
        /// </summary>


        public Item Item { get { return item; } }
        public string ItemId { get { return item.Id; } }
        public string Cost { get { return Converter.objToMoneyString(item.Cost); } }

        //public ItemPrice ItemPrice { get { return itemprice; } }
       


        public DataTable DiscrepancyDetailList
        {
            get 
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }

                foreach (DiscrepancyDetail temp in discrepancy.DiscrepancyDetails)
                {
                    dr = dt.NewRow();
                    dr["DiscrepancyDetailId"] = temp.Id;
                    dr["ItemNo"] = temp.Item.Id;
                    dr["ItemDescription"] = temp.Item.Description;
                    dr["Quantity"] = temp.Qty;
                    dr["Price"] = Converter.objToMoneyString(temp.Item.Cost);
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
                //dd.Discrepancy = discrepancy;
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
                discrepancy.DiscrepancyDetails.Add(dd);
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

            if (discrepancy.DiscrepancyDetails.Count >= index)
            {
                discrepancy.DiscrepancyDetails.Remove(discrepancy.DiscrepancyDetails.ElementAt(index));

                //List<DiscrepancyDetail> discrepancyDetails = discrepancy.DiscrepancyDetails.ToList<DiscrepancyDetail>();

                //discrepancy = new Discrepancy();
                //discrepancy.Id = discrepancyBroker.GetDiscrepancyId();
                //discrepancy.CreatedDate = DateTime.Now;
                //discrepancy.CreatedBy = Util.GetEmployee(new EmployeeBroker(inventory));
                //discrepancy.Status = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);

                //foreach (DiscrepancyDetail discrepancyDetail in discrepancyDetails)
                //{
                //    discrepancy.DiscrepancyDetails.Add(discrepancyDetail);
                //}

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

            int totalAdded = 0;
            foreach (DiscrepancyDetail discrepancyDetail in discrepancy.DiscrepancyDetails)
            {
                discrepancyDetail.Id = discrepancyBroker.GetDiscrepancyDetailId() + (totalAdded++);
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
