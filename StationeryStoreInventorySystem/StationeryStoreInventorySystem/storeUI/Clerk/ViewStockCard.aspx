<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ViewStockCard" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 241px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
         <%--<img alt="Print" src="~/Images/Common/print.png" />--%>
         <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ViewStockCard_Title %>" /></h1>
             <table>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, ViewStockCard_ItemDescription %>"/>
                        
                     </td>
                     <td class="style1">
                         <%--<ig:WebTextEditor ID="txtItemDescription" runat="server" 
                          CssClass="DefaultTextStyle" Width="250px">
                         </ig:WebTextEditor>--%>
                         <ig:WebDropDown ID="drdItemList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Item Description" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                          </ig:WebDropDown>
                         
                     </td>
                     <td>
                         <asp:Button ID="btnGetItem" runat="server" Text="Select" 
                             CssClass="Searchbutton" onclick="btnGetItem_Click"/>
                     </td>
                 </tr>
                 <tr>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="Label1" runat="server" 
                           Text="<%$ Resources:WebResources, ViewStockCard_ItemNo %>"/>
                    </td>
                    <td class="style1">
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblItemNo" runat="server"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="Label3" runat="server" 
                           Text="<%$ Resources:WebResources, ViewStockCard_Bin %>"/>
                    </td>
                    <td class="style1">
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblBin" runat="server"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                           <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label5" runat="server" 
                            Text="<%$ Resources:WebResources, ViewStockCard_UOM %>"/>
                    </td>
                    <td class="style1">
                           <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblUOM" runat="server"/><br />
                     </td>
                 </tr>
                  <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label7" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_SupplierList %>"/>
                    </td>
                    <td class="style1">
                            <br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label9" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_1stSupplier %>"/>
                    </td>
                    <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblSuplier1" runat="server"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                             <asp:Label CssClass="DefaultLabelstyle" 
                              ID="Label11" runat="server" 
                              Text="<%$ Resources:WebResources, ViewStockCard_2ndSupplier %>"/>
                    </td>
                    <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblSuplier2" runat="server"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label13" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_3rdSupplier %>"/>
                    </td>
                    <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblSuplier3" runat="server"/><br />
                     </td>
                 </tr>
             </table>
            <ig:WebDataGrid ID="DgvStockCardList" runat="server" Height="400px" 
            Width="500px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                <Columns>
                    <ig:BoundDataField DataFieldName="date" Key="date" Width="100px">
                        <Header Text="Date" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="dept/supplier" Key="dept/supplier" 
                        Width="200px">
                        <Header Text="Dept/Supplier" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="qty" Key="qty" Width="100px">
                        <Header Text="Qty" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="balance" Key="balance" Width="100px">
                        <Header Text="Balance" />
                    </ig:BoundDataField>
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
