using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using StationeryStoreInventorySystemController.commonController;
using Infragistics.Documents.Reports.Report;
using Infragistics.Documents.Excel;
using Infragistics.Web.UI.ListControls;
using Infragistics.WebUI.UltraWebChart;
using SystemStoreInventorySystemUtil;
using System.Collections;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class Report : System.Web.UI.Page
    {
        GenerateReportsControl grCtrl;
        DataTable reportDT;
        private GenerateReportsControl getControl()
        {
            if (grCtrl == null)
                grCtrl = new GenerateReportsControl();
            return grCtrl;
        }
        private void putInSession(DataTable dt)
        {
            Session["ItemConsumptionData"] = dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FilterPanel.Visible = false;
                lblNoDataAvailable.Visible = true;
                drdReportList.SelectedItemIndex = 0;
                reportDT = getControl().getItems();
                PrepareData();
            }
            Session["IsPostBack"] = true;
        }

        protected void drdReportList_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            if (Constants.ItemReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getItems();
            }
            else if (Constants.StationeryCatalogueReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getCatalogue();
            }
            else if (Constants.ColletionReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getCollections();
            }
            else if (Constants.RequisitionReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getRequisitions();
            }
            else if (Constants.SupplierReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getSuppliers();
            }
            else if (Constants.UserReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getUsers();
            }
            else if (Constants.ItemPriceReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getUsers();
            }
            else if (Constants.DepartmentReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getDepartments();
            }
            else if (Constants.EmployeeReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getEmployees();
            }
            else if (Constants.RolesReport == drdReportList.CurrentValue)
            {
                reportDT = getControl().getRoles();
            }
            else if (Constants.ItemConsumptionReport == drdReportList.CurrentValue)
            {
                fillData();
                FilterPanel.Visible = true;
                lblNoDataAvailable.Visible = false;
                drdReportType.SelectedItemIndex = 0;
                chkShowTotal.Enabled = true;
                firstLoad();

            }
            PrepareData();
        }

        private void firstLoad()
        {
            reportDT = getControl().defaultResultSet("2011-1-1", "2012-1-2");

            if (reportDT != null)
            {
                //Binding the initial chart
                DataTable chartDt = new DataTable();
                chartDt = copyTable(chartDt, reportDT, "Department Name", "Total Item Consumption");
                chartReport.DataSource = chartDt;
                chartReport.DataBind();
                Session["chartData"] = chartDt;
            }
        }
        private string getDate(string date)
        {
            string[] str = date.Split('/');
            return str[2].Substring(0,4)+"-"+str[0]+"-"+str[1];

        }
        private void PrepareData()
        {
            if (null != reportDT && reportDT.Rows.Count > 0)
            {
                WebTab1.SelectedIndex = 0;
                SetLabel(false);
                SetDataSource();
            }
            else
                SetLabel(true);
        }

        private void SetDataSource()
        {
            BindData();
            Session["ReportData"] = reportDT;
            Session["ReportType"] = drdReportList.SelectedItem.Text;
        }

        private void BindData()
        {
            if ((bool)Session["IsPostBack"] == true)
            {
                dgvReport.ClearDataSource();
            }
            dgvReport.DataSource = reportDT;
            dgvReport.DataBind();

            if(reportDT != null)
                lblTotalCount.Text = "Total Count : " + reportDT.Rows.Count;

            //BindChart();

            //To load specific requisition IDs only in requisitions drop down
            if (reportDT != null && reportDT.Columns.Contains("Requisition ID"))
            {
                drdRequisitions.DataSource = null;
                drdRequisitions.DataSource = reportDT;
                drdRequisitions.DataBind();
            }

        }

        private void BindChart()
        {
            if (chkShowTotal.Checked || 
                drdItems.SelectedItems.Count == 1 ||
                drdDepartment.SelectedValue != string.Empty ||
                drdEmployee.SelectedValue != string.Empty ||
                (drdRequisitions.SelectedItems.Count == 1 && chkShowTotal.Checked))
            {
                DataTable dt = (DataTable)reportDT;

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable chartDt = new DataTable();
                    if (dt.Columns.Contains("Requisition ID") &&
                        dt.Columns.Contains("Total number of Items consumed"))
                    {
                        chartDt = copyTable(chartDt, dt, "Requisition ID", "Total number of Items consumed");
                    }
                    else if (dt.Columns.Contains("Item") &&
                       dt.Columns.Contains("Quantity"))
                    {
                        chartDt = copyTable(chartDt, dt, "Item", "Quantity");
                    }

                    Session["chartData"] = chartDt;
                    if(rdBarChart.Checked)
                        chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
                    else if (rdlineChart.Checked)
                        chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackSplineAreaChart;
                    else if (pointChart.Checked)
                        chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackLineChart;
                    chartReport.DataSource = chartDt;
                    chartReport.DataBind();
                }
            }
        }

        private DataTable copyTable(DataTable chartDt, DataTable dt, string firstColumn, string secondColumn)
        {
            try
            {
                WebTab1.SelectedIndex = 0;
                WebTab1.Tabs[1].Enabled = true; 

                if (firstColumn == "Item" && secondColumn == "Quantity")
                {
                    foreach (DataRow sourcerow in dt.Rows)
                    {
                        chartDt.Columns.Add(sourcerow[firstColumn].ToString(), typeof(int));
                    }
                }
                foreach (DataRow sourcerow in dt.Rows)
                {
                    chartDt.Columns.Add(sourcerow[firstColumn].ToString(), typeof(int));
                }
                //if (flag)
                //{

                //}
                //else
                //{
                DataRow dr = chartDt.NewRow();
                int col = 0;
                foreach (DataRow sourcerow in dt.Rows)
                {
                    dr[col++] = Convert.ToInt16(sourcerow[secondColumn].ToString());
                }
                chartDt.Rows.Add(dr);
                //}
                return chartDt;
            }
            catch (Exception ex)
            {
                WebTab1.SelectedIndex = 0;
                WebTab1.Tabs[1].Enabled = false;
                return null;
            }
        }

        private void SetLabel(bool flag)
        {
            lblNoDataAvailable.Visible = flag;
            reportpanel.Visible = !flag;
            if (Constants.ItemConsumptionReport == drdReportList.CurrentValue)
            {
                FilterPanel.Visible = true;
            }
            else
            {
                FilterPanel.Visible = false;
            }
        }

        protected void PrintButton_Click(object sender, ImageClickEventArgs e)
        {

            string fileName = HttpUtility.UrlEncode(drdReportList.SelectedItem.Text.Trim() + System.DateTime.Now.ToString());
            fileName = fileName.Replace("+", "_");
            if (WebTab1.SelectedIndex == 1)
            {
                if (rdBarChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
                else if (rdlineChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackSplineAreaChart;
                else if (pointChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackLineChart;
                chartReport.DataSource = (DataTable)Session["chartData"];
                chartReport.DataBind();

                //creates a report object
                Infragistics.Documents.Reports.Report.Report r =
                    new Infragistics.Documents.Reports.Report.Report();
                //adds a section to add content to
                Infragistics.Documents.Reports.Report.Section.ISection s1 = r.AddSection();
                s1 = formatPage(s1);

                this.chartReport.RenderPdfFriendlyGraphics(r.AddSection().AddCanvas().CreateGraphics(), 500, 300);
                r.Publish(@"d:\" + fileName + ".pdf", FileFormat.PDF);

                //Response.Clear();

                Session["pdfFileName"] = @"d:\" + fileName + ".pdf";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Myscript", "<script language='javascript'> " +
                    "window.open('../commonUI/PrintReport.aspx?pdf=yes&excel=no');</script>");
            }
            else
            {
                dgvReport.DataSource = (DataTable)Session["ReportData"];
                dgvReport.DataBind();
                this.PDFExporter.DownloadName = fileName;
                this.PDFExporter.Format = Infragistics.Web.UI.GridControls.FileFormat.PDF;
                this.PDFExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
                this.PDFExporter.TargetPaperOrientation = PageOrientation.Portrait;
                this.PDFExporter.Margins = PageMargins.Normal;
                this.PDFExporter.TargetPaperSize = PageSizes.A4;
                this.PDFExporter.Export(dgvReport);
            }
        }

        protected void ExcelDownload_Click(object sender, ImageClickEventArgs e)
        {
            string fileName = HttpUtility.UrlEncode(drdReportList.SelectedItem.Text.Trim() + System.DateTime.Now.ToString());
            fileName = fileName.Replace("+", "_");
            this.ExcelExporter.DownloadName = fileName;
            this.ExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            this.ExcelExporter.WorkbookFormat = WorkbookFormat.Excel97To2003;
            this.ExcelExporter.Export(true, this.dgvReport);
        }

        protected void PDFDownload_Click(object sender, ImageClickEventArgs e)
        {
            string fileName = HttpUtility.UrlEncode(drdReportList.SelectedItem.Text.Trim() + System.DateTime.Now.ToString());
            fileName = fileName.Replace("+", "_");
            if (WebTab1.SelectedIndex == 0)
            {
                dgvReport.DataSource = (DataTable)Session["ReportData"];
                dgvReport.DataBind();

                //creates a report object
                Infragistics.Documents.Reports.Report.Report r = 
                    new Infragistics.Documents.Reports.Report.Report();
                //adds a section to add content to
                Infragistics.Documents.Reports.Report.Section.ISection s1 = r.AddSection();
                formatPage(s1);

                this.PDFExporter.DownloadName = fileName;
                this.PDFExporter.Format = Infragistics.Web.UI.GridControls.FileFormat.PDF;
                this.PDFExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
                this.PDFExporter.TargetPaperOrientation = PageOrientation.Portrait;
                this.PDFExporter.Margins = PageMargins.Normal;
                this.PDFExporter.TargetPaperSize = PageSizes.A4;
                this.PDFExporter.Export(dgvReport,r,s1);
            }
            else 
            {
                if (rdBarChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
                else if (rdlineChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackSplineAreaChart;
                else if (pointChart.Checked)
                    chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackLineChart;
                chartReport.DataSource = (DataTable)Session["chartData"];
                chartReport.DataBind();

                //creates a report object
                Infragistics.Documents.Reports.Report.Report r =
                    new Infragistics.Documents.Reports.Report.Report();
                //adds a section to add content to
                Infragistics.Documents.Reports.Report.Section.ISection s1 = r.AddSection();
                s1 = formatPage(s1);
                

                this.chartReport.RenderPdfFriendlyGraphics(r.AddSection().AddCanvas().CreateGraphics(),500,300);
                r.Publish(@"d:\" + fileName + ".pdf", FileFormat.PDF);

                Session["pdfFileName"] = @"d:\" + fileName + ".pdf";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Myscript", "<script language='javascript'> " +
                    "window.open('../commonUI/PrintReport.aspx?pdf=yes&excel=no');</script>");
            }
        }

        private Infragistics.Documents.Reports.Report.Section.ISection formatPage(Infragistics.Documents.Reports.Report.Section.ISection s1)
        {
            //sets properties on the section
            //to add page numbers
            s1.PageNumbering.SkipFirst = true;
            s1.PageNumbering.OffsetY = -18;
            s1.PageNumbering.Template = "Page [Page #] of [TotalPages]";

            //adds a header to the PDF
            Infragistics.Documents.Reports.Report.Section.ISectionHeader s1header = s1.AddHeader();
            s1header.Height = 20;
            s1header.Repeat = false;

            //adds text to the header area
            Infragistics.Documents.Reports.Report.Text.IText s1headertitle = s1header.AddText(0, 0);
            s1headertitle.AddContent("Logic University :" + drdReportList.SelectedItem.ToString());
            s1headertitle.Alignment = TextAlignment.Left;


            Infragistics.Documents.Reports.Report.Text.IText s1headertimestamp = s1header.AddText(0, 0);
            s1headertimestamp.AddContent("Generated on: ");
            s1headertimestamp.AddDateTime("MM/dd/yyyy hh:mm:ss");
            s1headertimestamp.Alignment = TextAlignment.Right;

            return s1;
        }

        protected void drdDepartment_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            fillEmployeesByDepartment();
            if (Constants.ByRequsitions == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue,
                    drdEmployee.SelectedValue, chkShowTotal.Checked, drdRequisitions.SelectedValue
                    , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            else if (Constants.ByItems == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByItems(drdDepartment.SelectedValue, drdEmployee.SelectedValue,
                    drdItems.CurrentValue, getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            BindData();
            Session["ReportData"] = reportDT;
        }
        private void fillData()
        {
            fillDepartments();
            fillEmployeesByDepartment();
            fillItems();
        }

        private void fillDepartments()
        {
            drdDepartment.DataSource = null;
            drdDepartment.DataSource = getControl().getDepartments();
        }
        private void fillItems()
        {
            drdItems.DataSource = null;
            drdItems.DataSource = getControl().getItems();
        }
        private void fillEmployeesByDepartment()
        {
            drdEmployee.DataSource = null;
            drdEmployee.DataSource = getControl().getEmployeesByDepartment(drdDepartment.SelectedValue);
        }

        protected void rdDateRage_CheckedChanged(object sender, EventArgs e)
        {
            rdMonth.Checked = !rdDateRage.Checked;
            EnableDisableControls();
        }

        protected void rdMonth_CheckedChanged(object sender, EventArgs e)
        {
            rdDateRage.Checked = !rdMonth.Checked;
            EnableDisableControls();
        }

        protected void EnableDisableControls()
        {
            if (rdDateRage.Checked)
            {
                FromDate.Enabled = true;
                ToDate.Enabled = true;
                drdMonth.Enabled = false;
                drdYear.Enabled = false;
                rdMonth.Checked = !rdDateRage.Checked;
            }
            else if (rdMonth.Checked)
            {
                FromDate.Enabled = false;
                ToDate.Enabled = false;
                drdMonth.Enabled = true;
                drdYear.Enabled = true;
                rdDateRage.Checked = !rdMonth.Checked;
            }
        }

        protected void drdReportType_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            if (Constants.ByRequsitions == drdReportType.SelectedItem.Text)
            {
                chkShowTotal.Enabled = true;
                drdRequisitions.Enabled = true;
                drdItems.Enabled = false;
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue,
                    drdEmployee.SelectedValue, chkShowTotal.Checked, drdRequisitions.SelectedValue
                    , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            else if(Constants.ByItems == drdReportType.SelectedItem.Text)
            {
                chkShowTotal.Enabled = false;
                chkShowTotal.Checked = false;
                drdRequisitions.Enabled = false;
                drdItems.Enabled = true;
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByItems(drdDepartment.SelectedValue, 
                    drdEmployee.SelectedValue, drdItems.CurrentValue
                    , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
            }
            BindData();
            Session["ReportData"] = reportDT;
        }

        protected void dgvReport_PageIndexChanged(object sender, Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            Session["IsPostBack"] = false;
            dgvReport.DataSource = (DataTable)Session["ReportData"];
            dgvReport.DataBind();
            lblTotalCount.Text = "Total Count : " + ((DataTable)Session["ReportData"]).Rows.Count;
        }

        protected void dgvReport_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
        {
            Session["IsPostBack"] = false;
            dgvReport.DataSource = (DataTable)Session["ReportData"];
            dgvReport.DataBind();
            lblTotalCount.Text = "Total Count : " + ((DataTable)Session["ReportData"]).Rows.Count;
        }

        protected void drdEmployee_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            if (Constants.ByRequsitions == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue,
                                drdEmployee.SelectedValue, chkShowTotal.Checked, drdRequisitions.SelectedValue
                                , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            else if (Constants.ByItems == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByItems(drdDepartment.SelectedValue, drdEmployee.SelectedValue,
                    drdItems.CurrentValue, getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
            }
            BindData();
            Session["ReportData"] = reportDT;
        }

        protected void chkShowTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (Constants.ByRequsitions == drdReportType.SelectedItem.Text)
            {
                drdRequisitions.Enabled = true;
                drdItems.Enabled = false;
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue,
                                drdEmployee.SelectedValue, chkShowTotal.Checked, drdRequisitions.SelectedValue
                                , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            BindData();
            Session["ReportData"] = reportDT;
        }

        protected void drdRequisitions_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            dgvReport.ClearDataSource();
            reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue, drdEmployee.SelectedValue,
                chkShowTotal.Checked, drdRequisitions.CurrentValue, getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
            
            dgvReport.ClearDataSource();
            dgvReport.DataSource = reportDT;
            dgvReport.DataBind();
            lblTotalCount.Text = "Total Count : " + reportDT.Rows.Count;
            BindChart();
            Session["ReportData"] = reportDT;
        }

        protected void deptButton_Click(object sender, ImageClickEventArgs e)
        {
            System.Web.UI.WebControls.ImageButton imgButton = (System.Web.UI.WebControls.ImageButton)sender;
            if (imgButton != null)
            {
                if (imgButton.ID.Contains("department"))
                {
                    drdDepartment.ClearSelection();
                    drdDepartment_SelectionChanged(null, null);
                }
                else if (imgButton.ID.Contains("employee"))
                {
                    drdEmployee.ClearSelection();
                    drdEmployee_SelectionChanged(null, null);
                }
                else if (imgButton.ID.Contains("requisition"))
                {
                    drdRequisitions.ClearSelection();
                    drdRequisitions_SelectionChanged(null, null);
                }
                else if (imgButton.ID.Contains("items"))
                {
                    drdItems.ClearSelection();
                    drdItems_SelectionChanged(null, null);
                }
            }
        }

        protected void drdItems_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            dgvReport.ClearDataSource();
            reportDT = getControl().getFilterDepartmentByItems(drdDepartment.SelectedValue,
                drdEmployee.SelectedValue, getSelectedValueFields(drdItems.SelectedItems),
                getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
            BindData();
            Session["ReportData"] = reportDT;
        }

        private string getSelectedValueFields(List<DropDownItem> DDI)
        {
            StringBuilder ids = new StringBuilder();
            if (DDI != null && DDI.Count > 0)
            {
                foreach (DropDownItem D in DDI)
                {
                    ids.Append(D.Value);
                    ids.Append(" , ");
                }
            }
            return ids.ToString();
        }

        protected void FromDate_ValueChanged(object sender, Infragistics.Web.UI.EditorControls.TextEditorValueChangedEventArgs e)
        {
            //if (FromDate.Value.ToString().CompareTo(ToDate.Value.ToString()) > 0)
            //{
            //    //lblError.Text = "From date can not be greater than To date.";
            //    return;
            //}
            //else if (ToDate.Value.ToString().CompareTo(FromDate.Value.ToString()) < 0)
            //{
            //    //lblError.Text = "To date can not be less than From date.";
            //    return;
            //}

            if (Constants.ByRequsitions == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByRequisitions(drdDepartment.SelectedValue,
                                drdEmployee.SelectedValue, chkShowTotal.Checked, drdRequisitions.SelectedValue
                                , getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
                BindChart();
            }
            else if (Constants.ByItems == drdReportType.SelectedItem.Text)
            {
                dgvReport.ClearDataSource();
                reportDT = getControl().getFilterDepartmentByItems(drdDepartment.SelectedValue, drdEmployee.SelectedValue,
                    drdItems.CurrentValue, getDate(FromDate.Value.ToString()), getDate(ToDate.Value.ToString()));
            }
            BindData();
            Session["ReportData"] = reportDT;
        }

        protected void rdlineChart_CheckedChanged(object sender, EventArgs e)
        {
            if (rdlineChart.Checked)
            {
                rdBarChart.Checked = false;
                pointChart.Checked = false;
                this.chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackSplineAreaChart;
                this.chartReport.DataSource = (DataTable)Session["chartData"];
                this.chartReport.DataBind();
            }
        }

        protected void rdBarChart_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBarChart.Checked)
            {
                rdlineChart.Checked = false;
                pointChart.Checked = false;
                this.chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
                this.chartReport.DataSource = (DataTable)Session["chartData"];
                this.chartReport.DataBind();
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            this.chartReport.DataSource = (DataTable)Session["chartData"];
            this.chartReport.DataBind();
            this.chartReport.SaveTo(@"D:\Item_Consumption_Report_.png", 
                System.Drawing.Imaging.ImageFormat.Png);
        }

        protected void pointChart_CheckedChanged(object sender, EventArgs e)
        {
            if (pointChart.Checked)
            {
                rdBarChart.Checked = false;
                rdlineChart.Checked = false;
                this.chartReport.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackLineChart;
                this.chartReport.DataSource = (DataTable)Session["chartData"];
                this.chartReport.DataBind();
            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            drdDepartment.ClearSelection();
            drdEmployee.ClearSelection();
            drdRequisitions.ClearSelection();
            drdItems.ClearSelection();
            firstLoad();
            PrepareData();
        }
    }
}