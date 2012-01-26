<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateStationeryRetrievalListAdjustment.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.CreateStationeryRetrievalListAdjustment" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
        <img alt="Print" src="../../Images/Common/print.png" />
    </div>
 <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="Create Stationery Retrieval List" /></h1>
    <table>
        <tr>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" 
                ID="Label2" runat="server" 
                Text="<%$ Resources:WebResources, CreateStationeryRetreivalList_RetrievalNo %>"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" 
                ID="lblRetrievalNo" runat="server" 
                Text="11122012"/><br />
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
    </table>
    <a href="#">Show automatically fulfilled Items</a><br /><br />
    <%--<asp:Repeater ID="RetrievalRepeater" runat="server">
          <ItemTemplate>
          </ItemTemplate>
    </asp:Repeater>--%>
     <igmisc:WebGroupBox ID="GrpBox" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" 
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle%>" 
                TitleAlignment="Left">
                <Template>
                <div style="float:left;width:250px">
                    <table>
                        <tr>
                            <td colspan="2"><asp:Label CssClass="DefaultLabelstyle" ID="lblItem" runat="server"
                                Text="stapler" Font-Bold="true"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label6" runat="server"
                                Text="<%$ Resources:WebResources, CreateStationeryRetreivalList_BinText%>"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="lblBin" runat="server"
                                Text="2"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server"
                                Text="<%$ Resources:WebResources, CreateStationeryRetreivalList_NeededQtyText%>"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="lblNeededQty" runat="server"
                                Text="2"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server"
                                Text="<%$ Resources:WebResources, CreateStationeryRetreivalList_ActualQtyText%>"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="lblActualQty" runat="server"
                                Text="2"/></td>
                        </tr>
                    </table>
                </div>
                <div style="float:left">
                    <div style="height:10px"></div>
                    <div>
                        <ig:WebDataGrid ID="dgvItemList" runat="server" Height="100px" Width="400px" 
                            AutoGenerateColumns="False" DefaultColumnWidth="50px" 
                            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                            ItemCssClass="DefaultGridViewStyle" StyleSetName="Office2010Blue">
                            <Columns>
                                <ig:BoundDataField DataFieldName="DepartmentCode" Key="DepartmentCode" 
                                    Width="150px">
                                    <Header Text="Department Code" />
                                </ig:BoundDataField>
                                <ig:BoundDataField DataFieldName="Needed" Key="Needed" Width="120px">
                                    <Header Text="Needed Quantity" />
                                </ig:BoundDataField>
                                <%--<ig:BoundDataField DataFieldName="Actual" Key="Actual" Width="50px">
                                    <Header Text="Actual" />
                                </ig:BoundDataField>--%>
                                <ig:TemplateDataField  Key="Actual" Width="120px">
                                    <ItemTemplate>
                                       <ig:WebTextEditor ID="WebTextEditor1" runat="server" Width="100px"
                                       Text='<%# Eval("Actual") %>' NullText="Enter Quantity">
                                       </ig:WebTextEditor>
                                    </ItemTemplate>
                                    <Header Text="Actual Quantity" />
                                </ig:TemplateDataField>
                            </Columns>
                            <Behaviors>
                                <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                </ig:Selection>
                                <ig:Sorting>
                                </ig:Sorting>
                            </Behaviors>
                        </ig:WebDataGrid>
                    </div>
                    <div style="height:20px">
                    </div>
                    <div style="float:right">
                        <input id="btnAdd" type="button" 
                            value="<%$ Resources:WebResources, CreateStationeryRetreivalList_ButtonText%>" runat="server"/>
                    </div>
                 </div>
                </Template>
            </igmisc:WebGroupBox>
            <div style="height:20px"></div>
            <div style="float:right">
                        <input id="Button1" type="button" 
                            value="Submit Actual Quantity" runat="server"/>
                    </div>
 </div>
</asp:Content>
