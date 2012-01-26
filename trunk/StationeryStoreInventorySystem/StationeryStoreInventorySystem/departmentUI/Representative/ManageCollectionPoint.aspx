<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCollectionPoint.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.ManageCollectionPoint" %>

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
        Text="<%$ Resources:WebResources, ManageCollectionPoint_Title %>" /></h1>

            <igmisc:WebGroupBox ID="dgvCollections" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" Text="<%$ Resources:WebResources,ManageCollectionPoint_GroupBox%>" 
                TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="WebDataGrid1" runat="server" Height="80px" Width="700px" 
                        AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                        <Columns>
                            <ig:BoundDataField DataFieldName="CollectionID" Key="CollectionID" 
                                Width="150px">
                                <Header Text="CollectionID" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="CollectionPoint" Key="CollectionPoint" 
                                Width="350px">
                                <Header Text="Collection Point" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="CollectionTime" Key="CollectionTime" 
                                Width="200px">
                                <Header Text="Collection Time" />
                            </ig:BoundDataField>
                        </Columns>
                        <Behaviors>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Sorting>
                            </ig:Sorting>
                        </Behaviors>
                    </ig:WebDataGrid>
                    <br>
                        <div style="float:left">
                            <asp:Label CssClass="DefaultLabelstyle" 
                                ID="Label3" runat="server" 
                                Text="<%$ Resources:WebResources, ManageCollectionPoint_SelectNewCollectionPoint %>"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float:left">
                            <%--<ig:WebDropDown ID="drpCollectionList" runat="server" Width="300px">
                            </ig:WebDropDown>--%>
                            <ig:WebDropDown ID="drpCollectionList" runat="server" Width="250px" 
                            DropDownAnimationType="EaseIn" NullText="Enter or Select Collection Point" 
                            StyleSetName="Office2010Blue">
                     </ig:WebDropDown>
                        </div>
                        <div style="float:left">
                        &nbsp;&nbsp;&nbsp;
                            <asp:Button id="btnSave" CssClass="button"  runat="server" Text="Save"/>
                        </div>
                </Template>
            </igmisc:WebGroupBox>
</div>
</asp:Content>
