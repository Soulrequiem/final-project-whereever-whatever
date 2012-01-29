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

        public void SelectAllPurchaseOrderDetails(int purchaseOrderNumber)
        {
            purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderNumber;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
        }

        public DataTable PurchaseOrder(int purchaseOrderNumber)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderNumber;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
            List<PurchaseOrderDetail> list = purchaseOrder.PurchaseOrderDetails.ToList();
            dt = new DataTable();
            
            foreach (PurchaseOrderDetail temp in list)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dt.Rows.Add(dr);
               
            }
            return dt;
        }

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
        public Constants.ACTION_STATUS SelectReceive(int purchaseOrderNumber)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            //update which one in purchase order table????
            DataTable dt=PurchaseOrder(purchaseOrderNumber);
            for (int i = 0; i < dt.Rows.Count;i++ )
               {
                    DataRow dr = dt.Rows[i];
                    Item item = new Item();
                    item.Id = dr[0].ToString();
                    item.Description = dr[1].ToString();
                    StockCardDetail temp = new StockCardDetail();
                    temp.Qty = Convert.ToInt32(dr[2].ToString());
                    temp.Item = item;
                    itemBroker.Insert(temp);
               }
            return status;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/

