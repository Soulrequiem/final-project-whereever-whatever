<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.RequisitionDetails" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
        <asp:HyperLink ID="HyperLink1" runat="server" onmouseover="javascript:this.style.cursor='hand'" 
          onmouseout="javascript:this.style.cursor='pointer'"  ImageUrl="~/Images/Common/print.png" 
          Target="_blank" Text="<%$ Resources:WebResources, PrintImage_text %>"></asp:HyperLink>
        <%--<img alt="Print" src="../Images/Common/print.png" />--%>
    </div>
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, RequisitionDetails_Title %>" /></h1>
                <table>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label2" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionDates %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRequisitionDate" runat="server" 
                            Text="11/01/2012"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label3" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRequisitionID" runat="server" 
                            Text="DDS/121/12"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_DeptCode %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblDeptCode" runat="server" 
                            Text="DDS"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label7" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_DeptName %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="LblDeptName" runat="server" 
                            Text="Department of Registrar"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label9" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeName %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmployeeName" runat="server" 
                            Text="Jenny Wong Mei Lin"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label11" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeNumber %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmployeeNumber" runat="server" 
                            Text="11233"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label13" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeEmailAddress %>"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmpEmailAddress" runat="server" 
                            Text="jenny@LogicUniversity.com"/><br />
                        </td>
                   </tr>
                </table>
                <br /><br />
                <ig:WebDataGrid ID="DgvRequisitionDetails" runat="server" Width="700px"
                 Height="300px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="200px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="300px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="200px">
                            <Header Text="Required Qty" />
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
                <br />
                <div style="float:right">
                        <a class="button" href="" style="float:right">Reject</a>
                </div>
                <div style="float:right;margin-right:10px">
                       <a class="button" href="" style="float:right">Approve</a>
                </div>
                <div style="float:right">
                    <ig:WebTextEditor ID="txtaRemarks" runat="server" Width="200px" Height="50px" 
                        NullText="<%$ Resources:WebResources, Text_Remarks %>">
                    </ig:WebTextEditor>
                </div>
                <div style="float:right;margin-right:10px">
                       <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRemarks" runat="server" 
                            Text="Remarks:"/>
                </div>                 
   </div>
</asp:Content>
