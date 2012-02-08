<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageStationeryRetrievalList.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.ManageStationeryRetrievalList" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showHiddenFulfill() {
            if ($('#fulfillRetrieval').is(':hidden')) {
                $('#fulfillRetrieval').show();
            }
            else{
                $('#fulfillRetrieval').hide();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
    Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Title %>" /></h1>
    <br />
    <asp:Label CssClass="DefaultLabelstyle" 
        ID="Label2" runat="server" 
        Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_RetrievalNo %>"/>

    <asp:Label CssClass="DefaultLabelstyle" 
        ID="lblRetrievalNo" runat="server" 
        Text=""/>

    <br />
    <br />

    <asp:Panel ID="fulfilledPanel" runat="server">
    <a href="javascript:showHiddenFulfill()">Show automatically fulfilled items</a>

    <div id="fulfillRetrieval" style="display: none;">
    <br />
    <br />
    <igmisc:WebGroupBox ID="FulfillWebGroupBox1" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lFulfillBin1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillBin1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillNeededQty1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillNeededQty1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillActualQty1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillActualQty1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="FulfillWebDataGrid1" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnFulfillSet1" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>    --%>                
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="FulfillWebGroupBox2" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lFulfillBin2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillBin2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillNeededQty2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillNeededQty2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillActualQty2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillActualQty2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="FulfillWebDataGrid2" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnFulfillSet2" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   --%>
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="FulfillWebGroupBox3" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lFulfillBin3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillBin3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillNeededQty3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillNeededQty3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillActualQty3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillActualQty3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="FulfillWebDataGrid3" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnFulfillSet3" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   --%>
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="FulfillWebGroupBox4" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lFulfillBin4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillBin4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillNeededQty4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillNeededQty4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillActualQty4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillActualQty4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="FulfillWebDataGrid4" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnFulfillSet4" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>  --%>
                        </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="FulfillWebGroupBox5" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lFulfillBin5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillBin5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillNeededQty5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillNeededQty5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lFulfillActualQty5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFulfillActualQty5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="FulfillWebDataGrid5" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnFulfillSet5" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   --%>
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <asp:Panel ID="FulfilledPaginating" HorizontalAlign="Right" runat="server">
    
    </asp:Panel>
    </div>

    </asp:Panel>


    <asp:Panel ID="unfulfilledPanel" runat="server">
    <br />
    <br />

    Below are the list of items that cannot be fulfilled automatically due to balance of stock:

    <br />
    <br />
    
    <igmisc:WebGroupBox ID="WebGroupBox1" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lBin1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBin1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lNeededQty1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNeededQty1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lActualQty1" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblActualQty1" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="DgvManageStationeryRetrievalList1" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSet1" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="WebGroupBox2" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lBin2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBin2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lNeededQty2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNeededQty2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lActualQty2" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblActualQty2" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="DgvManageStationeryRetrievalList2" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSet2" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="WebGroupBox3" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lBin3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBin3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lNeededQty3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNeededQty3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lActualQty3" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblActualQty3" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="DgvManageStationeryRetrievalList3" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSet3" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="WebGroupBox4" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lBin4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBin4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lNeededQty4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNeededQty4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lActualQty4" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblActualQty4" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="DgvManageStationeryRetrievalList4" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSet4" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   
                    </table>
                </Template>
    </igmisc:WebGroupBox>

    <br />

    <igmisc:WebGroupBox ID="WebGroupBox5" Visible="false" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="Office2007Black" width="700px"
                TitleAlignment="Left" 
                EnableAppStyling="True">
                <Template>
                    <table>
                        <tr>
                            <td width="300px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="lBin5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_Bin%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBin5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lNeededQty5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_NeededQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNeededQty5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lActualQty5" CssClass="DefaultLabelstyle" Text="<%$ Resources:WebResources, ManageStationeryRetrievalList_ActualQty%>" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblActualQty5" CssClass="DefaultLabelstyle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <ig:WebDataGrid ID="DgvManageStationeryRetrievalList5" runat="server" 
                                    Height="150px" Width="400px" DefaultColumnWidth="50px" 
                                    AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" EnableDataViewState="true"
                                    HeaderCaptionCssClass="HeaderGridViewStyle" DataKeyFields="Department"
                                    ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                        <Columns>
                                            <ig:BoundDataField DataFieldName="Department" Key="Department" 
                                                Width="150px">
                                                <Header Text="Department" />
                                            </ig:BoundDataField>
                                            <ig:BoundDataField DataFieldName="NeededQty" Key="NeededQty" 
                                                Width="100px">
                                                <Header Text="Needed Qty" />
                                            </ig:BoundDataField>
                                            <ig:TemplateDataField  Key="ActualQty" Width="100px">
                                                <ItemTemplate>
                                                     <ig:WebTextEditor ID="ActualQty" runat="server" Width="100px"
                                                      Text='<%# Eval("ActualQty") %>' >
                                                    </ig:WebTextEditor>
                                                </ItemTemplate>
                                             <Header Text="Actual Qty" />
                                         </ig:TemplateDataField>                  
                                        </Columns>
                                        <Behaviors>
                                            <ig:Filtering>
                                                <ColumnSettings>
                                                    <ig:ColumnFilteringSetting />
                                                </ColumnSettings>
                                            </ig:Filtering>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                            </ig:Selection>
                                            <ig:Sorting>
                                            </ig:Sorting>                    
                                        </Behaviors>
                                    </ig:WebDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSet5" style="width:200px" runat="server" CssClass="DefaultLargebutton"
                                    Text="Set Based On Request Sequence" onclick="btnGenerate_Click" />
                            </td>
                        </tr>   
                    </table>
                </Template>
    </igmisc:WebGroupBox>
    
    <asp:Panel ID="UnfulfilledPaginating" HorizontalAlign="Right" runat="server">
        
    </asp:Panel>

    </asp:Panel>

    <br />

    <div style="float: right">
    <asp:Button ID="btnSubmit" style="width:150px" runat="server" CssClass="DefaultLargebutton"
        Text="Submit Actual Quantity" onclick="btnSubmit_Click" />
    </div>
    <span style="clear: both"></span>

    </div>
</asp:Content>
