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
        private InventoryEntities inventory;

        private ICollectionPointBroker collectionPointBroker;
        private IEmployeeBroker employeeBroker;
        
        private Employee currentEmployee;
        
        private List<CollectionPoint> allCollectionPoint;

        private DataTable dt;
        private DataTable dtList;
        private DataRow dr;

        private string[] columnName = { "CollectionPoint", "CollectionTime", "CollectionID" };

        private DataColumn[] dataColumn; // for drop down list
        private DataColumn[] dataColumnList;
        
        public ManageCollectionPointControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            inventory = new InventoryEntities();

            collectionPointBroker = new CollectionPointBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            allCollectionPoint = collectionPointBroker.GetAllCollectionPoint();
            
            dataColumn = new DataColumn[] { new DataColumn(columnName[2]),
                                            new DataColumn(columnName[0]) };

            dataColumnList = new DataColumn[] { new DataColumn(columnName[2]),
                                                new DataColumn(columnName[0]),
                                                new DataColumn(columnName[1]) };
        }

        public DataTable CurrentCollectionPoint
        {
            get
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumnList);
                }
                else
                {
                    dt.Rows.Clear();
                }
                
                if (currentEmployee.Department.CollectionPoint != null)
                {
                    dr = dt.NewRow();
                    dr[columnName[2]] = currentEmployee.Department.CollectionPoint.Id;
                    dr[columnName[0]] = currentEmployee.Department.CollectionPoint.Name;
                    dr[columnName[1]] = currentEmployee.Department.CollectionPoint.Time;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }
        public DataTable AllCollectionPoint
        {
            get
            {
                if (dtList == null)
                {
                    dtList = new DataTable();
                    dtList.Columns.AddRange(dataColumn);
                }
                else
                {
                    dtList.Rows.Clear();
                }

                if (allCollectionPoint.Count > 0)
                {
                    foreach (CollectionPoint collectionPoint in allCollectionPoint)
                    {
                        dr = dtList.NewRow();
                        dr[columnName[2]] = collectionPoint.Id;
                        dr[columnName[0]] = collectionPoint.Name + " (" + collectionPoint.Time.ToString(@"hh\:mm") + ")";
                        dtList.Rows.Add(dr);
                    }
                }

                return dtList;
            }
        }

        
        public Constants.ACTION_STATUS SelectSave(int collectionPointId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            try
            {
                Employee employee = new Employee();
                employee.Id = currentEmployee.Id;
                employee = employeeBroker.GetEmployee(employee);

                CollectionPoint collectionPoint = new CollectionPoint();
                collectionPoint.Id = collectionPointId;
                collectionPoint = collectionPointBroker.GetCollectionPoint(collectionPoint);

                if (collectionPoint != null)
                {

                    employee.Department.CollectionPoint = collectionPoint;

                    if (employeeBroker.Update(employee) == SystemStoreInventorySystemUtil.Constants.DB_STATUS.SUCCESSFULL)
                    {
                        currentEmployee = employee;
                        Util.SetEmployee(currentEmployee);
                        status = SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS;
                    }
                    else
                    {
                        status = SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL;
                    }
                }
                else
                {
                    status = Constants.ACTION_STATUS.FAIL;
                }

                if (status == Constants.ACTION_STATUS.SUCCESS)
                {
                    inventory.SaveChanges();
                }
            }
            catch (Exception e)
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }

        public void SelectPrint()
        {
        }
    }
}
