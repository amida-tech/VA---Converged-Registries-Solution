<%@ Page Title="Survey" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="CRSe_WEB.Common.Survey" %>

<%@ Register Src="~/Controls/ViewPatient.ascx" TagPrefix="uc" TagName="ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Survey" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlForm" runat="server" style="width:500px;">
        <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
            <asp:TableRow>
                <asp:TableCell><uc:ViewPatient ID="viewPatient" runat="server" />&nbsp;</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit Survey" ToolTip="Select to edit this Survey" OnClick="LinkEdit_Click" />
        <br /><br />

        <asp:HiddenField ID="hideSurveyId" runat="server" />

        <asp:Table ID="tblForm" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save Survey values for later updates" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSaveComplete" runat="server" Text="Save and Complete" OnClick="BtnSaveComplete_Click" ToolTip="Select to save and complete Survey" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to return to previous list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
