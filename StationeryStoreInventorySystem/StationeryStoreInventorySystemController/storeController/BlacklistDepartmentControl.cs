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
    public class BlacklistDepartmentControl
    {
        private IDepartmentBroker departmentBroker;
        private ICollectionMissedBroker collectionMissedBroker;
        
        private Employee currentEmployee;

        private List<Department> cleanDepartmentList;
        private List<Department> unblacklistDepartmentList;
        private List<Department> blacklistDepartmentList;

        private DataTable dt;
        private DataRow dr;

        public BlacklistDepartmentControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_MANAGER);
            InventoryEntities inventory = new InventoryEntities();
            
            departmentBroker = new DepartmentBroker(inventory);

            cleanDepartmentList = departmentBroker.GetAllDepartment(Constants.DEPARTMENT_STATUS.SHOW);
            unblacklistDepartmentList = departmentBroker.GetAllDepartment(Constants.DEPARTMENT_STATUS.UNBLACKLIST);
            blacklistDepartmentList = departmentBroker.GetAllDepartment(Constants.DEPARTMENT_STATUS.BLACKLIST);
        }

        public DataTable DepartmentList
        {
            get
            {
                dt = new DataTable();

                this.ListToDataTable(cleanDepartmentList, Constants.VISIBILITY_STATUS.SHOW);
                this.ListToDataTable(unblacklistDepartmentList, Constants.VISIBILITY_STATUS.SHOW);
                this.ListToDataTable(blacklistDepartmentList, Constants.VISIBILITY_STATUS.SHOW);

                return dt;
            }
        }


        /// <summary>
        ///     Change List to DataTable
        ///     Created By:Zin Mar Thwin
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <returns>The return value of this method is resultItem.</returns>
        private DataTable ListToDataTable(List<Department> deptList, Constants.VISIBILITY_STATUS collectionMissedStatus){
            foreach (Department dep in deptList)
            {
                dr = dt.NewRow();
                dr["departmentName"] = dep.Name;
                List<CollectionMissed> missedTime = collectionMissedBroker.GetAllCollectionMissed(dep, collectionMissedStatus);
                int count = 0;
                foreach (CollectionMissed times in missedTime)
                {
                    count++;
                }
                dr["missedTime"] = count;
                dr["status"] = Converter.GetDepartmentStatusText(Converter.objToDepartmentStatus(dep.Status));
                dt.Rows.Add(dr);
            }
            return dt;
        }



         /// <summary>
         ///     Show all departments list except hidden departments
         ///     Created By:Zin Mar Thwin
         ///     Created Date:28-01-2012
         ///     Modified By:
         ///     Modified Date:
         ///     Modification Reason:
         ///     Modified By:
         ///     Modified Date:
         ///     Modification Reason:
         /// </summary>
         /// <param name="itemDescription"></param>
         /// <returns>The return value of this method is resultItem.</returns>
        //private List<Department> GetDepaermentList()
        //{
           
        //    List<Department> list = new List<Department>();
        //    List<Department> newList = new List<Department>();
        //    list = departmentBroker.GetAllDepartment();
        //    foreach (Department dep in list)
        //    {
        //        if (dep.Status != (int)Constants.DEPARTMENT_STATUS.HIDDEN)
        //        {
        //            newList.Add(dep);

        //        }
        //    }

        //    return newList;
        //}


        /// <summary>
        ///     Set blacklist/unblacklist according to the department list that user clicks
        ///     Created By:Zin Mar Thwin
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <returns>The return value of this method is resultItem.</returns>
        public Constants.ACTION_STATUS SelectLink(string departmentId){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            Department department = new Department();
            department.Id = departmentId;
            department = departmentBroker.GetDepartment(department);

            if (department != null)
            {

                switch (Converter.objToDepartmentStatus(department.Status))
                {
                    case Constants.DEPARTMENT_STATUS.BLACKLIST:
                        department = blacklistDepartmentList.Find(delegate(Department dep) { return dep.Id == departmentId; });
                        department.Status = Converter.objToInt(Constants.DEPARTMENT_STATUS.UNBLACKLIST);
                        break;
                    case Constants.DEPARTMENT_STATUS.UNBLACKLIST:
                        department = unblacklistDepartmentList.Find(delegate(Department dep) { return dep.Id == departmentId; });
                        department.Status = Converter.objToInt(Constants.DEPARTMENT_STATUS.BLACKLIST);
                        break;
                    case Constants.DEPARTMENT_STATUS.SHOW:
                        department = cleanDepartmentList.Find(delegate(Department dep) { return dep.Id == departmentId; });
                        department.Status = Converter.objToInt(Constants.DEPARTMENT_STATUS.BLACKLIST);
                        break;
                }

                departmentBroker.Update(department);
                status = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }
            
            return status;

        }


    }
}
