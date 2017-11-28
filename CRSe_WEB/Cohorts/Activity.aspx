<%@ Page Title="Activities" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="CRSe_WEB.Cohorts.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Activities" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlActivities" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Workstream" Value="STD_WKFCASETYPE.Name"></asp:ListItem>
            <asp:ListItem Text="Name" Value="NAME"></asp:ListItem>
            <asp:ListItem Text="Code" Value="CODE"></asp:ListItem>
            <asp:ListItem Text="Sort Order" Value="SORT_ORDER"></asp:ListItem>
            <asp:ListItem Text="Description" Value="DESCRIPTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
         <br /><br />
        <asp:GridView ID="gridActivities" runat="server"  CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            EmptyDataText="Currently no existing fields are available" DataSourceID="dsActivities" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit Activity information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete Activity" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFCASETYPE.Name" AccessibleHeaderText="Workstream" HeaderText="Workstream" DataField="STD_WKFCASETYPE.Name" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="NAME" AccessibleHeaderText="Name" HeaderText="Name" DataField="NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CODE" AccessibleHeaderText="Code" HeaderText="Code" DataField="CODE" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="SORT_ORDER" AccessibleHeaderText="Sort Order" HeaderText="Sort Order" DataField="SORT_ORDER" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="DESCRIPTION_TEXT" AccessibleHeaderText="Description" HeaderText="Description" DataField="DESCRIPTION_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsActivities" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkActivityAdd" runat="server" Text="Add New Activity" OnClick="LinkActivityAdd_Click" ToolTip="Select to add a new Activity" />
        
        <br /><br />

        <asp:Table ID="tblSaveForm1" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="30%">
                    <asp:Button ID="btnBack1" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="40%" HorizontalAlign="Center">&nbsp;</asp:TableCell>
                <asp:TableCell Width="30%">&nbsp;</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel ID="pnlActivity" runat="server">
        <asp:HiddenField ID="hideActivityId" runat="server" />
        <asp:Table ID="tblActivityInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstream" runat="server" Text="Workstream" AssociatedControlID="listWorkstream" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="listWorkstream" runat="server" Width="400" ToolTip="Select an associated Workstream" DataValueField="ID" DataTextField="NAME" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblActivityName" runat="server" Text="Name *" AssociatedControlID="txtActivityName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtActivityName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Activity Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblActivityCode" runat="server" Text="Code *" AssociatedControlID="txtActivityCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtActivityCode" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Activity Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblActivitySortOrder" runat="server" Text="Sort Order *" AssociatedControlID="txtActivitySortOrder" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtActivitySortOrder" runat="server" Width="400" ToolTip="Enter a value for Activity Sort Order" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblActivityDescription" runat="server" Text="Description *" ToolTip="txtActivityDescription" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtActivityDescription" runat="server" MaxLength="500" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Activity Description" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:CheckBox ID="chkAutoCreated" runat="server" Text="Automatically Created (when workstream is created)" ToolTip="Automatically Created (when workstream is created)" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm2" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="30%">
                    <asp:Button ID="btnBack2" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="40%" HorizontalAlign="Center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Activity values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Activity list" />
                </asp:TableCell>
                <asp:TableCell Width="30%">
                    &nbsp;
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
