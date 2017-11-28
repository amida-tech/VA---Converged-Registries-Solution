<%@ Page Title="Activity" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="CRSe_WEB.Common.Activity" %>

<%@ Register Src="~/Controls/ViewActivity.ascx" TagPrefix="uc" TagName="ViewActivity" %>
<%@ Register Src="~/Controls/ViewWorkstream.ascx" TagPrefix="uc" TagName="ViewWorkstream" %>
<%@ Register Src="~/Controls/ViewReferral.ascx" TagPrefix="uc" TagName="ViewReferral" %>
<%@ Register Src="~/Controls/ViewPatient.ascx" TagPrefix="uc" TagName="ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Activity" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
        <asp:TableRow>
            <asp:TableCell><uc:ViewActivity ID="viewActivity" runat="server" ShowViewDetails="false" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewWorkstream ID="viewWorkstream" runat="server" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewReferral ID="viewReferral" runat="server" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewPatient ID="viewPatient" runat="server" />&nbsp;</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:LinkButton ID="linkEdit" runat="server" Text="Edit Activity" ToolTip="Select to edit this Activity" OnClick="LinkEdit_Click" />
    <br /><br />

    <asp:Button ID="btnStart" runat="server" Text="Start" ToolTip="Select to Start this Activity" OnClick="BtnStart_Click" />&nbsp;
    <asp:Button ID="btnResume" runat="server" Text="Resume" ToolTip="Select to Resume this Activity" OnClick="BtnResume_Click" />&nbsp;
    <asp:Button ID="btnPause" runat="server" Text="Pause" ToolTip="Select to Pause this Activity" OnClick="BtnPause_Click" />&nbsp;
    <asp:Button ID="btnComplete" runat="server" Text="Complete" ToolTip="Select to Complete this Activity" OnClick="BtnComplete_Click" OnClientClick='return confirm("Are you sure you want to complete this Activity?");' />&nbsp;
    <asp:Button ID="btnTerminate" runat="server" Text="Terminate" ToolTip="Select to Terminate this Activity" OnClick="BtnTerminate_Click" OnClientClick='return confirm("Are you sure you want to terminate this Activity?");' />
    <br /><br />

    <%--<asp:Label ID="lblSubTitle" runat="server" Text="Activities" Font-Size="Large" />--%>
    <br /><br />
</asp:Content>
