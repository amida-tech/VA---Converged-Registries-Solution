<%@ Page Title="User-Defined Fields" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UDFs.aspx.cs" Inherits="CRSe_WEB.Common.UDFs" %>

<%@ Register Src="~/Controls/ViewReferral.ascx" TagPrefix="uc" TagName="ViewReferral" %>
<%@ Register Src="~/Controls/ViewPatient.ascx" TagPrefix="uc" TagName="ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="User-Defined Fields" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlSelectPatient" runat="server" Visible="false">
        <asp:Label ID="lblSelectPatient" runat="server" Text="Please select a patient or referral to use this functionality." /><br /><br />
        <asp:Button ID="btnSelectPatient" runat="server" Text="Continue" OnClick="BtnSelectPatient_Click" ToolTip="Select to continue and choose a patient or referral" />
    </asp:Panel>

    <asp:Panel ID="pnlForm" runat="server" style="width:500px;">
        <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
            <asp:TableRow>
                <asp:TableCell><uc:ViewReferral ID="viewReferral" runat="server" />&nbsp;</asp:TableCell>
                <asp:TableCell><uc:ViewPatient ID="viewPatient" runat="server" />&nbsp;</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblForm" runat="server" CssClass="tblForm">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to Save User-Defined Field values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
