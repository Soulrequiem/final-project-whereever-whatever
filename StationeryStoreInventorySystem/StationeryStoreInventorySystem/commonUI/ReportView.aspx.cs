using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using SA34_Team9_StationeryStoreInventorySystem.Reports;
using System.Data;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ReportView : System.Web.UI.Page
    {
        GenerateReportsControl grCtrl;
        ReportDocument rpt;
        private GenerateReportsControl getControl()
        {
            if (grCtrl == null)
                grCtrl = new GenerateReportsControl();
            return grCtrl;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SSISCrystalReportViewer.EnableDatabaseLogonPrompt = false;
            rpt = new ReportDocument();
            string sReportType = Session["ReportType"].ToString();
            if (sReportType.Equals(Constants.ItemReport))
            {
                LoadItemReport();
            }
            else if (sReportType.Equals(Constants.ColletionReport))
            {
                //LoadCollectionReport();
            
            }
            else if (sReportType.Equals(Constants.DepartmentReport))
            {
                LoadDepartmentReport();
            }
            else if (sReportType.Equals(Constants.EmployeeReport))
            {
                LoadEmployeeReport();
            }
            else if (sReportType.Equals(Constants.ItemPriceReport))
            {
                LoadItemPriceReport();
            }
            else if (sReportType.Equals(Constants.RequisitionReport))
            {
                LoadRequisitionReport();
            }
            else if (sReportType.Equals(Constants.SupplierReport))
            {
                LoadSupplierReport();
            }
            else if (sReportType.Equals(Constants.UserReport))
            {
                LoadUserReport();
            }
            else if (sReportType.Equals(Constants.RolesReport))
            {
                LoadRolesReport();
            }
            BindData();
        }

        private void BindData()
        {
            SSISCrystalReportViewer.DataBind();
        }

        private void LoadItemReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.ItemReportPath);

            DataTable dt = (DataTable)Session["ReportData"];

            SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.ItemsReport IR =
                new Reports.SSISReports.ItemsReport();
            IR.SetDataSource(dt);
            SSISCrystalReportViewer.ReportSource = IR;
        }

        //private void LoadCollectionReport()
        //{
        //    rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.CollectionReportPath);

        //    DataTable dt = (DataTable)Session["ReportData"];

        //    SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.CollectionsReport CR =
        //        new Reports.SSISReports.CollectionsReport();
        //    CR.SetDataSource(dt);
        //    SSISCrystalReportViewer.ReportSource = CR;
        //}

        private void LoadDepartmentReport()
        {
            //rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.DepartmentReportPath);

            //DataTable dt = (DataTable)Session["ReportData"];

            //SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.DepartmentsReport DR =
            //    new Reports.SSISReports.DepartmentsReport();
            //DR.SetDataSource(dt);
            //SSISCrystalReportViewer.ReportSource = DR;
        }

        private void LoadEmployeeReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.EmployeeReportPath);

            DataTable dt = (DataTable)Session["ReportData"];

            SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.EmployeesReport ER =
                new Reports.SSISReports.EmployeesReport();
            ER.SetDataSource(dt);
            SSISCrystalReportViewer.ReportSource = ER;

            //SSISCrystalReportViewer.ReportSource = CR;
        }

        private void LoadItemPriceReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.ItemPriceReportPath);

            DataTable dt = (DataTable)Session["ReportData"];


            //SSISCrystalReportViewer.ReportSource = CR;
        }

        private void LoadRequisitionReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.RequisitionReportPath);

            DataTable dt = (DataTable)Session["ReportData"];


            //SSISCrystalReportViewer.ReportSource = CR;
        }

        private void LoadSupplierReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.SupplierReportPath );

            DataTable dt = (DataTable)Session["ReportData"];


            SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.SupplierReport SR =
                new Reports.SSISReports.SupplierReport();
            SR.SetDataSource(dt);
            SSISCrystalReportViewer.ReportSource = SR;
        }

        private void LoadUserReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.UserReportPath);

            DataTable dt = (DataTable)Session["ReportData"];


            //SSISCrystalReportViewer.ReportSource = CR;
        }

        private void LoadRolesReport()
        {
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + Constants.RolesReportPath);

            DataTable dt = (DataTable)Session["ReportData"];

            SA34_Team9_StationeryStoreInventorySystem.Reports.SSISReports.RolesReport RR =
                new Reports.SSISReports.RolesReport();
            RR.SetDataSource(dt);
            SSISCrystalReportViewer.ReportSource = RR;
        }
        
    }
}