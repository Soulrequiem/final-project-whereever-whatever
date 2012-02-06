<%@ Page Title="" Language="C#" MasterPageFile="~/commonUI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="SA34_Team9_StationeryStoreInventorySystem.commonUI.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="NotificationPanel" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="ContentDivStyle">
    <h1 class="HeaderStyle"><asp:Literal ID="Literal1" runat="server" 
        Text="<%$ Resources:WebResources, Notification_Title %>" /></h1>
    <asp:Repeater ID="notificationRepeater" runat="server">
        <HeaderTemplate>
            <table width="750px">
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="font-size: 12px; padding-right: 10px; width: 120px;" align="left"><%# Eval("CreatedDate") %></td>
                    <td style="font-weight: bold;" align="left"><%# Eval("Message") %></td>
                </tr>
        </ItemTemplate>
        <SeparatorTemplate>
                <tr>
                    <td colspan="2"><hr /></td>
                </tr>
        </SeparatorTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
    </asp:Panel>
</asp:Content>
