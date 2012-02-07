<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateStationeryRetrieval.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk.UpdateStationeryRetrieval" %>
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
            Text="<%$ Resources:WebResources, UpdateStationeryRetrieval_Header_Title %>" /></h1>
            <igmisc:WebGroupBox ID="GroupBox" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" 
                Text="<%$ Resources:WebResources,UpdateCollectionByRequisions_GroupBoxTitle%>" 
                TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="dgvCollections" runat="server" Height="400px" Width="700px" 
                        AutoGenerateColumns="False" DefaultColumnWidth="50px" DataKeyFields="CollectionID"
                        CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue" 
                        oninitializerow="dgvCollections_InitializeRow">
                        <Columns>
                             <ig:UnboundCheckBoxField Key="UpdateStationeryRetrievalCheckBox" Width="50px">
                             </ig:UnboundCheckBoxField>
                           
                            <ig:BoundDataField DataFieldName="CollectionID" Key="CollectionID" Width="80px" >
                                <Header Text="Collection ID" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="CollectionPoint" Key="collectionPoint" 
                                Width="160px">
                                <Header Text="Collection Point" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="CollectionDate/Time" 
                                Key="collectionDate/Time" Width="150px">
                                <Header Text="Collection Date/Time" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="departmentRepresentativeName" Key="departmentRepresentativeName" 
                                Width="150px">
                                <Header Text="Dept. Rep. Name" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="DepartmentName" 
                                Key="departmentName" Width="120px">
                                <Header Text="Department Name" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="CollectionStatus" Key="collectionStatus" 
                                Width="100px">
                                <Header Text="Collection Status" />
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
                            <ig:EditingCore>
                                <Behaviors>
                                    <ig:CellEditing>
                                        <ColumnSettings>
                                            <ig:EditingColumnSetting ColumnKey="UpdateStationeryRetrievalCheckBox" />
                                            <ig:EditingColumnSetting ColumnKey="collectionId" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="collectionPoint" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="collectionDate/Time" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="departmentRepresentativeName" 
                                                ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="departmentName" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="collectionStatus" ReadOnly="True" />
                                        </ColumnSettings>
                                    </ig:CellEditing>
                                </Behaviors>
                            </ig:EditingCore>
                        </Behaviors>
                    </ig:WebDataGrid>
                    <br>
                    <div style="float:right" class="buttons">
                         <asp:Button id="btnCollected" CssClass="DefaultLargebutton"  runat="server" 
                             Text="Collected" onclick="btnCollected_Click"/>
                         <!--<a class="button" href="" style="float:right">Reset</a>-->
                     <%--</div>
                         <div style="float:right" class="button">--%>
                         <asp:Button ID="btnNotCollected" CssClass="DefaultLargebutton" runat="server" 
                             Text="Not Collected" onclick="btnNotCollected_Click" />
                         <!--<a class="button" href="" style="float:right">Change</a>-->
                      </div>
                </Template>
            </igmisc:WebGroupBox>
            <%--<igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="MediumGroupBoxstyle" StyleSetName="" 
                Text="<%$ Resources:WebResources,UpdateStationeryRetrieval_Header_GroupBoxTitle%>" 
                TitleAlignment="Left">
                <Template>
                    <table>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label8" runat="server"
                                Text="<%$ Resources:WebResources, RequisitionDetails_DeptName%>"/></td>
                            <td style="width:250px"><asp:Label CssClass="DefaultLabelstyle" ID="lblDepartmentName" runat="server"
                                Text="Department of University"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label1" runat="server"
                                Text="<%$ Resources:WebResources, UpdateCollectionByRequisions_CollectionPointLabel%>"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label2" runat="server"
                                Text="University Hospital"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label3" runat="server"
                                Text="<%$ Resources:WebResources, MissTime_Label%>"/></td>
                            <td><asp:Label CssClass="DefaultLabelstyle" ID="Label4" runat="server"
                                Text="3"/></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label CssClass="DefaultLabelstyle" ID="Label5" runat="server"
                                Text="<%$ Resources:WebResources, UpdateCollectionByItems_GroupBoxTitle1%>"/>
                    
                    <br>
                    <div style="float:right">
                        <div style="float:right">
                            <input id="btnAdd" type="button" 
                            value="<%$ Resources:WebResources,UpdateStationeryRetrieval_Header_ButtonText%>" runat="server"/>
                        </div>
                        <div style="float:right">
                            <textarea id="txtRemarks" cols="20" rows="2" style="resize: none;width:250px"
                                    runat="server"></textarea>
                        </div>
                        <div style="float:right">
                            <asp:Label CssClass="DefaultLabelstyle" ID="Label6" runat="server"
                                Text="<%$ Resources:WebResources, UpdateStationeryRetrieval_Header_RemarksTitle%>"/>
                        </div>   
                    </div>
                </Template>
            </igmisc:WebGroupBox>--%>
    </div>
</asp:Content>
