<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReceiveOrderForm.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ReceiveOrderForm" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
         <img alt="Print" src="../Images/Common/print.png" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ReceiveOrderForm_Title %>" /></h1>
             <br />
             <table>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_YourRefPONo %>"/>
                    </td>
                    <td style="width:200px">
                        <ig:WebDropDown ID="DrdPONo" runat="server" Width="150px">
                        </ig:WebDropDown>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label1" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_DeliveryOrderNo %>"/>
                    </td>
                    <td>
                        <ig:WebTextEditor ID="txtDeliveryOrderNo" runat="server">
                        </ig:WebTextEditor>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label3" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_SupplierName %>"/>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblSupplierName" runat="server" 
                           Text="ALPHA"/><br />
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label4" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_DeliverDate %>"/>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblDeliveryDate" runat="server" 
                           Text="11/01/2012"/><br />
                    </td>
                </tr>
             </table>
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server"
             CssClass="GroupBoxstyle" StyleSetName="" Text="Stationery Order" 
             TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="DgvStationeryOrder" runat="server" Height="400px" 
                        Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                        CssClass="DefaultGridViewStyle" ItemCssClass="ItemGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" StyleSetName="Office2010Blue">
                        <Columns>
                            <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                                <Header Text="Item No." />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                                Width="100px">
                                <Header Text="Item Description" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Quantity" Key="Quantity" Width="50px">
                                <Header Text="Quantity" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Remarks(Supplier)" Key="Remarks(Supplier)" 
                                Width="100px">
                                <Header Text="Remarks(Supplier)" />
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
                    <br />
                    <div style="float:left">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label5" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_Remarks%>"/>
                    </div>
                    <div style="float:left">
                        <textarea id="txtaRemarksClerk" cols="35" rows="2"></textarea>
                    </div>
                    <div style="float:right">
                        <a class="buttoningrid" href="" style="text-align:center">Received</a>
                    </div>
                </Template>
            </igmisc:WebGroupBox>
    </div>
</asp:Content>
