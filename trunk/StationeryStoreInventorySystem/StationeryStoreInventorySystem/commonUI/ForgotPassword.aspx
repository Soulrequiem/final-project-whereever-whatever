<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.ForgotPassword" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.Web.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics35.WebUI.WebResizingExtender.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>
<%@ Register assembly="Infragistics35.WebUI.Misc.v11.2, Version=11.2.20112.1019, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.Misc" tagprefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type = "text/javascript">
    function EmailCheck() {
        if (document.getElementById('MainContent_WebGroupBox1_txtemailaddress').value == "")
        {
            document.getElementById("MainContent_WebGroupBox1_lblStatusMessage").innerHTML = "Enter your Email Address.";
            return true;
        }
        else 
        {
            var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            if (emailPattern.test(elementValue) == false) {
                document.getElementById("MainContent_WebGroupBox1_lblStatusMessage").innerHTML = "Enter your correct Email Address.";
                return false;
            }
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
       Text="<%$ Resources:WebResources, ForgotPassword_Title %>" /></h1>

           <igmisc:WebGroupBox ID="WebGroupBox1" runat="server" 
               CssClass="GroupBoxstyle" StyleSetName="" Text="<%$ Resources:WebResources, ForgotPassword_grouptext %>" 
               TitleAlignment="Left">
               <Template>
                   <br />
                   <table>
                       <tr>
                           <td>
                               <asp:Label CssClass="DefaultLabelstyle" 
                               ID="Label2" runat="server" 
                               Text="<%$ Resources:WebResources, ForgotPassword_Email %>"/>
                           </td>
                           <td>
                               <ig:WebTextEditor ID="txtemailaddress" runat="server" 
                                CssClass="DefaultTextStyle" Width="250px" NullText="<%$ Resources:WebResources, Text_email %>">
                               </ig:WebTextEditor><br />
                           </td>
                       </tr>
                       <tr>
                           <td  style="width:150px">       
                                <asp:Label CssClass="ErrorLabelstyle" 
                                ID="lblStatusMessage" runat="server" />
                            </td>
                           <td>
                               <div style="float:right" class="button">
                                   <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="Defaultbutton" 
                                    OnClientClick = "return EmailCheck();" onclick="btnSend_Click"/>
                               </div>
                           </td>
                       
                       </tr>
                 </table>
               </Template>
          </igmisc:WebGroupBox>
   </div>
</asp:Content>
