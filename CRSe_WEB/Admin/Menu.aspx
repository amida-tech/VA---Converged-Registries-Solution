<%@ Page Title="Menu Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CRSe_WEB.Admin.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Label ID="lblPageTitle" runat="server" Text="Menu Administration" Font-Size="X-Large" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

            <asp:Label ID="lblRegistries" runat="server" Text="Available Registries" AssociatedControlID="listRegistries" />&nbsp;&nbsp;
            <asp:DropDownList ID="listRegistries" runat="server" ToolTip="Select to manage Menu Items for a Registry" 
                DataSourceID="dsRegistries" DataValueField="ID" DataTextField="NAME" AutoPostBack="true" OnDataBound="ListRegistries_DataBound" OnSelectedIndexChanged="ListRegistries_SelectedIndexChanged" />
            <asp:ObjectDataSource ID="dsRegistries" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER" OnSelecting="DsRegistries_Selecting" />

            &nbsp;&nbsp;

            <asp:Label ID="lblRoles" runat="server" Text="Available Roles" AssociatedControlID="listRoles" />&nbsp;&nbsp;
            <asp:DropDownList ID="listRoles" runat="server" ToolTip="Select to manage Menu Items for a Role" 
                DataSourceID="dsRoles" DataValueField="ID" DataTextField="NAME" AutoPostBack="true" OnDataBound="ListRoles_DataBound" OnSelectedIndexChanged="ListRoles_SelectedIndexChanged" />
            <asp:ObjectDataSource ID="dsRoles" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_ROLE_GET_ALL_REGISTRY_ROLES" OnSelecting="DsRoles_Selecting" />

            <br /><br />

            <ajax:TabContainer ID="TabControl" runat="server">
                <ajax:TabPanel ID="tabPages" runat="server" HeaderText="Pages">
                    <ContentTemplate>
                        <asp:Label ID="lblPageItems" runat="server" Text="Search By" AssociatedControlID="ddlPageItems" />&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlPageItems" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
                            <asp:ListItem Text="Page Name" Value="NAME"></asp:ListItem>
                            <asp:ListItem Text="Display Text" Value="DISPLAY_TEXT"></asp:ListItem>
                            <asp:ListItem Text="URL" Value="URL"></asp:ListItem>
                            <asp:ListItem Text="Core Page" Value="CORE_PAGE"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtPageItems" Width="120px"></asp:TextBox>
                        <asp:Button runat="server" ID="btnFilter" ToolTip="Click to Search" OnClick="BtnFilter_Click" Text="Search" />
                        <asp:Button runat="server" ID="btnClear" ToolTip="Click to Clear" OnClick="BtnClear_Click" Text="Clear" />
                        <br /><br />
                        <asp:Panel ID="pnlPages" runat="server">
                            <asp:GridView ID="gridPages" runat="server" CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty" 
                                EmptyDataText="Currently no existing pages are available" AllowSorting="true" 
                                DataSourceID="dsPages" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkPageEdit" runat="server" Text="Edit" OnClick="LinkPageEdit_Click" CommandArgument='<%# Eval("PAGE_ID") %>' ToolTip="Select to edit Page" />
                                            &nbsp;
                                            <asp:LinkButton ID="linkPageDelete" runat="server" Text="Delete" OnClick="LinkPageDelete_Click" CommandArgument='<%# Eval("PAGE_ID") %>' ToolTip="Select to delete Page" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField SortExpression="NAME" HeaderStyle-ForeColor="White" AccessibleHeaderText="Page Name" HeaderText="Page Name" DataField="NAME" />
                                    <asp:BoundField SortExpression="DISPLAY_TEXT" HeaderStyle-ForeColor="White" AccessibleHeaderText="Display Text" HeaderText="Display Text" DataField="DISPLAY_TEXT" />
                                    <asp:BoundField SortExpression="URL" HeaderStyle-ForeColor="White" AccessibleHeaderText="URL" HeaderText="URL" DataField="URL" />
                                    <asp:BoundField SortExpression="CORE_PAGE" HeaderStyle-ForeColor="White" AccessibleHeaderText="Core Page" HeaderText="Core Page" DataField="CORE_PAGE" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="dsPages" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_WEB_PAGES_GET_ALL" OnSelecting="DsPages_Selecting" SortParameterName="SORT_EXPRESSION" />
                            <br />  
                            <asp:LinkButton ID="linkPageAdd" runat="server" Text="Add New Page" OnClick="LinkPageAdd_Click" ToolTip="Select to add a new Page" />
                        </asp:Panel>
                        <asp:Panel ID="pnlPage" runat="server">
                            <asp:HiddenField ID="hidePageId" runat="server" />
                            <asp:Table ID="tblPageInfo" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblName" runat="server" Text="Page Name *" AssociatedControlID="txtName" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Page Name" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblDisplayText" runat="server" Text="Display Text *" AssociatedControlID="txtDisplayText" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtDisplayText" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Display Text" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblUrl" runat="server" Text="URL *" AssociatedControlID="txtUrl" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtUrl" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for URL" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblCorePage" runat="server" Text="Core Page" AssociatedControlID="listCorePage" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:DropDownList ID="listCorePage" runat="server" Width="404" ToolTip="Select a value for Core Page"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>

                            <br />

                            <asp:Table ID="tblSavePage" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button ID="btnSavePage" runat="server" Text="Save" OnClick="BtnSavePage_Click" ToolTip="Select to save all Page values" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancelPage" runat="server" Text="Return to List" OnClick="BtnCancelPage_Click" ToolTip="Select to cancel changes and return to Page list" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:Panel>

                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="tabMenu" runat="server" HeaderText="Menu Items">
                    <ContentTemplate>

                        <asp:Panel ID="pnlMenuItems" runat="server">
                            <asp:Label ID="LblMenuItems" runat="server" Text="Search By" AssociatedControlID="ddlMenuItems" />&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlMenuItems" runat="server" ToolTip="Select to filter column view results" 
                             AutoPostBack="false">
                                <asp:ListItem Text="Registry" Value="STD_REGISTRY.NAME"></asp:ListItem>
                                <asp:ListItem Text="Page Name" Value="STD_WEB_PAGES.NAME"></asp:ListItem>
                                <asp:ListItem Text="Menu Item Name" Value="MENU_PAGE.NAME"></asp:ListItem>
                                <asp:ListItem Text="Role Name" Value="STD_ROLE.NAME"></asp:ListItem>
                                <asp:ListItem Text="Sort Order" Value="SORT_ORDER"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtMenuItems" Width="120px"></asp:TextBox>
                            <asp:Button runat="server" ToolTip="Click to Search" ID="btnMenuItems" OnClick="BtnMenuItems_Click" Text="Search" />
                            <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClearMenuItems" OnClick="BtnClearMenuItems_Click" Text="Clear" />
                            <br /><br />
                            <asp:GridView ID="gridMenuItems" runat="server" CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
                                EmptyDataText="Currently no existing menu items are available" AllowSorting="true" 
                                DataSourceID="dsMenuItems" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkMenuEdit" runat="server" Text="Edit" OnClick="LinkMenuEdit_Click" CommandArgument='<%# Eval("MENU_ID") %>' ToolTip="Select to edit Menu Item" />
                                            &nbsp;
                                            <asp:LinkButton ID="linkMenuDelete" runat="server" Text="Delete" OnClick="LinkMenuDelete_Click" CommandArgument='<%# Eval("MENU_ID") %>' ToolTip="Select to delete Menu Item" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Registry" HeaderText="Registry" SortExpression="STD_REGISTRY.NAME" DataField="STD_REGISTRY.NAME" />
                                    <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Page Name" HeaderText="Page Name" SortExpression="STD_WEB_PAGES.NAME" DataField="STD_WEB_PAGES.NAME" />
                                    <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Menu Item Name" HeaderText="Menu Item Name" SortExpression="MENU_PAGE.NAME" DataField="MENU_PAGE.NAME" />
                                    <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Role Name" HeaderText="Role Name" SortExpression="STD_ROLE.NAME" DataField="STD_ROLE.NAME" />
                                    <asp:BoundField HeaderStyle-ForeColor="White" AccessibleHeaderText="Sort Order" HeaderText="Sort Order" SortExpression="SORT_ORDER" DataField="SORT_ORDER" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="dsMenuItems" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_MENU_ITEMS_GET_ALL_BY_REGISTRY" OnSelecting="DsMenuItems_Selecting" SortParameterName="SORT_EXPRESSION" />
                            <br />  
                            <asp:LinkButton ID="linkMenuAdd" runat="server" Text="Add New Menu Item" OnClick="LinkMenuAdd_Click" ToolTip="Select to add a new Menu Item" />
                        </asp:Panel>
                        <asp:Panel ID="pnlMenuItem" runat="server">
                            <asp:HiddenField ID="hideMenuId" runat="server" />
                            <asp:Table ID="tblMenuItemInfo" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblPageName" runat="server" Text="Page Name" AssociatedControlID="listPageName" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="listPageName" runat="server" Width="405" ToolTip="Select a Page Name value" DataSourceID="dsPageName" DataValueField="PAGE_ID" DataTextField="NAME" OnDataBound="ListPageName_DataBound" />
                                        <asp:ObjectDataSource ID="dsPageName" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_WEB_PAGES_GET_ALL" OnSelecting="Ds_Selecting" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblMenuPageName" runat="server" Text="Menu Item Name" AssociatedControlID="listMenuPageName" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="listMenuPageName" runat="server" Width="405" ToolTip="Select a Menu Item Name value" DataSourceID="dsMenuPageName" DataValueField="PAGE_ID" DataTextField="NAME" OnDataBound="ListMenuPageName_DataBound" />
                                        <asp:ObjectDataSource ID="dsMenuPageName" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_WEB_PAGES_GET_ALL" OnSelecting="Ds_Selecting" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblRoleName" runat="server" Text="Role Name" AssociatedControlID="listRoleName" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="listRoleName" runat="server" Width="405" ToolTip="Select a Role Name value" DataSourceID="dsRoleName" DataValueField="ID" DataTextField="NAME" OnDataBound="ListRoleName_DataBound" />
                                        <asp:ObjectDataSource ID="dsRoleName" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_ROLE_GET_ALL_REGISTRY_ROLES" OnSelecting="DsRoleName_Selecting" /></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell><asp:Label ID="lblSortOrder" runat="server" Text="Sort Order *" AssociatedControlID="txtSortOrder" />&nbsp;&nbsp;</asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSortOrder" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Sort Order" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>

                            <br />

                            <asp:Table ID="tblSaveMenu" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button ID="btnSaveMenu" runat="server" Text="Save" OnClick="BtnSaveMenu_Click" ToolTip="Select to save all Menu values" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancelMenu" runat="server" Text="Return to List" OnClick="BtnCancelMenu_Click" ToolTip="Select to cancel changes and return to Menu list" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:Panel>

                    </ContentTemplate>
                </ajax:TabPanel>
            </ajax:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
