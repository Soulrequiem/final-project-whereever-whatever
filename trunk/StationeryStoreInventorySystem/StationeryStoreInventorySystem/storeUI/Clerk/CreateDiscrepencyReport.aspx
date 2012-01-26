﻿<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateDiscrepencyReport.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.CreateDiscrepencyReport" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, CreateDiscrepencyReport_Header %>" /></h1>
     <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
        
        Text="<%$ Resources:WebResources, CreateDiscrepencyReport_GropuBoxHeader%>" 
        EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server" 
                                Text="<%$ Resources:WebResources, ViewStationeryCatalogue_EnterItemDescriptionLabel%>"/>
                            </td>
                            <td style="width:300px"><%--<ig:WebTextEditor ID="txtDescription" runat="server" 
                                 CssClass="DefaultTextStyle" Width="250px">
                                </ig:WebTextEditor>--%>
                                <ig:WebDropDown ID="drdItemList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="Enter Item Description" 
                                     StyleSetName="Office2010Blue" AutoFilterQueryType="Contains" 
                                    AutoFilterResultSize="5" AutoFilterSortOrder="Ascending">
                                    <Button Visible="False" />
                                    <Items>
                                        <ig:DropDownItem Selected="False" Text="Hello" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Awesome" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Super" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Admin" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="namaskar" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Namaste" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Hiiii" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="wowwwww" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Mast" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Aiyaaaaa" Value="">
                                        </ig:DropDownItem>
                                        <ig:DropDownItem Selected="False" Text="Hello1" Value="">
                                        </ig:DropDownItem>
                                    </Items>
                                </ig:WebDropDown>
                            </td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server" 
                                Text="<%$ Resources:WebResources, CreateDiscrepencyReport_ItemNo%>"/>
                            </td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="lblItemNumber" runat="server" 
                                Text="26187268"/>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server" 
                                Text="<%$ Resources:WebResources, CreateDiscrepencyReport_Quantity%>"/>
                            </td>
                            <td><ig:WebTextEditor ID="txtQuantity" runat="server" 
                                 CssClass="DefaultTextStyle" Width="250px" NullText="Enter Item Quantity">
                                </ig:WebTextEditor><br />
                            </td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label4" runat="server" 
                                Text="<%$ Resources:WebResources, CreateDiscrepencyReport_ItemPrice%>"/>
                            </td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="lblItemPrice" runat="server" 
                                Text="$2890"/>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label2" runat="server" 
                                Text="<%$ Resources:WebResources, CreateDiscrepencyReport_Reason%>"/>
                            </td>
                            <td>
                                <ig:WebTextEditor ID="txtReason" runat="server" 
                                 CssClass="DefaultTextStyle" Width="250px" NullText="Enter Reason" 
                                    Height="55px" TextMode="MultiLine">
                                </ig:WebTextEditor>
                            </td>
                            <td>
                                <input id="btnAdd" type="button" value="<%$ Resources:WebResources,CreateDiscrepencyReport_AddButton%>" runat="server"/>
                            </td>
                        </tr>
                    </table>
                </Template>
    </igmisc:WebGroupBox>
    <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left" Text="<%$ Resources:WebResources, CreateDiscrepencyReport_GropuBoxHeader%>">
                <Template>
                    <ig:WebDataGrid ID="dgvItemList" runat="server" Height="400px" Width="700px" 
                        AutoGenerateColumns="False" DefaultColumnWidth="50px" 
                        CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                        <Columns>
                            <ig:UnboundCheckBoxField Key="CreateDiscrepancyReportCheckBox" Width="80px">
                                <Header Text="Select" />
                            </ig:UnboundCheckBoxField>
                            <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="100px">
                                <Header Text="Item No." />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                                Width="120px">
                                <Header Text="ItemDescription" />
                            </ig:BoundDataField>
                            <ig:TemplateDataField  Key="Quantity" Width="160px">
                                 <ItemTemplate>
                                      <ig:WebTextEditor ID="Quantity" runat="server" Width="150px"
                                          Text='<%# Eval("Quantity") %>'>
                                       </ig:WebTextEditor>
                                  </ItemTemplate>
                                <Header Text="Remarks" />
                              </ig:TemplateDataField>
                            <%--<ig:BoundDataField DataFieldName="Quantity" Key="Quantity" Width="50px">
                                <Header Text="Quantity" />
                            </ig:BoundDataField>--%>
                            <ig:BoundDataField DataFieldName="Price" Key="Price" Width="120px">
                                <Header Text="Price" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Reason" Key="Reason" Width="120px">
                                <Header Text="Reason" />
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
                 </ig:WebDataGrid><br />
                 <div style="float:right">
                     <asp:Button ID="btnApprove" runat="server" Text="<%$ Resources:WebResources, ApproveButton_text%>" />
                     <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:WebResources, DeleteButton_text%>" />
                 </div>
                </Template>
    </igmisc:WebGroupBox>
</div>
</asp:Content>
