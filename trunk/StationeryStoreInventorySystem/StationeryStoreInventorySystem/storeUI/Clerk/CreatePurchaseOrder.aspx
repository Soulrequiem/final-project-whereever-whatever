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
         <%--<img alt="Print" src="../Images/Common/print.png" />--%>
         <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server"
             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Titile %>" /></h1>
             <igmisc:WebGroupBox ID="WebGroupBox3" runat="server" Width="700px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Create Purchase Order" 
                TitleAlignment="Left">
                <Template>
             <table>
                <tr>
                    <td style="width:150px">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_Supplier %>"/>
                    </td>
                    <td style="width:250px">
                   <%--      <ig:WebDropDown ID="DrdSupplier" runat="server" Width="220px" 
                            NullText="Select Supplier" CssClass="DefaultTextStyle">
                        </ig:WebDropDown> --%>
                        <ig:WebDropDown ID="DrdSupplier" runat="server" Width="220px" 
                                     DropDownAnimationType="EaseIn"
                                     StyleSetName="Office2010Blue" 
                                     AutoFilterQueryType="Contains"
                                     NullText="Select Supplier" ViewStateMode="Enabled" EnableViewState="true" >
                                     <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown>
                    </td>
                    <td style="width:150px">
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label1" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_PONo %>"/>
                    </td>
                    <td style="width:250px">
                        <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblPONumber" runat="server"/><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label3" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_SupplyDate %>"/>
                    </td>
                    <td>
                        <ig:WebTextEditor ID="txtSupplyDate" runat="server" Width="220px" 
                            NullText="Enter the Date (dd/mm/yyyy)" CssClass="DefaultTextStyle">
                        </ig:WebTextEditor>
                    </td>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label4" runat="server" 
                         Text="<%$ Resources:WebResources, CreatePurchaseOrder_DeliverTo %>"/>
                     </td>
                     <td>
                        <ig:WebTextEditor ID="txtaDeliverTo" runat="server" Width="250px" CssClass="DefaultTextStyle"
                            NullText="Enter the Date (dd/mm/yyyy)" Height="50px" TextMode="MultiLine">
                        </ig:WebTextEditor>
                         
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
                        <ig:WebTextEditor ID="txtAttn" runat="server" Width="250px" 
                            NullText="Enter Attention to" CssClass="DefaultTextStyle">
                        </ig:WebTextEditor>
                    </td>
                </tr>
             </table>
             </Template>
       </igmisc:WebGroupBox>
       <br />

        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
          CssClass="GroupBoxstyle" StyleSetName="" Text="Purchase Order Input Form" 
          TitleAlignment="Left">
            <Template>
                <table>
                    <tr>
                        <td style="width:150px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label6" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Description %>"/>
                        </td>
                        <td style="width:250px">
                            <ig:WebDropDown ID="drdItemList" runat="server" Width="220px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Item Description" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                             </ig:WebDropDown>
                        </td>
                        <td style="width:150px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label7" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Quantity %>"/>
                        </td>
                        <td style="width:250px">
                            <ig:WebNumericEditor ID="txtQuantity" runat="server" CssClass="DefaultTextStyle"
                                Width="150px" NullText="Enter Item Quantity">
                            </ig:WebNumericEditor>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label8" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_ItemNumber %>"/>
                        </td>
                        <td style="width:250px">
                            <asp:Label CssClass="DefaultLabelstyle" ID="lblItemNumber"
                             runat="server"/>
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label9" runat="server" 
                             Text="<%$ Resources:WebResources, CreatePurchaseOrder_Price %>"/>
                        </td>
                        <td style="width:100px">
                            <ig:WebTextEditor ID="txtPrice" runat="server" CssClass="DefaultTextStyle"
                                Width="150px" NullText="Enter Item Price">
                            </ig:WebTextEditor>
                        </td>
                        <td>
                            <%--<a class="buttoningrid" href="" style="float:right">Add</a>--%>
                            <asp:Button ID="btnApprove" runat="server" CssClass="Defaultbutton"
                                Text="Add" onclick="btnApprove_Click" />
                        </td>
                    </tr>
                </table>
            </Template>
        </igmisc:WebGroupBox>
        <br />
        <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="700px"
          CssClass="GroupBoxstyle" StyleSetName="" Text="Purchase Order Input Form" 
          TitleAlignment="Left">
            <Template>
                <ig:WebDataGrid ID="DgvPurchaseOrderInput" runat="server" Height="300px" 
                    Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                    CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" EnableDataViewState = "true"
                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:UnboundCheckBoxField Key="CreatePurchaseOrderCheckBox" Width="50px">
                        </ig:UnboundCheckBoxField>
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
                     <%--<a class="button" href="" style="float:right">Delete</a>--%>
                     <asp:Button ID="btnDelete" runat="server" CssClass="DefaultLargebutton"
                                Text="Delete" />
                </div>
                <div style="float:right;margin-right:10px">
                     <%--<a class="buttonlarge" href="" style="float:right">Make Order</a>--%>
                     <asp:Button ID="btnOrder" runat="server" CssClass="DefaultLargebutton"
                                Text="Create Order" />
                </div>
            </Template>
        </igmisc:WebGroupBox>
   </div>
</asp:Content>
