<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.Report" %>

<%@ Register Assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebChart" TagPrefix="igchart" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.UltraChart.Resources.Appearance" tagprefix="igchartprop" %>
<%@ Register assembly="Infragistics35.WebUI.UltraWebChart.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.UltraChart.Data" tagprefix="igchartdata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="script" runat="server" />
    <div class="ContentDivStyle">
    <ig:WebDocumentExporter ID="PDFExporter" runat="server"/>
    <ig:WebExcelExporter ID="ExcelExporter" runat="server"/>
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="Reports" /></h1>
    <div style="float:left; height: 21px;">
        <div style="float:left">
            <asp:Label ID="Label1" runat="server" Text="Select Report : " CssClass="DefaultLabelstyle"/>
        </div>
        <div style="float:left">
            <ig:WebDropDown ID="drdReportList" runat="server" Width="300px" 
                AutoPostBack="True" onselectionchanged="drdReportList_SelectionChanged" >
                <AutoPostBackFlags SelectionChanged="On" />
                <Items>
                    <ig:DropDownItem Selected="False" Text="Report1" Value="">
                    </ig:DropDownItem>
                    <ig:DropDownItem Selected="False" Text="Report2" Value="">
                    </ig:DropDownItem>
                </Items>
            </ig:WebDropDown>
        </div>
    </div>
    <br />
    <div id="ReportArea">
    <asp:Panel ID="reportpanel" runat="server" Visible="false">
    <div style="float:left;margin-top:20px">
        <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="350px" Width="600px" 
            StyleSetName="Office2010Blue">
            <Behaviors>
                <ig:Sorting>
                </ig:Sorting>
                <ig:Selection CellClickAction="Row" RowSelectType="Single">
                </ig:Selection>
                <ig:Paging PageSize="20">
                </ig:Paging>
                <ig:Filtering>
                </ig:Filtering>
            </Behaviors>
        </ig:WebDataGrid>
    </div>
    <div style="margin-top:20px">
        <div style="float:left">
            <asp:ImageButton ID="ExcelDownload" runat="server" 
                ImageUrl="~/Images/Common/Excel_Logo.jpg" Width="35px" Height="35px" 
                ToolTip="Export to Excel" />
        </div>
        <div style="float:left;margin-left:10px">
            <asp:ImageButton ID="PDFDownload" runat="server" 
            ImageUrl="~/Images/Common/PDF Icon.gif" Width="35px" Height="35px" 
                ToolTip="Export to PDF" />
        </div>
    </div>
    <div id="ChartDivision">
        <div>
            <asp:CheckBox ID="chkTrendAnalysis" runat="server" Text="Show Trend Analysis" CssClass="DefaultLabelstyle" />
        </div>
        <div>
            <igchart:UltraChart ID="UltraChart1" runat="server" Width="550px" 
                Height="400px" EmptyChartText="Data Not Available." 
                Version="11.2" Visible="False">
            </igchart:UltraChart>
        </div>
    </div>
    </asp:Panel>
    </div>
    
</div>
</asp:Content>
