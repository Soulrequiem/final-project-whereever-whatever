<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenerateDisbursement.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.GenerateDisbursement" %>

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
             Text="<%$ Resources:WebResources, GenerateDisbursement_Title %>" /></h1>
             <br />
            <ig:WebDataGrid ID="DgvGenerateDisbursement" runat="server" Height="300px" 
            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
            EnableDataViewState="True">
                <Columns>
                    <%--<ig:BoundCheckBoxField DataFieldName="GenerateReports" 
                        Key="GenerateReports" Width="80px">
                        <Header Text="Select" />
                    </ig:BoundCheckBoxField>--%>
                    <%--<ig:TemplateDataField Key="Select" Width="80px">
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton1" runat="server" />
                        </ItemTemplate>
                    </ig:TemplateDataField>--%>
                    <%--<ig:BoundDataField DataFieldName="RetrievalNo" Key="RetrievalNo" Width="120px">
                        <Header Text="Retrieval No." />
                    </ig:BoundDataField>--%>
                    <ig:TemplateDataField Key="RetrievalNo" Width="140px">
                        <ItemTemplate>
                            <asp:HyperLink ID="TripIDLink" runat="server" 
                                Text='<%# Eval("RetrievalNo" ) %>'
                                NavigateUrl="~/storeUI/Clerk/GenerateDisbursement.aspx" >
                                </asp:HyperLink>
                        </ItemTemplate>
                        <Header Text="Retrieval No." />
                    </ig:TemplateDataField>
                    <ig:BoundDataField DataFieldName="RetrievalDate/Time" Key="RetrievalDate/Time" 
                        Width="220px">
                        <Header Text="Retrieval Date/Time" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RetrievedQty" Key="RetrievedQty" 
                        Width="170px">
                        <Header Text="Retrieved Qty" />
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RetrievedBy" Key="RetrievedBy" Width="170px">
                        <Header Text="Retrieved By" />
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
                <%--<a class="buttoningrid" href="" style="float:right">Generate</a>--%>
                <asp:Button ID="btnGenerate" runat="server" CssClass="DefaultLargebutton"
                                Text="Generate" />
            </div>
    </div>
</asp:Content>
