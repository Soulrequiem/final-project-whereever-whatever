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
        List<Department> departmentList = null;
        IDepartmentBroker departmentBroker;

        public BlacklistDepartmentControl()
        {
            InventoryEntities inventory = new InventoryEntities();
            departmentBroker = new DepartmentBroker(inventory);
            departmentList = GetDepaermentList();
        }

        public DataTable DepartmentList
        {
            get
            {
              
                return ListToDataTable(departmentList);
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
     private DataTable ListToDataTable(List<Department> deptList){
          DataTable dt = new DataTable();
                DataRow dr;
                foreach (Department dep in deptList)
                {
                    dt.NewRow();
                    dr = new DataRow();
                    dr["departmentName"] = dep.Name;
                    List<CollectionMissed> missedTime = dep.CollectionMisseds.ToList();
                    int count = 0;
                    foreach (CollectionMissed times in missedTime)
                    {
                        if (times.Status != (int)Constants.VISIBILITY_STATUS.HIDDEN)
                        {
                            count++;
                        }
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
        private List<Department> GetDepaermentList()
        {
           
            List<Department> list = new List<Department>();
            List<Department> newList = new List<Department>();
            list = departmentBroker.GetAllDepartment();
            foreach (Department dep in list)
            {
                if (dep.Status != (int)Constants.DEPARTMENT_STATUS.HIDDEN)
                {
                    newList.Add(dep);

                }
            }

            return newList;
        }


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
        public DataTable SelectLink(string departmentId){
            Department department = new Department();
            department.Id = departmentId;
            department = departmentBroker.GetDepartment(department);
            if(department.Status == (int)Constants.DEPARTMENT_STATUS.UNBLACKLIST || department.Status == (int)Constants.DEPARTMENT_STATUS.SHOW){
                department.Status = (int) Constants.DEPARTMENT_STATUS.BLACKLIST;
            }
            else{
                department.Status = (int) Constants.DEPARTMENT_STATUS.UNBLACKLIST;
            }
            departmentBroker.Update(department);
            return ListToDataTable(GetDepaermentList());

        }


    }
}
