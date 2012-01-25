<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignDeptRepresentative.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head.AssignDeptRespresentative" %>

<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">

    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, AssignDeptRespresentative_Title %>" /></h1>
            <br />
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
                CssClass="GroupBoxstyle" StyleSetName="" Text="Current Department Representative" 
                TitleAlignment="Left">
                    <Template>
                            <ig:WebDataGrid ID="DgvCurrentDeptRepresentative" runat="server" Height="300px" 
                                Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                                CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                <Columns>
                                    <ig:BoundCheckBoxField DataFieldName="BoundCheckBoxField_0" 
                                        Key="BoundCheckBoxField_0" Width="50px">
                                        <Header Text="BoundCheckBoxField_0" />
                                    </ig:BoundCheckBoxField>
                                    <ig:BoundDataField DataFieldName="RepresentativeID" Key="BoundColumn_0" 
                                        Width="50px">
                                        <Header Text="Representative ID" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="RepresentativeName" Key="BoundColumn_1" 
                                        Width="50px">
                                        <Header Text="Representative Name" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Actual/Temporary" Key="BoundColumn_2" 
                                        Width="50px">
                                        <Header Text="Actual/Temporary" />
                                    </ig:BoundDataField>
                                </Columns>
                                <Behaviors>
                                    <ig:Sorting>
                                    </ig:Sorting>
                                    <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                    </ig:Selection>
                                    <ig:Paging PageSize="10">
                                    </ig:Paging>
                                    <ig:Filtering>
                                    </ig:Filtering>
                                    <ig:ColumnFixing>
                                    </ig:ColumnFixing>
                                </Behaviors>
                            </ig:WebDataGrid>
                            <div style="float:right">
                                    <a class="button" href="" style="float:right">Remove</a>
                            </div>
                    </Template>                
            </igmisc:WebGroupBox>
                <br /><br />  
                <div style="float:left">
                     <asp:Label CssClass="DefaultLabelstyle" 
                     ID="Label15" runat="server" 
                     Text="Employee Name:"/>           
                </div>
                <div style="float:left">
                    <%--<ig:WebDropDown ID="drdEmployeeName" runat="server" Width="150px">
                    </ig:WebDropDown>--%>
                     <%--<ig:WebTextEditor ID="txtEmployeeName" runat="server" 
                     CssClass="DefaultTextStyle" Width="150px">
                     </ig:WebTextEditor>--%>
                     <ig:WebDropDown ID="drdEmployeeList" runat="server" Width="250px" 
                            DropDownAnimationType="EaseIn" NullText="Enter Employee Name" 
                            StyleSetName="Office2010Blue">
                        <Button Visible="False" />
                     </ig:WebDropDown>
                     <br /><br />           
                </div>
                
                <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" 
                CssClass="GroupBoxstyle" StyleSetName="" Text="Search Result" 
                TitleAlignment="Left">
                    <Template>
                        <ig:WebDataGrid ID="DgvRepSearchDetails" runat="server" Height="300px" 
                            Width="700px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                            CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                            ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                            <Columns>
                                <ig:BoundCheckBoxField DataFieldName="BoundCheckBoxField_0" 
                                    Key="BoundCheckBoxField_0" Width="50px">
                                    <Header Text="BoundCheckBoxField_0" />
                                </ig:BoundCheckBoxField>
                                <ig:BoundDataField DataFieldName="EmployeeID" Key="BoundColumn_0" Width="50px">
                                    <Header Text="Employee ID" />
                                </ig:BoundDataField>
                                <ig:BoundDataField DataFieldName="EmployeeName" Key="BoundColumn_1" 
                                    Width="50px">
                                    <Header Text="Employee Name" />
                                </ig:BoundDataField>
                            </Columns>
                            <Behaviors>
                                <ig:Sorting>
                                </ig:Sorting>
                                <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                </ig:Selection>
                                <ig:Paging PageSize="10">
                                </ig:Paging>
                                <ig:Filtering>
                                </ig:Filtering>
                                <ig:ColumnFixing>
                                </ig:ColumnFixing>
                            </Behaviors>
                        </ig:WebDataGrid>
                        <div style="float:right">
                                <a class="button" href="" style="float:right">Assign</a>
                        </div>
                    </Template>
                </igmisc:WebGroupBox>
    </div>
</asp:Content>
