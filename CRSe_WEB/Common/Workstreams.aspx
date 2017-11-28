<%@ Page Title="Work Streams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workstreams.aspx.cs" Inherits="CRSe_WEB.Common.Workstreams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Work Streams" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlWorkstreams" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="ID" Value="WKF_CASE_ID"></asp:ListItem>
            <asp:ListItem Text="Name" Value="STD_WKFCASETYPE.Name"></asp:ListItem>
            <asp:ListItem Text="Status" Value="STD_WKFCASESTS.NAME"></asp:ListItem>
            <asp:ListItem Text="Case Number" Value="CASE_NUMBER"></asp:ListItem>
            <asp:ListItem Text="Case Start Date" Value="CASE_START_DATE"></asp:ListItem>
            <asp:ListItem Text="Case Due Date" Value="CASE_DUE_DATE"></asp:ListItem>
            <asp:ListItem Text="Referral Date" Value="REFERRAL.REFERRAL_DATE"></asp:ListItem>
            <asp:ListItem Text="Last Name" Value="PATIENT.LAST_NAME"></asp:ListItem>
            <asp:ListItem Text="First Name" Value="PATIENT.FIRST_NAME"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Work Streams are available"
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("WKF_CASE_ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("WKF_CASE_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White"  SortExpression="WKF_CASE_ID" AccessibleHeaderText="WORK_STREAM_ID" HeaderText="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectWorkstream" runat="server" Text='<%# Eval("WKF_CASE_ID") %>' OnClick="LinkSelectWorkstream_Click" CommandArgument='<%# Eval("WKF_CASE_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="PATIENT_ID" AccessibleHeaderText="PATIENT_ID" HeaderText="PATIENT_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectPatient" runat="server" Text='<%# Eval("PATIENT_ID") %>' OnClick="LinkSelectPatient_Click" CommandArgument='<%# Eval("PATIENT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="REFERRAL_ID" AccessibleHeaderText="REFERRAL_ID" HeaderText="REFERRAL_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectReferral" runat="server" Text='<%# Eval("REFERRAL_ID") %>' OnClick="LinkSelectReferral_Click" CommandArgument='<%# Eval("REFERRAL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFCASETYPE.Name" AccessibleHeaderText="WORK_STREAM_NAME" HeaderText="NAME" DataField="STD_WKFCASETYPE.Name" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFCASESTS.NAME" AccessibleHeaderText="STATUS" HeaderText="STATUS" DataField="STD_WKFCASESTS.NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CASE_NUMBER" AccessibleHeaderText="CASE_NUMBER" HeaderText="CASE NUMBER" DataField="CASE_NUMBER" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CASE_START_DATE" AccessibleHeaderText="CASE_START_DATE" HeaderText="CASE START DATE" DataField="CASE_START_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CASE_DUE_DATE" AccessibleHeaderText="CASE_DUE_DATE" HeaderText="CASE DUE DATE" DataField="CASE_DUE_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="REFERRAL.REFERRAL_DATE" AccessibleHeaderText="REFERRAL_DATE" HeaderText="REFERRAL DATE" DataField="REFERRAL.REFERRAL_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT.LAST_NAME" AccessibleHeaderText="LAST_NAME" HeaderText="LAST NAME" DataField="PATIENT.LAST_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT.FIRST_NAME" AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST NAME" DataField="PATIENT.FIRST_NAME" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="WKF_CASE_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkWorkstreamAdd" runat="server" Text="Add New Work Stream" OnClick="LinkWorkstreamAdd_Click" ToolTip="Select to add a new Work Stream" />

    </asp:Panel>

    <asp:Panel ID="pnlWorkstream" runat="server">

        <asp:HiddenField ID="hideWorkstreamId" runat="server" />
        <asp:Table ID="tblWorkstreamInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblPatientName" runat="server" Text="Patient Name" AssociatedControlID="txtPatientName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hidePatientId" runat="server" />
                    <asp:TextBox ID="txtPatientName" MaxLength="100" runat="server" Width="400" ToolTip="Patient Name" ReadOnly="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblReferralDate" runat="server" Text="Referral Date" AssociatedControlID="txtReferralDate" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hideReferralId" runat="server" />
                    <asp:TextBox ID="txtReferralDate" MaxLength="100" runat="server" Width="400" ToolTip="Referral Date" ReadOnly="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblWorkstreamName" runat="server" Text="Work Stream *" AssociatedControlID="listWorkstreamName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="listWorkstreamName" runat="server" Width="400" ToolTip="Select an available Work Stream" DataValueField="ID" DataTextField="NAME" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCaseNumber" runat="server" Text="Case Number *" AssociatedControlID="txtCaseNumber" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCaseNumber" runat="server" MaxLength="30" Width="400" ToolTip="Enter a value for Case Number" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCaseStartDate" runat="server" Text="Case Start Date" AssociatedControlID="txtCaseStartDate" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                        <asp:TextBox ID="txtCaseStartDate" runat="server" Width="400" ToolTip="Enter a value for Case Start Date" MaxLength="10" onkeypress="return CheckDate(event);" />
                        <ajax:TextBoxWatermarkExtender ID="wmCaseStartDate" runat="server" TargetControlID="txtCaseStartDate" WatermarkCssClass="watermark" />
                        <ajax:CalendarExtender runat="server" ID="calCaseStartDate" Animated="false" TargetControlID="txtCaseStartDate" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblCaseDueDate" runat="server" Text="Case Due Date" ToolTip="txtCaseDueDate" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                        <asp:TextBox ID="txtCaseDueDate" runat="server" Width="400" ToolTip="Enter a value for Case Due Date" MaxLength="10" onkeypress="return CheckDate(event);" />
                        <ajax:TextBoxWatermarkExtender ID="wmCaseDueDate" runat="server" TargetControlID="txtCaseDueDate" WatermarkCssClass="watermark" />
                        <ajax:CalendarExtender runat="server" ID="calCaseDueDate" Animated="false" TargetControlID="txtCaseDueDate" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Work Stream values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Work Stream list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel ID="pnlSelectPatient" runat="server" Visible="false">
        <asp:Label ID="lblSelectPatient" runat="server" Text="Please select a patient or referral to use this functionality." /><br /><br />
        <asp:Button ID="btnSelectPatient" runat="server" Text="Continue" OnClick="BtnSelectPatient_Click" ToolTip="Select to continue and choose a patient or referral" />
    </asp:Panel>
</asp:Content>
