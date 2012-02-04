<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="BlackListDepartment.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager.BlackListDepartment" %>

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
             Text="<%$ Resources:WebResources, BlackListDepartment_Title %>" /></h1>
             <br />
             <asp:Label CssClass="DefaultLabelstyle" 
              ID="Label2" runat="server"
              Text="<%$ Resources:WebResources, BlackListDepartment_DepartmentList %>"/>
            <ig:WebDataGrid ID="DgvDepartmentList" runat="server" Height="300px" 
            Width="550px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue"  DataKeyFields="DepartmentID"
            oninitializerow="DgvDepartmentList_InitializeRow" 
            ondatafiltering="DgvDepartmentList_DataFiltering" 
            onpageindexchanged="DgvDepartmentList_PageIndexChanged">
                <Columns>
                    <ig:BoundDataField DataFieldName="DepartmentName" Key="DepartmentName" 
                        Width="200px">
                        <Header Text="Department Name" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="MissedTime" Key="MissedTime" Width="100px">
                        <Header Text="Missed Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Status" Key="Status" Width="100px">
                        <Header Text="Status" />
                    </ig:BoundDataField>
                 <%--    <ig:BoundDataField DataFieldName="Remarks" Key="Remarks" Width="150px">
                        <Header Text="Remarks" />
                    </ig:BoundDataField> --%>
                    <%--<ig:BoundDataField DataFieldName="Black/UnblackList" Key="Black/UnblackList" 
                        Width="150px">
                        <Header Text="BoundColumn_4" />
                    </ig:BoundDataField>--%>
                    <ig:TemplateDataField Key="BlackUnblackList" Width="150px">
                        <ItemTemplate>
                            <asp:HyperLink ID="BlackUnblackList" runat="server" 
                                Text='<%# Eval("BlackUnblackList" ) %>'  >
                                </asp:HyperLink>
                        </ItemTemplate>
                        <Header Text="Black/UnblackList" />
                    </ig:TemplateDataField>
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
