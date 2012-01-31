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
         <%--<img alt="Print" src="../Images/Common/print.png" />--%>
         <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ReceiveOrderForm_Title %>" /></h1>
             <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="700px" CssClass="GroupBoxstyle" 
                    TitleAlignment="Left">
                <Template>
             <table>
                <tr>
                    <td style="width:150px">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_YourRefPONo %>"/>
                    </td>
                    <td style="width:250px">
                        <ig:WebDropDown ID="DrdPONo" runat="server" Width="200px" 
                            NullText="Enter or select PO number" CssClass="DefaultTextStyle">
                        </ig:WebDropDown>
                    </td>
                    <td style="width:150px">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label1" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_DeliveryOrderNo %>"/>
                    </td>
                    <td>
                        <ig:WebTextEditor ID="txtDeliveryOrderNo" runat="server" Width="170px" 
                            NullText="Enter Delivery Order No." CssClass="DefaultTextStyle">
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
             </Template>
             </igmisc:WebGroupBox>
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
             CssClass="GroupBoxstyle" StyleSetName="" Text="Stationery Order" 
             TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="DgvStationeryOrder" runat="server" Height="400px" 
                        Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                        CssClass="DefaultGridViewStyle" ItemCssClass="ItemGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" StyleSetName="Office2010Blue">
                        <Columns>
                            <ig:BoundDataField DataFieldName="ItemNo" Key="itemNo" Width="150px">
                                <Header Text="Item No." />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="ItemDescription" Key="itemDescription" 
                                Width="200px">
                                <Header Text="Item Description" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Quantity" Key="quantity" Width="150px">
                                <Header Text="Quantity" />
                            </ig:BoundDataField>
                            <%--<ig:BoundDataField DataFieldName="Remarks(Supplier)" Key="Remarks(Supplier)" 
                                Width="200px">
                                <Header Text="Remarks(Supplier)" />
                            </ig:BoundDataField>--%>
                            <ig:TemplateDataField Key="Remarks" Width="200px">
                                <ItemTemplate>
                                    <ig:WebTextEditor ID="Remarks" runat="server" Width="170px" 
                                        CssClass="DefaultTextStyle" Text='<%# Eval("Remarks" ) %>'>
                                    </ig:WebTextEditor>
                                </ItemTemplate>
                                <Header Text="Remarks(Supplier)" />
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
                    <br />
                    <div style="float:left">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label5" runat="server" 
                         Text="<%$ Resources:WebResources, ReceiveOrderForm_Remarks%>"/>
                    </div>
                    <div style="float:left">
                        <%--<textarea id="txtaRemarksClerk" cols="35" rows="2"></textarea>--%>
                        <ig:WebTextEditor ID="txtaRemarksClerk" runat="server" Width="498px" NullText="Enter Supplier Remarks"
                               CssClass="DefaultTextStyle" Height="50px" TextMode="MultiLine" >
                        </ig:WebTextEditor>
                    </div>
                    <div style="float:right">
                        <%--<a class="buttoningrid" href="" style="text-align:center">Received</a>--%>
                        <asp:Button ID="btnReceived" runat="server" CssClass="DefaultLargebutton"
                                Text="Received" onclick="btnReceived_Click" />
                    </div>
                </Template>
            </igmisc:WebGroupBox>
    </div>
</asp:Content>
