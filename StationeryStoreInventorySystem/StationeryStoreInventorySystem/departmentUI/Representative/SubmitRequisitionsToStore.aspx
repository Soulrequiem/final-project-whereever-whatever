<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubmitRequisitionsToStore.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.SubmitRequisitionsToStore" %>
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
        Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_Title %>" /></h1>
    <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px">
        <Template>
            <ig:WebDataGrid ID="dgvRequisitions" runat="server" Height="400px" Width="700px" 
                StyleSetName="Office2010Blue" AutoGenerateColumns="False" 
                CssClass="DefaultGridViewStyle" Font-Size="Small" 
                HeaderCaptionCssClass="HeaderGridViewStyle" 
                ItemCssClass="ItemGridViewStyle">
                <Columns>
                    <ig:TemplateDataField Key="RequisitionID" Width="150px">
                        <Header Text="Requisition ID" />
                    </ig:TemplateDataField>
                    <ig:BoundDataField DataFieldName="RequisitionDateTime" 
                        Key="RequisitionDateTime" Width="170px">
                        <Header Text="Requisition Date/Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RequisitionBy" Key="RequisitionBy" 
                        Width="120px">
                        <Header Text="Requisition By" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RequisitionStatus" Key="RequisitionStatus" 
                        Width="150px">
                        <Header Text="Requisition Status" />
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:Filtering>
                    </ig:Filtering>
                    <ig:Paging PageSize="15">
                    </ig:Paging>
                    <ig:Selection CellClickAction="Row">
                    </ig:Selection>
                    <ig:Sorting>
                    </ig:Sorting>
                </Behaviors>
            </ig:WebDataGrid>
                    <br>
            <div style="float:right">
                        &nbsp;&nbsp;&nbsp;
                            <asp:Button id="btnSave" CssClass="button"  runat="server" 
                            Text="<%$ Resources:WebResources, SubmitRequisitionsToStore_SubmitToStore %>"/>
                        </div>
        </Template>
    </igmisc:WebGroupBox>
</div>
</asp:Content>
