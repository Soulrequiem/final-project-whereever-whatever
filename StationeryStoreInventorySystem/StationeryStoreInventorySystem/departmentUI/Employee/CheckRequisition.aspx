<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckRequisition.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee.CheckRequisition" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">.hidden{visibility:hidden;}</style>

    <br />
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <br />
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
            Text="<%$ Resources:WebResources, CheckRequisition_header_Text %>" /></h1>
        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Appletini" width="700px"
                TitleAlignment="Left">
                <Template>
                     <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID%>"/></td>
                            <td>
                                 <%--<ig:WebTextEditor ID="txtRequisitionID" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px">
                                </ig:WebTextEditor>--%>
                                <ig:WebDropDown ID="drdRequisitionList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="<%$ Resources:WebResources, Text_RequisitionID%>" 
                                     StyleSetName="Office2010Blue">
                                    <Button Visible="False" />
                                </ig:WebDropDown>
                            </td>
                            <td>
                                <asp:Button ID="btnSerach" runat="server" Text="Search" CssClass="Searchbutton" 
                                        onclick="btnGetItem_Click"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label9" runat="server" 
                        Text="<%$ Resources:WebResources, SearchResult_Label%>"/>
                    <ig:WebDataGrid ID="dgvRequisitionList" runat="server" Width="700px"
                         Height="250px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" DataKeyFields="requisitionID"
                         oninitializerow="dgvRequisitionList_InitializeRow" EnableDataViewState="true"
                         oncellselectionchanged="dgvRequisitionList_CellSelectionChanged" 
                         onrowselectionchanged="dgvRequisitionList_RowSelectionChanged" 
                         onrowupdating="dgvRequisitionList_RowUpdating">
                    <Columns>
                        <%--<ig:TemplateDataField Key="CheckRequisitionCheckBox" Width="85px">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" OnCheckedChanged="chk_changed" />
                            </ItemTemplate>
                            </ig:TemplateDataField>--%>
                        <ig:UnboundCheckBoxField Key="CheckRequisitionCheckBox" Width="85px">
                        </ig:UnboundCheckBoxField>
                        <%--<ig:BoundDataField DataFieldName="RequisitionID" Key="RequisitionID" 
                            Width="110px">
                            <Header Text="Requisition ID" />
                        </ig:BoundDataField>--%>
                        <ig:TemplateDataField Key="requisitionID" Width="120px">
                            <ItemTemplate>
                                <asp:HyperLink ID="requisitionID" runat="server"
                                 Text='<%# Eval("requisitionID" ) %>'
                                 NavigateUrl="~/departmentUI/Employee/CheckRequisition.aspx" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </asp:HyperLink>
                             </ItemTemplate>
                           <Header Text="Requisition ID" />
                </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="requisitionDate" 
                            Key="requisitionDate" Width="130px">
                            <Header Text="Requisition Date/Time" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="status" Key="status" Width="110px">
                            <Header Text="status" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="remainingQty" Key="remainingQty" Hidden="True"
                            Width="100px">
                            <Header Text="Remaining Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Remarks" Key="Remarks" Width="100px">
                            <Header Text="Remarks" />
                        </ig:BoundDataField>
                        <%--<ig:TemplateDataField  Key="remarks" Width="150px" Hidden="True">
                            <ItemTemplate>
                                <ig:WebTextEditor ID="remarks" runat="server" Width="120px"
                                Text='<%# Eval("remarks") %>'>
                                </ig:WebTextEditor>
                            </ItemTemplate>
                            <Header Text="Remarks" />
                        </ig:TemplateDataField>--%>
                        
                    </Columns>
                        <Behaviors>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                <AutoPostBackFlags RowSelectionChanged="True" />
                            </ig:Selection>
                            <ig:Sorting>
                            </ig:Sorting>
                            <ig:Paging PageSize="5">
                            </ig:Paging>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:EditingCore>
                                <Behaviors>
                                    <ig:CellEditing>
                                        <ColumnSettings>
                                            <ig:EditingColumnSetting ColumnKey="CheckRequisitionCheckBox" />
                                            <ig:EditingColumnSetting ColumnKey="RequisitionID" />
                                            <ig:EditingColumnSetting ColumnKey="requisitionDate" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="status" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="remainingQty" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="remarks" />
                                        </ColumnSettings>
                                    </ig:CellEditing>
                                </Behaviors>
                            </ig:EditingCore>
                        </Behaviors>
                 </ig:WebDataGrid><br />
                 <div style="float:right">
                     <asp:Button ID="btnWithdraw" CssClass="DefaultLargebutton"
                        runat="server" Text="<%$ Resources:WebResources,Withdraw_Button_text %>" 
                         onclick="btnWithdraw_Click" />
                 </div>
                </Template>
        </igmisc:WebGroupBox><br />
        <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left"
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle1%>">
                <Template>
                     <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server" 
                                Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID%>"/></td>
                            <td>
                                 <asp:Label CssClass="DefaultLabelstyle" ID="lblRequisitionID" runat="server" 
                                   />
                            </td>
                        </tr>
                        <tr>
                            <%--<td><asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server" 
                                Text="<%$ Resources:WebResources, CheckRequisition_Status_Label%>"/></td>
                            <td>
                                 <asp:Label CssClass="DefaultLabelstyle" ID="lblRequistionStatus" runat="server" 
                                    />
                            </td>--%>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label2" runat="server" 
                        Text="<%$ Resources:WebResources, RequisitionDetails_Title%>"/>
                    <ig:WebDataGrid ID="dgvRequisitionDetails" runat="server"  
                          DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                         CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                         ItemCssClass="DefaultGridViewStyle" StyleSetName="Office2010Blue" 
                         Height="200px" Width="700px" 
                         ondatafiltering="dgvRequisitionDetails_DataFiltering" 
                         onpageindexchanged="dgvRequisitionDetails_PageIndexChanged">
                    <Columns>
                        
                        <ig:BoundDataField DataFieldName="ItemNo" Key="itemNo" Width="90px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemDescription" Key="itemDescription" 
                            Width="250px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RequiredQty" Key="requiredQty" Width="120px">
                            <Header Text="Required Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ReceivedQty" Key="receivedQty" Width="120px">
                            <Header Text="Received Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RemainingQty" Key="remainingQty" 
                            Width="120px">
                            <Header Text="Remaining Qty" />
                        </ig:BoundDataField>
                        
                    </Columns>
                        <Behaviors>
                            <ig:Sorting>
                            </ig:Sorting>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Paging>
                            </ig:Paging>
                            <ig:Filtering>
                            </ig:Filtering>
                        </Behaviors>
                 </ig:WebDataGrid><br />
                </Template>
        </igmisc:WebGroupBox>
    </igmisc:WebGroupBox>
</div>
</asp:Content>
