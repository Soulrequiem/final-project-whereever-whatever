<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStationeryRetrievalList.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ViewStationeryRetrievalList" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="print">
         <img alt="Print" src="~/Images/Common/print.png" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ViewStationeryRetrievalList_Title %>" /></h1>
             <br />
            <ig:WebDataGrid ID="DgvViewStationeryRetrievalList" runat="server" 
            Height="400px" Width="700px" DefaultColumnWidth="50px" 
            AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
            HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                <Columns>
                    <ig:BoundDataField DataFieldName="RetrievalNo" Key="RetrievalNo" Width="50px">
                        <Header Text="Retrieval No." />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RetrievalDate/Time" Key="RetrievalDate/Time" 
                        Width="100px">
                        <Header Text="Retrieval Date/Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RetrievedBy" Key="RetrievedBy" Width="80px">
                        <Header Text="Retrieved By" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" Width="50px">
                        <Header Text="Needed Qty" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="ActualQty" Key="ActualQty" Width="50px">
                        <Header Text="Actual Qty" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:ColumnFixing>
                    </ig:ColumnFixing>
                    <ig:Filtering>
                    </ig:Filtering>
                    <ig:Paging PageSize="10">
                    </ig:Paging>
                    <ig:Selection CellClickAction="Row" RowSelectType="Single">
                    </ig:Selection>
                    <ig:Sorting>
                    </ig:Sorting>
                </Behaviors>
            </ig:WebDataGrid>
    </div>
</asp:Content>
