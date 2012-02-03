<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/FirstMasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.LogIn" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function check() {
            if (document.getElementById('FirstContent_WebGroupBox1_txtUsername').value == "" || document.getElementById('FirstContent_WebGroupBox1_txtPassword').value == "") {
                document.getElementById('FirstContent_WebGroupBox1_lblStatusMessage').innerHTML = "Enter required feilds.";
                return false;
            }
            return true;
        }
    function forgot() {
        if (document.getElementById('FirstContent_WebGroupBox1_txtUsername').value == "") {
            document.getElementById('FirstContent_WebGroupBox1_lblStatusMessage').innerHTML = "Enter user name.";
            return false;
        }
        return true;
    }
</script>
<%--<script type="text/javascript">
    function check() {
        alert('blabla');
        return false;
    }
                    </script>--%>
    <style type="text/css">
        .style1
        {
            width: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FirstContent" runat="server">
    <div class="ContentDivStyle">
<asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <br />
        <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal19" runat="server" 
        Text="<%$ Resources:WebResources, LogIn_Header %>" /></h1>
        <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" BorderColor="#E5E5E5"
                CssClass="GroupBoxstyle" 
                TitleAlignment="Left">
                <Template>
                    
                    <br />
                    <table>
                        <tr>
                            <td class="style1">
                                <asp:Label CssClass="DefaultLabelstyle" Width="100px"
                                    ID="Label19" runat="server" 
                                    Text="<%$ Resources:WebResources, LogIn_UserNameLabel %>"/> 
                            </td>
                            <td>
                                <ig:WebTextEditor ID="txtUsername" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px" FocusOnInitialization="True">
                                </ig:WebTextEditor><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1"><asp:Label CssClass="DefaultLabelstyle" Width="100px"
                                    ID="Label1" runat="server" 
                                    Text="<%$ Resources:WebResources, LogIn_PasswordLabel %>"/> </td>
                            <td>
                                 <ig:WebTextEditor ID="txtPassword" runat="server" 
                                    CssClass="DefaultTextStyle" Width="250px" TextMode="Password">
                                </ig:WebTextEditor><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                <asp:Label CssClass="ErrorLabelstyle" 
                                ID="lblStatusMessage" runat="server"/>
                                <br />
                                <a href="ForgotPassword.aspx?"+  style="float:left; font-size: small;" onclick="forgot();">Forgot your password?</a>
                                <div style="float:right">
                                    <asp:Button ID="btnSignIn" CssClass="Defaultbutton"
                                        runat="server" OnClientClick="return check();" 
                                        Text="<%$ Resources:WebResources,LogIn_SignIn_Button_Text %>"
                                         OnClick="btnSignIn_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </Template>
        </igmisc:WebGroupBox>
</div>
</asp:Content>
