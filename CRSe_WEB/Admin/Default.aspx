<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRSe_WEB.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Administration" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" Text="Please select an item from the left-hand menu to continue..." />
</asp:Content>
