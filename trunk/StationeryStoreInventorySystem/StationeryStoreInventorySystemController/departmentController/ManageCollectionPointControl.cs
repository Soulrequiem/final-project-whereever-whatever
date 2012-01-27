using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class ManageCollectionPointControl
    {
        private ICollectionPointBroker collectionPointBroker;
        private Employee currentEmployee;
        private List<CollectionPoint> allCollectionPoint;
        private CollectionPoint currentCollectionPoint;

        public ManageCollectionPointControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            collectionPointBroker = new CollectionPointBroker();
            allCollectionPoint = collectionPointBroker.GetAllCollectionPoint();

            currentCollectionPoint = currentEmployee.Department.CollectionPoint;
        }

        public DataTable AllCollectionPoint
        {
            get
            {
                DataTable dt = new DataTable();

                if (allCollectionPoint.Count > 0)
                {
                    DataRow dr;
                    foreach (CollectionPoint collectionPoint in allCollectionPoint)
                    {
                        dr = new DataRow();

                        dt.NewRow();
                        dr["value"] = collectionPoint.Id;
                        dr["text"] = collectionPoint.Name + " (" + collectionPoint.Time.ToString("hh:ss tt") + ")";
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
        }

        //public List<CollectionPoint> GetAllCollectionPoint()
        //{
            

        //    return collectionPointBroker.GetAllCollectionPoint();
        //}

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
