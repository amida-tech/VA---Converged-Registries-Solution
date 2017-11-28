<%@ Page Title="User Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="CRSe_WEB.Admin.User" %>

<%@ Register Src="~/Controls/AdminUser.ascx" TagPrefix="uc" TagName="AdminUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="User Administration" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlUsers" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="User Name" Value="USERNAME"></asp:ListItem>
            <asp:ListItem Text="Name" Value="FULL_NAME"></asp:ListItem>
            <asp:ListItem Text="Email Address" Value="EMAIL_ADDRESS"></asp:ListItem>
            <asp:ListItem Text="Telephone Number" Value="TELEPHONE_NUMBER"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
         <br /><br />
        <asp:GridView ID="gridUsers" runat="server" EmptyDataText="Currently no existing users are available" CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            DataSourceID="dsUsers" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("USER_ID") %>' ToolTip="Select to edit User information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("USER_ID") %>' ToolTip="Select to delete User" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="USERNAME" AccessibleHeaderText="Username" HeaderText="Username" DataField="USERNAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="FULL_NAME" AccessibleHeaderText="Name" HeaderText="Name" DataField="FULL_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="EMAIL_ADDRESS" AccessibleHeaderText="Email" HeaderText="Email" DataField="EMAIL_ADDRESS" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="TELEPHONE_NUMBER" AccessibleHeaderText="Phone" HeaderText="Phone" DataField="TELEPHONE_NUMBER" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsUsers" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="USERS_GET_ALL_BY_USER" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

        <br />
        <asp:LinkButton ID="linkUserAdd" runat="server" Text="Add New User" OnClick="LinkUserAdd_Click" ToolTip="Select to add a new User" />
        <br /><br />

    </asp:Panel>

    <asp:Panel ID="pnlUser" runat="server">
        <uc:AdminUser ID="AdminUser" runat="server" OnSaveClicked="AdminUser_SaveClicked" OnCancelClicked="AdminUser_CancelClicked" />
    </asp:Panel>
</asp:Content>

