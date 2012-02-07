using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StationeryStoreInventorySystem.Reports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using SystemStoreInventorySystemUtil;
using CrystalDecisions.Shared;
using StationeryStoreInventorySystemController;
using StationeryStoreInventorySystem.Reports.SSISReports;

namespace StationeryStoreInventorySystem.departmentUI
{
    public partial class DepartmentPrint : System.Web.UI.Page
    {
        ReportDocument rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ReportType"].ToString().Equals("Stationery"))
                initializeReportDocument(Constants.RequisitionDetailsReportPath);

            loadPrintData();
            loadStationeryReport();
        }

        private void loadPrintData()
        {
            StationeryStoreInventorySystem.Reports.SSISReports.StationeryRequisitionReport RR =
               new StationeryStoreInventorySystem.Reports.SSISReports.StationeryRequisitionReport();
            RR.SetDataSource((DataTable)Session["PrintData"]);
            PrintReportViewer.ReportSource = RR;
        }

        private void initializeReportDocument(string filePath)
        {
            rpt = new ReportDocument();
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + filePath);
        }

        private void loadStationeryReport()
        {
            PrintReportViewer.ParameterFieldInfo["RequisitionID"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["DeptName"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["DeptCode"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["EmployeeName"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["EmployeeNumber"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["Email"].CurrentValues.Clear();

            ParameterField f1 = PrintReportViewer.ParameterFieldInfo["RequisitionID"];
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            v1.Value = Util.GetSession("RequisitionID");
            f1.CurrentValues.Add(v1);

            ParameterField f2 = PrintReportViewer.ParameterFieldInfo["DeptName"];
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();
            v2.Value = Util.GetSession("DeptName");
            f2.CurrentValues.Add(v2);

            ParameterField f3 = PrintReportViewer.ParameterFieldInfo["DeptCode"];
            ParameterDiscreteValue v3 = new ParameterDiscreteValue();
            v3.Value = Util.GetSession("DeptCode");
            f3.CurrentValues.Add(v3);

            ParameterField f4 = PrintReportViewer.ParameterFieldInfo["EmployeeName"];
            ParameterDiscreteValue v4 = new ParameterDiscreteValue();
            v4.Value = Util.GetSession("EmployeeName");
            f4.CurrentValues.Add(v4);

            ParameterField f5 = PrintReportViewer.ParameterFieldInfo["EmployeeNumber"];
            ParameterDiscreteValue v5 = new ParameterDiscreteValue();
            v5.Value = Util.GetSession("EmployeeNumber");
            f5.CurrentValues.Add(v5);


            ParameterField f6 = PrintReportViewer.ParameterFieldInfo["Email"];
            ParameterDiscreteValue v6 = new ParameterDiscreteValue();
            v6.Value = Util.GetSession("Email");
            f6.CurrentValues.Add(v6);

            PrintReportViewer.DataBind();

            Util.RemoveSession("RequisitionID");
            Util.RemoveSession("DeptName");
            Util.RemoveSession("DeptCode");
            Util.RemoveSession("EmployeeName");
            Util.RemoveSession("EmployeeNumber");
            Util.RemoveSession("Email");
        }
    }
}