<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewWorkstream.ascx.cs" Inherits="CRSe_WEB.Controls.ViewWorkstream" %>
<asp:Panel ID="pnlWorkstream" runat="server" GroupingText="<span style='color:#FFFFFF'>Work Stream Info</span>">
    <asp:Label ID="lblWorkstreamNameLabel" runat="server" Font-Bold="true" Text="Work Stream Name:" AssociatedControlID="lblWorkstreamName" />&nbsp;&nbsp;
    <asp:Label ID="lblWorkstreamName" runat="server" />
    <br />
    <asp:Label ID="lblStatusLabel" runat="server" Font-Bold="true" Text="Status:" AssociatedControlID="lblStatus" />&nbsp;&nbsp;
    <asp:Label ID="lblStatus" runat="server" />
    <br />
    <asp:Label ID="lblCaseNumberLabel" runat="server" Font-Bold="true" Text="Case Number:" AssociatedControlID="lblCaseNumber" />&nbsp;&nbsp;
    <asp:Label ID="lblCaseNumber" runat="server" />
    <br />
    <asp:Label ID="lblCaseStartDateLabel" runat="server" Font-Bold="true" Text="Case Start Date:" AssociatedControlID="lblCaseStartDate" />&nbsp;&nbsp;
    <asp:Label ID="lblCaseStartDate" runat="server" />
    <br />
    <asp:Label ID="lblCaseDueDateLabel" runat="server" Font-Bold="true" Text="Case Due Date:" AssociatedControlID="lblCaseDueDate" />&nbsp;&nbsp;
    <asp:Label ID="lblCaseDueDate" runat="server" />
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
    <br /><br />
    <asp:Hyperlink ID="linkViewDetails" runat="server" Text="View Details" NavigateUrl="~/Common/Workstream.aspx" />
</asp:Panel>