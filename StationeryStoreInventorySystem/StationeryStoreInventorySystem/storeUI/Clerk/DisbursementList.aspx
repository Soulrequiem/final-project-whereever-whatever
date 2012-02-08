<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisbursementList.aspx.cs" Inherits="StationeryStoreInventorySystem.storeUI.Clerk.DisbursementList" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, DisbursementList_Title %>" /></h1>
             <br />
             <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server"
                                Text = "Duisbursement List at " />
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" ID = "lblDate" runat="server" />
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" ID = "Label9" runat="server"
                                Text = "for " />
                        </td>
                        <td>
                            <asp:Label CssClass= "DefaultLabelstyle" ID = "lblCompany" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" ID = "Label10" runat="server"
                                Text = "Collection Point: " />
                        </td>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" ID = "lblCollection" runat="server" />
                        </td>
                    </tr>
                </table>
             </div>
             <asp:Panel ID="RetrievalPanel" runat="server">
            <ig:WebDataGrid ID="DgvDisbursementList" runat="server" Height="300px" 
            Width="500px" DefaultColumnWidth="50px" AutoGenerateColumns="False" DataKeyFields="RetrievalNo"
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
            EnableDataViewState="True">
                <Columns>
                    <ig:BoundDataField DataFieldName="StationeryDescription" Key="StationeryDescription" 
                        Width="300px">
                        <Header Text="Stationery Description" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="Quantity" Key="Quantity" 
                        Width="200px">
                        <Header Text="Quantity" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:Selection CellClickAction="Row" RowSelectType="Single">
                    </ig:Selection>
                    <ig:Sorting>
                    </ig:Sorting>
                </Behaviors>
            </ig:WebDataGrid>
            </asp:Panel>
    </div>
</asp:Content>
