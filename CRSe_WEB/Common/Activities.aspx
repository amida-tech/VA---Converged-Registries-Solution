<%@ Page Title="Activities" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="CRSe_WEB.Common.Activities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Activities" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlActivities" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Activity ID" Value="WKF_CASE_ACTIVITY_ID"></asp:ListItem>
            <asp:ListItem Text="Activity Name" Value="STD_WKFACTIVITYTYPE.NAME"></asp:ListItem>
            <asp:ListItem Text="Status" Value="STD_WKFACTIVITYSTS.NAME"></asp:ListItem>
            <asp:ListItem Text="Contact Name" Value="CONTACT_NAME"></asp:ListItem>
            <asp:ListItem Text="Workstream" Value="WKF_CASE.STD_WKFCASETYPE.Name"></asp:ListItem>
            <asp:ListItem Text="Referral Date" Value="WKF_CASE.REFERRAL.REFERRAL_DATE"></asp:ListItem>
            <asp:ListItem Text="Last Name" Value="WKF_CASE.PATIENT.LAST_NAME"></asp:ListItem>
            <asp:ListItem Text="First Name" Value="WKF_CASE.PATIENT.FIRST_NAME"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Activities are available" 
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField AccessibleHeaderText="ACTIVITY_ID" HeaderStyle-ForeColor="White" SortExpression="WKF_CASE_ACTIVITY_ID" HeaderText="ACTIVITY ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectActivity" runat="server" Text='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' OnClick="LinkSelectActivity_Click" CommandArgument='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField AccessibleHeaderText="WORK_STREAM_ID" HeaderText="WORK STREAM ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectWorkstream" runat="server" Text='<%# Eval("WKF_CASE_ID") %>' OnClick="LinkSelectWorkstream_Click" CommandArgument='<%# Eval("WKF_CASE_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField AccessibleHeaderText="PATIENT_ID" HeaderText="PATIENT_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectPatient" runat="server" Text='<%# Eval("WKF_CASE.PATIENT_ID") %>' OnClick="LinkSelectPatient_Click" CommandArgument='<%# Eval("WKF_CASE.PATIENT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField AccessibleHeaderText="REFERRAL_ID" HeaderText="REFERRAL_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectReferral" runat="server" Text='<%# Eval("WKF_CASE.REFERRAL_ID") %>' OnClick="LinkSelectReferral_Click" CommandArgument='<%# Eval("WKF_CASE.REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFACTIVITYTYPE.NAME" AccessibleHeaderText="ACTIVITY_NAME" HeaderText="ACTIVITY NAME" DataField="STD_WKFACTIVITYTYPE.NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFACTIVITYSTS.NAME" AccessibleHeaderText="STATUS" HeaderText="STATUS" DataField="STD_WKFACTIVITYSTS.NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_NAME" AccessibleHeaderText="CONTACT_NAME" HeaderText="CONTACT NAME" DataField="CONTACT_NAME"  />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_EMAIL" AccessibleHeaderText="CONTACT_EMAIL" HeaderText="CONTACT EMAIL" DataField="CONTACT_EMAIL" Visible="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_PHONE" AccessibleHeaderText="CONTACT_PHONE" HeaderText="CONTACT PHONE" DataField="CONTACT_PHONE" Visible="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="BEST_CALL_BACK_TIME" AccessibleHeaderText="BEST_CALL_BACK_TIME" HeaderText="BEST_CALL_BACK_TIME" DataField="BEST_CALL_BACK_TIME" Visible="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="WKF_CASE.STD_WKFCASETYPE.Name" AccessibleHeaderText="WORK_STREAM_NAME" HeaderText="WORK STREAM NAME" DataField="WKF_CASE.STD_WKFCASETYPE.NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="WKF_CASE.REFERRAL.REFERRAL_DATE" AccessibleHeaderText="REFERRAL_DATE" HeaderText="REFERRAL DATE" DataField="WKF_CASE.REFERRAL.REFERRAL_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="WKF_CASE.PATIENT.LAST_NAME" AccessibleHeaderText="LAST_NAME" HeaderText="LAST NAME" DataField="WKF_CASE.PATIENT.LAST_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="WKF_CASE.PATIENT.FIRST_NAME" AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST NAME" DataField="WKF_CASE.PATIENT.FIRST_NAME" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkActivityAdd" runat="server" Text="Add New Activity" OnClick="LinkActivityAdd_Click" ToolTip="Select to add a new Activity" />

    </asp:Panel>

    <asp:Panel ID="pnlActivity" runat="server">

        <asp:HiddenField ID="hideActivityId" runat="server" />
        <asp:Table ID="tblActivityInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamName" runat="server" Text="Work Stream" AssociatedControlID="txtWorkstreamName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hideWorkstreamId" runat="server" />
                    <asp:TextBox ID="txtWorkstreamName" runat="server" ReadOnly="true" Width="400" ToolTip="Work Stream" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblActivityName" runat="server" Text="Activity *" AssociatedControlID="listActivityName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="listActivityName" runat="server" Width="400" ToolTip="Select an available Activity" DataValueField="ID" DataTextField="NAME" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblContactName" runat="server" Text="Contact Name *" AssociatedControlID="txtContactName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtContactName" runat="server" MaxLength="255" Width="400" ToolTip="Enter a value for Contact Name" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblContactEmail" runat="server" Text="Contact Email *" AssociatedControlID="txtContactEmail" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtContactEmail" runat="server" MaxLength="255" Width="400" ToolTip="Enter a value for Contact Email" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblContactPhone" runat="server" Text="Contact Phone *" AssociatedControlID="txtContactPhone" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtContactPhone" runat="server" MaxLength="255" Width="400" ToolTip="Enter a value for Contact Phone" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblBestCallBackTime" runat="server" Text="Best Call Back Time *" AssociatedControlID="txtBestCallBackTime" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtBestCallBackTime" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Best Call Back Time" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1 *" AssociatedControlID="txtAddressLine1" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtAddressLine1" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Address Line 1" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2" AssociatedControlID="txtAddressLine2" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtAddressLine2" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Address Line 2" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblAddressLine3" runat="server" Text="Address Line 3" AssociatedControlID="txtAddressLine3" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtAddressLine3" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Address Line 3" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCity" runat="server" Text="City *" AssociatedControlID="txtCity" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCity" runat="server" MaxLength="60" Width="400" ToolTip="Enter a value for City" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblState" runat="server" Text="State *" AssociatedControlID="txtState" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtState" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for State" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblPostalCode" runat="server" Text="Postal Code *" AssociatedControlID="txtPostalCode" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPostalCode" runat="server" MaxLength="10" Width="400" ToolTip="Enter a value for Postal Code" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCountry" runat="server" Text="Country *" AssociatedControlID="txtCountry" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCountry" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Country" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblInfoConveyed" runat="server" Text="Info Conveyed *" AssociatedControlID="txtInfoConveyed" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtInfoConveyed" runat="server" TextMode="MultiLine" Rows="5" Width="400" ToolTip="Enter a value for Info Conveyed" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblInfoReceived" runat="server" Text="Info Received *" AssociatedControlID="txtInfoReceived" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtInfoReceived" runat="server" TextMode="MultiLine" Rows="5" Width="400" ToolTip="Enter a value for Info Receieved" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Activity values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Activity list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel ID="pnlSelectWorkstream" runat="server" Visible="false">
        <asp:Label ID="lblSelectWorkstream" runat="server" Text="Please select a Work Stream to use this functionality." /><br /><br />
        <asp:Button ID="btnSelectWorkstream" runat="server" Text="Continue" OnClick="BtnSelectWorkstream_Click" ToolTip="Select to continue and choose a Work Stream" />
    </asp:Panel>
</asp:Content>
