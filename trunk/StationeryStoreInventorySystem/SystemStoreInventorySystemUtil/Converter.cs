using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SystemStoreInventorySystemUtil
{
    public class Converter
    {
        public static Constants.DESIGNATION objToDesignation(object obj)
        {
            Constants.DESIGNATION designation = Constants.DESIGNATION.UNKNOWN;

            return designation;
        }

        public static string GetDesignationText(Constants.DESIGNATION designation)
        {
            string designationText = null;
            switch (designation)
            {
            }
            return designationText;
        }

        

        public static string GetDepartmentStatusText(Constants.DEPARTMENT_STATUS departmentStatus)
        {
            string departmentStatusText = null;

            switch (departmentStatus)
            {
                case Constants.DEPARTMENT_STATUS.BLACKLIST:
                    departmentStatusText = "Blacklist";
                    break;
                case Constants.DEPARTMENT_STATUS.HIDDEN:
                    departmentStatusText = "Hidden";
                    break;
                case Constants.DEPARTMENT_STATUS.SHOW:
                    departmentStatusText = "Show";
                    break;
                case Constants.DEPARTMENT_STATUS.UNBLACKLIST:
                    departmentStatusText = "Unblacklist";
                    break;
            }

            return departmentStatusText;
        }

        public static Constants.EMPLOYEE_ROLE objToEmployeeRole(object obj)
        {
            Constants.EMPLOYEE_ROLE status = Constants.EMPLOYEE_ROLE.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    status = Constants.EMPLOYEE_ROLE.ADMIN;
                    break;
                case 2:
                    status = Constants.EMPLOYEE_ROLE.EMPLOYEE;
                    break;
                case 3:
                    status = Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE;
                    break;
                case 4:
                    status = Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE;
                    break;
                case 5:
                    status = Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD;
                    break;
                case 6:
                    status = Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD;
                    break;
                case 7:
                    status = Constants.EMPLOYEE_ROLE.STORE_CLERK;
                    break;
                case 8:
                    status = Constants.EMPLOYEE_ROLE.STORE_MANAGER;
                    break;
                case 9:
                    status = Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR;
                    break;
            }
            return status;
        }

        /// <summary>
        ///     Converts object to Requisition Status
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Constants.REQUISITION_STATUS objToRequisitionStatus(object obj)
        {
            Constants.REQUISITION_STATUS status = Constants.REQUISITION_STATUS.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    status = Constants.REQUISITION_STATUS.PENDING;
                    break;
                case 2:
                    status = Constants.REQUISITION_STATUS.APPROVED;
                    break;
                case 3:
                    status = Constants.REQUISITION_STATUS.REJECTED;
                    break;
                case 4:
                    status = Constants.REQUISITION_STATUS.SUBMITTED;
                    break;
                case 5:
                    status = Constants.REQUISITION_STATUS.WITHDRAW;
                    break;
            }
            return status;
        }

        public static string GetRequisitionStatusText(Constants.REQUISITION_STATUS requisitionStatus)
        {
            string status = null;
            switch (requisitionStatus)
            {
                case Constants.REQUISITION_STATUS.PENDING:
                    status = "Pending";
                    break;
                case Constants.REQUISITION_STATUS.APPROVED:
                    status = "Approved";
                    break;
                case Constants.REQUISITION_STATUS.REJECTED:
                    status = "Rejected";
                    break;
                case Constants.REQUISITION_STATUS.SUBMITTED:
                    status = "Submitted";
                    break;
                case Constants.REQUISITION_STATUS.WITHDRAW:
                    status = "Withdraw";
                    break;
            }
            return status;
        }

        public static Constants.COLLECTION_STATUS objToCollectionStatus(object obj)
        {
            Constants.COLLECTION_STATUS status = Constants.COLLECTION_STATUS.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    status = Constants.COLLECTION_STATUS.NEED_TO_COLLECT;
                    break;
                case 2:
                    status = Constants.COLLECTION_STATUS.COLLECTED;
                    break;
            }

            return status;
        }

        public static string GetCollectionStatusText(Constants.COLLECTION_STATUS collectionStatus)
        {
            string status = null;
            switch (collectionStatus)
            {
                case Constants.COLLECTION_STATUS.NEED_TO_COLLECT:
                    status = "Need To Collect";
                    break;
                case Constants.COLLECTION_STATUS.COLLECTED:
                    status = "Collected";
                    break;
            }
            return status;
        }

        public static Constants.ITEM_CATEGORY objToItemCategory(object obj)
        {
            Constants.ITEM_CATEGORY category = Constants.ITEM_CATEGORY.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    category = Constants.ITEM_CATEGORY.CLIP;
                    break;
                case 2:
                    category = Constants.ITEM_CATEGORY.ENVELOPE;
                    break;
                case 3:
                    category = Constants.ITEM_CATEGORY.ERASER;
                    break;
                case 4:
                    category = Constants.ITEM_CATEGORY.EXERCISE;
                    break;
                case 5:
                    category = Constants.ITEM_CATEGORY.FILE;
                    break;
                case 6:
                    category = Constants.ITEM_CATEGORY.PAD;
                    break;
                case 7:
                    category = Constants.ITEM_CATEGORY.PAPER;
                    break;
                case 8:
                    category = Constants.ITEM_CATEGORY.PEN;
                    break;
                case 9:
                    category = Constants.ITEM_CATEGORY.PUNCHER;
                    break;
                case 10:
                    category = Constants.ITEM_CATEGORY.RULER;
                    break;
                case 11:
                    category = Constants.ITEM_CATEGORY.SCISSORS;
                    break;
                case 12:
                    category = Constants.ITEM_CATEGORY.SHARPENER;
                    break;
                case 13:
                    category = Constants.ITEM_CATEGORY.SHORTHAND;
                    break;
                case 14:
                    category = Constants.ITEM_CATEGORY.STAPLER;
                    break;
                case 15:
                    category = Constants.ITEM_CATEGORY.TACKS;
                    break;
                case 16:
                    category = Constants.ITEM_CATEGORY.TAPE;
                    break;
                case 17:
                    category = Constants.ITEM_CATEGORY.TPARENCY;
                    break;
                case 18:
                    category = Constants.ITEM_CATEGORY.TRAY;
                    break;
                case 19:
                    category = Constants.ITEM_CATEGORY.DISK;
                    break;
            }
            return category;
        }

        public static string GetItemCategoryText(Constants.ITEM_CATEGORY itemCategory)
        {
            string category = null;
            switch (itemCategory)
            {
                case Constants.ITEM_CATEGORY.CLIP:
                    category = "Clip";
                    break;
                case Constants.ITEM_CATEGORY.DISK:
                    category = "Disk";
                    break;
                case Constants.ITEM_CATEGORY.ENVELOPE:
                    category = "Envelope";
                    break;
                case Constants.ITEM_CATEGORY.ERASER:
                    category = "Eraser";
                    break;
                case Constants.ITEM_CATEGORY.EXERCISE:
                    category = "Exercise";
                    break;
                case Constants.ITEM_CATEGORY.FILE:
                    category = "File";
                    break;
                case Constants.ITEM_CATEGORY.PAD:
                    category = "Pad";
                    break;
                case Constants.ITEM_CATEGORY.PAPER:
                    category = "Paper";
                    break;
                case Constants.ITEM_CATEGORY.PEN:
                    category = "Pen";
                    break;
                case Constants.ITEM_CATEGORY.PUNCHER:
                    category = "Puncher";
                    break;
                case Constants.ITEM_CATEGORY.RULER:
                    category = "Ruler";
                    break;
                case Constants.ITEM_CATEGORY.SCISSORS:
                    category = "Scissors";
                    break;
                case Constants.ITEM_CATEGORY.SHARPENER:
                    category = "Sharpener";
                    break;
                case Constants.ITEM_CATEGORY.SHORTHAND:
                    category = "Shorthand";
                    break;
                case Constants.ITEM_CATEGORY.STAPLER:
                    category = "Stapler";
                    break;
                case Constants.ITEM_CATEGORY.TACKS:
                    category = "Tacks";
                    break;
                case Constants.ITEM_CATEGORY.TAPE:
                    category = "Tape";
                    break;
                case Constants.ITEM_CATEGORY.TPARENCY:
                    category = "Trapency";
                    break;
                case Constants.ITEM_CATEGORY.TRAY:
                    category = "Tray";
                    break;
            }
            return category;
        }

        public static Constants.DEPARTMENT_STATUS objToDepartmentStatus(object obj)
        {
            Constants.DEPARTMENT_STATUS status = Constants.DEPARTMENT_STATUS.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    status = Constants.DEPARTMENT_STATUS.SHOW;
                    break;
                case 2:
                    status = Constants.DEPARTMENT_STATUS.HIDDEN;
                    break;
                case 3:
                    status = Constants.DEPARTMENT_STATUS.BLACKLIST;
                    break;
                case 4:
                    status = Constants.DEPARTMENT_STATUS.UNBLACKLIST;
                    break;
            }
            return status;
        }

        public static Constants.UNIT_OF_MEASURE objToUnitOfMeasure(object obj)
        {
            Constants.UNIT_OF_MEASURE unit = Constants.UNIT_OF_MEASURE.UNKNOWN;

            switch (objToShort(obj))
            {
                case 1:
                    unit = Constants.UNIT_OF_MEASURE.DOZEN;
                    break;
                case 2:
                    unit = Constants.UNIT_OF_MEASURE.BOX;
                    break;
                case 3:
                    unit = Constants.UNIT_OF_MEASURE.EACH;
                    break;
                case 4:
                    unit = Constants.UNIT_OF_MEASURE.SET;
                    break;
                case 5:
                    unit = Constants.UNIT_OF_MEASURE.PACKET;
                    break;
            }
            return unit;
        }

        public static string GetUnitOfMeasureText(Constants.UNIT_OF_MEASURE unitOfMeasure)
        {
            string unit = null;
            switch (unitOfMeasure)
            {
                case Constants.UNIT_OF_MEASURE.BOX:
                    unit = "Box";
                    break;
                case Constants.UNIT_OF_MEASURE.DOZEN:
                    unit = "Dozen";
                    break;
                case Constants.UNIT_OF_MEASURE.EACH:
                    unit = "Each";
                    break;
                case Constants.UNIT_OF_MEASURE.SET:
                    unit = "Set";
                    break;
                case Constants.UNIT_OF_MEASURE.PACKET:
                    unit = "Packet";
                    break;
            }
            return unit;
        }

        /// <summary>
        ///     Converts an object into short(Int16)
        ///     If obj is null or a string, -1 will be returned
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short objToShort(object obj)
        {
            try
            {
                return Convert.ToInt16(obj);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        ///     Converts an object into int(Int32)
        ///     If obj is null or a string, -1 will be returned
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int objToInt(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        ///     Converts an object into long(Int64)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long objToLong(object obj)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        ///     Converts an object into double
        ///     
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double objToDouble(object obj)
        {
            try
            {
                return Convert.ToDouble(obj);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        
        /// <summary>
        ///     Converts an object into Datetime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime objToDateTime(object obj)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception e)
            {
                return new DateTime();
            }
        }

        /// <summary>
        ///     Converts an object into string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string objToString(object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        ///     Converts an object into money string, ex $123.45
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string objToMoneyString(object obj)
        {
            try
            {
                return String.Format("{0:C}", objToDouble(obj));
            }
            catch (Exception e)
            {
                return String.Format("{0:C", 0);
            }
        }

        public static bool objToBool(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public enum DATE_CONVERTER
        {
            DATE,
            DATETIME
        }

        /// <summary>
        ///     Converts a datetime to user formatted Date or DateTime
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string dateTimeToString(DATE_CONVERTER type, DateTime dateTime)
        {
            string result = "";

            //switch (type)
            //{
            //    case DATE_CONVERTER.DATE:
            //        result = dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
            //        break;
            //    case DATE_CONVERTER.DATETIME:
            //        result = dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
            //        break;
            //}

            switch (type)
            {
                case DATE_CONVERTER.DATE:
                    result = dateTime.ToString("yyyy-MM-dd");
                    break;
                case DATE_CONVERTER.DATETIME:
                    result = dateTime.ToString("yyyy-MM-dd HH:mm tt");
                    break;
            }

            return result;
        }
    }
}
