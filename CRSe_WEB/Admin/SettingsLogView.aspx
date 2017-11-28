<%@ Page Title="Settings Log View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SettingsLogView.aspx.cs" Inherits="CRSe_WEB.Admin.SettingsLogView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="updPnl">
        <ContentTemplate>
            <asp:Label ID="lblPageTitle" runat="server" Text="Settings Log View" Font-Size="X-Large" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Red" />
            <asp:TextBox ID="txtOutput" runat="server" ReadOnly="true" TextMode="MultiLine" Width="800px" Rows="30" />
            <br /><br />
            <asp:HyperLink ID="lnkReturn" runat="server" Text="Return To Settings" ToolTip="Select to return to Settings page" NavigateUrl="~/Admin/Settings.aspx" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
