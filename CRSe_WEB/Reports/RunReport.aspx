<%@ Page Title="Run Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RunReport.aspx.cs" Inherits="CRSe_WEB.Reports.RunReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ReportViewer ID="reportViewer" runat="server" SizeToReportContent="true" ForeColor="Black" />
</asp:Content>
