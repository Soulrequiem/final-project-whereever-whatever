<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateCollectionByItems.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.UpdateCollectionByItems" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
            <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="<%$ Resources:WebResources, UpdateCollectionByItems_Header %>" /></h1>
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server"
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle%>" 
                TitleAlignment="Left">
                <Template>
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label5" runat="server" 
                        Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_SelectCollectionLabel%>"/>
                    <ig:WebDataGrid ID="dgvCollectionList" runat="server" Height="200px" 
                        Width="700px" AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" EnableViewState="true"
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
                        oninitializerow="dgvCollectionList_InitializeRow1">
                    <Columns>
                        <%--<ig:TemplateDataField Key="CollectionID" VisibleIndex="0">
                            <Header Text="Collection ID" />
                        </ig:TemplateDataField>--%>
                        <ig:TemplateDataField Key="CollectionID">
                            <ItemTemplate>
                                <asp:HyperLink ID="TripIDLink" runat="server" 
                                    Text='<%# Eval("CollectionID") %>' >
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
                        <%--<ig:BoundDataField DataFieldName="CollectionStatus" Key="CollectionStatus" Hidden="false">
                            <Header Text="Collection Status" />
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
            <br />
            <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px" Height="400px"
                Text="<%$ Resources:WebResources,UpdateCollectionByItems_GroupBoxTitle1%>" 
                TitleAlignment="Left">
                <Template>
                    <table>
                        <tr>
                            <td width="150px">
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label2" runat="server" 
                                    Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_CollectionIDLabel %>"/>
                            </td>
                            <td width="100px">
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
                            <td colspan="3">
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
                        Text="<%$ Resources:WebResources, UpdateCollectionByItems_GridViewTitle%>"/>
                    <ig:WebDataGrid ID="dgvItems" runat="server" Height="250px" Width="700px" 
                        AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableViewState="true"
                        HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="ItemNo"
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty">
                            <Header Text="Required Qty." />
                        </ig:BoundDataField>
                       <%-- <ig:UnboundField Key="ActualQty">
                            <Header Text="Actual Qty" />
                        </ig:UnboundField>--%>
                        <ig:TemplateDataField Key="ActualQty">
                        <ItemTemplate>
                           <ig:WebTextEditor ID="ActualQty" Width="150px" runat="server" Text='<%# Eval("ActualQty" ) %>' NullText="0">
                           </ig:WebTextEditor>
                        </ItemTemplate>
                        <Header Text="Actual Qty." />
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
                 <div style="float:right;margin-top:5px">
                    <asp:Button ID="btnSave" runat="server" CssClass="Defaultbutton" Text="Save" 
                         onclick="btnSave_Click" />
                 </div>
                </Template>
            </igmisc:WebGroupBox>
</div>
</asp:Content>
