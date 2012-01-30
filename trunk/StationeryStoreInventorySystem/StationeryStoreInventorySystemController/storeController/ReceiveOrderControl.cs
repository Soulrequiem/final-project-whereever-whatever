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

        private List<PurchaseOrder> purchaseOrderList;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "itemNo", "itemDescription", "quantity" };

        private DataColumn[] dataColumn;

        public ReceiveOrderControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory = new InventoryEntities();

            purchaseOrderBroker = new PurchaseOrderBroker(inventory);
            itemBroker = new ItemBroker(inventory);

            purchaseOrderList = purchaseOrderBroker.GetAllPurchaseOrder();
        }

        public DataTable PurchaseOrderList
        {
            get 
            {
                DataTable dt = new DataTable();
                DataRow dr;
                foreach (PurchaseOrder po in purchaseOrderList)
                {
                    dr = dt.NewRow();
                    dr["poNumber"] = po.Id;
                    dr["poNumberText"] = po.Id;
                    dt.Rows.Add(dr);
                }
                return purchaseOrderNumber; 
            }
        }
       
        public Constants.ACTION_STATUS SelectAllPurchaseOrderDetails(int index)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

            if (purchaseOrderList.Count >= index)
            {
                purchaseOrder = purchaseOrderList.ElementAt(index - 1);

                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }

            return selectStatus;            
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
        public Constants.ACTION_STATUS SelectReceived(DataTable purchaseOrderDetailTable)
        {
            Constants.ACTION_STATUS receivedStatus = Constants.ACTION_STATUS.UNKNOWN;

            if (purchaseOrderList.Count > 0)
            {
                int index = 0;
                foreach (PurchaseOrderDetail purchaseOrderDetail in purchaseOrder.PurchaseOrderDetails)
                {
                    purchaseOrderDetail.AcceptedQty = Converter.objToInt(purchaseOrderDetailTable.Rows[index++][columnName[2]]);
                    //purchaseOrderDetail. = Converter.objToInt(purchaseOrderDetailTable.Rows[index++][columnName[2]]); Need to add Remarks!!!! Arghhhhh
                }

                if (purchaseOrderBroker.Update(purchaseOrder) == Constants.DB_STATUS.SUCCESSFULL)
                {
                    receivedStatus = Constants.ACTION_STATUS.SUCCESS;
                }
                else
                {
                    receivedStatus = Constants.ACTION_STATUS.FAIL;
                }
            }
            else
            {
                receivedStatus = Constants.ACTION_STATUS.FAIL;
            }

            return receivedStatus;
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/

