<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewActivity.ascx.cs" Inherits="CRSe_WEB.Controls.ViewActivity" %>
<asp:Panel ID="pnlActivity" runat="server" GroupingText="<span style='color:#FFFFFF'>Activity Info</span>">
    <asp:Label ID="lblActivityNameLabel" runat="server" Font-Bold="true" Text="Activity Name:" AssociatedControlID="lblActivityName" />&nbsp;&nbsp;
    <asp:Label ID="lblActivityName" runat="server" />
    <br />
    <asp:Label ID="lblStatusLabel" runat="server" Font-Bold="true" Text="Status:" AssociatedControlID="lblStatus" />&nbsp;&nbsp;
    <asp:Label ID="lblStatus" runat="server" />
    <br />
    <asp:Label ID="lblContactNameLabel" runat="server" Font-Bold="true" Text="Contact Name:" AssociatedControlID="lblContactName" />&nbsp;&nbsp;
    <asp:Label ID="lblContactName" runat="server" />
    <br />
    <asp:Label ID="lblContactEmailLabel" runat="server" Font-Bold="true" Text="Contact Email:" AssociatedControlID="lblContactEmail" />&nbsp;&nbsp;
    <asp:Label ID="lblContactEmail" runat="server" />
    <br />
    <asp:Label ID="lblContactPhoneLabel" runat="server" Font-Bold="true" Text="Contact Phone:" AssociatedControlID="lblContactPhone" />&nbsp;&nbsp;
    <asp:Label ID="lblContactPhone" runat="server" />
    <br />
    <asp:Label ID="lblBestCallBackTimeLabel" runat="server" Font-Bold="true" Text="Best Call Back Time:" AssociatedControlID="lblBestCallBackTime" />&nbsp;&nbsp;
    <asp:Label ID="lblBestCallBackTime" runat="server" />
    <br />
    <asp:Label ID="lblInfoConveyedTextLabel" runat="server" Font-Bold="true" Text="Info Conveyed:" AssociatedControlID="lblInfoConveyedText" />&nbsp;&nbsp;
    <asp:Label ID="lblInfoConveyedText" runat="server" />
    <br />
    <asp:Label ID="lblInforReceivedTextLabel" runat="server" Font-Bold="true" Text="Info Received:" AssociatedControlID="lblInforReceivedText" />&nbsp;&nbsp;
    <asp:Label ID="lblInforReceivedText" runat="server" />
    <br />
    <asp:Label ID="lblAddressLine1Label" runat="server" Font-Bold="true" Text="Address Line 1:" AssociatedControlID="lblAddressLine1" />&nbsp;&nbsp;
    <asp:Label ID="lblAddressLine1" runat="server" />
    <br />
    <asp:Label ID="lblAddressLine2Label" runat="server" Font-Bold="true" Text="Address Line 2:" AssociatedControlID="lblAddressLine2" />&nbsp;&nbsp;
    <asp:Label ID="lblAddressLine2" runat="server" />
    <br />
    <asp:Label ID="lblAddressLine3Label" runat="server" Font-Bold="true" Text="Address Line 3:" AssociatedControlID="lblAddressLine3" />&nbsp;&nbsp;
    <asp:Label ID="lblAddressLine3" runat="server" />
    <br />
    <asp:Label ID="lblCityLabel" runat="server" Font-Bold="true" Text="City:" AssociatedControlID="lblCity" />&nbsp;&nbsp;
    <asp:Label ID="lblCity" runat="server" />
    <br />
    <asp:Label ID="lblStateLabel" runat="server" Font-Bold="true" Text="State:" AssociatedControlID="lblState" />&nbsp;&nbsp;
    <asp:Label ID="lblState" runat="server" />
    <br />
    <asp:Label ID="lblPostalCodeLabel" runat="server" Font-Bold="true" Text="Postal Code:" AssociatedControlID="lblPostalCode" />&nbsp;&nbsp;
    <asp:Label ID="lblPostalCode" runat="server" />
    <br />
    <asp:Label ID="lblCountryLabel" runat="server" Font-Bold="true" Text="Country:" AssociatedControlID="lblCountry" />&nbsp;&nbsp;
    <asp:Label ID="lblCountry" runat="server" />
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
    <asp:Hyperlink ID="linkViewDetails" runat="server" Text="View Details" NavigateUrl="~/Common/Activity.aspx" />
</asp:Panel>