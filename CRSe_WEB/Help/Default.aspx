<%@ Page Title="Online Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRSe_WEB.Help.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Online Help" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <table style="width:600px">
                <tr>
                    <th align="left"><b>Converged Registries Solution Enhancements </b></th>
                </tr>
                <tr>
                    <td align="left">
                        <p>The Converged Registries Solution (CRS) is a centralized relational database framework and architectural platform for the registries in the Health Registries program. This relational database assists in effectively managing national registry data to support the goals of the Veterans Health Administration (VHA) to be a Veteran-centered, integrated organization that provides excellence in health care, research, and education. Comprised of standardized common patient data and registry-specific data elements, CRS is the cohesive backend database architecture for each national health registry. </p>
                    </td>
                </tr>
    </table>


    <asp:Label ID="lblSearch" runat="server" Text="Search Text" AssociatedControlID="txtSearch" />&nbsp;&nbsp;
    <asp:TextBox ID="txtSearch" runat="server" />&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Search" ToolTip="Select to search online help" OnClick="BtnSearch_Click" />

    <br /><br />

    <asp:Label ID="lblSearchResults" runat="server" />
</asp:Content>
