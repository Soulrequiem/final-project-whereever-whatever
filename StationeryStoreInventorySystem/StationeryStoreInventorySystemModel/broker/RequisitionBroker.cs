/***************************************************************************/
/*  File Name       : RequisitionBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin
/*  class Name      : Requisition
/*  Details         : Model Requisition of Requisition and Requisition detail table
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{

    public class RequisitionBroker : brokerinterface.IRequisitionBroker
    {
        private InventoryEntities inventory;
        private Requisition req = null;
        private RequisitionDetail reqDetail = null;
        private List<Requisition> reqList = null;
        private List<RequisitionDetail> reqDetailList = null;

        public RequisitionBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Retrieve the Requisition and RequisitionDetail information according to the Requisition Parameter 
        /// 
        /// </summary>
        /// <param name="requisition"></param>
        /// <returns></returns>
        public Requisition GetRequisition(Requisition requisition)
        {
            int showStatus = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);
            req = inventory.Requisitions.Where(reqObj => reqObj.Id == requisition.Id && reqObj.Status == showStatus).First();
            if (!req.Equals(null))
            {
                var requisitionDetailsResult = from rd in inventory.RequisitionDetails
                                               where rd.Requisition.Id == req.Id
                                               select rd;
                foreach (RequisitionDetail rd in requisitionDetailsResult)
                {
                    req.RequisitionDetails.Add(rd);
                }
                return req;
            }
            return null;
        }
        /// <summary>
        ///  Retrieve All of the Requisition information from Requisition Table
        /// </summary>
        /// <returns></returns>

        public List<Requisition> GetAllRequisition()
        {
            reqList=inventory.Requisitions.ToList<Requisition>();
            if (!reqList.Equals(null))
                return reqList;
            return null;
        }
        /// <summary>
        /// Insert Requisition data to the Requisition Table according to the Requisition Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisition"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Insert(Requisition requisition)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToRequisitions(requisition);
                foreach (RequisitionDetail requisitionDetail in requisition.RequisitionDetails)
                {
                    this.Insert(requisitionDetail);
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
        /// Update Requisition data to Requisition Table according to the Requisition Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisition"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Update(Requisition requisition)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                req = inventory.Requisitions.Where(reqObj => reqObj.Id == requisition.Id).First();
                Employee empId=inventory.Employees.Where(e=>e.Id==requisition.CreatedBy.Id).First();
                Employee approvedBy=inventory.Employees.Where(e=>e.Id==requisition.ApprovedBy.Id).First();
                req.Id = requisition.Id;
                req.Department = requisition.Department;
                req.CreatedBy = empId;
                req.ApprovedBy = approvedBy;
                req.ApprovedDate = req.ApprovedDate;
                req.CreatedDate = req.CreatedDate;
                foreach (RequisitionDetail requisitionDetail in req.RequisitionDetails)
                {
                    this.Update(requisitionDetail);
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
        /// Logically delete the Requisition by setting the status to 2 in the Requisition table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisiton"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Delete(Requisition requisiton)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                req = inventory.Requisitions.Where(reqObj => reqObj.Id == requisiton.Id).First();
                req.Status = 2;
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
        ///  Retrieve the RequisitionDetail information according to the Requisition detail Parameter 
        /// </summary>
        /// <param name="requisitionDetail"></param>
        /// <returns></returns>

        public RequisitionDetail GetRequisitionDetail(RequisitionDetail requisitionDetail)
        {
            reqDetail = inventory.RequisitionDetails.Where(reqObj => reqObj.Id == requisitionDetail.Id).First();
            if (!reqDetail.Equals(null))
                return reqDetail;
            return null;
        }
        /// <summary>
        /// Retrieve All of the Requisition detail information from Requisition detail Table
        /// </summary>
        /// <returns></returns>

        public List<RequisitionDetail> GetAllRequisitionDetail()
        {
            reqDetailList = inventory.RequisitionDetails.ToList<RequisitionDetail>();
            if (!reqDetailList.Equals(null))
                return reqDetailList;
            return null;
        }
        /// <summary>
        /// Insert Requisition dtail data to the Requisition detail Table according to the Requisition Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisitionDetail"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Insert(RequisitionDetail requisitionDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToRequisitionDetails(requisitionDetail);
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
        /// Update Requisition detail data to Requisition detail Table according to the Requisition Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisitionDetail"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Update(RequisitionDetail requisitionDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                reqDetail = inventory.RequisitionDetails.Where(reqObj => reqObj.Id == requisitionDetail.Id).First();
                Item itemId = inventory.Items.Where(i => i.Id == requisitionDetail.Item.Id).First();
                Requisition reqId = inventory.Requisitions.Where(r => r.Id == requisitionDetail.Requisition.Id).First();
                reqDetail.Id = requisitionDetail.Id;
                reqDetail.Requisition = reqId;
                reqDetail.Qty = requisitionDetail.Qty;
                reqDetail.DeliveredQty = requisitionDetail.DeliveredQty;
                reqDetail.Item = itemId;
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
        /// There is no status in RetrievalTable.
        /// </summary>
        /// <param name="requisitionDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(RequisitionDetail requisitionDetail)
        {
            throw new NotImplementedException();
        }



        public string GetRequisitionId(Requisition requisition)
        {
            Requisition lastRequisition = inventory.Requisitions.Where(r => r.Id.IndexOf(requisition.Department.Id) > -1).OrderBy(r => r.Id).Last();
            
            int idInt;
            string newYr;
            if (lastRequisition != null)
            {
                string requisitionId = lastRequisition.Id;
                string[] stringList = requisitionId.Split('/');
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
            return requisition.Department.Id + "/" + idInt + "/" + newYr;
        }

        public int GetRequisitionDetailId()
        {
            //List<RequisitionDetail> list = GetAllRequisitionDetail();
            //RequisitionDetail requisitionDetail = list.Last();
            //int id = requisitionDetail.Id;
            //id++;
            //return id;
            return inventory.RetrievalDetails.Last().Id + 1;
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/
