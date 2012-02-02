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
        <%--<asp:HyperLink ID="HyperLink1" runat="server" onmouseover="javascript:this.style.cursor='hand'" 
          onmouseout="javascript:this.style.cursor='pointer'"  ImageUrl="~/Images/Common/print.png" 
          Target="_blank" Text="<%$ Resources:WebResources, PrintImage_text %>"></asp:HyperLink>--%>
        <%--<img alt="Print" src="../../Images/Common/print.png" />--%>
        <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
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
    <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="600px"
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
                                     DropDownAnimationType="EaseIn" NullText="<%$ Resources:WebResources, Text_Item %>" 
                                     StyleSetName="Office2010Blue" 
                                     onselectionchanged="drdItemList_SelectionChanged" 
                                     AutoFilterQueryType="Contains" >
                                     <%--onvaluechanged="drdItemList_ValueChanged">--%>
                                     <Button Visible="False" />
                                    <Items>
                                        <ig:DropDownItem Selected="false" Text="DropDown Item" Value="">
                                        </ig:DropDownItem>
                                    </Items>
                                </ig:WebDropDown>
                                <asp:Button ID="btnGetItem" runat="server" Text="Select" CssClass="Defaultbutton" 
                                        onclick="btnGetItem_Click"/>
                            </td>
                        </tr>
                    </table>
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label9" runat="server" 
                        Text="<%$ Resources:WebResources, SearchResult_Label%>"/>
                    <ig:WebDataGrid ID="dgvStationeryList" runat="server" Height="150px" 
                         Width="570px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="140px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="270px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <%--<ig:BoundDataField DataFieldName="AddToTable" Key="AddToTable" Width="80px">
                            <Header Text="" />
                        </ig:BoundDataField>--%>
                        <ig:TemplateDataField Key="AddToTable" Width="160px">
                                <ItemTemplate>
                                   <asp:HyperLink ID="AddToTable" runat="server"
                                       Text="Add to Table"
                                       NavigateUrl="~/departmentUI/Employee/RequestStationery.aspx" >
                                       </asp:HyperLink>
                               </ItemTemplate>
                            <Header Text="" />
                        </ig:TemplateDataField>
                        
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
                </Template>
     </igmisc:WebGroupBox>
     <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="600px"
                TitleAlignment="Left">
                <Template>
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label11" runat="server" 
                        Text="<%$ Resources:WebResources, RequisitionDetails_Label_Text%>"/>
                    <ig:WebDataGrid ID="dgvStationeryDetailsList" runat="server" Height="200px" Width="570px" 
                        DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                        CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        
                        <ig:UnboundCheckBoxField Key="RequestStationeryCheckBox" Width="60px">
                            <Header Text="" />
                        </ig:UnboundCheckBoxField>
                        <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="80px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                            Width="270px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                       <%-- <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="80px">
                            <Header Text="Required Qty" />
                        </ig:BoundDataField>--%>
                        <ig:TemplateDataField  Key="RequiredQty" Width="160px">
                            <ItemTemplate>
                                <ig:WebTextEditor ID="WebTextEditor1" runat="server" Width="140px"
                                Text='<%# Eval("RequiredQty") %>' NullText="Enter Required Quantity">
                                </ig:WebTextEditor>
                            </ItemTemplate>
                            <Header Text="Required Qty" />
                        </ig:TemplateDataField>
                        
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
                            <ig:EditingCore>
                                <Behaviors>
                                    <ig:CellEditing>
                                        <ColumnSettings>
                                            <ig:EditingColumnSetting ColumnKey="RequestStationeryCheckBox" />
                                            <ig:EditingColumnSetting ColumnKey="ItemNo" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="ItemDescription" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="RequiredQty" />
                                        </ColumnSettings>
                                    </ig:CellEditing>
                                </Behaviors>
                            </ig:EditingCore>
                        </Behaviors>
                 </ig:WebDataGrid>
                 <div style="float:right;margin-right:15px">
                    <asp:Button ID="btnRequest" CssClass="DefaultLargebutton"
                        runat="server" Text="<%$ Resources:WebResources,Request_Button_text %>" />
                    <asp:Button ID="btnRemove" CssClass="DefaultLargebutton"
                        runat="server" Text="<%$ Resources:WebResources,Remove_Button_text %>" />
                    <asp:Button ID="btnReset" CssClass="DefaultLargebutton"
                        runat="server" Text="<%$ Resources:WebResources,Reset_Button_text %>" />
                 </div>
                </Template>
     </igmisc:WebGroupBox>
</div>
</asp:Content>
