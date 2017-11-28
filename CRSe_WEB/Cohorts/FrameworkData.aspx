<%@ Page Title="Framework Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrameworkData.aspx.cs" Inherits="CRSe_WEB.Cohorts.FrameworkData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Framework Data" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Table ID="tblCategories" runat="server">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">Available Categories</asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" Width="100"></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">Selected Categories</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ListBox ID="listSource" runat="server" Width="200px" Rows="10" SelectionMode="Multiple" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="100">
                        <asp:Button ID="btnAddAll" runat="server" Text="►►" ToolTip="Add All" Width="50" OnClick="BtnAddAll_Click" /><br /><br />
                        <asp:Button ID="btnAddOne" runat="server" Text="►" ToolTip="Add Selected" Width="50" OnClick="BtnAddOne_Click" /><br /><br />
                        <asp:Button ID="btnRemOne" runat="server" Text="◄" ToolTip="Remove Selected" Width="50" OnClick="BtnRemOne_Click" /><br /><br />
                        <asp:Button ID="btnRemAll" runat="server" Text="◄◄" ToolTip="Remove All" Width="50" OnClick="BtnRemAll_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ListBox ID="listDestination" runat="server" Width="200px" Rows="10" SelectionMode="Multiple" OnSelectedIndexChanged="ListDestination_SelectedIndexChanged" AutoPostBack="true" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <br /><br />

            <asp:Label ID="lblCategories" runat="server" Font-Bold="true" Font-Underline="true" />
            <br />
            <asp:CheckBox ID="chkAll" runat="server" Text="Toggle All" ToolTip="Select to toggle all check boxes" AutoPostBack="true" OnCheckedChanged="ChkAll_CheckedChanged" />
            <br />
            <asp:CheckBoxList ID="listCategories" runat="server" OnSelectedIndexChanged="ListCategories_SelectedIndexChanged" AutoPostBack="true" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <asp:Table ID="tblForm2" runat="server" style="width:100%; display:inline;">
        <asp:TableRow>
            <asp:TableCell Width="30%">
                <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
            </asp:TableCell>
            <asp:TableCell Width="40%" HorizontalAlign="Center">
                <asp:Button ID="btnSave1" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save selected Core Data criteria" />
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" ToolTip="Select to clear or undo changes made to Core Data criteria" />
            </asp:TableCell>
            <asp:TableCell Width="33%" HorizontalAlign="Right">
                <asp:Button ID="btnNext" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
