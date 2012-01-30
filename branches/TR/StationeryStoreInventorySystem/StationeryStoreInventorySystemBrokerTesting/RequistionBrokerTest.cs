/* Custom Project and Libraries Copyright, 2006.  Venkat, ISS */

using System;
using System.Collections.Generic;
using System.Text;
using ISS.RV.LIB;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.broker;

namespace StationeryStoreInventorySystemBrokerTesting
{
    class RequistionBrokerTest
    {
        static void Main()
        {
            // Write the Main Program for RequistionBrokerTest here... 

            RequisitionBroker reqBroker = new RequisitionBroker();
           Requisition req = new Requisition();
            RequisitionDetail reqDetail=new RequisitionDetail();
            Department dept = new Department();
            Item item = new Item();
            Employee emp = new Employee();
            dept.Id = "COMM";
            emp.Id = 1;
            emp.Department = dept;
            emp.Role = new Role();
            emp.Role.Id = 1;
            emp.User = new User();
            emp.User.Employee = emp;
            emp.User1 = new User();
            emp.User1.Employee = emp;
            
            req.Department = dept;
            
          //  req.Employee = emp;
            
            //req.Employee.Id=1;
            req.Remarks="Insert Test";
            //req.ApprovedDate=new DateTime(23-01-2012);
            //req.CreatedDate=new DateTime(23-01-2012);
            req.Status=1;
            req.Employee = emp;
            req.Employee1 = emp;
            
           // reqDetail.Requisition.Id
           // reqDetail.Item.Id="1";
            item.Id = "1";
             reqDetail.Item=item;
            reqDetail.Qty=10;
            reqDetail.DeliveredQty=20;
            req.RequisitionDetails.Add(reqDetail);
            reqDetail.Item.Employee = reqDetail.Requisition.Employee;
            
            if (reqBroker.Insert(req).Equals("FAILED"))
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Error");
            }
            /*  req.Id = "1";
    
           if (reqBroker.GetRequisition(req) != null)
           {
               Console.WriteLine(reqBroker.GetRequisition(req).Remarks);
               foreach(RequisitionDetail reqDetial in reqBroker.GetRequisition(req).RequisitionDetails)
               Console.WriteLine(reqDetial.DeliveredQty);
           }

           if (reqBroker.GetAllRequisition().Count > 0)
           {
               Console.WriteLine("Retrieve all requisitions");
               foreach (Requisition r in reqBroker.GetAllRequisition())
               {
                   Console.WriteLine(r.Id + " " + r.Remarks);
                   foreach (RequisitionDetail rd in r.RequisitionDetails)
                   {
                       Console.WriteLine(rd.Id + " " + rd.Item.Description);
                   }
               }
           }
           else
           {
               Console.WriteLine("Cannot read all requisitions");
           }

           Console.WriteLine(SystemStoreInventorySystemUtil.Converter.objToInt(SystemStoreInventorySystemUtil.Constants.VISIBILITY_STATUS.SHOW));
           Console.WriteLine(SystemStoreInventorySystemUtil.Constants.VISIBILITY_STATUS.SHOW);
*/
        
        
            #region /* Do not remove this or write codes after this  */
            ISSConsole.Pause();
            #endregion
        }
    }
}
