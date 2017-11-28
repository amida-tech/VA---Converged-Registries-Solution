<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewProvider.ascx.cs" Inherits="CRSe_WEB.Controls.ViewProvider" %>
<asp:Panel ID="pnlPatient" runat="server" GroupingText="<span style='color:#FFFFFF'>Provider Info</span>">
    <asp:Label ID="lblIenLabel" runat="server" Font-Bold="true" Text="IEN:" AssociatedControlID="lblIen" />&nbsp;&nbsp;
    <asp:Label ID="lblIen" runat="server" />
    <br />
    <asp:Label ID="lblLastNameLabel" runat="server" Font-Bold="true" Text="Last Name:" AssociatedControlID="lblLastName" />&nbsp;&nbsp;
    <asp:Label ID="lblLastName" runat="server" />
    <br />
    <asp:Label ID="lblFirstNameLabel" runat="server" Font-Bold="true" Text="First Name:" AssociatedControlID="lblFirstName" />&nbsp;&nbsp;
    <asp:Label ID="lblFirstName" runat="server" />
    <br />
    <asp:Label ID="lblStationLabel" runat="server" Font-Bold="true" Text="Station:" AssociatedControlID="lblStation" />&nbsp;&nbsp;
    <asp:Label ID="lblStation" runat="server" />
    <br />
    <asp:Label ID="lblCityLabel" runat="server" Font-Bold="true" Text="City:" AssociatedControlID="lblCity" />&nbsp;&nbsp;
    <asp:Label ID="lblCity" runat="server" />
    <br />
    <asp:Label ID="lblStateLabel" runat="server" Font-Bold="true" Text="State:" AssociatedControlID="lblState" />&nbsp;&nbsp;
    <asp:Label ID="lblState" runat="server" />
    <br /><br />
    <asp:Hyperlink ID="linkViewDetails" runat="server" Text="View Details" NavigateUrl="~/Common/Provider.aspx" />
</asp:Panel>