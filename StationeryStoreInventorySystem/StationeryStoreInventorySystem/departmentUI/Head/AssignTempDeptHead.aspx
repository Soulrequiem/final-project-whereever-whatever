<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignTempDeptHead.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head.AssignTempDeptHead" %>
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
        <h1 class="HeaderStyle"><asp:Literal ID="Literal19" runat="server" 
        Text="<%$ Resources:WebResources, AssignTempDeptHead_Title %>" /></h1>
            <br />
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="530px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Current Authorized Person" 
                TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="DgvCurrentAuthorizedPerson" runat="server" Height="130px" 
                        Width="530px" DefaultColumnWidth="50px" AutoGenerateColumns="False" 
                        CssClass="DefaultGridViewStyle" HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:UnboundCheckBoxField Key="BoundCheckBoxField_0" Width="50px">
                        </ig:UnboundCheckBoxField>
                        <ig:BoundDataField DataFieldName="EmployeeID" Key="EmployeeID" Width="100px">
                            <Header Text="Employee ID" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="EmployeeName" Key="EmployeeName" 
                            Width="160px">
                            <Header Text="Employee Name" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Designation" Key="Designation" Width="100px">
                            <Header Text="Designation" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="JoiningDate" Key="JoiningDate" Width="120px">
                            <Header Text="Joining Date" />
                        </ig:BoundDataField>
                    </Columns>
                        <Behaviors>
                            <ig:Sorting>
                            </ig:Sorting>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                            <ig:Filtering>
                            </ig:Filtering>
                            <ig:EditingCore>
                                <Behaviors>
                                    <ig:CellEditing>
                                        <ColumnSettings>
                                            <ig:EditingColumnSetting ColumnKey="BoundCheckBoxField_0" />
                                            <ig:EditingColumnSetting ColumnKey="EmployeeID" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="EmployeeName" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="Designation" ReadOnly="True" />
                                            <ig:EditingColumnSetting ColumnKey="JoiningDate" ReadOnly="True" />
                                        </ColumnSettings>
                                    </ig:CellEditing>
                                </Behaviors>
                            </ig:EditingCore>
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
                     ID="Label19" runat="server" 
                     Text="Employee Name:"/>           
                </div>
                <div style="float:left">
                     <%--<ig:WebTextEditor ID="txtEmployeeName" runat="server" 
                     CssClass="DefaultTextStyle" Width="150px">
                     </ig:WebTextEditor>--%>
                     <ig:WebDropDown ID="drdEmployeeList" runat="server" Width="250px" 
                            DropDownAnimationType="EaseIn" NullText="<%$ Resources:WebResources, Text_EmployeeName %>" 
                            StyleSetName="Office2010Blue">
                        <Button Visible="False" />
                     </ig:WebDropDown>
                     <br /><br />           
                </div>
                <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="530px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="Search Result" 
                TitleAlignment="Left">
                    <Template>
                            <ig:WebDataGrid ID="DgvTempDepteHeadSearchDetails" runat="server" Height="120px" 
                                Width="530px" AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                                HeaderCaptionCssClass="HeaderGridViewStyle" 
                                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                                <Columns>
                                    <%--ig:BoundCheckBoxField DataFieldName="BoundCheckBoxField_0" 
                                     Key="BoundCheckBoxField_0" Width="50px">
                                    </ig:BoundCheckBoxField>--%>
                                    <ig:TemplateDataField  Key="AssignTempDeptHeadRadio" Width="50px">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="AssignTempDeptHeadRadio" runat="server" />
                                        </ItemTemplate>
                                     <Header Text="" />
                                    </ig:TemplateDataField>
                                    <ig:BoundDataField DataFieldName="EmployeeID" Key="EmployeeID" Width="100px">
                                        <Header Text="Employee ID" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="EmployeeName" Key="EmployeeName" 
                                        Width="160px">
                                        <Header Text="Employee Name" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Designation" Key="Designation" Width="120px">
                                        <Header Text="Designation" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="JoiningDate" Key="JoiningDate" Width="100px">
                                        <Header Text="Joining Date" />
                                    </ig:BoundDataField>
                                </Columns>
                                <Behaviors>
                                    <ig:EditingCore>
                                        <Behaviors>
                                            <ig:CellEditing>
                                                <ColumnSettings>
                                                    <ig:EditingColumnSetting ColumnKey="AssignTempDeptHeadRadio" />
                                                    <ig:EditingColumnSetting ColumnKey="EmployeeID" ReadOnly="True" />
                                                    <ig:EditingColumnSetting ColumnKey="EmployeeName" ReadOnly="True" />
                                                    <ig:EditingColumnSetting ColumnKey="Designation" ReadOnly="True" />
                                                    <ig:EditingColumnSetting ColumnKey="JoiningDate" ReadOnly="True" />
                                                </ColumnSettings>
                                            </ig:CellEditing>
                                        </Behaviors>
                                    </ig:EditingCore>
                                </Behaviors>
                            </ig:WebDataGrid>
                            <br />
                            <div style="float:right">
                                    <a class="button" href="" style="float:right">Assign</a>
                            </div>
                            <div style="float:right">
                            <ig:WebTextEditor ID="txtaRemarks" runat="server" Width="200px" Height="50px" 
                                NullText="<%$ Resources:WebResources, Text_Remarks %>">
                            </ig:WebTextEditor>
                            </div>
                            <div style="float:right;margin-right:10px">
                                   <asp:Label CssClass="DefaultLabelstyle" 
                                        ID="lblRemarks" runat="server" 
                                        Text="Remarks:"/>
                            </div>                 
                    </Template>
                </igmisc:WebGroupBox>

                
    </div>
</asp:Content>
