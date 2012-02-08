<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.RequisitionDetails" %>

<%@ Register Assembly="Infragistics35.WebUI.WebDataInput.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <%--<div class="print">--%>
        <%--<asp:HyperLink ID="HyperLink1" runat="server" onmouseover="javascript:this.style.cursor='hand'" 
          onmouseout="javascript:this.style.cursor='pointer'"  ImageUrl="~/Images/Common/print.png" 
          Target="_blank" Text="<%$ Resources:WebResources, PrintImage_text %>"></asp:HyperLink>--%>
          <%--<asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/Common/print.png" onclick="ImageButton1_Click"/>--%>
        <%--<img alt="Print" src="../Images/Common/print.png" />--%>
    </div>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, RequisitionDetails_Title %>" /></h1>
                <table>
                    <tr>
                        <%--<td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label2" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionDates %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRequisitionDate" runat="server" 
                            Text="11/01/2012"/><br />
                        </td>--%>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label3" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_RequisitionID %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRequisitionID" runat="server" 
                            Text="DDS/121/12"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_DeptCode %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblDeptCode" runat="server" 
                            Text="DDS"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label7" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_DeptName %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="LblDeptName" runat="server" 
                            Text="Department of Registrar"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label9" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeName %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmployeeName" runat="server" 
                            Text="Jenny Wong Mei Lin"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label11" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeNumber %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmployeeNumber" runat="server" 
                            Text="11233"/><br />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label13" runat="server" 
                            Text="<%$ Resources:WebResources, RequisitionDetails_EmployeeEmailAddress %>"/>
                        </td>
                        <td class="style1">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblEmpEmailAddress" runat="server" 
                            Text="jenny@LogicUniversity.com"/><br />
                        </td>
                   </tr>
                </table>
                <br />
                <ig:WebDataGrid ID="DgvRequisitionDetails" runat="server" Width="700px"
                 Height="300px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
            EnableDataViewState="True" DataKeyFields="itemNo">
                    <Columns>
                        <ig:BoundDataField DataFieldName="itemNo" Key="itemNo" Width="150px">
                            <Header Text="Item No." />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="itemDescription" Key="itemDescription" 
                            Width="250px">
                            <Header Text="Item Description" />
                        </ig:BoundDataField>
                         <ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="150px">
                            <Header Text="Required Qty" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="receivedQty" Key="receivedQty" 
                            Width="250px">
                            <Header Text="Delivered Qty" />
                        </ig:BoundDataField>
                        <%--<ig:BoundDataField DataFieldName="RequiredQty" Key="RequiredQty" Width="200px">
                            <Header Text="Required Qty" />
                        </ig:BoundDataField>--%>
                        <%--<ig:TemplateDataField Key="requiredQty" Width="150px">
                                <ItemTemplate>
                                    <ig:WebTextEditor ID="WebTextEditor1" runat="server" Width="120px"
                                    Text='<%# Eval("requiredQty") %>' NullText="Enter Required Qty">
                                    </ig:WebTextEditor>
                                </ItemTemplate>
                            <Header Text="Required Qty" />
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="receivedQty" Width="150px" Hidden="True">
                                <ItemTemplate>
                                    <ig:WebTextEditor ID="WebTextEditor1" runat="server" Width="120px"
                                    Text='<%# Eval("receivedQty") %>' NullText="Enter Delivered Qty" AutoPostBackFlags-ValueChanged="On"
                                    AutoPostBackFlags-EnterKeyDown="On">
                                    </ig:WebTextEditor>
                                </ItemTemplate>
                            <Header Text="Delivered Qty" />
                        </ig:TemplateDataField>--%>
                    </Columns>
                    <Behaviors>
                        <ig:Selection CellClickAction="Row" RowSelectType="Single">
                        </ig:Selection>
                        <ig:Paging PageSize="10">
                        </ig:Paging>
                        <ig:Filtering>
                        </ig:Filtering>
                        <ig:Sorting>
                        </ig:Sorting>
                        <ig:EditingCore>
                            <Behaviors>
                                <ig:CellEditing>
                                    <ColumnSettings>
                                        <ig:EditingColumnSetting ColumnKey="itemNo" ReadOnly="True" />
                                        <ig:EditingColumnSetting ColumnKey="itemDescription" ReadOnly="True" />
                                        <ig:EditingColumnSetting ColumnKey="RequiredQty" />
                                        <ig:EditingColumnSetting ColumnKey="receivedQty" />
                                    </ColumnSettings>
                                </ig:CellEditing>
                                <ig:RowEditingTemplate>
                                    <EditModeActions MouseClick="Single" />
                                </ig:RowEditingTemplate>
                            </Behaviors>
                        </ig:EditingCore>
                    </Behaviors>
                </ig:WebDataGrid>
                <div style="float:left">
                   <asp:Label CssClass="ErrorLabelstyle" 
                               ID="lblStatusMessage" runat="server"/>
               </div>
                <br />
                <div style="float:right">
                        <asp:Button ID="btnReject" CssClass="Defaultbutton"
                                        runat="server" Text="Reject" onclick="btnReject_Click" 
                            Visible="False"/>
                </div>
                <div style="float:right;margin-right:10px">
                       <asp:Button ID="btnApprove" CssClass="Defaultbutton"
                                        runat="server" Text="Approve" onclick="btnApprove_Click" 
                           Visible="False"/>
                </div>
                <div style="float:right;margin-right:10px">
                       <asp:Button ID="btnSave" CssClass="Defaultbutton"
                                        runat="server" Text="Save" Visible="False" 
                           onclick="btnSave_Click"/>
                </div>
                <div style="float:right;margin-right:10px">
                    <ig:WebTextEditor ID="txtaRemarks" runat="server" Width="200px" Height="50px" 
                        NullText="<%$ Resources:WebResources, Text_Remarks %>" 
                        TextMode="MultiLine" Visible="False">
                    </ig:WebTextEditor>
                </div>
                <div style="float:right;margin-right:10px">
                       <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblRemarks" runat="server" 
                            Text="Remarks:" Visible="False"/>
                </div>    
                <div style="float:left">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Complete Requisition" 
                        CssClass="DefaultLabelstyle" 
                        Visible="False"/>
                        <div style="float:left">
                            <asp:HyperLink ID="lnkback" runat="server" Text="<%$ Resources:WebResources,Back_Link_Text %>" 
                                CssClass="DefaultLabelstyle">
                            </asp:HyperLink>
                        </div>
                </div>  
   </div>    
</asp:Content>
