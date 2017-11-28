<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRSe_WEB.Reports.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Reports" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlReports" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Report Store" Value="ReportStore" />
            <asp:ListItem Text="Report Name" Value="Name" />
            <asp:ListItem Text="Report Description" Value="Description" />
            <asp:ListItem Text="Last Updated" Value="ModifiedDate" />
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" EmptyDataText="Currently no Reports are available"
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowSorting="true" OnSorting="GridRegistry_Sorting" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridRegistry_PageIndexChanging">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField SortExpression="ReportStore" HeaderStyle-ForeColor="White" AccessibleHeaderText="REPORT STORE" HeaderText="REPORT STORE" DataField="ReportStore" />
                <asp:TemplateField SortExpression="Name" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false" AccessibleHeaderText="REPORT NAME" HeaderText="REPORT NAME">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkRunReport" runat="server" ToolTip="Select to Run Report" Text='<%# Eval("Name") %>' NavigateUrl='<%# string.Concat("~/Reports/RunReport.aspx?path=", Eval("Path")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField SortExpression="Description" HeaderStyle-ForeColor="White" AccessibleHeaderText="REPORT DESCRIPTION" HeaderText="REPORT DESCRIPTION" DataField="Description" />
                <asp:BoundField SortExpression="ModifiedDate" HeaderStyle-ForeColor="White" AccessibleHeaderText="LAST UPDATED" HeaderText="LAST UPDATED" DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="false" />
            </Columns>
        </asp:GridView>
        <%--DataSourceID="dsRegistry" --%>
        <%--<asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="REPORTS_GET_ALL_BY_USER_REGISTRY" OnSelecting="Ds_Selecting" />--%>

        <br />
        <asp:HyperLink ID="linkReportAdd" runat="server" Text="Add New Report" ToolTip="Select to add a new Report" />

    </asp:Panel>

        <asp:Panel ID="pnlReport" runat="server">

        <asp:HiddenField ID="hideReportId" runat="server" />
        <asp:Table ID="tblReportInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblReportName" runat="server" Text="Report Name" AssociatedControlID="txtReportName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtReportName" runat="server" MaxLength="30" Width="400" ToolTip="Report Name" ReadOnly="true" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblReportDescription" runat="server" Text="Report Description" AssociatedControlID="txtReportDescription" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtReportDescription" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for Report Description" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Report values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Report list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>
</asp:Content>
