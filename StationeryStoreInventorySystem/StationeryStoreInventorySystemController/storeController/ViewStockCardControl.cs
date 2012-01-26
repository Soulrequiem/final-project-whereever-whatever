using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewStockCardControl
    {
        IItemBroker itemBroker;
        IStockCardBroker stockCardBroker;
        Employee employee;
        public ViewStockCardControl()
        {
            employee = Util.ValidateUser();
            itemBroker = new ItemBroker();
            stockCardBroker = new StockCardBroker();
        }

        public StockCard GetStockCard(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            
            item = itemBroker.GetItem(item);
            
            StockCard stockCard = null;
            if (item != null)
            {
                stockCard = new StockCard();
                stockCard.Item = item;

                stockCard = stockCardBroker.GetStockCard(stockCard);

            }
            
            return stockCard;
        }

        public DataTable GetStockCardDetails(StockCard stockCard)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            List<StockCardDetail> stockCardDetailList = (List<StockCardDetail>)stockCard.StockCardDetails;
            string name = null;
            foreach(StockCardDetail temp in stockCardDetailList){
                int type = temp.InputFrom;
                string id = temp.InputFromId;
                if(type == (int) Constants.INPUT_FROM_TYPE.SUPPLIER){
                    ISupplierBroker supplierBroker = new SupplierBroker();
                    Supplier supplier = new Supplier();
                    supplier.Id = id;
                    supplier = supplierBroker.GetSupplier(supplier);
                    name = "Supplier- "+supplier.Name;
                }
                else if(type == (int) Constants.INPUT_FROM_TYPE.DEPT)
                {
                    IDepartmentBroker departmentBroker = new DepartmentBroker();
                    Department department = new Department();
                    department.Id = id;
                    department = departmentBroker.GetDepartment(department);
                    name = department.Name;
                }
                else{
                    IDiscrepancyBroker discrepancyBroker = new DiscrepancyBroker();
                    StockAdjustment stockAdjustment = new StockAdjustment();
                    stockAdjustment.id = id;
                    stockAdjustment = discrepancyBroker.GetStockAdjustment(stockAdjustment);
                    name = "Stock Adjustment "+ stockAdjustment.createddate;
                }

                dt.NewRow();
                dr = new DataRow();
                dr["date"] = temp.CreatedDate;
                dr["dept/supplier"] = name;
                dr["qty"] = temp.Qty;
                dr["balance"] = temp.Balance;
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
