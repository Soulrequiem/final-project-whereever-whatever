<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStationeryCatalogue.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.ViewStationeryCatalogue" %>

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
            Text="<%$ Resources:WebResources, ViewStationeryCatalogue_Header %>" /></h1>
    <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" width="700px"
                TitleAlignment="Left">
                <Template>
                    <br />
                    <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server" 
                                Text="<%$ Resources:WebResources, ViewStationeryCatalogue_EnterItemDescriptionLabel%>"/></td>
                            <td>
                                 <%--<ig:WebTextEditor ID="txtItemDescription" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px">
                                </ig:WebTextEditor><br />--%>
                                <ig:WebDropDown ID="drdItemList" runat="server" Width="250px" 
                                     DropDownAnimationType="EaseIn" NullText="<%$ Resources:WebResources, Text_Item %>" 
                                     StyleSetName="Office2010Blue" 
                                     onselectionchanged="drdItemList_SelectionChanged" AutoPostBack="True">
                                </ig:WebDropDown>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label5" runat="server" 
                        Text="<%$ Resources:WebResources, ViewStationeryCatalogue_Label%>"/>
                    <ig:WebDataGrid ID="dgvStationeryList" runat="server" Width="700px" 
                        Height="500px" DefaultColumnWidth="50px" StyleSetName="Office2010Blue" 
                        AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle">
                        <Columns>
                            <ig:BoundDataField DataFieldName="ItemNo" Key="ItemNo" Width="150px">
                                <Header Text="Item No." />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Category" Key="Category" Width="150px">
                                <Header Text="Category" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="ItemDescription" Key="ItemDescription" 
                                Width="250px">
                                <Header Text="Item Description" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="UnitOfMeasure" Key="UnitOfMeasure" 
                                Width="150px">
                                <Header Text="UnitOfMeasure" />
                            </ig:BoundDataField>
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
                        </Behaviors>
                 </ig:WebDataGrid>
                </Template>
     </igmisc:WebGroupBox>
</div>
</asp:Content>
