<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateDiscrepencyReport.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.CreateDiscrepencyReport" %>
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
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                                </ig:WebDropDown>
                                <br />
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
                                 CssClass="DefaultTextStyle" Width="250px">
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
                                <textarea id="txtReason" cols="20" rows="2" style="resize: none;width:250px"
                                    runat="server"></textarea>
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
                            <ig:BoundCheckBoxField DataFieldName="CreateDiscrepancyReportCheckBox" 
                                Key="CreateDiscrepancyReportCheckBox" Width="50px">
                                <Header Text="BoundCheckBoxField_0" />
                            </ig:BoundCheckBoxField>
                            <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                                <Header Text="Item No." />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                                Width="100px">
                                <Header Text="ItemDescription" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Quantity" Key="Quantity" Width="50px">
                                <Header Text="Quantity" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Price" Key="Price" Width="50px">
                                <Header Text="Price" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Reason" Key="Reason" Width="100px">
                                <Header Text="Reason" />
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
                 </ig:WebDataGrid><br />
                 <div style="float:right">
                     <asp:Button ID="btnApprove" runat="server" Text="<%$ Resources:WebResources, ApproveButton_text%>" />
                     <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:WebResources, DeleteButton_text%>" />
                 </div>
                </Template>
    </igmisc:WebGroupBox>
</div>
</asp:Content>
