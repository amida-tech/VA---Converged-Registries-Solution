<%@ Page Title="Registry Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistryInfo.aspx.cs" Inherits="CRSe_WEB.RegistryInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblRegistryInfo" runat="server" Text="Registry Information" Font-Size="X-Large" />
    <br /><br />

    <asp:Table ID="tblRegistryInfo" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryName" runat="server" Text="Registry Name:" AssociatedControlID="lblRegistryNameValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryNameValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryCode" runat="server" Text="Abbreviation:" AssociatedControlID="lblRegistryCodeValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryCodeValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryDescription" runat="server" Text="Description:" AssociatedControlID="lblRegistryDescriptionValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryDescriptionValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryStatus" runat="server" Text="Status:" AssociatedControlID="lblRegistryStatusValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryStatusValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br /><br />
    <asp:Label ID="lblContactInfo" runat="server" Text="Contact Information" Font-Size="X-Large" />
    <br /><br />

    <asp:Table ID="tblContactInfo" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryOwner" runat="server" Text="Registry Owner:" AssociatedControlID="lblRegistryOwnerValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryOwnerValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryAdministrator" runat="server" Text="Registry Administrator:" AssociatedControlID="lblRegistryAdministratorValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryAdministratorValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSupportContact" runat="server" Text="Support Contact:" AssociatedControlID="lblSupportContactValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblSupportContactValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>