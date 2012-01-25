<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStockCard.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ViewStockCard" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
         <img alt="Print" src="~/Images/Common/print.png" />
    </div>
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, ViewStockCard_Title %>" /></h1>
             <br />
             <table>
                <tr>
                    <td>
                        <asp:Label CssClass="DefaultLabelstyle" 
                         ID="Label2" runat="server" 
                         Text="<%$ Resources:WebResources, ViewStockCard_ItemDescription %>"/>
                        
                     </td>
                     <td>
                         <%--<ig:WebTextEditor ID="txtItemDescription" runat="server" 
                          CssClass="DefaultTextStyle" Width="250px">
                         </ig:WebTextEditor>--%>
                         <ig:WebDropDown ID="drdItemList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Item Description" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                          </ig:WebDropDown>
                     </td>
                 </tr>
                 <tr>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="Label1" runat="server" 
                           Text="<%$ Resources:WebResources, ViewStockCard_ItemNo %>"/>
                    </td>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="lblItemNo" runat="server" 
                           Text="P085"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="Label3" runat="server" 
                           Text="<%$ Resources:WebResources, ViewStockCard_Bin %>"/>
                    </td>
                    <td>
                          <asp:Label CssClass="DefaultLabelstyle" 
                           ID="Label4" runat="server" 
                           Text="A7"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                           <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label5" runat="server" 
                            Text="<%$ Resources:WebResources, ViewStockCard_UOM %>"/>
                    </td>
                    <td>
                           <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label6" runat="server" 
                            Text="Box"/><br />
                     </td>
                 </tr>
                  <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label7" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_SupplierList %>"/>
                    </td>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label8" runat="server" 
                            Text="ALpha"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label9" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_1stSupplier %>"/>
                    </td>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label10" runat="server" 
                            Text="BANES"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                             <asp:Label CssClass="DefaultLabelstyle" 
                              ID="Label11" runat="server" 
                              Text="<%$ Resources:WebResources, ViewStockCard_2ndSupplier %>"/>
                    </td>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label12" runat="server" 
                            Text="CHEP"/><br />
                     </td>
                 </tr>
                 <tr>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                             ID="Label13" runat="server" 
                             Text="<%$ Resources:WebResources, ViewStockCard_3rdSupplier %>"/>
                    </td>
                    <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label14" runat="server" 
                            Text="ALPHA"/><br />
                     </td>
                 </tr>
             </table>
            <ig:WebDataGrid ID="DgvStockCardList" runat="server" Height="400px" 
            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                <Columns>
                    <ig:BoundDataField DataFieldName="Date" Key="Date" Width="80px">
                        <Header Text="Date" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Dept/Supplier" Key="Dept/Supplier" 
                        Width="100px">
                        <Header Text="Dept/Supplier" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Qty" Key="Qty" Width="50px">
                        <Header Text="Qty" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Balance" Key="Balance" Width="80px">
                        <Header Text="Balance" />
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
    </div>
</asp:Content>
