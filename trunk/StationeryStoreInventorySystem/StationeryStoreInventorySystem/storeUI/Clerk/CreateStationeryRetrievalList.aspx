<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateStationeryRetrievalList.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.CreateStationeryRetrievalList" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div class="print">
         <img alt="Print" src="../Images/Common/print.png" />
         <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div>--%>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, CreateStationeryRetrievalList_Title %>" /></h1>
             <br />
            <ig:WebDataGrid ID="DgvCreateStationeryRetrievalList" runat="server" 
            Height="500px" Width="700px" DefaultColumnWidth="50px" 
            AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
            HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="CollectionID"
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                <Columns>
                    <ig:UnboundCheckBoxField Key="CreateStationeryRetrievalListCheckBox" Width="50px">
                    </ig:UnboundCheckBoxField>
                    <ig:BoundDataField DataFieldName="CollectionID" Key="CollectionID" 
                        Width="120px">
                        <Header Text="Collection ID" />
                    </ig:BoundDataField>
                    <%--<ig:BoundDataField DataFieldName="CollectionID" Key="CollectionID" Width="50px">
                        <Header Text="Collection ID" />
                    </ig:BoundDataField>--%>
                    <ig:BoundDataField DataFieldName="CollectionDateTime" Key="CollectionDateTime" 
                        Width="150px">
                        <Header Text="Collection Date/Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Department" Key="Department" Width="180px">
                        <Header Text="Department" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="DepartmentStatus" Key="DepartmentStatus" 
                        Width="200px">
                        <Header Text="Department Status" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:Filtering>
                        <ColumnSettings>
                            <ig:ColumnFilteringSetting />
                        </ColumnSettings>
                    </ig:Filtering>
                    <ig:Selection CellClickAction="Row" RowSelectType="Single">
                    </ig:Selection>
                    <ig:Sorting>
                    </ig:Sorting>
                    <ig:EditingCore>
                        <Behaviors>
                            <ig:CellEditing>
                                <ColumnSettings>
                                    <ig:EditingColumnSetting ColumnKey="CreateStationeryRetrievalListCheckBox" />
                                </ColumnSettings>
                            </ig:CellEditing>
                        </Behaviors>
                    </ig:EditingCore>
                </Behaviors>
            </ig:WebDataGrid>
            <div style="float:right">
                <%--<a class="buttoningrid" href="" style="float:right">Create</a>--%>
                <asp:Button ID="btnApprove" runat="server" CssClass="Defaultbutton"
                                Text="Create" onclick="btnApprove_Click" />
            </div>
    </div>
</asp:Content>
