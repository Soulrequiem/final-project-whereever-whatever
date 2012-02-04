<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.Report" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebChart" TagPrefix="igchart" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" 
namespace="Infragistics.UltraChart.Resources.Appearance" tagprefix="igchartprop" %>
<%@ Register assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" 
namespace="Infragistics.UltraChart.Data" tagprefix="igchartdata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
//    function LoadReportWindow() {
//        window.open("../commonUI/ReportView.aspx");
        //    }

        function RadioButtonClick() {
            if (document.getElementById["rdDateRage"].Checked) {
                document.getElementById["FromDate"].Enabled = true;
                document.getElementById["ToDate"].Enabled = true;
            }
            else if (document.getElementById["rdMonth"].Checked) {
                document.getElementById["FromDate"].Enabled = false;
                document.getElementById["ToDate"].Enabled = false;
            }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="script" runat="server" />
    <%--<div class="ContentDivStyle">--%>
    <div style="float:left;width:750px;margin-left:10px">
    <ig:WebDocumentExporter ID="PDFExporter" runat="server"/>
    <ig:WebExcelExporter ID="ExcelExporter" runat="server"/>
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="Reports" /></h1>
    <div style="float:left; height: 21px;width:100%">
        <div style="float:left">
            <asp:Label ID="Label1" runat="server" Text="Select Report : " CssClass="DefaultLabelstyle"/>
        </div>
        <div style="float:left">
            <ig:WebDropDown ID="drdReportList" runat="server" Width="300px" 
                AutoPostBack="True" onselectionchanged="drdReportList_SelectionChanged" 
                DisplayMode="DropDownList" LoadingItemsMessageText="Loading..." 
                NullText="Select Report" StyleSetName="Office2010Blue" >
                <AutoPostBackFlags SelectionChanged="On" />
                <Items>
                    <ig:DropDownItem Selected="False" Text="Inventory Status Report" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Reorder Report" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Item Consumption Report" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Disbursement List" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Stationery Catalogue" Value=""/>
                    <ig:DropDownItem Selected="false" Text="Stationery Supply Tender Form" Value="" /> 
                    <ig:DropDownItem Selected="False" Text="Collection List" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Employees List" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Department List" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Requisitions List" Value=""/>
                    <ig:DropDownItem Selected="False" Text="Supplier List" Value=""/>
                </Items>
            </ig:WebDropDown>
        </div>
        <asp:Panel runat="server" ID="panelSupplier" Visible="true">
            <div style="float:left;margin-left:10px">
                <asp:Label ID="lblselect" runat="server" Text="Select Supplier : " 
                    CssClass="DefaultLabelstyle" />
            </div>
            <div style="float:left">
                <ig:WebDropDown ID="drdSupplier" runat="server" Width="220px" 
                    AutoPostBack="True" onselectionchanged="drdSupplier_SelectionChanged" 
                    DisplayMode="DropDownList" LoadingItemsMessageText="Loading..." 
                    NullText="Select Supplier" StyleSetName="Office2010Blue" 
                    TextField="SupplierName" ValueField="SupplierID">
                    <AutoPostBackFlags SelectionChanged="On" />
                    <Items>
                    </Items>
                    <DropDownItemBinding TextField="SupplierName" ValueField="SupplierID" />
                </ig:WebDropDown>
            </div>
        </asp:Panel>
    </div>
    <br />
    <div id="ReportArea">
    <br />
    <div style="float:left">
        <asp:Label CssClass="HeaderStyle" runat="server" ID="lblNoDataAvailable" Text="No Data Available."/>
    </div>
    <br />
    <div style="float:left;width:98%">
        <asp:Panel ID="FilterPanel" runat="server">
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="100%">
            <Template>
            <div style="float:left;width:100%;height:40px">
                <div style="float:left">
                    <asp:Label ID="Label2" runat="server" Text="Select Dept. : " CssClass="DefaultLabelstyle" Width="232px"/>
                    <asp:ImageButton    runat="server" ImageUrl="../Images/Common/Delete.png" 
                                        Height="12px" Width="12px" ToolTip="Clear Selection" 
                        id="imgdepartment" onclick="deptButton_Click" />
                    <ig:WebDropDown ID="drdDepartment" runat="server" Width="250px" 
                        NullText="Select Department" 
                        ValueField="DepartmentID" TextField="DepartmentName" AutoPostBack="True" 
                        onselectionchanged="drdDepartment_SelectionChanged">
                        <DropDownItemBinding ValueField="DepartmentID" TextField="DepartmentName" />
                    </ig:WebDropDown>
                </div>
                <div style="float:left;margin-left:10px">
                    <asp:Label ID="Label3" runat="server" Text="Select Employee : " CssClass="DefaultLabelstyle" Width="232px"/>
                    <asp:ImageButton    runat="server" ImageUrl="../Images/Common/Delete.png" 
                                        Height="12px" Width="12px" ToolTip="Clear Selection" 
                        id="imgemployee" onclick="deptButton_Click" />
                    <ig:WebDropDown ID="drdEmployee" runat="server" Width="250px" 
                        NullText="Select Employee" AutoPostBack="True" TextField="EmployeeName" 
                        ValueField="EmployeeId" onselectionchanged="drdEmployee_SelectionChanged">
                        <DropDownItemBinding TextField="EmployeeName" ValueField="EmployeeId" />
                    </ig:WebDropDown>
                </div> 
                <div style="float:left;margin-left:10px">
                    <asp:Label ID="Label4" runat="server" Text="Show Report : " CssClass="DefaultLabelstyle" Width="100px"/>
                    <ig:WebDropDown ID="drdReportType" runat="server" Width="120px" 
                        NullText="Select Report type" AutoPostBack="True" 
                        onselectionchanged="drdReportType_SelectionChanged">
                        <Items>
                            <ig:DropDownItem Selected="True" Text="By Requisitions" Value="">
                            </ig:DropDownItem>
                            <ig:DropDownItem Selected="False" Text="By Items" Value="">
                            </ig:DropDownItem>
                        </Items>
                    </ig:WebDropDown>
                </div>  
                <div style="float:left;margin-top:15px">
                    <asp:CheckBox id="chkShowTotal" runat="server" Text="Show Total" 
                        CssClass="DefaultLabelstyle" AutoPostBack="True" Enabled="False" 
                        oncheckedchanged="chkShowTotal_CheckedChanged"/>
                </div>  
            </div>
            </Template>
            </igmisc:WebGroupBox>
            <br />
            <igmisc:WebGroupBox ID="ReportType" runat="server" Width="100%">
            <Template>
                <div style="float:left;margin-left:50px">
                    <asp:Label ID="Label11" runat="server" Text="Select Requisition : " CssClass="DefaultLabelstyle" Width="230px"/>
                    <asp:ImageButton    runat="server" ImageUrl="../Images/Common/Delete.png" 
                                        Height="12px" Width="12px" ToolTip="Clear Selection" 
                        id="imgrequisition" onclick="deptButton_Click" />
                    <ig:WebDropDown ID="drdRequisitions" runat="server" Width="250px" 
                        NullText="Enter or select Requisition" AutoPostBack="True" 
                        EnableMultipleSelection="True" AutoFilterQueryType="Contains" 
                        onselectionchanged="drdRequisitions_SelectionChanged" 
                        TextField="Requisition ID" ValueField="Requisition ID">
                        <DropDownItemBinding TextField="Requisition ID" ValueField="Requisition ID" />
                    </ig:WebDropDown>
                </div>
                <div style="float:left;margin-left:10px">
                    <asp:Label ID="Label12" runat="server" Text="Select Item : " CssClass="DefaultLabelstyle" Width="275px"/>
                    <asp:ImageButton    runat="server" ImageUrl="../Images/Common/Delete.png" 
                                        Height="12px" Width="12px" ToolTip="Clear Selection" 
                        id="imgitems" onclick="deptButton_Click" />
                    <ig:WebDropDown ID="drdItems" runat="server" Width="300px" 
                        NullText="Enter or Select Item Description" AutoPostBack="True" EnableMultipleSelection="True" 
                        Enabled="False" AutoFilterQueryType="Contains" TextField="Description" 
                        ValueField="Id" onselectionchanged="drdItems_SelectionChanged">
                        
                        <DropDownItemBinding TextField="Description" ValueField="Id" />
                    </ig:WebDropDown>
                </div>
                </Template>
            </igmisc:WebGroupBox>
            <br />
            <igmisc:WebGroupBox ID="DateGroupBox" runat="server" Width="100%">
            <Template>
                <div style="float:left;width:90%">
                    <asp:RadioButton Text="Date Range" ID="rdDateRage" runat="server" 
                            CssClass="DefaultLabelstyle" Checked="true" AutoPostBack="True" 
                        oncheckedchanged="rdDateRage_CheckedChanged" />
                    <asp:RadioButton Text="Month" ID="rdMonth" runat="server" 
                            CssClass="DefaultLabelstyle" Checked="false" AutoPostBack="True" 
                        oncheckedchanged="rdMonth_CheckedChanged" />
                        <%--<asp:Label ID="lblError" runat="server" CssClass="DefaultLabelstyle" />--%>
                </div>
                <div style="float:left">
                    <asp:Label ID="Label5" runat="server" Text="From : " CssClass="DefaultLabelstyle"/>
                    <ig:WebDatePicker ID="FromDate" runat="server" 
                        onvaluechanged="FromDate_ValueChanged" 
                        Fields="2011-1-1-0-0-0-0" Enabled="true" EditMode="CalendarOnly" 
                        AlwaysInEditMode="False" StyleSetName="Office2010Blue" ToolTip="From Date">
                        <AutoPostBackFlags ValueChanged="On" />
                    </ig:WebDatePicker>
                </div>
                <div style="float:left;margin-left:10px">
                    <asp:Label ID="Label6" runat="server" Text="To : " CssClass="DefaultLabelstyle"/>
                    <ig:WebDatePicker ID="ToDate" runat="server" 
                        onvaluechanged="FromDate_ValueChanged" Enabled="true" 
                        Fields="2012-2-1-0-0-0-0" EditMode="CalendarOnly" AlwaysInEditMode="False" 
                        StyleSetName="Office2010Blue">
                        <AutoPostBackFlags ValueChanged="On" />
                    </ig:WebDatePicker>
                </div> 
                <div style="float:left;margin-left:10px">
                    <asp:Label ID="Label7" runat="server" Text="Show Month : " CssClass="DefaultLabelstyle"/>
                    <ig:WebDropDown ID="drdMonth" runat="server" Width="200px" 
                        NullText="Select Month" AutoPostBack="True" EnableMultipleSelection="True" 
                        Enabled="False" onselectionchanged="drdMonth_SelectionChanged">
                        <Items>
                            <ig:DropDownItem Selected="False" Text="January" Value="01"/>
                            <ig:DropDownItem Selected="False" Text="February" Value="02"/>
                            <ig:DropDownItem Selected="False" Text="March" Value="03"/>
                            <ig:DropDownItem Selected="False" Text="April" Value="04"/>
                            <ig:DropDownItem Selected="False" Text="May" Value="05"/>
                            <ig:DropDownItem Selected="False" Text="June" Value="06"/>
                            <ig:DropDownItem Selected="False" Text="July" Value="07"/>
                            <ig:DropDownItem Selected="False" Text="August" Value="08"/>
                            <ig:DropDownItem Selected="False" Text="September" Value="09"/>
                            <ig:DropDownItem Selected="False" Text="October" Value="10"/>
                            <ig:DropDownItem Selected="False" Text="November" Value="11"/>
                            <ig:DropDownItem Selected="False" Text="December" Value="12"/>
                        </Items>
                    </ig:WebDropDown>
                </div>
                <div style="float:left;width:200px">
                    <div style="float:left">
                    <asp:Label ID="Label8" runat="server" Text="Show Year : " CssClass="DefaultLabelstyle"/>
                    <ig:WebDropDown ID="drdYear" runat="server" Width="100px" 
                        NullText="Select Year" AutoPostBack="True" 
                        Enabled="False" onselectionchanged="drdYear_SelectionChanged">
                        <Items>
                            <ig:DropDownItem Selected="False" Text="2010" Value="2010"/>
                            <ig:DropDownItem Selected="False" Text="2011" Value="2011" />
                            <ig:DropDownItem Selected="False" Text="2012" Value="2012"/>
                            <ig:DropDownItem Selected="False" Text="2013" Value="2013"/>
                            <ig:DropDownItem Selected="False" Text="2014" Value="2014"/>
                            <ig:DropDownItem Selected="False" Text="2015" Value="2015"/>
                            <ig:DropDownItem Selected="False" Text="2016" Value="2016"/>
                            <ig:DropDownItem Selected="False" Text="2017" Value="2017"/>
                            <ig:DropDownItem Selected="False" Text="2018" Value="2018"/>
                            <ig:DropDownItem Selected="False" Text="2019" Value="2019"/>
                            <ig:DropDownItem Selected="False" Text="2020" Value="2020"/>
                            <ig:DropDownItem Selected="False" Text="2021" Value="2021"/>
                        </Items>
                    </ig:WebDropDown>
                    </div>
                    <div style="float:left;margin-top:10px;margin-left:10px">
                        <asp:Button ID="btnClearAll" runat="server" Text="Clear All" 
                            CssClass="Defaultbutton" onclick="btnClearAll_Click" />
                    </div>
                </div>
               <%-- <div style="float:left">
                    <asp:Button ID="btnClearAll" runat="server" Text="Clear All" />
                </div>--%>
                </Template>
            </igmisc:WebGroupBox>
        </asp:Panel>
    </div>
    <div style="float:left;width:100%">
    <asp:Panel ID="reportpanel" runat="server" Visible="false">
    <div style="float:left;margin-top:20px;width:100%">
        <ig:WebTab ID="WebTab1" runat="server" Height="500px" Width="100%" 
            StyleSetName="Office2010Blue" SelectedIndex="1">
            <Tabs>
                <ig:ContentTabItem runat="server" Text="List View">
                    <Template>
                        <ig:WebDataGrid ID="dgvReport" runat="server" Height="440px" Width="99.7%" 
                            StyleSetName="Office2010Blue" EnableDataViewState="True" 
                            ondatafiltered="dgvReport_DataFiltered" 
                            onpageindexchanged="dgvReport_PageIndexChanged">
                            <Behaviors>
                                <ig:Sorting Enabled = "true">
                                </ig:Sorting>
                                <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                </ig:Selection>
                                <ig:Paging>  
                                </ig:Paging>
                                <ig:Filtering >
                                    <ColumnSettings>
                                        <ig:ColumnFilteringSetting />
                                    </ColumnSettings>
                                </ig:Filtering>
                            </Behaviors>
                        </ig:WebDataGrid>
                    </Template>
                </ig:ContentTabItem>
                <ig:ContentTabItem runat="server" Text="Chart View">
                    <Template>
                        <div style="margin-left:20px;margin-top:10px">
                            <igchart:UltraChart ID="chartReport" runat="server" Width="700px" 
                            Height="400px" EmptyChartText="Data Not Available." 
                            Version="11.2" ChartType="StackSplineAreaChart">
                            <ColorModel AlphaLevel="150">
                            </ColorModel>
                                <%--<Axis>
                                    
                                    <PE ElementType="None" Fill="Cornsilk" />
                                    <X TickmarkInterval="0" Visible="True">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Near" ItemFormatString="&lt;ITEM_LABEL&gt;" 
                                            Orientation="VerticalLeftFacing" VerticalAlign="Center">
                                            <SeriesLabels FormatString="" HorizontalAlign="Near" 
                                                Orientation="VerticalLeftFacing" VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </X>
                                    <Y TickmarkInterval="0" Visible="True">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Far" ItemFormatString="&lt;DATA_VALUE:00.##&gt;" 
                                            Orientation="Horizontal" VerticalAlign="Center">
                                            <SeriesLabels FormatString="" HorizontalAlign="Far" Orientation="Horizontal" 
                                                VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </Y>
                                    <Y2 TickmarkInterval="0" Visible="False">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Near" ItemFormatString="&lt;DATA_VALUE:00.##&gt;" 
                                            Orientation="Horizontal" VerticalAlign="Center" Visible="False">
                                            <SeriesLabels FormatString="" HorizontalAlign="Near" Orientation="Horizontal" 
                                                VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </Y2>
                                    <X2 TickmarkInterval="0" Visible="False">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Far" ItemFormatString="&lt;ITEM_LABEL&gt;" 
                                            Orientation="VerticalLeftFacing" VerticalAlign="Center" Visible="False">
                                            <SeriesLabels FormatString="" HorizontalAlign="Far" 
                                                Orientation="VerticalLeftFacing" VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </X2>
                                    <Z TickmarkInterval="0" Visible="False">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Near" ItemFormatString="" Orientation="Horizontal" 
                                            VerticalAlign="Center">
                                            <SeriesLabels HorizontalAlign="Near" Orientation="Horizontal" 
                                                VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </Z>
                                    <Z2 TickmarkInterval="0" Visible="False">
                                        <MajorGridLines AlphaLevel="255" Color="Gainsboro" DrawStyle="Dot" 
                                            Thickness="1" Visible="True" />
                                        <MinorGridLines AlphaLevel="255" Color="LightGray" DrawStyle="Dot" 
                                            Thickness="1" Visible="False" />
                                        <Labels HorizontalAlign="Near" ItemFormatString="" Orientation="Horizontal" 
                                            VerticalAlign="Center" Visible="False">
                                            <SeriesLabels HorizontalAlign="Near" Orientation="Horizontal" 
                                                VerticalAlign="Center">
                                            </SeriesLabels>
                                        </Labels>
                                    </Z2>
                                    
                                </Axis>--%>
                            </igchart:UltraChart>
                        </div>
                        <div style="float:left;margin-left:10px;margin-top:10px">
                            <asp:RadioButton ID="rdlineChart" runat="server" Checked="true"
                                oncheckedchanged="rdlineChart_CheckedChanged" Text="Line Chart" AutoPostBack="True" />
                            <asp:RadioButton ID="rdBarChart" runat="server" 
                                oncheckedchanged="rdBarChart_CheckedChanged" Text="Bar Chart" AutoPostBack="True" />
                            <asp:RadioButton ID="pointChart" runat="server" 
                                Text = "Point Chart" AutoPostBack="True" 
                                oncheckedchanged="pointChart_CheckedChanged" />
                        </div>
                    </Template>
                </ig:ContentTabItem>
            </Tabs>
        </ig:WebTab>
       </div>
    <div style="margin-top:20px">
        <div style="float:left">
            <asp:ImageButton ID="ExcelDownload" runat="server" 
                ImageUrl="~/Images/Common/Excel_Logo.jpg" Width="35px" Height="35px" 
                ToolTip="Export to Excel" onclick="ExcelDownload_Click" />
        </div>
        <div style="float:left;margin-left:10px">
            <asp:ImageButton ID="PDFDownload" runat="server" 
            ImageUrl="~/Images/Common/PDF Icon.gif" Width="35px" Height="35px" 
                ToolTip="Export to PDF" onclick="PDFDownload_Click" />
        </div>
        <div style="float:left">
            <asp:ImageButton ID="PrintButton" runat="server" 
            ImageUrl="~/Images/Common/iconPrint.gif" Width="35px" Height="35px" 
                ToolTip="Print" onclick="PrintButton_Click" />
        </div>
        <div style="float:right">
            <asp:Label ID="lblTotalCount" runat="server" Text="Total Count :" CssClass="DefaultLabelstyle"/>
        </div>
    </div>
   </asp:Panel>
  </div>
 </div>
</div>
</asp:Content>
