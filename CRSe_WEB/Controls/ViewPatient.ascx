<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewPatient.ascx.cs" Inherits="CRSe_WEB.Controls.ViewPatient" %>
<asp:Panel ID="pnlPatient" runat="server" GroupingText="<span style='color:#FFFFFF'>Patient Info</span>">
    <asp:Label ID="lblIcnLabel" runat="server" Font-Bold="true" Text="ICN:" AssociatedControlID="lblIcn" />&nbsp;&nbsp;
    <asp:Label ID="lblIcn" runat="server" />
    <br />
    <asp:Label ID="lblLastNameLabel" runat="server" Font-Bold="true" Text="Last Name:" AssociatedControlID="lblLastName" />&nbsp;&nbsp;
    <asp:Label ID="lblLastName" runat="server" />
    <br />
    <asp:Label ID="lblFirstNameLabel" runat="server" Font-Bold="true" Text="First Name:" AssociatedControlID="lblFirstName" />&nbsp;&nbsp;
    <asp:Label ID="lblFirstName" runat="server" />
    <br />
    <asp:Label ID="lblDateOfBirthLabel" runat="server" Font-Bold="true" Text="Date of Birth:" AssociatedControlID="lblDateOfBirth" />&nbsp;&nbsp;
    <asp:Label ID="lblDateOfBirth" runat="server" />
    <br />
    <asp:Label ID="lblLastFourLabel" runat="server" Font-Bold="true" Text="Last Four:" AssociatedControlID="lblLastFour" />&nbsp;&nbsp;
    <asp:Label ID="lblLastFour" runat="server" />
    <br />
    <asp:Label ID="lblOefOifLabel" runat="server" Font-Bold="true" Text="OEF/OIF Indicator:" AssociatedControlID="lblOefOif" />&nbsp;&nbsp;
    <asp:Label ID="lblOefOif" runat="server" />
    <br />
    <asp:Label ID="lblServiceSeparationLabel" runat="server" Font-Bold="true" Text="Service Separation Date:" AssociatedControlID="lblServiceSeparation" />&nbsp;&nbsp;
    <asp:Label ID="lblServiceSeparation" runat="server" />
    <br /><br />
    <asp:Hyperlink ID="linkViewDetails" runat="server" Text="View Details" NavigateUrl="~/Common/Patient.aspx" />
</asp:Panel>