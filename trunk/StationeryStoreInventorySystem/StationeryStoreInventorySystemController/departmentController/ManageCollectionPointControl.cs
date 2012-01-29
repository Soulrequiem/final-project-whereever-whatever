using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class ManageCollectionPointControl
    {
        private ICollectionPointBroker collectionPointBroker;
        
        private Employee currentEmployee;
        private CollectionPoint currentCollectionPoint;
        
        private List<CollectionPoint> allCollectionPoint;

        private DataTable dt;
        private DataRow dr;
        
        public ManageCollectionPointControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            InventoryEntities inventory = new InventoryEntities();

            collectionPointBroker = new CollectionPointBroker(inventory);

            allCollectionPoint = collectionPointBroker.GetAllCollectionPoint();
            currentCollectionPoint = currentEmployee.Department.CollectionPoint;
        }

        public DataTable CurentCollectionPoint
        {
            get
            {
                dt = new DataTable();
                
                if (currentCollectionPoint != null)
                {
                    dr = dt.NewRow();
                    dr["collectionPoint"] = currentCollectionPoint.Name;
                    dr["collectionTime"] = currentCollectionPoint.Time;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }
        public DataTable AllCollectionPoint
        {
            get
            {
                dt = new DataTable();

                if (allCollectionPoint.Count > 0)
                {
                    foreach (CollectionPoint collectionPoint in allCollectionPoint)
                    {
                        dr = dt.NewRow();
                        dr["value"] = collectionPoint.Id;
                        dr["text"] = collectionPoint.Name + " (" + collectionPoint.Time.ToString("hh:ss tt") + ")";
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
        }

        
        public Constants.ACTION_STATUS SelectSave(int collectionPointId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            CollectionPoint collectionPoint = currentEmployee.Department.CollectionPoint;
            collectionPoint.Id = collectionPointId;

            if (collectionPointBroker.Update(collectionPoint) == SystemStoreInventorySystemUtil.Constants.DB_STATUS.SUCCESSFULL)
            {
                status = SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                status = SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }

        public void SelectPrint()
        {
        }
    }
}
