<%@ Page Title="Survey Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="CRSe_WEB.Admin.Survey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Survey Administration" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Label ID="lblRegistries" runat="server" Text="Available Registries" AssociatedControlID="listRegistries" />&nbsp;&nbsp;
    <asp:DropDownList ID="listRegistries" runat="server" ToolTip="Select to manage Surveys for a Registry" 
        DataSourceID="dsRegistries" DataValueField="ID" DataTextField="NAME" AutoPostBack="true" OnDataBound="ListRegistries_DataBound" OnSelectedIndexChanged="ListRegistries_SelectedIndexChanged" />
    <asp:ObjectDataSource ID="dsRegistries" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER" OnSelecting="DsRegistries_Selecting" />

    <br /><br />

    <asp:Panel ID="pnlSurveys" runat="server">

        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Name" Value="NAME"></asp:ListItem>
            <asp:ListItem Text="Code" Value="CODE"></asp:ListItem>
            <asp:ListItem Text="Description" Value="DESCRIPTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
         <br /><br />

        <asp:GridView ID="gridSurveys" runat="server"  CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty" 
            EmptyDataText="Currently no existing surveys are available" DataSourceID="dsSurveys" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit Survey information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete Survey" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ID" AccessibleHeaderText="Name" HeaderText="Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkName" runat="server" Text='<%# Eval("NAME") %>' CommandArgument='<%# Eval("ID") %>' OnClick="LinkName_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CODE" AccessibleHeaderText="Code" HeaderText="Code" DataField="CODE" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="DESCRIPTION_TEXT" AccessibleHeaderText="Description" HeaderText="Description" DataField="DESCRIPTION_TEXT" />
            </Columns>
        </asp:GridView>
        
        <asp:ObjectDataSource ID="dsSurveys" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
  
        <br />
        <asp:LinkButton ID="linkSurveyAdd" runat="server" Text="Add New Survey" OnClick="LinkSurveyAdd_Click" ToolTip="Select to add a new Survey" />
    </asp:Panel>

    <asp:Panel ID="pnlSurvey" runat="server">
        <asp:HiddenField ID="hideSurveyId" runat="server" />
        <asp:Table ID="tblSurveyInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSurveyName" runat="server" Text="Name *" AssociatedControlID="txtSurveyName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSurveyName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Survey Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSurveyCode" runat="server" Text="Code *" AssociatedControlID="txtSurveyCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSurveyCode" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Survey Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSurveyDescription" runat="server" Text="Description *" ToolTip="txtSurveyDescription" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSurveyDescription" runat="server" MaxLength="500" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Survey Description" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Survey values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Survey list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
