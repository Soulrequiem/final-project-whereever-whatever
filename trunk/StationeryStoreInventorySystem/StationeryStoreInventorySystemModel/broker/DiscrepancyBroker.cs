/***************************************************************************/
/*  File Name       : DiscrepancyBroker.cs
/*  Module Name     : Models
/*  Owner           : Priyanka
/*  class Name      : Discrepancy
/*  Details         : Model Discrepancy of discrepancy and discrepancy detail, stock adjustment table
/***************************************************************************/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.broker
{
    public class DiscrepancyBroker : IDiscrepancyBroker
    {
        #region IRequisitionCollectionBroker Members
        private InventoryEntities inventory;
        private Discrepancy dis = null;
        private DiscrepancyDetail disDetail = null;
        private List<DiscrepancyDetail> disDetailList = null;
        private List<Discrepancy> disList = null;
        private StockAdjustment sta = null;
        private List<StockAdjustment> staList = null;

        public DiscrepancyBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Retrieve the Discrepancy and DiscrepancyDetail information  from Department Table according to the department Parameter
        /// Return Discrepancy
        /// </summary>
        /// <param name="discrepancy"></param>
        /// <returns></returns>
        public Discrepancy GetDiscrepancy(Discrepancy discrepancy)
        {
            dis = inventory.Discrepancies.Where(disObj => disObj.Id == discrepancy.Id).First();
            if (!dis.Equals(null))
            {
                var discrepancyDetailResult = from dd in inventory.DiscrepancyDetails
                                              where dd.Discrepancy.Id == dis.Id
                                              select dd;

                foreach (DiscrepancyDetail dd in discrepancyDetailResult)
                {
                    dis.DiscrepancyDetails.Add(dd);
                }

            }
            return dis;

        }
        /// <summary>
        /// Retrieve All of the discrepancy information from Discrepancy Table
        /// Return Discrepancy Collection
        /// </summary>
        /// <returns></returns>
        public List<Discrepancy> GetAllDiscrepancy()
        {
            disList = inventory.Discrepancies.ToList<Discrepancy>();
            if (!disList.Equals(null))
                return disList;
            return null;
        }
        /// <summary>
        ///  Insert Discrepancy data to the Discrepancy and Discrepancy Detail Table according to the newdiscrepancy Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newdiscrepancy"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Discrepancy newdiscrepancy)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToDiscrepancies(newdiscrepancy);
                foreach (DiscrepancyDetail discrepancyDetail in newdiscrepancy.DiscrepancyDetails)
                {
                    this.Insert(discrepancyDetail);
                }


                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;

            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        /// <summary>
        /// Update Discrepancy data to the Discrepancy and Discrepancy Detail Table according to the discrepancy Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="discrepancy"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(Discrepancy discrepancy)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {

                dis = inventory.Discrepancies.Where(d => d.Id == discrepancy.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == discrepancy.CreatedBy.Id).First();
                dis.Id = discrepancy.Id;
                dis.CreatedDate = discrepancy.CreatedDate;
                dis.CreatedBy = createdBy;
                foreach (DiscrepancyDetail discrepancyDetail in discrepancy.DiscrepancyDetails)
                {
                    this.Update(discrepancyDetail);
                }

                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;

        }
        /// <summary>
        ///  Logically delete the Discrepancy table by setting the status to 2 in the Discrepancy table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="discrepancy"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Discrepancy discrepancy)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {
                dis = inventory.Discrepancies.Where(disObj => disObj.Id == discrepancy.Id).First();
                dis.Status = 2;
                foreach (DiscrepancyDetail discrepancyDetail in discrepancy.DiscrepancyDetails)
                {
                    this.Delete(discrepancyDetail);
                }

                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;

        }
        public DiscrepancyDetail GetDiscrepancyDetail(DiscrepancyDetail discrepancyDetail)
        {
            disDetail = inventory.DiscrepancyDetails.Where(disDetailObj => disDetailObj.Id == discrepancyDetail.Id).First();
            if (!disDetail.Equals(null))
                return disDetail;
            return null;
        }
        public List<DiscrepancyDetail> GetAllDiscrepancyDetail()
        {
            disDetailList = inventory.DiscrepancyDetails.ToList<DiscrepancyDetail>();
            if (!disDetailList.Equals(null))
                return disDetailList;
            return null;
        }
        public Constants.DB_STATUS Insert(DiscrepancyDetail discrepancyDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            //disDetail = inventory.DiscrepancyDetails.Where(disDetailObj => disDetailObj.Id == discrepancyDetail.Id).FirstOrDefault();
            //disDetail.ItemReference = discrepancyDetail.ItemReference;
            // disDetail.Qty = discrepancyDetail.Qty;
            // disDetail.Remarks = discrepancyDetail.Remarks;

            try
            {
                inventory.AddToDiscrepancyDetails(discrepancyDetail);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public Constants.DB_STATUS Update(DiscrepancyDetail discrepancyDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {
                disDetail = inventory.DiscrepancyDetails.Where(disDetailObj => disDetailObj.Id == discrepancyDetail.Id).First();
                Discrepancy disId = inventory.Discrepancies.Where(d => d.Id == discrepancyDetail.Discrepancy.Id).First();
                Item item = inventory.Items.Where(i => i.Id == discrepancyDetail.Item.Id).First();
                disDetail.Qty = discrepancyDetail.Qty;
                disDetail.Discrepancy = disId;
                disDetail.Item = item;
                disDetail.DiscrepancyType = discrepancyDetail.DiscrepancyType;
                disDetail.Qty = discrepancyDetail.Qty;
                disDetail.Remarks = discrepancyDetail.Remarks;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public Constants.DB_STATUS Delete(DiscrepancyDetail discrepancyDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public StockAdjustment GetStockAdjustment(StockAdjustment stockAdjustment)
        {
            sta = inventory.StockAdjustments.Where(staObj => staObj.Id == stockAdjustment.Id).First();
            if (!sta.Equals(null))
            {
                Discrepancy dis = inventory.Discrepancies.Where(disObj => disObj.Id == sta.Discrepancy.Id).First();

                sta.Discrepancy = dis;
            }
            return sta;

        }
        public List<StockAdjustment> GetAllStockAdjustment()
        {
            staList = inventory.StockAdjustments.ToList<StockAdjustment>();
            if (!staList.Equals(null))
                return staList;
            return null;
        }
        public Constants.DB_STATUS Insert(StockAdjustment newStockAdjustment)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToStockAdjustments(newStockAdjustment);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;

            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        public Constants.DB_STATUS Update(StockAdjustment stockAdjustment)
        {
            throw new NotImplementedException();
        }

        public Constants.DB_STATUS Delete(StockAdjustment stockAdjustment)
        {
            throw new NotImplementedException();
        }
        public int GetDiscrepancyId()
        {

            var maxDiscrepacnyId = inventory.Discrepancies.Max(xObj => xObj.Id) + 1;
            return maxDiscrepacnyId;
        }

    }
}
        #endregion
/****************************************/
/********* End of the Class *****************/
/****************************************/