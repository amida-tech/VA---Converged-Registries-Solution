<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUser.ascx.cs" Inherits="CRSe_WEB.Controls.AdminUser" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSearch" />
        <asp:PostBackTrigger ControlID="btnSearchCancel" />
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnCancel" />
    </Triggers>
    <ContentTemplate>

        <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

        <asp:Panel ID="pnlSearch" runat="server">
            <asp:Table ID="tblSearch" runat="server">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="lblSearchLastName" runat="server" Text="Last Name" AssociatedControlID="txtSearchLastName" />&nbsp;&nbsp;</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSearchLastName" runat="server" Width="400" ToolTip="Enter a value to include Last Name in Active Directory search" onkeypress="return CheckAlpha(event);" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="lblSearchFirstName" runat="server" Text="First Name" AssociatedControlID="txtSearchFirstName" />&nbsp;&nbsp;</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSearchFirstName" runat="server" Width="400" ToolTip="Enter a value to include First Name in Active Directory search" onkeypress="return CheckAlpha(event);" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" style="text-align:center;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" ToolTip="Select to Search Active Directory" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearchCancel" runat="server" Text="Close Search" OnClick="BtnSearchCancel_Click" ToolTip="Select to close Search" />
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>

        <asp:Panel ID="pnlResult" runat="server">
            <br /><br />
            <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
                <asp:ListItem Text="Username" Value="Username" />
                <asp:ListItem Text="First Name" Value="FirstName" />
                <asp:ListItem Text="Last Name" Value="LastName" />
                <asp:ListItem Text="Email" Value="Mail" />
                <asp:ListItem Text="Job Title" Value="Title" />
                <asp:ListItem Text="Phone" Value="TelephoneNumber" />
                <asp:ListItem Text="Fax" Value="FacsimileTelephoneNumber" />
            </asp:DropDownList>
            <asp:TextBox runat="server" ToolTip="Enter Search Text"  ID="txtSearch" Width="120px"></asp:TextBox>
            <asp:Button runat="server" ToolTip="Click to Search" ID="btnFilter" OnClick="BtnFilter_Click" Text="Search" />
            <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
            <br /><br />
            <asp:GridView ID="gridActiveDirectory" runat="server" 
                EmptyDataText="Currently no Users are available that match search criteria"
                CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
                AutoGenerateColumns="false" AllowSorting="true" OnSorting="GridActiveDirectory_Sorting" AllowPaging="true" PageSize="10" 
                OnPageIndexChanging="GridActiveDirectory_PageIndexChanging" OnSelectedIndexChanged="GridActiveDirectory_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Link" SelectText="Select" ShowSelectButton="true" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Username" AccessibleHeaderText="Username" HeaderText="Username" DataField="Username" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="FirstName" AccessibleHeaderText="First Name" HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="LastName" AccessibleHeaderText="Last Name" HeaderText="Last Name" DataField="LastName" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Mail" AccessibleHeaderText="Email" HeaderText="Email" DataField="Mail" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Title" AccessibleHeaderText="Job Title" HeaderText="Job Title" DataField="Title" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="TelephoneNumber" AccessibleHeaderText="Phone" HeaderText="Phone" DataField="TelephoneNumber" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="FacsimileTelephoneNumber" AccessibleHeaderText="Fax" HeaderText="Fax" DataField="FacsimileTelephoneNumber" />
                </Columns>
            </asp:GridView>
            <br />
        </asp:Panel>

        <asp:Panel ID="pnlUserInfo" runat="server">
            <asp:HiddenField ID="hideUserId" runat="server" />

            <ajax:TabContainer ID="TabControl" runat="server">
                <ajax:TabPanel ID="tabUserInfo" runat="server" HeaderText="User Info">
                    <ContentTemplate>

                        <asp:Table ID="tblUserInfo" runat="server">
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblUsername" runat="server" Text="Username *" AssociatedControlID="txtUsername" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtUsername" runat="server" Width="400" ToolTip="Select an Active Directory user to add a Username value" ReadOnly="true" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnActiveDirectory" runat="server" Text="..." ToolTip="Select to search Active Directory for a user" OnClick="BtnActiveDirectory_Click" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblFirstName" runat="server" Text="First Name *" AssociatedControlID="txtFirstName" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for the user's First Name" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblMiddleName" runat="server" Text="Middle Name" AssociatedControlID="txtMiddleName" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtMiddleName" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for the user's Middle Name" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblLastName" runat="server" Text="Last Name *" AssociatedControlID="txtLastName" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtLastName" runat="server" MaxLength="40" Width="400" ToolTip="Enter a value for the user's Last Name" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblFullName" runat="server" Text="Full Name *" AssociatedControlID="txtFullName" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtFullName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for the user's Full Name" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblMaidenName" runat="server" Text="Maiden Name" AssociatedControlID="txtMaidenName" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtMaidenName" runat="server" MaxLength="40" Width="400" ToolTip="Enter a value for the user's Maiden Name" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblEmployeeNumber" runat="server" Text="Employee Number" AssociatedControlID="txtEmployeeNumber" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtEmployeeNumber" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for the user's Employee Number" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblJobTitle" runat="server" Text="Job Title *" AssociatedControlID="txtJobTitle" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtJobTitle" runat="server" MaxLength="80" Width="400" ToolTip="Enter a value for the user's Job Title" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblEmailAddress" runat="server" Text="Email Address" AssociatedControlID="txtEmailAddress" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtEmailAddress" runat="server" MaxLength="128" Width="400" ToolTip="Enter a value for the user's Email Address" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblTelephoneNumber" runat="server" Text="Phone Number" AssociatedControlID="txtTelephoneNumber" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtTelephoneNumber" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for the user's Phone Number" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblFaxNumber" runat="server" Text="Fax Number" AssociatedControlID="txtFaxNumber" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="txtFaxNumber" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for the user's Fax Number" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:CheckBox ID="chkEmailAlerts" runat="server" Text="Receive Email Alerts" ToolTip="Select to Receive Email Alerts" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="tabRoleInfo" runat="server" HeaderText="Role Info">
                    <ContentTemplate>

                        <asp:Table ID="tblRoleInfo" runat="server">
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblSystemRoles" runat="server" Text="System Roles" AssociatedControlID="rblSystemRoles" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell>
                                    <asp:RadioButtonList ID="rblSystemRoles" runat="server" ToolTip="Select a system role for the current user" 
                                        DataSourceID="dsSystemRoles" DataValueField="ID" DataTextField="NAME" OnDataBound="RblSystemRoles_DataBound" AutoPostBack="true" OnSelectedIndexChanged="RblSystemRoles_SelectedIndexChanged" />
                                    <asp:ObjectDataSource ID="dsSystemRoles" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_ROLE_GET_ALL_SYSTEM_ROLES" OnSelecting="DsSystemRoles_Selecting" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblRegistries" runat="server" Text="Available Registries" AssociatedControlID="listRegistries" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="listRegistries" runat="server" ToolTip="Select to assign Registry specific roles" 
                                        DataSourceID="dsRegistries" DataValueField="ID" DataTextField="NAME" AutoPostBack="true" OnDataBound="ListRegistries_DataBound" OnSelectedIndexChanged="ListRegistries_SelectedIndexChanged" />
                                    <asp:ObjectDataSource ID="dsRegistries" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER" OnSelecting="DsRegistries_Selecting" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell><asp:Label ID="lblRegistryRoles" runat="server" Text="Registry Roles" AssociatedControlID="rblRegistryRoles" />&nbsp;&nbsp;</asp:TableCell>
                                <asp:TableCell>
                                    <asp:RadioButtonList ID="rblRegistryRoles" runat="server" ToolTip="Select a Registry specific role for the current user" 
                                        DataSourceID="dsRegistryRoles" DataValueField="ID" DataTextField="NAME" OnDataBound="RblRegistryRoles_DataBound" AutoPostBack="true" OnSelectedIndexChanged="RblRegistryRoles_SelectedIndexChanged" />
                                    <asp:ObjectDataSource ID="dsRegistryRoles" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_ROLE_GET_ALL_REGISTRY_ROLES" OnSelecting="DsRegistryRoles_Selecting" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </ContentTemplate>
                </ajax:TabPanel>
            </ajax:TabContainer>

            <br />

            <asp:Table ID="tblSaveForm" runat="server">
                <asp:TableRow>
                    <asp:TableCell style="text-align:center;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all User values" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to return to previous list" />
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>