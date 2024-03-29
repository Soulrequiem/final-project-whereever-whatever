﻿<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApproveRequisition.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head.ApproveRequisition" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
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
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" DataKeyFields="RequisitionID"
            Height="400px" Width="700px">
            <Columns>
                <ig:UnboundCheckBoxField Key="ApproveRequisitionCheckBox" HeaderChecked="false" HeaderCheckBoxMode="Off" 
                    Width="50px">
                </ig:UnboundCheckBoxField>
                <%--<ig:BoundDataField DataFieldName="RequisitionID" Key="RequisitionID" 
                    Width="100px">
                    <Header Text="Requisition ID" />
                </ig:BoundDataField>--%>
                <ig:TemplateDataField Key="RequisitionID" Width="110px">
                    <ItemTemplate>
                        <asp:HyperLink ID="RequisitionID" runat="server"
                         Text='<%# Eval("RequisitionID" ) %>'
                         NavigateUrl='<%# Eval("RequisitionID","~/commonUI/RequisitionDetails.aspx?ReqID={0}") %>'>
                        </asp:HyperLink>
                     </ItemTemplate>
                   <Header Text="Requisition ID" />
                </ig:TemplateDataField>
                <ig:BoundDataField DataFieldName="RequisitionDate/Time" Key="RequisitionDate/Time" 
                    Width="150px">
                    <Header Text="Requisition Date/Time" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="RequisitionBy" Key="RequisitionBy" 
                    Width="100px">
                    <Header Text="Requisition By" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="RequisitionQty" Key="RequisitionQty" 
                    Width="120px">
                    <Header Text="Requisition Qty" />
                </ig:BoundDataField>
                <ig:TemplateDataField  Key="Remarks" Width="155px">
                        <ItemTemplate>
                             <ig:WebTextEditor ID="Remarks" runat="server" Width="110px"
                              Text='<%# Eval("Remarks") %>' >
                            </ig:WebTextEditor>
                        </ItemTemplate>
                     <Header Text="Remarks" />
                 </ig:TemplateDataField>
                <%--<ig:BoundDataField DataFieldName="Remarks" Key="Remarks" Width="100px">
                    <Header Text="Remarks" />
                </ig:BoundDataField>--%>

            </Columns>
            <Behaviors>
                <ig:Selection CellClickAction="Cell" RowSelectType="Single" Enabled="true">
                </ig:Selection>
                <ig:Paging PageSize="10">
                </ig:Paging>
                <ig:Filtering>
                </ig:Filtering>
                <ig:Sorting>
                </ig:Sorting>
                <ig:EditingCore>
                    <Behaviors>
                        <ig:CellEditing>
                            <ColumnSettings>
                                <ig:EditingColumnSetting ColumnKey="ApproveRequisitionCheckBox" />
                                <ig:EditingColumnSetting ColumnKey="RequisitionID" />
                                <ig:EditingColumnSetting ColumnKey="RequisitionDate/Time" ReadOnly="True" />
                                <ig:EditingColumnSetting ColumnKey="RequisitionBy" ReadOnly="True" />
                                <ig:EditingColumnSetting ColumnKey="RequisitionQty" ReadOnly="True" />
                                <ig:EditingColumnSetting ColumnKey="Remarks" />
                            </ColumnSettings>
                        </ig:CellEditing>
                    </Behaviors>
                </ig:EditingCore>
            </Behaviors>
        </ig:WebDataGrid>
        <div style="float:right">
               <asp:Button ID="btnReject" CssClass="DefaultLargebutton"
                        runat="server" Text="Reject" onclick="btnReject_Click" />
        </div>
        <div style="float:right;margin-right:10px">
                <asp:Button ID="btnApprove" CssClass="DefaultLargebutton"
                        runat="server" Text="Approve" onclick="btnApprove_Click" />
               <%--<a class="button" href="#" style="float:right">Approve</a>--%>
        </div>
        <asp:HiddenField ID="hdnApprove" runat="server" />
    </div>
</asp:Content>
