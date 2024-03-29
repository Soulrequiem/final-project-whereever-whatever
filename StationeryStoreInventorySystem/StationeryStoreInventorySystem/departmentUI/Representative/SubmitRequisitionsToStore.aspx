﻿<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubmitRequisitionsToStore.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.SubmitRequisitionsToStore" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_Title %>" /></h1>
    <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px">
        <Template>
            <div style="float:left; width:80px">
                <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblCollection" runat="server" 
                            Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_CollectionID %>"/> 
            </div>
            <div style="float:left">
                <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblCollectionID" runat="server" />
            </div>
            <div style="float:right">
                <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblCollectionPoint" runat="server" />
            </div>
            <div style="float:right; width:100px">
                <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_CollectionPoint %>"/> 
            </div><br />
            <ig:WebDataGrid ID="dgvRequisitions" runat="server" Height="400px" Width="700px" 
                StyleSetName="Office2010Blue" AutoGenerateColumns="False" 
                CssClass="DefaultGridViewStyle" Font-Size="Small" 
                HeaderCaptionCssClass="HeaderGridViewStyle" 
                ItemCssClass="ItemGridViewStyle" 
                ondatafiltering="dgvRequisitions_DataFiltering" 
                onpageindexchanged="dgvRequisitions_PageIndexChanged">
                <Columns>
                    <%--<ig:TemplateDataField Key="RequisitionID" Width="150px">
                        <ItemTemplate>
                            <asp:HyperLink ID="TripIDLink" runat="server" 
                                Text='<%# Eval("RequisitionID" ) %>'
                                NavigateUrl='<%# Eval("RequisitionID","~/commonUI/RequisitionDetails.aspx?ReqID={0}") %>'>
                                </asp:HyperLink>
                        </ItemTemplate>
                        <Header Text="Requisition ID" />
                    </ig:TemplateDataField>--%>
                    <ig:BoundDataField DataFieldName="RequisitionID" 
                        Key="RequisitionID" Width="150px">
                        <Header Text="Requisition ID" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RequisitionDateTime" 
                        Key="RequisitionDateTime" Width="170px">
                        <Header Text="Requisition Date/Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RequisitionBy" Key="RequisitionBy" 
                        Width="170px">
                        <Header Text="Requisition By" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RequisitionStatus" Key="RequisitionStatus" 
                        Width="200px">
                        <Header Text="Requisition Status" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:Filtering>
                    </ig:Filtering>
                    <ig:Paging PageSize="15">
                    </ig:Paging>
                    <ig:Selection CellClickAction="Row">
                    </ig:Selection>
                    <ig:Sorting>
                    </ig:Sorting>
                </Behaviors>
            </ig:WebDataGrid>
                    <br>
            <div style="float:right">
                        &nbsp;&nbsp;&nbsp;
                            <asp:Button id="btnSave" CssClass="MediumLargeButton"  runat="server" 
                            Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_SubmitToStore %>" 
                            onclick="btnSave_Click"/>
                        </div>
        </Template>
    </igmisc:WebGroupBox>
</div>
</asp:Content>
