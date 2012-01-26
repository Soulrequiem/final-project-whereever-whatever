<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignTempDeptRepresentative.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative.AssignTempDeptHead" %>
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
        Text="<%$ Resources:WebResources, AssignTempDeptRep_Title %>" /></h1>
            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" 
                Text="<%$ Resources:WebResources,CurrentAuthorizedPerson%>" 
                TitleAlignment="Left">
                <Template>
                    <ig:WebDataGrid ID="DgvCurrentAuthorizedPersonRep" runat="server" Height="80px" 
                        Width="700px" AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                        HeaderCaptionCssClass="HeaderGridViewStyle" 
                        ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                    <Columns>
                        <ig:BoundDataField DataFieldName="EmployeeID" Key="EmployeeID">
                            <Header Text="Employee ID" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="EmployeeName" Key="EmployeeName">
                            <Header Text="Employee Name" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Designation" Key="Designation">
                            <Header Text="Designation" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="JoiningDate" Key="JoiningDate">
                            <Header Text="Joining Date" />
                        </ig:BoundDataField>
                    </Columns>
                        <Behaviors>
                            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                            </ig:Selection>
                        </Behaviors>
                 </ig:WebDataGrid>
                         <div style="float:right">
                                <a class="button" href="" style="float:right">Remove</a>
                        </div>
                </Template>
            </igmisc:WebGroupBox>
                <br />
                <div style="float:left">
                     <asp:Label CssClass="DefaultLabelstyle" 
                     ID="Label15" runat="server" 
                     Text="Employee Name:"/>      &nbsp;&nbsp;&nbsp;     
                </div>
                <div style="float:left">
                     <%--<ig:WebTextEditor ID="txtEmployeeName" runat="server" 
                     CssClass="DefaultTextStyle" Width="250px">
                     </ig:WebTextEditor>--%>
                     <ig:WebDropDown ID="drdEmployeeList" runat="server" Width="250px" 
                            DropDownAnimationType="EaseIn" NullText="Enter Employee Name" 
                            StyleSetName="Office2010Blue">
                        <Button Visible="False" />
                     </ig:WebDropDown>
                     <br />
                </div><br />
                <igmisc:WebGroupBox ID="WebGroupBox2" runat="server" Width="700px"
                CssClass="MediumGroupBoxstyle" StyleSetName="" Text="Search Result" 
                TitleAlignment="Left">
                    <Template>
                            <ig:WebDataGrid ID="DgvTempDepteHeadSearchDetails" runat="server" Height="150px" 
                                Width="700px" AutoGenerateColumns="False" CssClass="DefaultGridViewStyle" 
                                HeaderCaptionCssClass="HeaderGridViewStyle" 
                                ItemCssClass="ItemGridViewStyle" StyleSetName="Office2010Blue">
                               <Columns>
                                    <ig:TemplateDataField Key="TemplateField_0" Width="50px">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="RadioButton1" runat="server" />
                                        </ItemTemplate>
                                        <Header Text="Select" />
                                    </ig:TemplateDataField>
                                    <ig:BoundDataField DataFieldName="EmployeeID" Key="EmployeeID" Width="100px">
                                        <Header Text="Employee ID" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="EmployeeName" Key="EmployeeName">
                                        <Header Text="Employee Name" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="Designation" Key="Designation">
                                        <Header Text="Designation" />
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="JoiningDate" Key="JoiningDate" Width="150px">
                                        <Header Text="Joining Date" />
                                    </ig:BoundDataField>
                                </Columns>
                                <Behaviors>
                                    <ig:Selection CellClickAction="Row" RowSelectType="Single">
                                    </ig:Selection>
                                </Behaviors>
                            </ig:WebDataGrid>
                            <div style="float:right">
                                    <a class="button" href="" style="float:right">Assign</a>
                            </div>
                    </Template>
                </igmisc:WebGroupBox>

                
    </div>
</asp:Content>
