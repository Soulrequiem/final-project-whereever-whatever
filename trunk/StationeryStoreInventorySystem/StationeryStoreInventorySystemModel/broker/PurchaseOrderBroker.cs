
/***************************************************************************/
/*  File Name       : PurchaseOrderBroker.cs
/*  Module Name     : Models
/*  Owner           : Su Lai Naing
/*  class Name      : PurchaseOrderBroker
/*  Details         : Model PurchaseOrderBroker of PurchaseOrder and PurchaseOrderDetail table
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class PurchaseOrderBroker : IPurchaseOrderBroker
    {

        #region IPurchaseOrderBroker Members

        private InventoryEntities inventory;
        private PurchaseOrder purchaseorder = null;
        private List<PurchaseOrder> purchaseOrderList = null;
        private PurchaseOrderDetail purchaseorderdetail = null;
        private List<PurchaseOrderDetail> purchaseOrderDetailList = null;

        public PurchaseOrderBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        
        //public int GetPurchaseOrderId()
        //{
        //    var maxPurchaseOrderId = inventory.PurchaseOrders.Max(xObj => xObj.Id) + 1;
        //    return maxPurchaseOrderId;

        //}

        /// <summary>
        /// Retrieve the PurchaseOrder information  from PurchaseOrder Table according to the purchaseOrder Parameter
        /// Return purchaseorder
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        public PurchaseOrder GetPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            //int showStatus = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);
            purchaseorder = inventory.PurchaseOrders.Where(purchaseOrderObj => purchaseOrderObj.Id == purchaseOrder.Id).First();
            if (!purchaseorder.Equals(null))
            {
                var purchaseOrderDetailsResult = from rd in inventory.PurchaseOrderDetails
                                                 where rd.PurchaseOrder.Id == purchaseorder.Id
                                                 select rd;
                foreach (PurchaseOrderDetail rd in purchaseOrderDetailsResult)
                {
                    purchaseorder.PurchaseOrderDetails.Add(rd);
                }
            }
            return purchaseorder;
        }

        /// <summary>
        /// Retrieve All of the PurchaseOrder information from PurchaseOrder Table
        /// Return PurchaseOrder Collection
        /// </summary>
        /// <returns></returns>

        public List<entity.PurchaseOrder> GetAllPurchaseOrder()
        {
            purchaseOrderList = inventory.PurchaseOrders.ToList<PurchaseOrder>();
            if (!purchaseOrderList.Equals(null))
                return purchaseOrderList;
            return null;
        }

        /// <summary>
        ///  Insert PurchaseOrder data to the PurchaseOrder Table according to the newPurchaseOrder Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newPurchaseOrder"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(PurchaseOrder newPurchaseOrder)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToPurchaseOrders(newPurchaseOrder);
                foreach (PurchaseOrderDetail puchaseOrderDetail in newPurchaseOrder.PurchaseOrderDetails)
                {
                    this.Insert(puchaseOrderDetail);
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
        /// Update PurchaseOrder data to the PurchaseOrder Table according to the purchaseOrder Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(PurchaseOrder purchaseOrder)
        {
            // throw new NotImplementedException();
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                //foreach (PurchaseOrderDetail purchaseOrderDetail in purchaseOrder.PurchaseOrderDetails)
                //{
                //    this.Update(purchaseOrderDetail);
                //}
                //inventory.SaveChanges();
                //status = Constants.DB_STATUS.SUCCESSFULL;
                purchaseorder = inventory.PurchaseOrders.Where(iObj => iObj.Id == purchaseOrder.Id).First();
                Supplier supplierId = inventory.Suppliers.Where(s => s.Id == purchaseorder.Supplier.Id).First();
               // purchaseorder.Supplier.Id = purchaseOrder.Supplier.Id;
                purchaseorder.Supplier = supplierId;
                purchaseorder.DeliverAddress = purchaseOrder.DeliverAddress;
                purchaseorder.Attn = purchaseOrder.Attn;
                purchaseorder.ExpectedDate = purchaseOrder.ExpectedDate;
                purchaseorder.CreatedDate = purchaseOrder.CreatedDate;
                purchaseorder.ApprovedDate = purchaseOrder.ApprovedDate;
                purchaseorder.Status = purchaseOrder.Status;

                //  supplierObj.CreatedDate = supplier.CreatedDate;

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
        ///  Logically delete the PurchaseOrder table by setting the status to 2 in the PurchaseOrder table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="purchaseOrder"></param>i
        /// <returns></returns>
        public Constants.DB_STATUS Delete(PurchaseOrder purchaseOrder)
        {
            //   throw new NotImplementedException();
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                PurchaseOrder purchase = inventory.PurchaseOrders.Where(p => p.Id == purchaseorder.Id).First();
                purchase.Status = 2;
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
        /// Retrieve the PurchaseOrderdetail information  from  PurchaseOrderDetail Table according to the purchaseOrderDetail Parameter
        /// Return PurchaseOrderDetail
        /// </summary>
        /// <param name="purchaseOrderDetail"></param>
        /// <returns></returns>
        public PurchaseOrderDetail GetPurchaseOrderDetail(entity.PurchaseOrderDetail purchaseOrderDetail)
        {

            purchaseorderdetail = inventory.PurchaseOrderDetails.Where(reqObj => reqObj.Id == purchaseorderdetail.Id).First();
            if (!purchaseorderdetail.Equals(null))
                return purchaseorderdetail;
            return null;
        }
        /// <summary>
        /// Retrieve All of the PurchaseOrderDetail information from PurchaseOrderDetail Table
        /// Return PurchaseOrderDetail Collection
        /// </summary>
        /// <returns></returns>
        public List<entity.PurchaseOrderDetail> GetAllPurchaseOrderDetail()
        {
            purchaseOrderDetailList = inventory.PurchaseOrderDetails.ToList<PurchaseOrderDetail>();
            if (!purchaseOrderDetailList.Equals(null))
                return purchaseOrderDetailList;
            return null;
        }
        /// <summary>
        ///  Insert PurchaseOrderDetail data to the PurchaseOrderDetail Table according to the newPurchaseOrderDetail Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newPurchaseOrderDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(PurchaseOrderDetail newPurchaseOrderDetail)
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
        /// <summary>
        /// Update PurchaseOrderDetail data to the PurchaseOrderDetail Table according to the purchaseOrderDetail Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="purchaseOrderDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(PurchaseOrderDetail purchaseOrderDetail)
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
        /// <summary>
        ///  Logically delete the PurchaseOrderDetail table by setting the status to 2 in the PurchaseOrderDetail table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="purchaseOrderDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(PurchaseOrderDetail purchaseOrderDetail)
        {
             throw new NotImplementedException();
            //Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            //try
            //{
            //    inventory.SaveChanges();
            //    status = Constants.DB_STATUS.SUCCESSFULL;
            //}
            //catch (Exception e)
            //{
            //    status = Constants.DB_STATUS.FAILED;
            //}

            //return status;
        }

        /// <summary>
        /// Get the last record of the PurchaserOrder Id from the Purchase Order table
        /// </summary>
        /// <returns></returns>
        public int GetPurchaseOrderId()
        {
            int lastPurchaseOrderNumber = inventory.PurchaseOrders.Last().Id + 1;
            if (lastPurchaseOrderNumber.ToString().Substring(0, 4).CompareTo(DateTime.Now.Year.ToString()) != 0)
            {
                lastPurchaseOrderNumber = Converter.objToInt(DateTime.Now.Year.ToString() + "1".PadLeft(5, '0'));
            }
            return lastPurchaseOrderNumber;
        }

        public int GetPurchaseOrderDetailId()
        {
            return GetAllPurchaseOrderDetail().Last().Id + 1;
        }
    }
}
        #endregion
/****************************************/
/********* End of the Class *****************/
/****************************************/