<%@ Page Title="Referral" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Referral.aspx.cs" Inherits="CRSe_WEB.Common.Referral" %>

<%@ Register Src="~/Controls/ViewReferral.ascx" TagPrefix="uc" TagName="ViewReferral" %>
<%@ Register Src="~/Controls/ViewPatient.ascx" TagPrefix="uc" TagName="ViewPatient" %>
<%@ Register Src="~/Controls/ViewProvider.ascx" TagPrefix="uc" TagName="ViewProvider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Referral" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
        <asp:TableRow>
            <asp:TableCell><uc:ViewReferral ID="viewReferral" runat="server" ShowViewDetails="false" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewPatient ID="viewPatient" runat="server" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewProvider ID="viewProvider" runat="server" />&nbsp;</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="tblDisqualify" runat="server" CssClass="tblForm">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblDisqualify" runat="server" Text="Enter Disqualify Reason :" Visible="false" ></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtDisqualifyReason" runat="server" TextMode="MultiLine" Rows="3" Visible="false"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Button ID="btnSaveDisqualifyReason" runat="server" Text="Save" OnClick="BtnSaveDisqualifyReason_Click" ToolTip="Select to Disqualify this Referral with entered Reason" Visible="false" /></asp:TableCell>
            <asp:TableCell><asp:Button ID="btnCancelDisqualifyReason" runat="server" Text="Cancel" OnClick="BtnCancelDisqualifyReason_Click" ToolTip="Select to Cancel Disqualify" Visible="false" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>    

    <asp:LinkButton ID="linkEdit" runat="server" Text="Edit Referral" ToolTip="Select to edit this Referral" OnClick="LinkEdit_Click" />
    <br /><br />

    <asp:Button ID="btnActivate" runat="server" Text="Activate" ToolTip="Select to Activate this Referral" OnClick="BtnActivate_Click" />&nbsp;
    <asp:Button ID="btnDisqualify" runat="server" Text="Disqualify" ToolTip="Select to Disqualify this Referral" OnClick="BtnDisqualify_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel " ToolTip="Select to Cancel this Referral due to criteria match no longer exists" OnClick="BtnCancel_Click" />&nbsp;
    <asp:Button ID="btnDuplicate" runat="server" Text="Duplicate" ToolTip="Select to mark this Referral as a Subsequent-Duplicate" OnClick="BtnDuplicate_Click" />&nbsp;
    <asp:Button ID="btnComplete" runat="server" Text="Complete" ToolTip="Select to Complete this Referral" OnClick="BtnComplete_Click" />
    <br /><br />
</asp:Content>
