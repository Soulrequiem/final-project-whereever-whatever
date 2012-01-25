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
    public class IssueAdjustmentVoucherControl
    {
        IDiscrepancyBroker discrepancyBroker;
        public IssueAdjustmentVoucherControl()
        {
            discrepancyBroker = new DiscrepancyBroker();
        }

        public List<Discrepancy> GetAllDiscrepancy()
        {
            List<Discrepancy> discrepancyList = discrepancyBroker.GetAllDiscrepancy();
            List<Discrepancy> newList = new List<Discrepancy>();
            foreach (Discrepancy discrepancy in discrepancyList)
            {
                if (discrepancy.status == (int)Constants.VISIBILITY_STATUS.SHOW)
                {
                    newList.Add(discrepancy);
                }

            }
            return newList;
        }

        public Discrepancy SelectDiscrepancy(int discrepancyId)
        {
            Discrepancy discrepancy = new Discrepancy();
            discrepancy.id = discrepancyId;
            return discrepancyBroker.GetDiscrepancy(discrepancy);
        }

        public Constants.ACTION_STATUS SelectDiscrepancyApprove(Discrepancy discrepancy)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            StockAdjustment stockAdjustment = new StockAdjustment();
            stockAdjustment.Discrepancy = discrepancy;
            Constants.DB_STATUS dbStatus = discrepancyBroker.Insert(stockAdjustment);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }


    }
}
