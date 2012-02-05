/***************************************************************************/
/*  File Name       : RequisitionBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
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
        private Requisition requisitionObj= null;
        private RequisitionDetail requisitionDetailObj = null;
        private List<Requisition> requisitionList = null;
        private List<RequisitionDetail> requisitionDetailList = null;

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
            try
            {
                if (requisition.Status != 0)
                {
                    int status = Converter.objToInt(requisition.Status);
                    requisitionObj = inventory.Requisitions.Where(reqObj => reqObj.Id == requisition.Id && reqObj.Status == status).First();
                }
                else
                {
                    requisitionObj = inventory.Requisitions.Where(reqObj => reqObj.Id == requisition.Id).First();
                }
            }
            catch (Exception e)
            {
                requisitionObj = null;
            }
            //if (!req.Equals(null))
            //{
            //    var requisitionDetailsResult = from rd in inventory.RequisitionDetails
            //                                   where rd.Requisition.Id == req.Id
            //                                   select rd;
            //    foreach (RequisitionDetail rd in requisitionDetailsResult)
            //    {
            //        req.RequisitionDetails.Add(rd);
            //    }
            //    return req;
            //}
            return requisitionObj;
        }

        /// <summary>
        ///  Retrieve All of the Requisition information from Requisition Table
        /// </summary>
        /// <returns>
        /// List of Requisition
        /// </returns>

        public List<Requisition> GetAllRequisition()
        {
            try
            {
                requisitionList = inventory.Requisitions.ToList<Requisition>();
            }
            catch (Exception e)
            {
                requisitionList = null;
            }
            return requisitionList;
        }

        /// <summary>
        ///  Retrieve All of the Requisition information according to the status
        /// </summary>
        /// <returns>
        /// List of Requisition
        /// </returns>

        public List<Requisition> GetAllRequisitionByStatus()
        {
            try
            {

                requisitionList = inventory.Requisitions.Where(reqObj=>reqObj.Status==1 || reqObj.Status==2).ToList<Requisition>();
            }
            catch (Exception e)
            {
                requisitionList = null;
            }
            return requisitionList;
        }

        /// <summary>
        ///  Retrieve All of the Requisition information according to the status
        /// </summary>
        /// <returns>
        /// List of Requisition
        /// </returns>

        public List<Requisition> GetAllRequisitionByEmployee(int employeeID)
        {
            try
            {
                requisitionList = inventory.Requisitions.Where(reqObj => reqObj.CreatedBy.Id == employeeID).ToList<Requisition>();
            }
            catch (Exception e)
            {
                requisitionList = null;
            }
            return requisitionList;
        }


        /// <summary>
        /// Retreive All of the requisition information according to status
        /// </summary>
        /// <param name="requisitionStatus"></param>
        /// <returns></returns>
        public List<Requisition> GetAllRequisition(Constants.REQUISITION_STATUS requisitionStatus)
        {
            try
            {
                int status = Converter.objToInt(requisitionStatus);
                requisitionList = inventory.Requisitions.Where(reqObj => reqObj.Status == status).ToList<Requisition>();
            }
            catch (Exception e)
            {
                requisitionList = null;
            }
            return requisitionList;
        }

        /// <summary>
        /// Insert Requisition data to the Requisition Table according to the Requisition Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="requisition"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Insert(Requisition requisition)//, Boolean isSaved)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToRequisitions(requisition);
                //foreach (RequisitionDetail requisitionDetail in requisition.RequisitionDetails)
                //{
                //    this.Insert(requisitionDetail);
                //}
             //   if (isSaved) inventory.SaveChanges();//to add in all insert method
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
                //requisitionObj = inventory.Requisitions.Where(reqObj => reqObj.Id == requisition.Id).First();
                //Employee empId=inventory.Employees.Where(e=>e.Id==requisition.CreatedBy.Id).First();
                //Employee approvedBy=inventory.Employees.Where(e=>e.Id==requisition.ApprovedBy.Id).First();
                //Department department = inventory.Departments.Where(d => d.Id == requisition.Department.Id).First();
                ////requisitionObj.Id = requisition.Id;
                //requisitionObj.Department = department;
                //requisitionObj.CreatedBy = empId;
                //requisitionObj.ApprovedBy = approvedBy;
                //requisitionObj.ApprovedDate = requisition.ApprovedDate;
                //requisitionObj.CreatedDate = requisition.CreatedDate;
                //foreach (RequisitionDetail requisitionDetail in requisition.RequisitionDetails)
                //{
                //    this.Update(requisitionDetail);
                //}
                //if (isSaved) inventory.SaveChanges();
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

        public Constants.DB_STATUS Delete(Requisition requisiton)//,Boolean isSaved)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                requisitionObj = inventory.Requisitions.Where(reqObj => reqObj.Id == requisiton.Id).First();
                requisitionObj.Status = Converter.objToInt(Constants.REQUISITION_STATUS.HIDDEN);
                //if(isSaved) inventory.SaveChanges();
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
            try
            {
                requisitionDetailObj = inventory.RequisitionDetails.Where(reqObj => reqObj.Id == requisitionDetail.Id || reqObj.Requisition.Id == requisitionDetail.Requisition.Id
                    ).First();
            }
            catch (Exception e)
            {
                requisitionDetailObj = null;
            }
            return requisitionDetailObj;
        }
        /// <summary>
        ///  Retrieve the list of RequisitionDetail information according to the Requisition detail Parameter 
        /// </summary>
        /// <param name="requisitionDetail"></param>
        /// <returns>
        /// List of Requisition Detail
        /// </returns>

        public List<RequisitionDetail> GetAllRequisitionDetailByObj(RequisitionDetail requisitionDetail)
        {
            try
            {
                requisitionDetailList = inventory.RequisitionDetails.Where(reqObj => reqObj.Requisition.Id == requisitionDetail.Requisition.Id).ToList<RequisitionDetail>();
            }
            catch (Exception e)
            {
                requisitionDetailList = null;
            }
            return requisitionDetailList;
        }
        /// <summary>
        /// Retrieve All of the Requisition detail information from Requisition detail Table
        /// </summary>
        /// <returns></returns>

        public List<RequisitionDetail> GetAllRequisitionDetail()
        {
            try
            {
                requisitionDetailList = inventory.RequisitionDetails.ToList<RequisitionDetail>();
            }
            catch (Exception e)
            {
                requisitionDetailList = null;
            }

            return requisitionDetailList;
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
                requisitionDetailObj = inventory.RequisitionDetails.Where(reqObj => reqObj.Id == requisitionDetail.Id).First();
                Item itemId = inventory.Items.Where(i => i.Id == requisitionDetail.Item.Id).First();
                Requisition requisitionId = inventory.Requisitions.Where(r => r.Id == requisitionDetail.Requisition.Id).First();
                requisitionDetailObj.Id = requisitionDetail.Id;
                requisitionDetailObj.Requisition = requisitionId;
                requisitionDetailObj.Qty = requisitionDetail.Qty;
                requisitionDetailObj.DeliveredQty = requisitionDetail.DeliveredQty;
                requisitionDetailObj.Item = itemId;
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


        /// <summary>
        /// Get the last requisition Id from requistion table
        /// </summary>
        /// <param name="requisition"></param>
        /// <returns>
        /// Return RequisitionId
        /// </returns>
        public string GetRequisitionId(Requisition requisition)
        {
            try
            {
                int idInt;
                string newYr;
                if (inventory.Requisitions.Where(r => r.Id.IndexOf(requisition.Department.Id) > -1).Count() > 0)
                {
                    Requisition lastRequisition = inventory.Requisitions.Where(r => r.Id.IndexOf(requisition.Department.Id) > -1).OrderByDescending(x => x.CreatedDate).First();

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
                }
                else
                {
                    idInt = 1;
                    newYr = DateTime.Now.Year.ToString().Substring(2);
                }

                return requisition.Department.Id + "/" + idInt + "/" + newYr;
            }
            catch (Exception e)
            {
                return "Unknown";
            }
        }
        /// <summary>
        /// Get the last record of RequistionDetailId
        /// </summary>
        /// <returns>
        /// Return RequistionDetailId
        /// </returns>
        public int GetRequisitionDetailId()
        {
            //List<RequisitionDetail> list = GetAllRequisitionDetail();
            //RequisitionDetail requisitionDetail = list.Last();
            //int id = requisitionDetail.Id;
            //id++;
            //return id;
            if (inventory.RequisitionDetails.Count() > 0)
            {
                return inventory.RequisitionDetails.Max(xObj => xObj.Id) + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/
