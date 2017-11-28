<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewReferral.ascx.cs" Inherits="CRSe_WEB.Controls.ViewReferral" %>
<asp:Panel ID="pnlReferral" runat="server" GroupingText="<span style='color:#FFFFFF'>Referral Info</span>">
    <asp:Label ID="lblStatusLabel" runat="server" Font-Bold="true" Text="Status:" AssociatedControlID="lblStatus" />&nbsp;&nbsp;
    <asp:Label ID="lblStatus" runat="server" />
    <br />
    <asp:Label ID="lblReferralDateLabel" runat="server" Font-Bold="true" Text="Referral Date:" AssociatedControlID="lblReferralDate" />&nbsp;&nbsp;
    <asp:Label ID="lblReferralDate" runat="server" />
    <br />
    <asp:Label ID="lblCreatedByLabel" runat="server" Font-Bold="true" Text="Created By:" AssociatedControlID="lblCreatedBy" />&nbsp;&nbsp;
    <asp:Label ID="lblCreatedBy" runat="server" />
    <br />
    <asp:Label ID="lblCreatedLabel" runat="server" Font-Bold="true" Text="Created:" AssociatedControlID="lblCreated" />&nbsp;&nbsp;
    <asp:Label ID="lblCreated" runat="server" />
    <br />
    <asp:Label ID="lblUpdatedByLabel" runat="server" Font-Bold="true" Text="Updated By:" AssociatedControlID="lblUpdatedBy" />&nbsp;&nbsp;
    <asp:Label ID="lblUpdatedBy" runat="server" />
    <br />
    <asp:Label ID="lblUpdatedLabel" runat="server" Font-Bold="true" Text="Updated:" AssociatedControlID="lblUpdated" />&nbsp;&nbsp;
    <asp:Label ID="lblUpdated" runat="server" />
    <br />
    <asp:Label ID="lblReviewByLabel" runat="server" Font-Bold="true" Text="Reviewed By:" AssociatedControlID="lblReviewBy" />&nbsp;&nbsp;
    <asp:Label ID="lblReviewBy" runat="server" />
    <br />
    <asp:Label ID="lblReviewDateLabel" runat="server" Font-Bold="true" Text="Reviewed:" AssociatedControlID="lblReviewDate" />&nbsp;&nbsp;
    <asp:Label ID="lblReviewDate" runat="server" />
    <br /><br />
    <asp:Hyperlink ID="linkViewDetails" runat="server" Text="View Details" NavigateUrl="~/Common/Referral.aspx" />&nbsp;&nbsp;
</asp:Panel>