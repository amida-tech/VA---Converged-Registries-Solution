<%@ Page Title="Registries and Cohorts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registry.aspx.cs" Inherits="CRSe_WEB.Cohorts.Registry" %>

<%@ Register Src="~/Controls/AdminUser.ascx" TagPrefix="uc" TagName="AdminUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Registries and Cohorts" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlRegistries" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Name" Value="NAME"></asp:ListItem>
            <asp:ListItem Text="Abbreviation" Value="CODE"></asp:ListItem>
            <asp:ListItem Text="Description Text" Value="DESCRIPTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            EmptyDataText="Currently no existing Registries are available" DataSourceID="dsRegistry" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField  SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit Registry information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete Registry" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="NAME" AccessibleHeaderText="Name" HeaderText="Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkName" runat="server" Text='<%# Eval("NAME") %>' CommandArgument='<%# Eval("ID") %>' OnClick="LinkName_Click" ToolTip="Select to edit extended information for this Registry" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CODE" AccessibleHeaderText="Abbreviation" HeaderText="Abbreviation" DataField="CODE" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="DESCRIPTION_TEXT" AccessibleHeaderText="Description" HeaderText="Description" DataField="DESCRIPTION_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_REGISTRY_GET_ALL_BY_USER" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

        <br />
        <asp:LinkButton ID="linkRegistryAdd" runat="server" Text="Add New Registry" OnClick="LinkRegistryAdd_Click" ToolTip="Select to add a new Registry" />
        <br /><br />
    </asp:Panel>

    <asp:Panel ID="pnlRegistry" runat="server">
        <asp:Label ID="lblRegistryResult" runat="server" ForeColor="Red" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajax:TabContainer ID="TabControl" runat="server">
                    <ajax:TabPanel ID="tabInfo" runat="server" HeaderText="Registry Info">
                        <ContentTemplate>
                            <asp:HiddenField ID="hideRegistryId" runat="server" />
                            <asp:Table ID="tblRegistryInfo" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRegistryName" runat="server" Text="Registry Name *" AssociatedControlID="txtRegistryName" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtRegistryName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Registry Name" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRegistryCode" runat="server" Text="Abbreviation *" AssociatedControlID="txtRegistryCode" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtRegistryCode" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Registry Abbreviation" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRegistryDescription" runat="server" Text="Description *" AssociatedControlID="txtRegistryDescription" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtRegistryDescription" runat="server" MaxLength="500" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Registry Description" /></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="tabIcd" runat="server" HeaderText="Contact Info">
                        <ContentTemplate>
                            <asp:Table ID="tblContactInfo" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRegistryOwner" runat="server" Text="Registry Owner" AssociatedControlID="listRegistryOwner" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                            <asp:DropDownList ID="listRegistryOwner" runat="server" ToolTip="Select a value for Registry Owner" DataValueField="USER_ID" DataTextField="FULL_NAME" />&nbsp;&nbsp;
                                            <asp:Button ID="btnAddUser1" runat="server" Text="New User" OnClick="BtnAddUser_Click" ToolTip="Select to create a new user" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRegistryAdministrator" runat="server" Text="Registry Administrator" AssociatedControlID="listRegistryAdministrator" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                            <asp:DropDownList ID="listRegistryAdministrator" runat="server" ToolTip="Select a value for Registry Administrator" DataValueField="USER_ID" DataTextField="FULL_NAME" />&nbsp;&nbsp;
                                            <asp:Button ID="btnAddUser2" runat="server" Text="New User" OnClick="BtnAddUser_Click" ToolTip="Select to create a new user" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblSupportContact" runat="server" Text="Support Contact" AssociatedControlID="listSupportContact" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                            <asp:DropDownList ID="listSupportContact" runat="server" ToolTip="Select a value for Registry Support Contact" DataValueField="USER_ID" DataTextField="FULL_NAME" />&nbsp;&nbsp;
                                            <asp:Button ID="btnAddUser3" runat="server" Text="New User" OnClick="BtnAddUser_Click" ToolTip="Select to create a new user" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ContentTemplate>
                    </ajax:TabPanel>
                </ajax:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="25%">
                    <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
                <asp:TableCell Width="50%" HorizontalAlign="Center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Registry values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Registry list" />
                </asp:TableCell>
                <asp:TableCell Width="25%" HorizontalAlign="Right">
                    <asp:Button ID="btnNext" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel ID="pnlAddUser" runat="server" CssClass="modalPopup" style="display:none;">
        <div class="modalPopupTitle">&nbsp;&nbsp;<asp:Label ID="lblAddUser" runat="server" Text="Add New User" /></div>
        <br />
        <asp:Label ID="lblAddUserResult" runat="server" ForeColor="Red" />
        <uc:AdminUser ID="AdminUser" runat="server" 
            OnSearchClicked="AdminUser_SearchClicked" OnSearchCancelClicked="AdminUser_SearchCancelClicked" 
            OnSaveClicked="AdminUser_SaveClicked" OnCancelClicked="AdminUser_CancelClicked" OnSaveRolesClicked="AdminUser_SaveRolesClicked" />
    </asp:Panel>

    <asp:Button ID="btnHideShow" runat="server" style="display:none;" />
    <asp:Button ID="btnHideCancel" runat="server" style="display:none;" />

    <ajax:ModalPopupExtender ID="mpeAddUser" runat="server" 
        BackgroundCssClass="modalBackground" CancelControlID="btnHideCancel" PopupControlID="pnlAddUser" TargetControlID="btnHideShow"  />
</asp:Content>
