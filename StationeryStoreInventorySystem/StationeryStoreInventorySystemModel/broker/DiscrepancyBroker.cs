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
        private Discrepancy discrepancyObj = null;
        private DiscrepancyDetail discrepancyDetailObj = null;
        private List<DiscrepancyDetail> discrepancyDetailListObj = null;
        private List<Discrepancy> discrepancyListObj = null;
        private StockAdjustment stockAdjustmentObj = null;
        private List<StockAdjustment> stockAdjustmentListObj = null;

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
            try
            {
                discrepancyObj = inventory.Discrepancies.Where(disObj => disObj.Id == discrepancy.Id).First();
            }
            catch (Exception e)
            {
                discrepancyObj = null;
            }
            return discrepancyObj;

        }
        /// <summary>
        /// Retrieve All of the discrepancy information from Discrepancy Table
        /// Return Discrepancy Collection
        /// </summary>
        /// <returns></returns>
        public List<Discrepancy> GetAllDiscrepancy()
        {
            try
            {

                discrepancyListObj = inventory.Discrepancies.ToList<Discrepancy>();
            }
            catch (Exception e)
            {
                discrepancyListObj = null;
            }

            return discrepancyListObj;
        }

        public List<Discrepancy> GetAllDiscrepancy(Constants.VISIBILITY_STATUS visibilityStatus)
        {
            try
            {
                int status = Converter.objToInt(visibilityStatus);
                discrepancyListObj = inventory.Discrepancies.Where(x=> x.Status == status).ToList<Discrepancy>();
            }
            catch (Exception e)
            {
                discrepancyListObj = null;
            }

            return discrepancyListObj;
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

                discrepancyObj = inventory.Discrepancies.Where(d => d.Id == discrepancy.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == discrepancy.CreatedBy.Id).First();
                discrepancyObj.Id = discrepancy.Id;
                discrepancyObj.CreatedDate = discrepancy.CreatedDate;
                discrepancyObj.CreatedBy = createdBy;
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
                discrepancyObj = inventory.Discrepancies.Where(disObj => disObj.Id == discrepancy.Id).First();
                discrepancyObj.Status = 2;
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
            discrepancyDetailObj = inventory.DiscrepancyDetails.Where(disDetailObj => disDetailObj.Id == discrepancyDetail.Id).First();
            if (!discrepancyDetailObj.Equals(null))
                return discrepancyDetailObj;
            return null;
        }
        public List<DiscrepancyDetail> GetAllDiscrepancyDetail()
        {
            discrepancyDetailListObj = inventory.DiscrepancyDetails.ToList<DiscrepancyDetail>();
            if (!discrepancyDetailListObj.Equals(null))
                return discrepancyDetailListObj;
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
                discrepancyDetailObj = inventory.DiscrepancyDetails.Where(disDetailObj => disDetailObj.Id == discrepancyDetail.Id).First();
                Discrepancy disId = inventory.Discrepancies.Where(d => d.Id == discrepancyDetail.Discrepancy.Id).First();
                Item item = inventory.Items.Where(i => i.Id == discrepancyDetail.Item.Id).First();
                discrepancyDetailObj.Qty = discrepancyDetail.Qty;
                discrepancyDetailObj.Discrepancy = disId;
                discrepancyDetailObj.Item = item;
                discrepancyDetailObj.DiscrepancyType = discrepancyDetail.DiscrepancyType;
                discrepancyDetailObj.Qty = discrepancyDetail.Qty;
                discrepancyDetailObj.Remarks = discrepancyDetail.Remarks;
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
            stockAdjustmentObj = inventory.StockAdjustments.Where(staObj => staObj.Id == stockAdjustment.Id).First();
            if (!stockAdjustmentObj.Equals(null))
            {
                Discrepancy dis = inventory.Discrepancies.Where(disObj => disObj.Id == stockAdjustmentObj.Discrepancy.Id).First();

                stockAdjustmentObj.Discrepancy = dis;
            }
            return stockAdjustmentObj;

        }
        public List<StockAdjustment> GetAllStockAdjustment()
        {
            stockAdjustmentListObj = inventory.StockAdjustments.ToList<StockAdjustment>();
            if (!stockAdjustmentListObj.Equals(null))
                return stockAdjustmentListObj;
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



        public string GetDiscrepancyDetailId(Employee employee)
        {
           
            try
            {
                int idInt;
                string newYr;
                string prefix = String.Empty;
                if (employee.Role.Id == Converter.objToInt(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR))
                {
                    prefix = "001";
                }
                else if (employee.Role.Id == Converter.objToInt(Constants.EMPLOYEE_ROLE.STORE_MANAGER))
                {
                    prefix = "002";
                }
                if (inventory.StockAdjustments.Where(s=> s.Id.IndexOf(prefix) > -1).Count() > 0)
                {
                    //Discrepancy lastDiscrepancy = inventory.Discrepancies.Where(d => d.Id.IndexOf(discrepancy.CreatedBy.CreatedBy) > -1).OrderByDescending(x => x.CreatedDate).First();
                    StockAdjustment lastStockAdjustment = inventory.StockAdjustments.Where(s => s.Id.IndexOf(prefix) > -1).OrderByDescending(s => s.CreatedDate).First();

                    if (lastStockAdjustment != null)
                    {
                        string stockAdjustmentId = lastStockAdjustment.Id;
                        string[] stringList = stockAdjustmentId.Split('/');
                        string idString = stringList[1];
                        idInt = Converter.objToInt(idString);

                        int yearInt = DateTime.Now.Year;
                        string yrString = yearInt.ToString();
                        char[] charYr = yrString.ToCharArray();
                        newYr = charYr[2].ToString() + charYr[3].ToString();
                        if (newYr.Equals(stringList[2]))
                        {
                            idInt++;
                        }
                        else
                        {
                            idInt = 1;
                        }
                    }
                    else
                    {
                        idInt = 1;
                        newYr = DateTime.Now.Year.ToString().Substring(2);
                    }
                }
                else
                {
                    idInt = 1;
                    newYr = DateTime.Now.Year.ToString().Substring(2);
                }

                return prefix + "/" + idInt + "/" + newYr;
            }
            catch (Exception e)
            {
                return "Unknown";
            }
        
        }

        public string GetStockAdjustmentId()
        {
            throw new NotImplementedException();
        }
    }
}
        #endregion
/****************************************/
/********* End of the Class *****************/
/****************************************/