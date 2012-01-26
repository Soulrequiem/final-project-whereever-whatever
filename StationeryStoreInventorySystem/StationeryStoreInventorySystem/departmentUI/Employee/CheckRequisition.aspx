﻿<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckRequisition.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee.CheckRequisition" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="<%$ Resources:WebResources, CheckRequisition_header_Text %>" /></h1>
        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left">
                <Template>
                     <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID%>"/></td>
                            <td>
                                 <%--<ig:WebTextEditor ID="txtRequisitionID" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px">
                                </ig:WebTextEditor>--%>
                                <ig:WebDropDown ID="drdRequisitionList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Requisition ID" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                                </ig:WebDropDown>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label9" runat="server" 
                        Text="<%$ Resources:WebResources, SearchResult_Label%>"/>
                    <ig:WebDataGrid ID="dgvRequisitionList" runat="server" Width="700px"  
                         Height="400px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:BoundCheckBoxField DataFieldName="CheckRequisitionCheckBox" 
                            Key="CheckRequisitionCheckBox" Width="50px">
                            <Header Text="BoundCheckBoxField_0" />
                        </ig:BoundCheckBoxField>
                        <ig:BoundDataField DataFieldName="RequisitionID" Key="RequisitionID" 
                            Width="80px">
                            <Header Text="Requisition ID" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequisitionDate/Time" 
                            Key="RequisitionDate/Time" Width="120px">
                            <Header Text="Requisition Date/Time" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="status" Key="status" Width="80px">
                            <Header Text="status" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RemainingQty" Key="RemainingQty" Width="50px">
                            <Header Text="Remaining Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Remarks" Key="Remarks" Width="100px">
                            <Header Text="Remarks" />
                        </ig:BoundDataField>
                        
                    </Columns>
                        <Behaviors>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Sorting>
                            </ig:Sorting>
                            <ig:Paging PageSize="10">
                            </ig:Paging>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:ColumnFixing>
                            </ig:ColumnFixing>
                        </Behaviors>
                 </ig:WebDataGrid><br />
                 <div style="float:right">
                     <asp:Button ID="btnWithdraw" 
                        runat="server" Text="<%$ Resources:WebResources,Withdraw_Button_text %>" />
                 </div>
                </Template>
        </igmisc:WebGroupBox><br />
        <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left"
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle1%>">
                <Template>
                     <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID%>"/></td>
                            <td>
                                 <asp:Label CssClass="DefaultLabelstyle" ID="lblRequisitionID" runat="server" 
                                    Text="DDS/111/20"/>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server" 
                                Text="<%$ Resources:WebResources, CheckRequisition_Status_Label%>"/></td>
                            <td>
                                 <asp:Label CssClass="DefaultLabelstyle" ID="lblRequistionStatus" runat="server" 
                                    Text="Incomplete"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label2" runat="server" 
                        Text="<%$ Resources:WebResources, RequisitionDetails_Title%>"/>
                    <ig:WebDataGrid ID="dgvRequisitionDetails" runat="server"  
                          DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="DefaultGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="120px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="50px">
                            <Header Text="Required Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ReceivedQty" Key="ReceivedQty" Width="50px">
                            <Header Text="Received Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RemainingQty" Key="RemainingQty" Width="50px">
                            <Header Text="Remaining Qty" />
                        </ig:BoundDataField>
                        
                    </Columns>
                        <Behaviors>
                            <ig:Sorting>
                            </ig:Sorting>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Paging PageSize="10">
                            </ig:Paging>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:ColumnFixing>
                            </ig:ColumnFixing>
                        </Behaviors>
                 </ig:WebDataGrid><br />
                </Template>
        </igmisc:WebGroupBox>
    </igmisc:WebGroupBox>
</div>
</asp:Content>