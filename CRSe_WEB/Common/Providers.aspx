<%@ Page Title="Providers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Providers.aspx.cs" Inherits="CRSe_WEB.Common.Providers" %>

<%@ Register Src="~/Controls/PatientReferral.ascx" TagPrefix="uc" TagName="PatientReferral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Providers" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlProviders" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Provider ID" Value="Provider_ID"></asp:ListItem>
            <asp:ListItem Text="Last Name" Value="LastName"></asp:ListItem>
            <asp:ListItem Text="First Name" Value="FirstName"></asp:ListItem>
            <asp:ListItem Text="Gender" Value="Gender"></asp:ListItem>
            <asp:ListItem Text="City" Value="City"></asp:ListItem>
            <asp:ListItem Text="State" Value="StateName"></asp:ListItem>
            <asp:ListItem Text="Zip Code" Value="ZipCode"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" 
            EmptyDataText="Currently no Providers are available"
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("REFERRAL.REFERRAL_ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("REFERRAL.REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="Provider_ID" AccessibleHeaderText="PROVIDER_ID" HeaderText="PROVIDER_ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text='<%# Eval("Provider_ID") %>' OnClick="LinkSelect_Click" CommandArgument='<%# Eval("REFERRAL.REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="LastName" AccessibleHeaderText="LAST_NAME" HeaderText="LAST_NAME" DataField="LastName" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="FirstName" AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST_NAME" DataField="FirstName" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Gender" AccessibleHeaderText="GENDER" HeaderText="GENDER" DataField="Gender" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="City" AccessibleHeaderText="CITY" HeaderText="CITY" DataField="City" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="StateName" AccessibleHeaderText="STATE" HeaderText="STATE" DataField="StateName" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ZipCode" AccessibleHeaderText="POSTAL_CODE" HeaderText="POSTAL_CODE" DataField="ZipCode" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="SStaff_SStaff_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

        <br />
        <asp:LinkButton ID="linkProviderAdd" runat="server" Text="Add New Provider" OnClick="LinkProviderAdd_Click" ToolTip="Select to add a new Provider" />

    </asp:Panel>

    <asp:Panel ID="pnlSearch" runat="server">
        <uc:PatientReferral ID="PatientReferral" runat="server" SearchType="PROVIDER" OnSearchCancelClicked="PatientReferral_SearchCancelClicked" OnSelectClicked="PatientReferral_SelectClicked" />
    </asp:Panel>

    <asp:Panel ID="pnlProvider" runat="server">
        <asp:HiddenField ID="hideResultId" runat="server" />
        <asp:Table ID="tblResultInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblLastFour" runat="server" Text="Last Four" AssociatedControlID="txtLastFour" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtLastFour" runat="server" MaxLength="4" Width="400" ReadOnly="true" ToolTip="Last Four" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblLastName" runat="server" Text="Last Name" AssociatedControlID="txtLastName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtLastName" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="Last Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="First Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblBirthDate" runat="server" Text="Birth Date" AssociatedControlID="txtBirthDate" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                        <asp:TextBox ID="txtBirthDate" runat="server" Width="400" ReadOnly="true" ToolTip=" Birth Date" MaxLength="10" onkeypress="return CheckDate(event);" />
                        <ajax:TextBoxWatermarkExtender ID="wmBirthDate" runat="server" TargetControlID="txtBirthDate" WatermarkCssClass="watermark" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblGender" runat="server" Text="Gender" AssociatedControlID="txtGender" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtGender" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="Gender" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="txtCity" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCity" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="City" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="txtState" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtState" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="State" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblPostalCode" runat="server" Text="Postal Code" AssociatedControlID="txtPostalCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPostalCode" runat="server" MaxLength="50" Width="400" ReadOnly="true" ToolTip="Postal Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblPatient" runat="server" Text="Patient *" AssociatedControlID="txtPatient" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hidePatientId" runat="server" />
                    <asp:TextBox ID="txtPatient" runat="server" MaxLength="102" Width="400" ReadOnly="true" ToolTip="Patient" />&nbsp;
                    <asp:Button ID="btnAddPatient" runat="server" Text="..." OnClick="BtnAddPatient_Click" ToolTip="Select to add a Patient" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to add Referral to the Registry" OnClientClick='return confirm("Are you sure you want to add this Provider to the Registry?");' />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
