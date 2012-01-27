<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="IssueAdjustmentVoucher.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager.IssueAdjustmentVoucher" %>

<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <br />
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, IssueAdjustmentVoucher_Title %>" /></h1>
             <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="700px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Voucher List" 
                TitleAlignment="Left">
                    <Template>
             <ig:WebDataGrid ID="DgvDiscrepancyReportList" runat="server" Height="200px" 
            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
                            onrowselectionchanged="DgvDiscrepancyReportList_RowSelectionChanged">
                 <Columns>
                     <%--<ig:BoundDataField DataFieldName="VoucherNo" Key="VoucherNo" Width="150px">
                         <Header Text="Voucher No." />
                     </ig:BoundDataField>--%>
                     <ig:TemplateDataField Key="VoucherNo" Width="120px">
                        <ItemTemplate>
                            <asp:HyperLink ID="VoucherNo" runat="server" 
                                Text='<%# Eval("VoucherNo" ) %>'
                                NavigateUrl="~/storeUI/Clerk/GenerateDisbursement.aspx" >
                                </asp:HyperLink>
                        </ItemTemplate>
                        <Header Text="Voucher No." />
                    </ig:TemplateDataField>
                     <ig:BoundDataField DataFieldName="CreatedBy" Key="CreatedBy" Width="150px">
                         <Header Text="Created By" />
                     </ig:BoundDataField>
                     <ig:BoundDataField DataFieldName="CreatedDate" Key="CreatedDate" Width="150px">
                         <Header Text="Created Date" />
                     </ig:BoundDataField>
                     <ig:BoundDataField DataFieldName="TotalQty" Key="TotalQty" Width="100px">
                         <Header Text="Total Qty" />
                     </ig:BoundDataField>
                     <ig:BoundDataField DataFieldName="Status" Key="Status" Width="150px">
                         <Header Text="Status" />
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
             </ig:WebDataGrid>
             </Template>
             </igmisc:WebGroupBox>
             <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Discrepancy Report" 
                TitleAlignment="Left">
                    <Template>
                        <div style="float:left;width:70px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label2" runat="server" 
                            Text="<%$ Resources:WebResources, IssueAdjustmentVoucher_Voucher %>"/>
                        </div>
                        <div style="float:left">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblVoucher" runat="server" 
                            Text="[000/00000/99]"/><br />
                        </div>
                        <br />
                        <div style="float:left;width:70px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, IssueAdjustmentVoucher_By %>"/>
                        </div>
                        <div style="float:left">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblBy" runat="server" 
                            Text="Clerk"/><br />
                        </div>
                        <div style="float:right;margin-right:20px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblDateIssue" runat="server" 
                            Text="dd/mm/yy"/><br />
                        </div>
                        <div style="float:right">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label3" runat="server" 
                            Text="<%$ Resources:WebResources, IssueAdjustmentVoucher_IssueDate %>"/>
                        </div>
                        <br />
                            <ig:WebDataGrid ID="DgvDiscrepancyReport" runat="server" Height="300px" 
                            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                <Columns>
                                    <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="100px">
                                        <Header Text="Item No." />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                                        Width="200px">
                                        <Header Text="Item Description" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Quantity" Key="Quantity" Width="120px">
                                        <Header Text="Quantity" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="PricePerItem" Key="PricePerItem" 
                                        Width="120px">
                                        <Header Text="Price Per Item" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Reason" Key="Reason" Width="150px">
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
                            </ig:WebDataGrid>
                            <div style="float:right">
                                    <%--<a class="button" href="" style="float:right">Issue</a>--%>
                                    <asp:Button ID="btnIssue" runat="server" CssClass="Defaultbutton" Text="Issue" />
                            </div>
                            <div style="float:left;margin-right:10px">
                                   <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblAuthorizedBy" runat="server" 
                                    Text="<%$ Resources:WebResources, IssueAdjustmentVoucher_AuthorizedBy %>"/>
                            </div>    
                            <div style="float:left">
                                   <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblAuthorizedName" runat="server" 
                                    Text="Wai Yan Ko Ko"/>
                            </div>                                         
                    </Template>                
            </igmisc:WebGroupBox>
    </div>
</asp:Content>
