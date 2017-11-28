<%@ Page Title="Referrals" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Referrals.aspx.cs" Inherits="CRSe_WEB.Common.Referrals" %>

<%@ Register Src="~/Controls/PatientReferral.ascx" TagPrefix="uc" TagName="PatientReferral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Referrals" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlReferrals" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Referral ID" Value="REFERRAL_ID"></asp:ListItem>
            <asp:ListItem Text="Status" Value="STD_REFERRALSTS_CODE"></asp:ListItem>
            <asp:ListItem Text="Referral Date" Value="REFERRAL_DATE"></asp:ListItem>
            <asp:ListItem Text="Last Four" Value="PATIENT_LastFour"></asp:ListItem>
            <asp:ListItem Text="Last Name" Value="PATIENT_LAST_NAME"></asp:ListItem>
            <asp:ListItem Text="First Name" Value="PATIENT_FIRST_NAME"></asp:ListItem>
            <asp:ListItem Text="Birth Date" Value="PATIENT_BIRTH_DATE"></asp:ListItem>
            <asp:ListItem Text="Gender" Value="PATIENT_Gender"></asp:ListItem>
            <asp:ListItem Text="City" Value="PATIENT_City"></asp:ListItem>
            <asp:ListItem Text="State" Value="PATIENT_State"></asp:ListItem>
            <asp:ListItem Text="Postal Code " Value="PATIENT_PostalCode"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Referrals are available" 
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField  ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("REFERRAL_ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="REFERRAL_ID" AccessibleHeaderText="REFERRAL_ID" HeaderText="REFERRAL ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text='<%# Eval("REFERRAL_ID") %>' OnClick="LinkSelect_Click" CommandArgument='<%# Eval("REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_REFERRALSTS_CODE" AccessibleHeaderText="STATUS" HeaderText="STATUS" DataField="STD_REFERRALSTS_CODE" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="REFERRAL_DATE" AccessibleHeaderText="REFERRAL_DATE" HeaderText="REFERRAL DATE" DataField="REFERRAL_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_LastFour"  AccessibleHeaderText="LAST_FOUR" HeaderText="LAST FOUR" DataField="PATIENT_LastFour" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_LAST_NAME"  AccessibleHeaderText="LAST_NAME" HeaderText="LAST NAME" DataField="PATIENT_LAST_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_FIRST_NAME"  AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST NAME" DataField="PATIENT_FIRST_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_BIRTH_DATE"  AccessibleHeaderText="BIRTH_DATE" HeaderText="BIRTH DATE" DataField="PATIENT_BIRTH_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_Gender"  AccessibleHeaderText="GENDER" HeaderText="GENDER" DataField="PATIENT_Gender" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_City"  AccessibleHeaderText="CITY" HeaderText="CITY" DataField="PATIENT_City" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_State"  AccessibleHeaderText="STATE" HeaderText="STATE" DataField="PATIENT_State" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT_PostalCode" AccessibleHeaderText="POSTAL_CODE" HeaderText="POSTAL CODE" DataField="PATIENT_PostalCode" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="REFERRAL_GET_COMMON_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

        <br />
        <asp:LinkButton ID="linkReferralAdd" runat="server" Text="Add New Referral" OnClick="LinkReferralAdd_Click" ToolTip="Select to add a new Referral" />

    </asp:Panel>

    <asp:Panel ID="pnlSearch" runat="server">
        <uc:PatientReferral ID="PatientReferral" runat="server" SearchType="PATIENT" OnSearchCancelClicked="PatientReferral_SearchCancelClicked" OnSelectClicked="PatientReferral_SelectClicked" />
    </asp:Panel>

    <asp:Panel ID="pnlReferral" runat="server">
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
                <asp:TableCell><asp:Label ID="lblProvider" runat="server" Text="Provider" AssociatedControlID="txtProvider" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hideProviderId" runat="server" />
                    <asp:TextBox ID="txtProvider" runat="server" MaxLength="102" Width="400" ReadOnly="true" ToolTip="Provider" />&nbsp;
                    <asp:Button ID="btnAddProvider" runat="server" Text="..." OnClick="BtnAddProvider_Click" ToolTip="Select to add a Provider" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to add Referral to the Registry" OnClientClick='return confirm("Are you sure you want to add this Referral to the Registry?");' />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
