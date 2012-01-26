using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.storeController
{
    public class CreateDiscrepencyReportControl
    {
        IItemBroker itemBroker;
        List<DiscrepancyDetail> discrepancyDetailList;
        IDiscrepancyBroker discrepancyBroker;

        public CreateDiscrepencyReportControl()
        {
            itemBroker = new ItemBroker();
            discrepancyDetailList = new List<DiscrepancyDetail>();
            discrepancyBroker = new DiscrepancyBroker();
        }

        public Item EnterItemDescription(String itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            Item resultItem = itemBroker.GetItem(item);
            return resultItem;
        }

        public Constants.ACTION_STATUS SelectAdd(DiscrepancyDetail discrepancyDetail)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            discrepancyDetailList.Add(discrepancyDetail);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;
        }

        public Constants.ACTION_STATUS SelectRemove(DiscrepancyDetail discrepancyDetail)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            discrepancyDetailList.Remove(discrepancyDetail);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;
        }

        public Constants.ACTION_STATUS SelectCreate()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Discrepancy discrepancy = new Discrepancy();
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
