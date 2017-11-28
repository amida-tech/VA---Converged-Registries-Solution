<%@ Page Title="Error Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRSe_WEB.CustomErrors.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text="An unexpected error has occurred.  Please select the button below to continue." />
    <br /><br />
    <asp:Button ID="btnContinue" runat="server" Text="Continue" ToolTip="Select to continue" />
</asp:Content>
