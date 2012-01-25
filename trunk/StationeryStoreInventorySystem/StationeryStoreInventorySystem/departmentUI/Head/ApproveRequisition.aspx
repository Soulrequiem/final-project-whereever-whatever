<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApproveRequisition.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head.ApproveRequisition" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, ApproveRequisition_Title %>" /></h1>
        <ig:WebDataGrid ID="DgvRequisitionList" runat="server" 
            DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
            Height="400px" Width="700px">
            <Columns>
                <ig:BoundCheckBoxField DataFieldName="ApproveRequisitionCheckBox" 
                    Key="ApproveRequisitionCheckBox" Width="50px">
                </ig:BoundCheckBoxField>
                <ig:BoundDataField DataFieldName="RequisitionID" Key="RequisitionID" 
                    Width="100px">
                    <Header Text="Requisition ID" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="RequisitionDate/Time" Key="RequisitionDate/Time" 
                    Width="150px">
                    <Header Text="Requisition Date/Time" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="RequisitionBy" Key="RequisitionBy" 
                    Width="100px">
                    <Header Text="Requisition By" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="RequisitionQty" Key="RequisitionQty" 
                    Width="100px">
                    <Header Text="Requisition Qty" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="Remarks" Key="Remarks" Width="100px">
                    <Header Text="Remarks" />
                </ig:BoundDataField>
            </Columns>
            <Behaviors>
                <ig:Selection CellClickAction="Row" RowSelectType="Single">
                </ig:Selection>
                <ig:Paging PageSize="10">
                </ig:Paging>
                <ig:Filtering>
                </ig:Filtering>
                <ig:Sorting>
                </ig:Sorting>
            </Behaviors>
        </ig:WebDataGrid>
        <div style="float:right">
               <a class="button" href="#" style="float:right">Reject</a>
        </div>
        <div style="float:right;margin-right:10px">
               <a class="button" href="#" style="float:right">Approve</a>
        </div>
    </div>
</asp:Content>
