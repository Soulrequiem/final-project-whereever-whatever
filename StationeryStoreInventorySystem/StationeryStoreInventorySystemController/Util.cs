using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using System.Web;

namespace StationeryStoreInventorySystemController
{
    class Util
    {
        public static void PutSession(string key, object obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        /// <summary>
        ///     Return session object from session
        ///     Created By: Taufin Rusli
        ///     Created Date: 2012/01/25
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        ///     Object of the session
        /// </returns>
        public static object GetSession(string obj)
        {
            return HttpContext.Current.Session[obj];
        }

        public static void RemoveSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        ///     Retrieve employee object from session
        ///     Created By: Taufin Rusli
        ///     Created Date: 2012/01/25
        /// </summary>
        /// <returns>
        ///     Employee object
        /// </returns>
        public static Employee GetEmployee()
        {
            return (Employee)HttpContext.Current.Session["employee"];
        }

        public static Employee ValidateUser()
        {
            Employee employee = GetEmployee();

            if (employee == null)
            {
                HttpContext.Current.Response.Redirect(Constants.loginPage, true);
            }
            return employee;
        }

        public static List<Item> GetItems(string itemDescription)
        {
            IItemBroker itemBroker = new ItemBroker();
            List<Item> items = new List<Item>();

            Item item = new Item();
            item.Description = itemDescription;

            //items = itemBroker.GetItem(item); // need to add a method to return list of item in broker
            return items;
        }
    }
}
