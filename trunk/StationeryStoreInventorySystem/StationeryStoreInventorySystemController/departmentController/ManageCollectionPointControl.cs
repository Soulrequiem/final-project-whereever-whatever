/***************************************************************************/
/*  File Name       : ManageCollectionPointControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ManageCollectionPointControl
/*  Details         : Controller representation of ManageCollectionPoint 
/***************************************************************************/
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
    class ManageCollectionPointControl
    {
        ICollectionPointBroker collectionPointBroker;
        IDepartmentBroker departmentBroker;
        List<CollectionPoint> collectionPointList;
        CollectionPoint collectionPoint;
        CollectionPoint newCollectionPoint;
        Employee employee;
        public ManageCollectionPointControl()
        {
            collectionPointBroker = new CollectionPointBroker();
            collectionPoint = new CollectionPoint();
            //collectionPoint = new CollectionPoint();
            //collectionPoint=collectionPointBroker.GetCollectionPoint(collectionPoint);
        }

        //public CollectionPoint GetCollectionPoint()
        //{
        //    return collectionPoint;
        //}
        //public List<CollectionPoint> CollectionPointList()
        //{
        //    collectionPointList = collectionPointBroker.GetAllCollectionPoint();
        //    return collectionPointList;
        //}

        /// <summary>
        ///     The usage of this method
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetCollectionPoint(int employeeId)
        {
            DataTable dt = new DataTable();
            DataRow dr = new DataRow();
            collectionPoint.Id = employee.Department.CollectionPoint.Id;
            collectionPoint=collectionPointBroker.GetCollectionPoint(collectionPoint);
            dt.NewRow();
            dr["collectionId"] = collectionPoint.Id;
            dr["collectionPoint"] = collectionPoint.Name;
            dr["collectionTime"] = collectionPoint.Time;
            dt.Rows.Add(dr);
            return dt;
        }

        //public Constants.ACTION_STATUS SelectSave(int collectionPoint)
        //{
        //    Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
        //    CollectionPoint collectionpoint = new CollectionPoint();
        //    Constants.DB_STATUS dbStatus = collectionPointBroker.Insert(collectionpoint);
        //    if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
        //        status = Constants.ACTION_STATUS.SUCCESS;
        //    else
        //        status = Constants.ACTION_STATUS.FAIL;
        //    return status;
        //}


        /// <summary>
        ///     The usage of this method
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="collectionPointId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectSave(int collectionPointId)
        {
            DataTable dt = new DataTable();
            DataRow dr = new DataRow();
            newCollectionPoint = new CollectionPoint();
            newCollectionPoint.Id = collectionPointId;
            employee.Department.CollectionPoint.Id = newCollectionPoint.Id;
            dt.NewRow();
            dr["collectionId"] = newCollectionPoint.Id;
            dr["collectionPoint"] = newCollectionPoint.Name;
            dr["collectionTime"] = newCollectionPoint.Time;
            dt.Rows.Add(dr);
            return dt;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/