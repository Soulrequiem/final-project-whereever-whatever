﻿/***************************************************************************/
/*  File Name       : UpdateStationeryRetrievalControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : UpdateStationeryRetrievalControl
/*  Details         : Control representation of UpdateStationeryRetrievalControl 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemController.storeController;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class UpdateStationeryRetrievalControl
    {
        private IRetrievalBroker retrievalBroker;
        private InventoryEntities inventory;
        private IRequisitionCollectionBroker requisitionCollectionBroker;
        private ICollectionMissedBroker collectionMissedBroker;
        private Employee currentEmployee;
        private IEmployeeBroker employeeBroker;

        List<RequisitionCollection> collectionList;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "CollectionID", "collectionPoint", "collectionDate/Time", "departmentRepresentativeName", "departmentName", "collectionStatus" };

        private DataColumn[] dataColumn;

        public UpdateStationeryRetrievalControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            inventory = new InventoryEntities();
            collectionMissedBroker = new CollectionMissedBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);
            retrievalBroker = new RetrievalBroker(inventory);
            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);

            //collectionList = requisitionCollectionBroker.GetAllRequisitionCollection();

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]),
                                            new DataColumn(columnName[4]),
                                            new DataColumn(columnName[5]) };
        }
        /// <summary>
        ///     Update stationery retrieval by collection point
        ///     Created By:JinChengCheng
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetCollectionIDList()
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
            collectionList = requisitionCollectionBroker.GetAllRequisitionCollection();
            foreach (RequisitionCollection temp in collectionList)
            {
                dr = dt.NewRow();
                dr[columnName[0]] = temp.Id;
                dr[columnName[1]] = temp.CollectionPoint == null ? "" : temp.CollectionPoint.Name;
                dr[columnName[2]] = temp.CollectionPoint == null ? "" : Converter.dateTimeToString(SystemStoreInventorySystemUtil.Converter.DATE_CONVERTER.DATE, temp.CreatedDate) + " " + temp.CollectionPoint.Time;
                dr[columnName[3]] = temp.Department.Representative == null ? "" : temp.Department.Representative.Name;
                dr[columnName[4]] = temp.Department == null ? "" : temp.Department.Name;
                dr[columnName[5]] = Converter.GetCollectionStatusText(Converter.objToCollectionStatus(temp.Status));
                dt.Rows.Add(dr);
            }
            return dt;
        }
        
        public Constants.ACTION_STATUS SetCollectionStatus(Constants.COLLECTION_STATUS collectionStatus, List<string> collectionIdList)
        {
            foreach (string collectionId in collectionIdList)
            {
                RequisitionCollection requisitionCollection = new RequisitionCollection();
                requisitionCollection.Id = Converter.objToInt(collectionId);
                requisitionCollection = requisitionCollectionBroker.GetRequisitionCollection(requisitionCollection);
                requisitionCollection.Status = Converter.objToInt(collectionStatus);
                requisitionCollectionBroker.Update(requisitionCollection);
                if (collectionStatus == Constants.COLLECTION_STATUS.UNCOLLECTED)
                {
                    CollectionMissed collectionMissed = new CollectionMissed();
                    collectionMissed.Id = collectionMissedBroker.GetCollectionMissedId();
                    collectionMissed.Department = requisitionCollection.Department;
                    collectionMissed.CreatedBy = Util.GetEmployee(employeeBroker);
                    collectionMissed.CreatedDate = DateTime.Now;
                    collectionMissed.Status = Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW);
                    collectionMissedBroker.Insert(collectionMissed);
                }
            }

           
        
            return SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.UNKNOWN;
        }
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/

