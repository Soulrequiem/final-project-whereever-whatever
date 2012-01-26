using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryEntities inventory = new InventoryEntities();

            DepartmentBroker departmentBroker = new DepartmentBroker(inventory);
            Department department = new Department();
            department.Id = "COMM";
            department = departmentBroker.GetDepartment(department);

            CollectionPointBroker collectionPointBroker = new CollectionPointBroker(inventory);
            CollectionPoint collectionPoint = new CollectionPoint();
            collectionPoint.Id = 1;
            collectionPoint = collectionPointBroker.GetCollectionPoint(collectionPoint);

            department.CollectionPoint = collectionPoint;

            Console.WriteLine(departmentBroker.Update(department));
        }
    }
}
