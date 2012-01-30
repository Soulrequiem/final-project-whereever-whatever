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

            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:/TR/final-project-whereever-whatever/branches/TR/StationeryStoreInventorySystem/ConsoleApplication1/aha/DataInput.xls;";

        connectionString += "Extended Properties=Excel 8.0;";

        // always read from the sheet1.

        OleDbCommand myCommand = new OleDbCommand("Select * from [Data$];");

        OleDbConnection myConnection = new OleDbConnection(connectionString);

        myConnection.Open();

        myCommand.Connection = myConnection;

        OleDbDataReader myReader = myCommand.ExecuteReader();

            InventoryEntities inventory = new InventoryEntities();
            ItemBroker itemBroker = new ItemBroker(inventory);
            EmployeeBroker employeeBroker = new EmployeeBroker(inventory);

            Employee employee = new Employee();
            employee.Id = 1;
            employee = employeeBroker.GetEmployee(employee);

        while (myReader.Read())

        {

            Item item = new Item(myReader.GetValue(0).ToString(), Convert.ToInt32(myReader.GetValue(1)), myReader.GetValue(2).ToString(), Convert.ToInt32(myReader.GetValue(3)), Convert.ToInt32(myReader.GetValue(4)), 0, Convert.ToInt32(myReader.GetValue(5)), DateTime.Now, employee, 1);

        // it can read upto 5 columns means A to E. In your case if the requirement is different then change the loop limits a/c to it.
        
        for (int i = 0; i < 5; i++)

        {

            Console.Write(myReader.GetValue(i) + " ");
        //Console.Write(myReader.ToString() + " ");

        }

        Console.WriteLine(item.Description + " has been added " + itemBroker.Insert(item));

        }

        myConnection.Close();

        }
    }
}
