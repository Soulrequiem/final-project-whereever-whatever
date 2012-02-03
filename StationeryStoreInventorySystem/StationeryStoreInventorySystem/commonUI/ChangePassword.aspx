<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.ChangePassword" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" id="igClientScript">
        function Reset() {
            document.getElementById("MainContent_WebGroupBox1_txtOldPassword").value = "";
            document.getElementById("MainContent_WebGroupBox1_txtNewPassword").value = "";
            document.getElementById("MainContent_WebGroupBox1_txtConfirmPassword").value = "";
            return false;
    }

    function Change() {
        if (document.getElementById('MainContent_WebGroupBox1_txtOldPassword').value == "" || document.getElementById('MainContent_WebGroupBox1_txtNewPassword').value == "" || document.getElementById('MainContent_WebGroupBox1_txtConfirmPassword').value == "") {
            document.getElementById("MainContent_WebGroupBox1_lblStatusMessage").innerHTML = "Enter required fields.";
            return false;
        }
        else if (document.getElementById('MainContent_WebGroupBox1_txtNewPassword').value.length <= 7) {
            document.getElementById("MainContent_WebGroupBox1_lblStatusMessage").innerHTML = "Password should be at least 7 charaters";
            return false;
        }
        else if (document.getElementById('MainContent_WebGroupBox1_txtNewPassword').value != document.getElementById('MainContent_WebGroupBox1_txtConfirmPassword').value) {
            document.getElementById("MainContent_WebGroupBox1_lblStatusMessage").innerHTML = "New & Confirm not matched.";
            return false;
        }
        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentDivStyle">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <br />
        <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, ChangePassword_Title %>" /></h1>

            <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" Width="400px"
                CssClass="GroupBoxstyle" StyleSetName="" Text="<%$ Resources:WebResources, ChangePassword_text %>" 
                TitleAlignment="Left">
                <Template>
                    <br />
                    <table>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                                ID="Label2" runat="server" 
                                Text="<%$ Resources:WebResources, ChangePassword_OldPassword %>"/>
                        </td>
                        <td>
                            <ig:WebTextEditor ID="txtOldPassword" runat="server" 
                             CssClass="DefaultTextStyle" Width="250px" TextMode="Password">
                            </ig:WebTextEditor><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label3" runat="server" 
                            Text="<%$ Resources:WebResources, ChangePassword_NewPassword %>"/>
                        </td>
                        <td>
                            <ig:WebTextEditor ID="txtNewPassword" runat="server" 
                            CssClass="DefaultTextStyle" Width="250px" TextMode="Password">
                            </ig:WebTextEditor><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label CssClass="DefaultLabelstyle" 
                            ID="Label1" runat="server" 
                            Text="<%$ Resources:WebResources, ChangePassword_ConfirmPassword %>"/>
                        </td>
                        <td>
                            <ig:WebTextEditor ID="txtConfirmPassword" runat="server" 
                            CssClass="DefaultTextStyle" Width="250px" TextMode="Password">
                        </ig:WebTextEditor>
                        </td>
                    </tr>
                    <tr>
                       <td style="width:100px">
                            <asp:Label CssClass="ErrorLabelstyle" 
                            ID="lblStatusMessage" runat="server" />
                        </td>
                        <td>
                            <div style="float:right">
                                <!--<a class="button" href="" style="float:right">Change</a>-->
                                <asp:Button id="btnReset" CssClass="Defaultbutton"  runat="server" 
                                    Text="Reset" OnClientClick = "return Reset();" onclick="btnReset_Click1"/>
                            </div>
                            <div style="float:right;margin-right:10px" class="buttons">
                                <asp:Button id="btnChange" CssClass="MediumLargeButton"  runat="server" 
                                    Text="Change Password" OnClientClick = "return Chang();" onclick="btnChange_Click1"/>
                                <!--<a class="button" href="" style="float:right">Reset</a>-->
                            </div>
                            
                        </td>
                    </tr>
                  </table>
                </Template>
            </igmisc:WebGroupBox>
</div>
</asp:Content>
