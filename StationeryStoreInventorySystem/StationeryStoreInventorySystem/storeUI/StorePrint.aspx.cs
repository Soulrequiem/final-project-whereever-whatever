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

namespace StationeryStoreInventorySystem.storeUI
{
    public partial class StorePrint : System.Web.UI.Page
    {
        ReportDocument rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ReportType"].ToString().Equals("Stockcard"))
                initializeReportDocument(Constants.stockCardReportPath);
            else if (Session["ReportType"].ToString().Equals("PurchaseOrder"))
                initializeReportDocument(Constants.purchaseOrderReportPath);
            else if (Session["ReportType"].ToString().Equals("DeliverOrder"))
                initializeReportDocument(Constants.deliverOrderReportPatch);
            else if (Session["ReportType"].ToString().Equals("AdjustmentVoucher"))
                initializeReportDocument(Constants.adjustmentOrderReportPath);

            loadPrintData();

            if (Session["ReportType"].ToString().Equals("Stockcard"))
                loadStockCardReport();
            else if (Session["ReportType"].ToString().Equals("PurchaseOrder"))
                loadPurchaseOrderReport();
            else if (Session["ReportType"].ToString().Equals("DeliverOrder"))
                loadDeliverOrderReport();
            else if (Session["ReportType"].ToString().Equals("AdjustmentVoucher"))
                loadAdjustmentVoucherReport();
        }

        private void loadPrintData()
        {
            if (Session["ReportType"].ToString().Equals("Stockcard"))
            {
                StationeryStoreInventorySystem.Reports.SSISReports.ViewStockCardReport RR =
                    new StationeryStoreInventorySystem.Reports.SSISReports.ViewStockCardReport();
                RR.SetDataSource((DataTable)Session["PrintData"]);
                PrintReportViewer.ReportSource = RR;
            }
            else if (Session["ReportType"].ToString().Equals("PurchaseOrder"))
            {
                StationeryStoreInventorySystem.Reports.SSISReports.StationeryPurchaseOrderReport RR =
                    new StationeryStoreInventorySystem.Reports.SSISReports.StationeryPurchaseOrderReport();
                RR.SetDataSource((DataTable)Session["PrintData"]);
                PrintReportViewer.ReportSource = RR;
            }
            else if (Session["ReportType"].ToString().Equals("DeliverOrder"))
            {
                StationeryStoreInventorySystem.Reports.SSISReports.DeliveryOrderFormReport RR =
                    new StationeryStoreInventorySystem.Reports.SSISReports.DeliveryOrderFormReport();
                RR.SetDataSource((DataTable)Session["PrintData"]);
                PrintReportViewer.ReportSource = RR;
            }
            else if (Session["ReportType"].ToString().Equals("AdjustmentVoucher"))
            {
                StationeryStoreInventorySystem.Reports.SSISReports.InventoryAdjustmentVoucherReport RR =
                    new StationeryStoreInventorySystem.Reports.SSISReports.InventoryAdjustmentVoucherReport();
                RR.SetDataSource((DataTable)Session["PrintData"]);
                PrintReportViewer.ReportSource = RR;
            } 
        }

        private void initializeReportDocument(string filePath)
        {
            rpt = new ReportDocument();
            rpt.Load(AppDomain.CurrentDomain.BaseDirectory + filePath);
        }

        private void loadStockCardReport()
        {
            PrintReportViewer.ParameterFieldInfo["ItemCode"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["ItemDes"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["BIN"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["UOM"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["firstSupp"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["secondSupp"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["thirdSupp"].CurrentValues.Clear();

            ParameterField f1 = PrintReportViewer.ParameterFieldInfo["ItemCode"];
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            v1.Value = Util.GetSession("ItemCode");
            f1.CurrentValues.Add(v1);

            ParameterField f2 = PrintReportViewer.ParameterFieldInfo["ItemDes"];
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();
            v2.Value = Util.GetSession("ItemDes");
            f2.CurrentValues.Add(v2);

            ParameterField f3 = PrintReportViewer.ParameterFieldInfo["BIN"];
            ParameterDiscreteValue v3 = new ParameterDiscreteValue();
            v3.Value = Util.GetSession("BIN");
            f3.CurrentValues.Add(v3);

            ParameterField f4 = PrintReportViewer.ParameterFieldInfo["UOM"];
            ParameterDiscreteValue v4 = new ParameterDiscreteValue();
            v4.Value = Util.GetSession("UOM");
            f4.CurrentValues.Add(v4);

            ParameterField f5 = PrintReportViewer.ParameterFieldInfo["firstSupp"];
            ParameterDiscreteValue v5 = new ParameterDiscreteValue();
            v5.Value = Util.GetSession("firstSupp");
            f5.CurrentValues.Add(v5);


            ParameterField f6 = PrintReportViewer.ParameterFieldInfo["secondSupp"];
            ParameterDiscreteValue v6 = new ParameterDiscreteValue();
            v6.Value = Util.GetSession("secondSupp");
            f6.CurrentValues.Add(v6);

            ParameterField f7 = PrintReportViewer.ParameterFieldInfo["thirdSupp"];
            ParameterDiscreteValue v7 = new ParameterDiscreteValue();
            v7.Value = Util.GetSession("thirdSupp");
            f7.CurrentValues.Add(v7);

            PrintReportViewer.DataBind();

            Util.RemoveSession("ItemCode");
            Util.RemoveSession("ItemDes");
            Util.RemoveSession("BIN");
            Util.RemoveSession("UOM");
            Util.RemoveSession("firstSupp");
            Util.RemoveSession("secondSupp");
            Util.RemoveSession("thirdSupp");
        }

        private void loadPurchaseOrderReport()
        {
            PrintReportViewer.ParameterFieldInfo["supplier"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["PONumber"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["DeliverTo"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["Attention"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["date"].CurrentValues.Clear();
            //PrintReportViewer.ParameterFieldInfo["approvedBy"].CurrentValues.Clear();
            //PrintReportViewer.ParameterFieldInfo["orderedBy"].CurrentValues.Clear();
            //PrintReportViewer.ParameterFieldInfo["approvedDate"].CurrentValues.Clear();
            //PrintReportViewer.ParameterFieldInfo["orderedDate"].CurrentValues.Clear();

            ParameterField f1 = PrintReportViewer.ParameterFieldInfo["supplier"];
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            v1.Value = Util.GetSession("supplier");
            f1.CurrentValues.Add(v1);

            ParameterField f2 = PrintReportViewer.ParameterFieldInfo["PONumber"];
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();
            v2.Value = Util.GetSession("PONumber");
            f2.CurrentValues.Add(v2);

            ParameterField f3 = PrintReportViewer.ParameterFieldInfo["DeliverTo"];
            ParameterDiscreteValue v3 = new ParameterDiscreteValue();
            v3.Value = Util.GetSession("DeliverTo");
            f3.CurrentValues.Add(v3);

            ParameterField f4 = PrintReportViewer.ParameterFieldInfo["Attention"];
            ParameterDiscreteValue v4 = new ParameterDiscreteValue();
            v4.Value = Util.GetSession("Attention");
            f4.CurrentValues.Add(v4);

            ParameterField f5 = PrintReportViewer.ParameterFieldInfo["date"];
            ParameterDiscreteValue v5 = new ParameterDiscreteValue();
            v5.Value = Util.GetSession("date");
            f5.CurrentValues.Add(v5);


            //ParameterField f6 = PrintReportViewer.ParameterFieldInfo["approvedBy"];
            //ParameterDiscreteValue v6 = new ParameterDiscreteValue();
            //v6.Value = Util.GetSession("approvedBy");
            //f6.CurrentValues.Add(v6);

            //ParameterField f7 = PrintReportViewer.ParameterFieldInfo["orderedBy"];
            //ParameterDiscreteValue v7 = new ParameterDiscreteValue();
            //v7.Value = Util.GetSession("orderedBy");
            //f7.CurrentValues.Add(v7);

            //ParameterField f8 = PrintReportViewer.ParameterFieldInfo["approvedDate"];
            //ParameterDiscreteValue v8 = new ParameterDiscreteValue();
            //v8.Value = Util.GetSession("approvedDate");
            //f8.CurrentValues.Add(v8);

            //ParameterField f9 = PrintReportViewer.ParameterFieldInfo["orderedDate"];
            //ParameterDiscreteValue v9 = new ParameterDiscreteValue();
            //v9.Value = Util.GetSession("orderedDate");
            //f9.CurrentValues.Add(v9);

            PrintReportViewer.DataBind();

            Util.RemoveSession("supplier");
            Util.RemoveSession("PONumber");
            Util.RemoveSession("DeliverTo");
            Util.RemoveSession("Attention");
            Util.RemoveSession("date");
            //Util.RemoveSession("approvedBy");
            //Util.RemoveSession("orderedBy");
            //Util.RemoveSession("approvedDate");
            //Util.RemoveSession("orderedDate");
        }

        private void loadDeliverOrderReport()
        {
            PrintReportViewer.ParameterFieldInfo["orderno"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["reference"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["date"].CurrentValues.Clear();

            ParameterField f1 = PrintReportViewer.ParameterFieldInfo["orderno"];
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            v1.Value = Util.GetSession("orderno");
            f1.CurrentValues.Add(v1);

            ParameterField f2 = PrintReportViewer.ParameterFieldInfo["reference"];
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();
            v2.Value = Util.GetSession("reference");
            f2.CurrentValues.Add(v2);

            ParameterField f3 = PrintReportViewer.ParameterFieldInfo["date"];
            ParameterDiscreteValue v3 = new ParameterDiscreteValue();
            v3.Value = Util.GetSession("date");
            f3.CurrentValues.Add(v3);

            PrintReportViewer.DataBind();

            Util.RemoveSession("orderno");
            Util.RemoveSession("reference");
            Util.RemoveSession("date");
        }

        private void loadAdjustmentVoucherReport()
        {
            PrintReportViewer.ParameterFieldInfo["VoucherNo"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["Supervisor"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["date"].CurrentValues.Clear();
            PrintReportViewer.ParameterFieldInfo["authorizedBy"].CurrentValues.Clear();

            ParameterField f1 = PrintReportViewer.ParameterFieldInfo["VoucherNo"];
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            v1.Value = Util.GetSession("VoucherNo");
            f1.CurrentValues.Add(v1);

            ParameterField f2 = PrintReportViewer.ParameterFieldInfo["Supervisor"];
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();
            v2.Value = Util.GetSession("Supervisor");
            f2.CurrentValues.Add(v2);

            ParameterField f3 = PrintReportViewer.ParameterFieldInfo["date"];
            ParameterDiscreteValue v3 = new ParameterDiscreteValue();
            v3.Value = Util.GetSession("date");
            f3.CurrentValues.Add(v3);

            ParameterField f4 = PrintReportViewer.ParameterFieldInfo["authorizedBy"];
            ParameterDiscreteValue v4 = new ParameterDiscreteValue();
            v4.Value = Util.GetSession("authorizedBy");
            f4.CurrentValues.Add(v4);

            PrintReportViewer.DataBind();

            Util.RemoveSession("VoucherNo");
            Util.RemoveSession("Supervisor");
            Util.RemoveSession("date");
            Util.RemoveSession("authorizedBy");
        }
    }
}