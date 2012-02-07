using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemStoreInventorySystemUtil
{
    public class Constants
    {
        public const string ReorderReport = "Reorder Report";
        public const string ItemMovementReport = "Stock Item Movement Report";
        public const string StationeryTenderReport = "Stationery Supply Tender Form";
        public const string ItemReportPath = "\\Reports\\SSISReports\\ItemsReport.rpt";
        public const string ItemReport = "Inventory Status Report";
        public const string StationeryCatalogueReport = "Stationery Catalogue";
        public const string CollectionReportPath = "\\Reports\\SSISReports\\CollectionsReport.rpt";
        public const string ColletionReport = "Collection List";
        public const string EmployeeReportPath = "\\Reports\\SSISReports\\EmployeesReport.rpt";
        public const string EmployeeReport = "Employees List";
        public const string DepartmentReportPath = "\\Reports\\SSISReports\\DepartmentsReport.rpt";
        public const string DepartmentReport = "Department List";
        public const string RequisitionReportPath = "\\Reports\\SSISReports\\RequisitionReport.rpt";
        public const string RequisitionReport = "Requisitions List";
        public const string SupplierReportPath = "\\Reports\\SSISReports\\SupplierReport.rpt";
        public const string SupplierReport = "Supplier List";
        public const string UserReportPath = "\\Reports\\SSISReports\\UserReport.rpt";
        public const string UserReport = "User List";
        public const string ItemPriceReportPath = "\\Reports\\SSISReports\\ItemPriceReport.rpt";
        public const string ItemPriceReport = "ItemPrice List";
        public const string RolesReportPath = "\\Reports\\SSISReports\\RolesReport.rpt";
        public const string RolesReport = "Roles List";
        public const string ReportViewPath = "../commonUI/ReportView.aspx";
        public const string PrintViewPath = "../commonUI/PrintView.aspx";
        public const string RequisitionDetailsReportPath = "\\Reports\\SSISReports\\StationeryRequisitionReport.rpt";
        public const string ItemConsumptionReport = "Item Consumption Report";
        public const string ByRequsitions = "By Requisitions";
        public const string ByItems = "By Items";
        public const string stockCardReportPath = "\\Reports\\SSISReports\\ViewStockCardReport.rpt";
        public const string purchaseOrderReportPath = "\\Reports\\SSISReports\\StationeryPurchaseOrderReport.rpt";
        public const string deliverOrderReportPatch = "\\Reports\\SSISReports\\DeliveryOrderFormReport.rpt";
        public const string adjustmentOrderReportPath = "\\Reports\\SSISReports\\InventoryAdjustmentVoucherReport.rpt";
        public enum VISIBILITY_STATUS
        {
            UNKNOWN = 0,
            SHOW,
            HIDDEN
        }

        public enum DEPARTMENT_STATUS
        {
            UNKNOWN = 0,
            SHOW,
            HIDDEN,
            BLACKLIST,
            UNBLACKLIST
        }

        public enum REQUISITION_STATUS
        {
            UNKNOWN = 0,
            PENDING,
            APPROVED,
            REJECTED,
            SUBMITTED,
            WITHDRAW,
            HIDDEN,
            COMPLETE
        }

        public enum COLLECTION_STATUS
        {
            UNKNOWN = 0,
            NEED_TO_RETRIEVE,
            NEED_TO_COLLECT,
            COLLECTED,
            UNCOLLECTED
        }

        public enum ITEM_CATEGORY
        {
            UNKNOWN = 0,
            CLIP,
            ENVELOPE,
            ERASER,
            EXERCISE,
            FILE,
            PEN,
            PUNCHER,
            PAD,
            PAPER,
            RULER,
            SCISSORS,
            TAPE,
            SHARPENER,
            SHORTHAND,
            STAPLER,
            TACKS,
            TPARENCY,
            TRAY, 
            DISK
        }

        public enum UNIT_OF_MEASURE
        {
            UNKNOWN = 0,
            DOZEN,
            BOX,
            EACH,
            SET,
            PACKET
        }

        public enum DB_STATUS
        {
            UNKNOWN = 0,
            SUCCESSFULL,
            FAILED,
        }

        public enum ACTION_STATUS
        {
            UNKNOWN = 0,
            SUCCESS,
            FAIL
        }

        public enum INPUT_FROM_TYPE // inputFrom from StockCardDetails
        {
            UNKNOWN = 0,
            DEPT,
            SUPPLIER,
            STOCK_ADJUSTMENT
        }

        public enum EMPLOYEE_ROLE
        {
            UNKNOWN = 0,
            ADMIN,
            EMPLOYEE,
            DEPARTMENT_REPRESENTATIVE,
            TEMPORARY_DEPARTMENT_REPRESENTATIVE,
            DEPARTMENT_HEAD,
            TEMPORARY_DEPARTMENT_HEAD,
            STORE_CLERK,
            STORE_MANAGER,
            STORE_SUPERVISOR
        }

        public enum DESIGNATION
        {
            UNKNOWN = 0,
            PROFESSOR,
            SENIOR_PROFESSOR,
            ACCOUNTANT,
            SENIOR_ACCOUNTANT
        }

        public enum NOTIFICATION_STATUS
        {
            UNKNOWN = 0,
            UNREAD,
            READ,
            HIDDEN
        }

        public enum DISCREPANCY_TYPE
        {
            UNKNOWN,
            SUPERVISOR,
            MANAGER
        }
    }
}