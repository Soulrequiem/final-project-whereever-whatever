<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateCollectionByRequisitions.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.UpdateCollectionByRequisitions" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
            <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="<%$ Resources:WebResources, UpdateCollectionByRequisitions %>" /></h1>
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" 
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle%>" 
                TitleAlignment="Left">
                <Template>
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label5" runat="server" 
                        Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_SelectCollectionLabel%>"/>
                    <ig:WebDataGrid ID="dgvCollectionList" runat="server" Height="200px" 
                        Width="700px" AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <%--<ig:TemplateDataField Key="CollectionID" VisibleIndex="0">
                            <Header Text="Collection ID" />
                        </ig:TemplateDataField>--%>
                        <ig:TemplateDataField Key="CollectionID">
                            <ItemTemplate>
                                <asp:HyperLink ID="TripIDLink" runat="server" 
                                    Text='<%# Eval("CollectionID" ) %>'
                                    NavigateUrl="~/storeUI/Clerk/GenerateDisbursement.aspx" >
                                    </asp:HyperLink>
                            </ItemTemplate>
                            <Header Text="Collection ID" />
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="CollectionPoint" Key="CollectionPoint" 
                            VisibleIndex="1">
                            <Header Text="Collection Point" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CollectionDay" Key="CollectionDay">
                            <Header Text="Collection Day" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CollectionDateTime" Key="CollectionDateTime">
                            <Header Text="Collection Date/Time" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CollectionStatus" Key="CollectionStatus">
                            <Header Text="Collection Status" />
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="Status">
                            <ItemTemplate>
                            <asp:HyperLink ID="Status" runat="server" 
                                Text='Update Status'
                                NavigateUrl="~/storeUI/Clerk/GenerateDisbursement.aspx" >
                                </asp:HyperLink>
                                <Header Text="" />
                        </ItemTemplate>
                        </ig:TemplateDataField>
                        <%--<ig:BoundDataField DataFieldName="Status" Key="Status">
                            <Header Text="Status" />
                        </ig:BoundDataField>--%>
                    </Columns>
                        <Behaviors>
                            <ig:Paging>
                            </ig:Paging>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Sorting>
                            </ig:Sorting>
                        </Behaviors>
                 </ig:WebDataGrid>
                </Template>
            </igmisc:WebGroupBox>
            <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" Height="400px"
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle1%>" 
                TitleAlignment="Left">
                <Template>
                    <table>
                        <tr>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label2" runat="server" 
                                    Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_CollectionIDLabel %>"/>
                            </td>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblCollectionID" runat="server" 
                                    Text="C0019"/>
                            </td>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label3" runat="server" 
                                    Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_CollectionPointLabel %>"/>
                            </td>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblCollectionPoint" runat="server" 
                                    Text="University Hospital"/>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label1" runat="server" 
                                    Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_CollectionDateTimeLabel %>"/>
                            </td>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblDateTime" runat="server" 
                                    Text="Monday 20-01-2012 11.35 AM"/>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label4" runat="server" 
                        Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_RequisitionLabel%>"/>
                    
                <ig:WebDataGrid ID="dgvRequisitions" runat="server" Height="300px" Width="700px" 
                        AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="DefaultGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:BoundDataField DataFieldName="RequisitionID" Key="RequisitionID" 
                            Width="80px">
                            <Header Text="Requisition ID" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequisitionDateTime" 
                            Key="RequisitionDateTime">
                            <Header Text="Requisition Date/Time" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequisitionBy" Key="RequisitionBy">
                            <Header Text="Requisition By" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequisitionStatus" Key="RequisitionStatus">
                            <Header Text="Requisition Status" />
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="ModifyRequisition">
                            <ItemTemplate>
                            <asp:HyperLink ID="TripIDLink" runat="server" 
                                Text='Modify Delivered Quantity'
                                NavigateUrl="~/storeUI/Clerk/GenerateDisbursement.aspx" >
                                </asp:HyperLink>
                        </ItemTemplate>
                        </ig:TemplateDataField>
                    </Columns>
                        <Behaviors>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:Paging>
                            </ig:Paging>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Sorting>
                            </ig:Sorting>
                        </Behaviors>
                 </ig:WebDataGrid>
                 </Template>
            </igmisc:WebGroupBox>
</div>
</asp:Content>
