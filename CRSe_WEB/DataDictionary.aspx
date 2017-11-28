<%@ Page Title="Data Dictionary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataDictionary.aspx.cs" Inherits="CRSe_WEB.DataDictionary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Data Dictionary" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
        <asp:ListItem Text="ObjectName" Value="ObjectName" />
        <asp:ListItem Text="ColumnName" Value="ColumnName" />
        <asp:ListItem Text="DataType" Value="DataType" />
        <asp:ListItem Text="AllowsNull" Value="AllowsNull" />
        <asp:ListItem Text="Description" Value="Description" />
    </asp:DropDownList>
    <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
    <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
    <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
    <br /><br />
    <asp:GridView ID="gridDataDictionary" runat="server" CssClass="gridRegistry" 
        EmptyDataText="Currently no existing fields are available"
        DataSourceID="dsDataDictionary" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="true" PageSize="10">
        <Columns>
            <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="ObjectName" HeaderText="ObjectName" DataField="ObjectName" SortExpression="ObjectName" />
            <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="ColumnName" HeaderText="ColumnName" DataField="ColumnName" SortExpression="ColumnName" />
            <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="DataType" HeaderText="DataType" DataField="DataType" SortExpression="DataType" />
            <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="AllowsNull" HeaderText="AllowsNull" DataField="AllowsNull" SortExpression="AllowsNull" />
            <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Description" HeaderText="Description" DataField="Description" SortExpression="Description" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="dsDataDictionary" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="DATA_DICTIONARY_GET_ALL" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

    <br />
</asp:Content>
