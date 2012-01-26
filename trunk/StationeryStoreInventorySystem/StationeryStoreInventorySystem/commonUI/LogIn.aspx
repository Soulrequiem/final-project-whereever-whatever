<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/FirstMasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.LogIn" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FirstContent" runat="server">
    <div class="ContentDivStyle">
<asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <br />
        <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal19" runat="server" 
        Text="<%$ Resources:WebResources, LogIn_Header %>" /></h1>
        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" BorderColor="#E5E5E5"
                CssClass="GroupBoxstyle" StyleSetName="" width="350px"
                TitleAlignment="Left">
                <Template>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label19" runat="server" 
                                    Text="<%$ Resources:WebResources, LogIn_UserNameLabel %>"/> 
                            </td>
                            <td>
                                <ig:WebTextEditor ID="txtUsername" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px">
                                </ig:WebTextEditor><br />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label CssClass="DefaultLabelstyle" 
                                    ID="Label1" runat="server" 
                                    Text="<%$ Resources:WebResources, LogIn_PasswordLabel %>"/> </td>
                            <td>
                                 <ig:WebTextEditor ID="txtPassword" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px" TextMode="Password">
                                </ig:WebTextEditor><br />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <a href="#" style="float:left; font-size: small;">Forgot your password?</a>
                                <div style="float:right">
                                    <asp:Button ID="btnSignIn" CssClass="Defaultbutton"
                                        runat="server" 
                                        Text="<%$ Resources:WebResources,LogIn_SignIn_Button_Text %>" onclick="btnSignIn_Click" 
                                        />
                                </div>
                            </td>
                        </tr>
                    </table>
                </Template>
        </igmisc:WebGroupBox>
</div>
</asp:Content>
