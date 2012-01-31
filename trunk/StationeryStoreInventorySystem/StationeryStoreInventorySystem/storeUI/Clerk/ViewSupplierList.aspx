<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewSupplierList.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ViewSupplierList" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
         <%--<img alt="Print" src="../Images/Common/print.png" />--%>
         <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ViewSupplierList_Title %>" /></h1>
            <ig:WebDataGrid ID="DgvSupplierList" runat="server" Height="500px" 
            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                <Columns>
                    <ig:BoundDataField DataFieldName="SupplierCode" Key="supplierCode" 
                        Width="80px">
                        <Header Text="Supplier Code" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="GSTRegistrationNo" Key="gstRegistrationNo" 
                        Width="80px">
                        <Header Text="GST Registration No" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="SupplierName" Key="supplierName" 
                        Width="120px">
                        <Header Text="Supplier Name" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="ContactName" Key="contactName" Width="120px">
                        <Header Text="Contact Name" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="PhoneNo" Key="phoneNo" Width="100px">
                        <Header Text="Phone No" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="FaxNo" Key="faxNo" Width="100px">
                        <Header Text="Fax No" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Address" Key="address" Width="100px">
                        <Header Text="Address" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
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
