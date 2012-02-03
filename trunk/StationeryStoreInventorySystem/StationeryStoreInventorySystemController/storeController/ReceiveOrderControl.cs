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
        private DataTable dtt;
      

        private string[] columnName = { "poNumber", "poNumberText" };
        private string[] detail = { "itemNo", "itemDescription", "quantity", "Remarks" };

        private DataColumn[] dataColumn;
        private DataColumn[] detailColumn;

        public ReceiveOrderControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory = new InventoryEntities();

            purchaseOrderBroker = new PurchaseOrderBroker(inventory);
            itemBroker = new ItemBroker(inventory);

            purchaseOrderList = purchaseOrderBroker.GetAllPurchaseOrder();

            dataColumn = new DataColumn[]{ new DataColumn(columnName[0]),
                                           new DataColumn(columnName[1])
                                          
                                          };
            detailColumn = new DataColumn[]{new DataColumn(detail[0]),
                new DataColumn(detail[1]),new DataColumn(detail[2]),new DataColumn(detail[3])};

                                

        }

        public DataColumn[] DataColumn
        {
            get { return dataColumn; }
        }
        public DataColumn[] DetailColumn
        {
            get
            {
                return new DataColumn[]{new DataColumn(detail[0]),
                new DataColumn(detail[1]),new DataColumn(detail[2]),new DataColumn(detail[3])};
            }
        }

        public DataTable PurchaseOrderNo
        {
            get 
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }
                DataRow dr;
                if(purchaseOrderList == null)
                    purchaseOrderList = purchaseOrderBroker.GetAllPurchaseOrder();
                foreach (PurchaseOrder po in purchaseOrderList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = po.Id;
                    dr[columnName[1]] = po.Id;
                    dt.Rows.Add(dr);
                }
                return dt; 
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



        public DataTable GetPurchaseOrderDetail(int purchaseOrderNumber)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderNumber;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
            List<PurchaseOrderDetail> list = purchaseOrder.PurchaseOrderDetails.ToList();
            if (dtt == null)
            {
                dtt = new DataTable();
                dtt.Columns.AddRange(detailColumn);
            }
            else
            {
                dtt.Rows.Clear();
            }
            DataRow drr;
            
            foreach (PurchaseOrderDetail temp in list)
            {
                drr = dtt.NewRow();
                drr[detail[0]] = temp.Item.Id;
                drr[detail[1]] = temp.Item.Description;
                drr[detail[2]] = temp.Qty;
                //drr[detail[3]] = "remark";
                dtt.Rows.Add(drr);

            }
            return dtt;
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

        public Constants.ACTION_STATUS ClickReceived(DataTable dt, string deliveryNo, string poNumber)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            string itemNo, itemDesc, quantity, remark;
            PurchaseOrder po = new PurchaseOrder();
            po.Id = Converter.objToInt(poNumber);
            po = purchaseOrderBroker.GetPurchaseOrder(po);
            po.DeliveryOrderNumber = deliveryNo;
            List<PurchaseOrderDetail> poDetailList = po.PurchaseOrderDetails.ToList();
            foreach (DataRow dr in dt.Rows)
            {
                itemNo = dr[detail[0]].ToString();
                itemDesc = dr[detail[1]].ToString();
                quantity = dr[detail[2]].ToString();
                remark = dr[detail[3]].ToString();
                foreach (PurchaseOrderDetail poDetail in poDetailList)
                {
                    if(poDetail.Item.Id.Equals(itemNo)){
                        poDetail.Qty = Converter.objToInt(quantity);
                        //need or not to update from purchaseOrderDetailBroker???
                        // add remark later
                    }
                }

            }

            Constants.DB_STATUS dbStatus = purchaseOrderBroker.Update(po);
            if(dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }


        public string[] GetLabelData(int purchaseOrderId)
        {
            string[] labels = new string[2];
            PurchaseOrder po = new PurchaseOrder();
            po.Id = purchaseOrderId;
            po = purchaseOrderBroker.GetPurchaseOrder(po);
            labels[0] = po.Supplier.Name;
            labels[1] = SystemStoreInventorySystemUtil.Converter.dateTimeToString(Converter.DATE_CONVERTER.DATE, po.ExpectedDate);
            return labels;
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/

