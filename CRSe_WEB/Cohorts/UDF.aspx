<%@ Page Title="User-Defined Fields" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UDF.aspx.cs" Inherits="CRSe_WEB.Cohorts.UDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="User-Defined Fields" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlUdfs" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Name" Value="NAME"></asp:ListItem>
            <asp:ListItem Text="Description" Value="DESCRIPTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
         <br /><br />
        <asp:GridView ID="gridUdfs" runat="server" CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty" 
            EmptyDataText="Currently no existing fields are available" DataSourceID="dsUdfs" AutoGenerateColumns="false" OnDataBound="GridUdfs_DataBound" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit User-Defined Field information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete User-Defined Field" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="NAME" AccessibleHeaderText="Name" HeaderText="Name" DataField="NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="DESCRIPTION_TEXT" AccessibleHeaderText="Description" HeaderText="Description" DataField="DESCRIPTION_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsUdfs" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_REG_UDFs_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting"   SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkUdfAdd" runat="server" Text="Add New Field" OnClick="LinkUdfAdd_Click" ToolTip="Select to add a new User-Defined Field" />
        
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

    <asp:Panel ID="pnlUdf" runat="server">
        <asp:HiddenField ID="hideUdfId" runat="server" />
        <asp:Table ID="tblUdfInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblUdfName" runat="server" Text="Name *" AssociatedControlID="txtUdfName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtUdfName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for User-Defined Field Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblUdfCode" runat="server" Text="Code *" AssociatedControlID="txtUdfCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtUdfCode" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for User-Defined Field Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblUdfDescription" runat="server" Text="Description *" ToolTip="txtUdfDescription" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtUdfDescription" runat="server" MaxLength="500" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for User-Defined Field Description" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm2" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="30%">
                    <asp:Button ID="btnBack2" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="40%" HorizontalAlign="Center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all User-Defined Field values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to User-Defined Field list" />
                </asp:TableCell>
                <asp:TableCell Width="33%" HorizontalAlign="Right">
                    <asp:Button ID="btnNext2" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
