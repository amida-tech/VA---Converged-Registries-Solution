<%@ Page Title="Work Streams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workstream.aspx.cs" Inherits="CRSe_WEB.Cohorts.Workstream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Work Streams" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlWorkstreams" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Name" Value="Name"></asp:ListItem>
            <asp:ListItem Text="Code" Value="CODE"></asp:ListItem>
            <asp:ListItem Text="Sort Order" Value="SORT_ORDER"></asp:ListItem>
            <asp:ListItem Text="Description" Value="DESCRIPTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridWorkstreams" runat="server"  CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty" 
            EmptyDataText="Currently no existing Workstreams are available" DataSourceID="dsWorkstreams" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit Workstream information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete Workstream" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Name" AccessibleHeaderText="Name" HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CODE" AccessibleHeaderText="Code" HeaderText="Code" DataField="CODE" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="SORT_ORDER" AccessibleHeaderText="Sort Order" HeaderText="Sort Order" DataField="SORT_ORDER" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="DESCRIPTION_TEXT" AccessibleHeaderText="Description" HeaderText="Description" DataField="DESCRIPTION_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsWorkstreams" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_WKFCASETYPE_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkWorkstreamAdd" runat="server" Text="Add New Workstream" OnClick="LinkWorkstreamAdd_Click" ToolTip="Select to add a new Workstream" />
        
        <br /><br />

        <asp:Table ID="tblSaveForm1" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="30%">
                    <asp:Button ID="btnBack1" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="40%" HorizontalAlign="Center">&nbsp;</asp:TableCell>
                <asp:TableCell Width="33%" HorizontalAlign="Right">
                    <asp:Button ID="btnNext1" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel ID="pnlWorkstream" runat="server">
        <asp:HiddenField ID="hideWorkstreamId" runat="server" />
        <asp:Table ID="tblWorkstreamInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamName" runat="server" Text="Name *" AssociatedControlID="txtWorkstreamName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtWorkstreamName" MaxLength="100" runat="server" Width="400" ToolTip="Enter a value for Workstream Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamCode" runat="server" Text="Code *" AssociatedControlID="txtWorkstreamCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtWorkstreamCode" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Workstream Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamSortOrder" runat="server" Text="Sort Order *" AssociatedControlID="txtWorkstreamSortOrder" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtWorkstreamSortOrder" runat="server" Width="400" ToolTip="Enter a value for Workstream Sort Order" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamDescription" runat="server" Text="Description *" ToolTip="txtWorkstreamDescription" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtWorkstreamDescription" runat="server" MaxLength="500" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Workstream Description" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:CheckBox ID="chkAutoCreated" runat="server" Text="Automatically Created (when referral is created)" ToolTip="Automatically Created (when referral is created)" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm2" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="30%">
                    <asp:Button ID="btnBack2" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="40%" HorizontalAlign="Center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Workstream values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Workstream list" />
                </asp:TableCell>
                <asp:TableCell Width="33%" HorizontalAlign="Right">
                    <asp:Button ID="btnNext2" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
