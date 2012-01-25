<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreatePurchaseOrder.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.CreatePurchaseOrder" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
         <img alt="Print" src="../Images/Common/print.png" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Titile %>" /></h1>
             <br />
             <table>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_Supplier %>"/>
                    </td>
                    <td style="width:200px">
                        <ig:WebDropDown ID="DrdSupplier" runat="server" Width="150px">
                        </ig:WebDropDown>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label1" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_PONo %>"/>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblPONumber" runat="server" 
                           Text="201201068"/><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label3" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_SupplyDate %>"/>
                    </td>
                    <td>
                        <ig:WebTextEditor ID="txtSupplyDate" runat="server" Width="150px">
                        </ig:WebTextEditor>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label4" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_DeliverTo %>"/>
                     </td>
                     <td>
                         <textarea id="txtaRemarksClerk" cols="10" rows="1"></textarea>
                     </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label5" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_Attention %>"/>
                    </td>
                    <td>
                        <ig:WebTextEditor ID="txtAttn" runat="server" Width="150px">
                        </ig:WebTextEditor>
                    </td>
                </tr>
             </table>
             <br />
        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server"
          CssClass="GroupBoxstyle" StyleSetName="" Text="Purchase Order Input Form" 
          TitleAlignment="Left">
            <Template>
                <table>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label6" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Description %>"/>
                        </td>
                        <td style="width:250px">
                            <%--<ig:WebTextEditor ID="txtDescription" runat="server" Width="150px">
                            </ig:WebTextEditor>--%>
                            <ig:WebDropDown ID="drdItemList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Item Description" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                             </ig:WebDropDown>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label7" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Quantity %>"/>
                        </td>
                        <td style="width:250px">
                            <ig:WebTextEditor ID="txtQuantity" runat="server" Width="150px">
                            </ig:WebTextEditor>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label8" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_ItemNumber %>"/>
                        </td>
                        <td style="width:200px">
                            <ig:WebTextEditor ID="txtItemNumber" runat="server" Width="150px">
                            </ig:WebTextEditor>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label9" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Price %>"/>
                        </td>
                        <td style="width:200px">
                            <ig:WebTextEditor ID="txtPrice" runat="server" Width="150px">
                            </ig:WebTextEditor>
                        </td>
                        <td>
                            <a class="buttoningrid" href="" style="float:right">Add</a>
                        </td>
                    </tr>
                </table>
            </Template>
        </igmisc:WebGroupBox>
        <br />
        <igmisc:WebGroupBox ID="WebGroupBox2" runat="server"
          CssClass="GroupBoxstyle" StyleSetName="" Text="Purchase Order Input Form" 
          TitleAlignment="Left">
            <Template>
                <ig:WebDataGrid ID="DgvPurchaseOrderInput" runat="server" Height="400px" 
                    Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                    CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:BoundCheckBoxField DataFieldName="CreatePurchaseOrderCheckBox" 
                            Key="CreatePurchaseOrderCheckBox" Width="50px">
                            <Header Text="BoundCheckBoxField_0" />
                        </ig:BoundCheckBoxField>
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                            <Header Text="Item No" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Description" Key="Description" Width="100px">
                            <Header Text="Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Quantity" Key="Quantity" Width="50px">
                            <Header Text="Quantity" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Price" Key="Price" Width="50px">
                            <Header Text="Price" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Amount" Key="Amount" Width="50px">
                            <Header Text="Amount" />
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
                <div style="float:right">
                     <a class="button" href="" style="float:right">Delete</a>
                </div>
                <div style="float:right;margin-right:10px">
                     <a class="buttonlarge" href="" style="float:right">Make Order</a>
                </div>
            </Template>
        </igmisc:WebGroupBox>
   </div>
</asp:Content>
