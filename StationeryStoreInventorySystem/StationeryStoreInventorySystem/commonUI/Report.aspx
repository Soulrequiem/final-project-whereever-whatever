<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.Report" %>

<%@ Register Assembly="Infragistics4.WebUI.WebDataInput.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentDivStyle">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"/>
        <ig:WebDropDown ID="drdReportList" runat="server" Width="300px"/>
    </div>
    <div style="margin-top:20px">
        <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="350px" Width="400px" 
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
</div>
</asp:Content>
