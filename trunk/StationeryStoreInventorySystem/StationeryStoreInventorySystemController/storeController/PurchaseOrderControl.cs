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
        private IItemPriceBroker itemPriceBroker;
        private IPurchaseOrderBroker purchaseOrderBroker;
        private ISupplierBroker supplierBroker;
        private IEmployeeBroker employeeBroker;

        private DataTable SupplierList;
        private DataTable table;
        private int purchaseOrderId;
        private List<PurchaseOrderDetail> poDetailList;
        private List<Item> reorderList;
        private Dictionary<Item, List<double>> addedItemList;

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

        private Item item;
        private ItemPrice itemPrice;
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
            itemPriceBroker = new ItemPriceBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            //reorderList = GetReorderItemList();
            purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderBroker.GetPurchaseOrderId();
            purchaseOrder.CreatedBy = Util.GetEmployee(employeeBroker);
            purchaseOrder.CreatedDate = DateTime.Now;
            purchaseOrder.Status = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);

            poDetailList = new List<PurchaseOrderDetail>();
            addedItemList = new Dictionary<Item, List<double>>();
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
                
                // reorder item
                foreach (Item temp in reorderList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = temp.Id;
                    dr[columnName[1]] = temp.Description;
                    dr[columnName[2]] = temp.ReorderQty;
                    dr[columnName[3]] = temp.Cost;
                    dr[columnName[4]] = temp.ReorderQty * temp.Cost;
                    dt.Rows.Add(dr);
                }

                // manually added item
                foreach (Item item in addedItemList.Keys)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = item.Id;
                    dr[columnName[1]] = item.Description;
                    dr[columnName[2]] = Converter.objToInt(addedItemList[item][0]);
                    dr[columnName[3]] = Converter.objToDouble(addedItemList[item][1]);
                    dr[columnName[4]] = Converter.objToDouble(Converter.objToInt(dr[columnName[2]]) * Converter.objToDouble(dr[columnName[3]]));
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        public string ItemCode { get { return item.Id; } }
        public string Price { get { return Converter.objToMoneyString(itemPrice.Price).Substring(1); } }

        public Constants.ACTION_STATUS SelectItemDescription(string itemDescription, string supplierId)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

            item = Util.GetItem(itemBroker, itemDescription);

            itemPrice = new ItemPrice();
            itemPrice.SupplierId = supplierId;
            itemPrice.ItemId = item.Id;
            itemPrice = itemPriceBroker.GetItemPrice(itemPrice);

            if (item != null && itemPrice != null)
            {
                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }

            return selectStatus;
        }

        public void SetSupplier(string supplierCode)
        {
            reorderList = GetReorderItemList(supplierCode);
        }

        private List<Item> GetReorderItemList(string supplierCode)
        {
            List<Item> reorderList = new List<Item>();
            List<Item> itemList = itemBroker.GetAllItem();
            ItemPrice itemPrice;

            foreach (Item item in itemList)
            {
                itemPrice = new ItemPrice();
                itemPrice.ItemId = item.Id;
                itemPrice.SupplierId = supplierCode;
                itemPrice = itemPriceBroker.GetItemPrice(itemPrice);

                if (itemPrice != null)
                {
                    int bal = itemBroker.GetCurrentBalance(item);

                    decimal price = (decimal)Converter.objToDouble(itemPrice.Price);

                    item.Cost = price; // set the price

                    if (bal + purchaseOrderBroker.GetPendingQuantity(item) < item.ReorderLevel)
                    {
                        reorderList.Add(item);
                    }
                }

            }

            return reorderList;
        }

        public Constants.ACTION_STATUS AddItem(string itemId, int qty, double price)
        {
            Constants.ACTION_STATUS addStatus = Constants.ACTION_STATUS.UNKNOWN;

            Item item = new Item();
            item.Id = itemId;
            item = itemBroker.GetItem(item);

            if (item != null && qty > 0 && price > 0)
            {

                if (!addedItemList.ContainsKey(item))
                {
                    List<double> other = new List<double>();
                    other.Add(qty);
                    other.Add(price);

                    addedItemList.Add(item, other);

                    addStatus = Constants.ACTION_STATUS.SUCCESS;
                }
                else
                {
                    addStatus = Constants.ACTION_STATUS.FAIL;
                }
            }
            else
            {
                addStatus = Constants.ACTION_STATUS.FAIL;
            }

            return addStatus;
        }

        public Constants.ACTION_STATUS SelectSave(string supplierCode, string deliveryAddress, string attn, DateTime expectedDate)
        {
            Constants.ACTION_STATUS saveStatus = Constants.ACTION_STATUS.UNKNOWN;

            Supplier supplier = new Supplier();
            supplier.Id = supplierCode;
            supplier = supplierBroker.GetSupplier(supplier);
            purchaseOrder.Supplier = supplier;

            purchaseOrder.DeliverAddress = deliveryAddress;
            purchaseOrder.Attn = attn;
            purchaseOrder.ExpectedDate = expectedDate;

            PurchaseOrderDetail purchaseOrderDetail;
            int addedDetail = 0;

            // reorder item
            foreach (Item temp in reorderList)
            {
                item = new Item();
                item.Id = temp.Id;
                item = itemBroker.GetItem(item);

                purchaseOrderDetail = new PurchaseOrderDetail(purchaseOrderBroker.GetPurchaseOrderDetailId() + (addedDetail++), purchaseOrder, item, temp.Cost, temp.ReorderQty, 0);

                purchaseOrder.PurchaseOrderDetails.Add(purchaseOrderDetail);
            }

            // manually added item
            foreach (Item item in addedItemList.Keys)
            {
                purchaseOrderDetail = new PurchaseOrderDetail(purchaseOrderBroker.GetPurchaseOrderDetailId() + (addedDetail++), purchaseOrder, item, (decimal)Converter.objToDouble(addedItemList[item][1]), Converter.objToInt(addedItemList[item][0]), 0);

                purchaseOrder.PurchaseOrderDetails.Add(purchaseOrderDetail);
            }

            if (purchaseOrderBroker.Insert(purchaseOrder) == Constants.DB_STATUS.SUCCESSFULL)
            {
                saveStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                saveStatus = Constants.ACTION_STATUS.FAIL;
            }

            return saveStatus;
        }

        //public Constants.ACTION_STATUS SelectAdd()
        //{
        //    Constants.ACTION_STATUS addStatus = Constants.ACTION_STATUS.UNKNOWN;
            
        //    bool isFound = false;

        //    foreach (PurchaseOrderDetail purchaseOrderDetailTemp in purchaseOrderDetailList)
        //    {
        //        if (purchaseOrderDetailTemp.Item.Id == itemId)
        //        {
        //            isFound = true;
        //        }
        //    }

        //    if (!isFound)
        //    {
        //        PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
        //        purchaseOrderDetail.Id = purchaseOrderBroker.GetPurchaseOrderDetailId();
        //        Item item = new Item();
        //        item.Id = itemId;
        //        purchaseOrderDetail.Item = itemBroker.GetItem(item);

        //        purchaseOrderDetailList.Add(purchaseOrderDetail);

        //        addStatus = Constants.ACTION_STATUS.SUCCESS;
        //    }
        //    else
        //    {
        //        addStatus = Constants.ACTION_STATUS.FAIL;
        //    }

        //    return addStatus;
           
        //}

        //public Constants.ACTION_STATUS SelectRemove(int index)
        //{
        //    Constants.ACTION_STATUS removeStatus = Constants.ACTION_STATUS.UNKNOWN;

        //    if (purchaseOrderDetailList.Count >= index)
        //    {
        //        PurchaseOrderDetail purchaseOrderDetail = purchaseOrderDetailList.ElementAt(index - 1);

        //        purchaseOrderDetailList.Remove(purchaseOrderDetail);
        //        removeStatus = Constants.ACTION_STATUS.SUCCESS;
        //    }
        //    else
        //    {
        //        removeStatus = Constants.ACTION_STATUS.FAIL;
        //    }
            
        //    return removeStatus;
        }

        //public Constants.ACTION_STATUS SelectCreate()
        //{
        //    Constants.ACTION_STATUS createStatus = Constants.ACTION_STATUS.UNKNOWN;

        //    purchaseOrder.PurchaseOrderDetails = purchaseOrderDetailList;

        //    if (purchaseOrderBroker.Insert(purchaseOrder) == Constants.DB_STATUS.SUCCESSFULL)
        //        createStatus = Constants.ACTION_STATUS.SUCCESS;
        //    else
        //        createStatus = Constants.ACTION_STATUS.FAIL;
        //    return createStatus;
        //}

        //public Constants.ACTION_STATUS SelectCancel()
        //{
        //    Constants.ACTION_STATUS cancelStatus = Constants.ACTION_STATUS.UNKNOWN;

        //    if (purchaseOrderDetailList.Count > 0)
        //    {
        //        purchaseOrderDetailList = null;
        //        cancelStatus = Constants.ACTION_STATUS.SUCCESS;
        //    }
        //    else
        //    {
        //        cancelStatus = Constants.ACTION_STATUS.FAIL;
        //    }
        //    return cancelStatus;
        //}

    }


