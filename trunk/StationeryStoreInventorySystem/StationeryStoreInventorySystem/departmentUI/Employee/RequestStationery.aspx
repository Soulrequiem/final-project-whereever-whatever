<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="RequestStationery.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee.RequestStationery" %>
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
    <div class="print">
        <img alt="Print" src="../../Images/Common/print.png" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="<%$ Resources:WebResources, RequestStationery_Header %>" /></h1>
    <table>
        <tr>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionDates%>"/>
            </td>
            <td style="width:200px">
                <asp:Label CssClass="DefaultLabelstyle" ID="lblRequisitionDate" runat="server" 
                                Text="20-01-2012"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label4" runat="server" 
                                Text="<%$ Resources:WebResources, RequestStationery_EmpName_Label%>"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblEmployeeName" runat="server" 
                                Text="Shekhar Kamble"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label7" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID%>"/>
                
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblRequisitionID" runat="server" 
                                Text="DDS/111/19"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label5" runat="server" 
                                Text="<%$ Resources:WebResources, RequestStationery_EmpNumber_Label%>"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblEmployeeID" runat="server" 
                                Text="E0019"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label2" runat="server" 
                                Text="<%$ Resources:WebResources, RequestStationery_DeptCode_Label%>"/>
                
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblDepartmentCode" runat="server" 
                                Text="DDS"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label6" runat="server" 
                                Text="<%$ Resources:WebResources, RequestStationery_EmpEmail_Label%>"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblEmployeeEmailID" runat="server" 
                                Text="shekharskamble@gmail.com"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server" 
                                Text="<%$ Resources:WebResources, RequestStationery_DeptName_Label%>"/>
            </td>
            <td>
                <asp:Label CssClass="DefaultLabelstyle" ID="lblDepartmentName" runat="server" 
                                Text="Department of Registrar"/>
            </td>
        </tr>
    </table>
    <br />
    <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left">
                <Template>
                     <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server" 
                                Text="<%$ Resources:WebResources, ViewStationeryCatalogue_EnterItemDescriptionLabel%>"/></td>
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
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label9" runat="server" 
                        Text="<%$ Resources:WebResources, SearchResult_Label%>"/>
                    <ig:WebDataGrid ID="dgvStationeryList" runat="server" Height="300px" 
                         Width="515px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="120px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AddToTable" Key="BoundColumn_2" Width="50px">
                            <Header Text="BoundColumn_2" />
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
                </Template>
     </igmisc:WebGroupBox>
     <br />
     <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left">
                <Template>
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label11" runat="server" 
                        Text="<%$ Resources:WebResources, RequisitionDetails_Label_Text%>"/>
                    <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="400px" Width="700px" 
                        DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                        CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:BoundCheckBoxField DataFieldName="RequestStationeryCheckBox" 
                            Key="RequestStationeryCheckBox" Width="50px">
                            <Header Text="BoundCheckBoxField_0" />
                        </ig:BoundCheckBoxField>
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="50px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="120px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="50px">
                            <Header Text="Required Qty" />
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
                    <asp:Button ID="btnRequest" 
                        runat="server" Text="<%$ Resources:WebResources,Request_Button_text %>" />
                    <asp:Button ID="btnRemove" 
                        runat="server" Text="<%$ Resources:WebResources,Remove_Button_text %>" />
                    <asp:Button ID="btnReset" 
                        runat="server" Text="<%$ Resources:WebResources,Reset_Button_text %>" />
                 </div>
                </Template>
     </igmisc:WebGroupBox>
</div>
</asp:Content>
