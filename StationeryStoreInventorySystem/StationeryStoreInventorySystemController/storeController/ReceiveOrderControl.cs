/***************************************************************************/
/*  File Name       : ReceiveOrderControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ReceiveOrderControl
/*  Details         : Control representation of ReceiveOrderControl 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;


namespace StationeryStoreInventorySystemController.storeController
{
    public class ReceiveOrderControl
    {
        private IPurchaseOrderBroker purchaseOrderBroker;
        private IItemBroker itemBroker;
        
        private Employee currentEmployee;
        private DataTable purchaseOrderNumber;
        private PurchaseOrder purchaseOrder;
        private Supplier supplier;

        private DataTable dt;
        private DataRow dr;



        public ReceiveOrderControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory = new InventoryEntities();

            purchaseOrderBroker = new PurchaseOrderBroker(inventory);
            itemBroker = new ItemBroker(inventory);
        }

        public DataTable PurchaseOrderNumber
        {
            get {
                DataTable dt = new DataTable();
                DataRow dr;
                List<PurchaseOrder> list = purchaseOrderBroker.GetAllPurchaseOrder();
                foreach (PurchaseOrder po in list)
                {
                    dt.NewRow();
                    dr = new DataRow();
                    dr["poNumber"] = po.Id;
                    dt.Rows.Add(dr);
                }
                return purchaseOrderNumber; }
           
        }
       

        public DataTable SelectAllPurchaseOrderDetails(int purchaseOrderNumber)
        {
            purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderNumber;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
            List<PurchaseOrderDetail> list = purchaseOrder.PurchaseOrderDetails.ToList();
            DataTable dt = new DataTable();
            DataRow dr;
            foreach (PurchaseOrderDetail pod in list)
            {
                dt.NewRow();
                dr = new DataRow();
                dr["itemNo"] = pod.Item.Id;
                dr["itemDescription"] = pod.Item.Description;
                dr["quantity"] = pod.Qty;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        //public DataTable PurchaseOrder(int purchaseOrderNumber)
        //{
        //    PurchaseOrder purchaseOrder = new PurchaseOrder();
        //    purchaseOrder.Id = purchaseOrderNumber;
        //    purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
        //    List<PurchaseOrderDetail> list = purchaseOrder.PurchaseOrderDetails.ToList();
        //    dt = new DataTable();
            
        //    foreach (PurchaseOrderDetail temp in list)
        //    {
        //        dr = dt.NewRow();
        //        dr["itemNo"] = temp.Item.Id;
        //        dr["itemDescription"] = temp.Item.Description;
        //        dr["quantity"] = temp.Qty;
        //        dt.Rows.Add(dr);
               
        //    }
        //    return dt;
        //}

        /// <summary>
        ///     Insert stock card details and update purchase order
        ///     Created By:JinChengCheng
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="purchaseOrderNumber"></param>
        /// <returns>The return type of this method is status.</returns>
        public Constants.ACTION_STATUS SelectReceive(int purchaseOrderId ,DataTable dt)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            PurchaseOrder po = new PurchaseOrder();
            po.Id = purchaseOrderId;
            po = purchaseOrderBroker.GetPurchaseOrder(po);
            List<PurchaseOrderDetail> poDetailList = po.PurchaseOrderDetails.ToList();
           
            foreach(DataRow dr in dt.Rows)
            {
                foreach (PurchaseOrderDetail poDetail in poDetailList)
                {
                    if (poDetail.Item.Id == dr["itemNo"])
                    {
                        poDetail.AcceptedQty = (int)dr["quantity"];
                        purchaseOrderBroker.Update(poDetail);
                    }
                }
              
             }
            
            return status;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/

