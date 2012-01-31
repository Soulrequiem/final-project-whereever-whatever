<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdjustmentVoucher.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager.AdjustmentVoucher" %>

<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="print">
        <%--<img alt="Print" src="../Images/Common/print.png" />--%>
        <asp:ImageButton ID="Print" runat="server" 
            ImageUrl="~/Images/Common/print.png" Width="30px" Height="45px" 
            ToolTip="Print" />
    </div> 
    <div class="ContentDivStyle">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
             <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
             Text="<%$ Resources:WebResources, AdjustmentVoucher_Title %>" /></h1>
             <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Adjustment Voucher" 
                TitleAlignment="Left">
                    <Template>
                        <div style="float:left;width:70px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label2" runat="server" 
                            Text="<%$ Resources:WebResources, AdjustmentVoucher_Voucher %>"/>
                        </div>
                        <div style="float:left">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblVoucher" runat="server" 
                            Text="[000/00000/99]"/><br />
                        </div>
                        <br />
                        <div style="float:left;height:5px"></div>
                        <div style="float:left;width:70px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, AdjustmentVoucher_By %>"/>
                        </div>
                        <div style="float:left">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblBy" runat="server" 
                            Text="Clerk"/><br />
                        </div>
                        <div style="float:right;margin-right:30px">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="lblDateIssue" runat="server" 
                            Text="19/04/1985"/><br />
                        </div>
                        <div style="float:right">
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label3" runat="server" 
                            Text="<%$ Resources:WebResources, AdjustmentVoucher_IssueDate %>"/>
                        </div>
                        <br />
                        <br />
                            <ig:WebDataGrid ID="DgvAdjustmentVoucherDetails" runat="server" Height="300px" 
                                Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                                CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">                                
                                <Columns>
                                    <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="230px">
                                        <Header Text="Item No." />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="QuantityAdjusted" Key="QuantityAdjusted" 
                                        Width="230px">
                                        <Header Text="Quantity Adjusted" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Reason" Key="Reason" Width="240px">
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
                            <div style="float:left;margin-right:10px">
                                   <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblAuthorizedByAdjustment" runat="server" 
                                    Text="<%$ Resources:WebResources, AdjustmentVoucher_AuthorizedBy %>"/>
                            </div>    
                            <div style="float:left">
                                   <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="lblAuthorizedNameAdjustment" runat="server" 
                                    Text="Wai Yan Ko Ko"/>
                            </div>
                            <br />
                    </Template>                
            </igmisc:WebGroupBox>
            <br />
            <div style="float:right">
                   <%--<a href="IssueAdjustmentVoucher.aspx">Back to Issue Adjustment Voucher</a>--%>
                   <asp:Button ID="btnSave" runat="server" CssClass="DefaultVeryLargebutton"
                     Text="<< Back to Issue Adjustment Voucher" />
            </div>
            <div style = "float:right; padding-right: 20px">
                <asp:Button ID="btnBack" runat="server" CssClass="DefaultVeryLargebutton"
                     Text="Go to View Adjustment Voucher List>>" />
            </div>
    </div>
</asp:Content>
