using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data.OleDb;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*InventoryEntities inventory = new InventoryEntities();

            DepartmentBroker departmentBroker = new DepartmentBroker(inventory);
            Department department = new Department();
            department.Id = "COMM";
            department = departmentBroker.GetDepartment(department);

            CollectionPointBroker collectionPointBroker = new CollectionPointBroker(inventory);
            CollectionPoint collectionPoint = new CollectionPoint();
            collectionPoint.Id = 1;
            collectionPoint = collectionPointBroker.GetCollectionPoint(collectionPoint);

            department.CollectionPoint = collectionPoint;

            Console.WriteLine(departmentBroker.Update(department));*/

            Read_Excel();
        }

        static void Read_Excel()

        {

        // Test.xls is in the C:\

            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/Users/User/Desktop/StationeryStoreInventorySystem/ConsoleApplication1/aha/DataInput.xls;";

        connectionString += "Extended Properties=Excel 8.0;";

        // always read from the sheet1.

        OleDbCommand myCommand = new OleDbCommand("Select * from [Data$];");

        OleDbConnection myConnection = new OleDbConnection(connectionString);

        myConnection.Open();

        myCommand.Connection = myConnection;

        OleDbDataReader myReader = myCommand.ExecuteReader();

        while (myReader.Read())

        {

        // it can read upto 5 columns means A to E. In your case if the requirement is different then change the loop limits a/c to it.

        for (int i = 0; i < 5; i++)

        {

            Console.Write(myReader.GetValue(i) + " ");
        //Console.Write(myReader.ToString() + " ");

        }

        Console.WriteLine();

        }

        myConnection.Close();

        }
    }
}
