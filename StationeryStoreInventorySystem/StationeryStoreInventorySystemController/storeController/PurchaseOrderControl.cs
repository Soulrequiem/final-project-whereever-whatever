using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class PurchaseOrderControl
    {
        private IItemBroker itemBroker;
        private IPurchaseOrderBroker purchaseOrderBroker;
        private DataTable SupplierList;
        private ISupplierBroker supplierBroker;
        private DataTable table;
        private int purchaseOrderId;
        private List<PurchaseOrderDetail> poDetailList;

        public int PurchaseOrderId
        {
            get
            {
                purchaseOrderId = purchaseOrder.Id;
                return purchaseOrderId; 
}
            
        }

        public DataTable SupplierList1
        {
            get {
                List<Supplier> suppliers = supplierBroker.GetAllSupplier();
                if (table == null)
                {
                    table = new DataTable();
                    table.Columns.AddRange(supplierColumn);
                }
                else
                {
                    table.Rows.Clear();
                }

                DataRow row;
                foreach (Supplier supplier in suppliers)
                {
                    row = table.NewRow();
                    row[supplierColumn[0]]= supplier.Id;
                    row[supplierColumn[1]] = supplier.Name;
                    table.Rows.Add(row);
                }
                return table; }
            
        }
        private Employee currentEmployee;
        private PurchaseOrder purchaseOrder;
        
        //private System.Data.Objects.DataClasses.EntityCollection<PurchaseOrderDetail> purchaseOrderDetailList;

        private DataTable dt;
        private DataRow dr;
        private string[] supplierColumnName = { "SupplierID", "SupplierName" };
        private string[] columnName = { "ItemNo", "Description", "Quantity", "Price", "Amount" };
        private DataColumn[] supplierColumn;
        private DataColumn[] dataColumn;
        
        public PurchaseOrderControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            InventoryEntities inventory = new InventoryEntities();
            supplierBroker = new SupplierBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            purchaseOrderBroker = new PurchaseOrderBroker(inventory);
            
            purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderBroker.GetPurchaseOrderId();
            poDetailList = new List<PurchaseOrder>();
            //purchaseOrderDetailList = new System.Data.Objects.DataClasses.EntityCollection<PurchaseOrderDetail>();
            
            // need to load reorder quantity
            // need to load unfulfilled quantity
            supplierColumn = new DataColumn[] { new DataColumn(supplierColumnName[0]), new DataColumn(supplierColumnName[1])};
            dataColumn = new DataColumn[] { new DataColumn(columnName[0]), 
                                            new DataColumn(columnName[1]), 
                                            new DataColumn(columnName[2]), 
                                            new DataColumn(columnName[3]), 
                                            new DataColumn(columnName[4])};
        }

        public DataTable PurchaseOrderDetailList
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
                
                foreach (PurchaseOrderDetail temp in poDetailList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = temp.Item.Id;
                    dr[columnName[1]] = temp.Item.Description;
                    dr[columnName[2]] = temp.Qty;
                    dr[columnName[3]] = temp.Price;
                    dr[columnName[4]] = temp.Qty * temp.Price;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        public string SelectItemDescription(string itemDescription)
        {
            Item item = Util.GetItem(itemBroker, itemDescription);
            return item.Id;

        }

        public Constants.ACTION_STATUS SelectAdd(string itemId)
        {
            Constants.ACTION_STATUS addStatus = Constants.ACTION_STATUS.UNKNOWN;
            
            bool isFound = false;

            foreach (PurchaseOrderDetail purchaseOrderDetailTemp in purchaseOrderDetailList)
            {
                if (purchaseOrderDetailTemp.Item.Id == itemId)
                {
                    isFound = true;
                }
            }

            if (!isFound)
            {
                PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                purchaseOrderDetail.Id = purchaseOrderBroker.GetPurchaseOrderDetailId();
                Item item = new Item();
                item.Id = itemId;
                purchaseOrderDetail.Item = itemBroker.GetItem(item);

                purchaseOrderDetailList.Add(purchaseOrderDetail);

                addStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                addStatus = Constants.ACTION_STATUS.FAIL;
            }

            return addStatus;
           
        }

        public Constants.ACTION_STATUS SelectRemove(int index)
        {
            Constants.ACTION_STATUS removeStatus = Constants.ACTION_STATUS.UNKNOWN;

            if (purchaseOrderDetailList.Count >= index)
            {
                PurchaseOrderDetail purchaseOrderDetail = purchaseOrderDetailList.ElementAt(index - 1);

                purchaseOrderDetailList.Remove(purchaseOrderDetail);
                removeStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                removeStatus = Constants.ACTION_STATUS.FAIL;
            }
            
            return removeStatus;
        }

        public Constants.ACTION_STATUS SelectCreate()
        {
            Constants.ACTION_STATUS createStatus = Constants.ACTION_STATUS.UNKNOWN;

            purchaseOrder.PurchaseOrderDetails = purchaseOrderDetailList;

            if (purchaseOrderBroker.Insert(purchaseOrder) == Constants.DB_STATUS.SUCCESSFULL)
                createStatus = Constants.ACTION_STATUS.SUCCESS;
            else
                createStatus = Constants.ACTION_STATUS.FAIL;
            return createStatus;
        }

        public Constants.ACTION_STATUS SelectCancel()
        {
            Constants.ACTION_STATUS cancelStatus = Constants.ACTION_STATUS.UNKNOWN;

            if (purchaseOrderDetailList.Count > 0)
            {
                purchaseOrderDetailList = null;
                cancelStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                cancelStatus = Constants.ACTION_STATUS.FAIL;
            }
            return cancelStatus;
        }

    }
}
