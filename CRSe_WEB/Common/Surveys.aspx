<%@ Page Title="Surveys" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Surveys.aspx.cs" Inherits="CRSe_WEB.Common.Surveys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Surveys" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlSurveys" runat="server">
        <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Survey ID" Value="SURVEYS_ID"></asp:ListItem>
            <asp:ListItem Text="Survey Name" Value="STD_SURVEY_TYPE.NAME"></asp:ListItem>
            <asp:ListItem Text="Survey Date" Value="SURVEY_DATE"></asp:ListItem>
            <asp:ListItem Text="Survey Status" Value="SURVEY_STATUS"></asp:ListItem>
            <asp:ListItem Text="Last Name" Value="PATIENT.LAST_NAME"></asp:ListItem>
            <asp:ListItem Text="First Name " Value="PATIENT.FIRST_NAME"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Surveys are available" 
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("SURVEYS_ID") %>' />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("SURVEYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="SURVEYS_ID" AccessibleHeaderText="SURVEY_ID" HeaderText="SURVEY_ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectSurvey" runat="server" Text='<%# Eval("SURVEYS_ID") %>' OnClick="LinkSelectSurvey_Click" CommandArgument='<%# Eval("SURVEYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="PATIENT_ID" AccessibleHeaderText="PATIENT_ID" HeaderText="PATIENT_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectPatient" runat="server" Text='<%# Eval("PATIENT_ID") %>' OnClick="LinkSelectPatient_Click" CommandArgument='<%# Eval("PATIENT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="PROVIDER_ID" AccessibleHeaderText="PROVIDER_ID" HeaderText="PROVIDER_ID" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelectProvider" runat="server" Text='<%# Eval("PROVIDER_ID") %>' OnClick="LinkSelectProvider_Click" CommandArgument='<%# Eval("PROVIDER_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_SURVEY_TYPE.NAME" AccessibleHeaderText="SURVEY_NAME" HeaderText="SURVEY_NAME" DataField="STD_SURVEY_TYPE.NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="SURVEY_DATE" AccessibleHeaderText="SURVEY_DATE" HeaderText="SURVEY_DATE" DataField="SURVEY_DATE" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="SURVEY_STATUS" AccessibleHeaderText="SURVEY_STATUS" HeaderText="SURVEY_STATUS" DataField="SURVEY_STATUS" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT.LAST_NAME" AccessibleHeaderText="LAST_NAME" HeaderText="LAST_NAME" DataField="PATIENT.LAST_NAME" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PATIENT.FIRST_NAME" AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST_NAME" DataField="PATIENT.FIRST_NAME" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="SURVEYS_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />

        <br />
        <asp:LinkButton ID="linkSurveyAdd" runat="server" Text="Add New Survey" OnClick="LinkSurveyAdd_Click" ToolTip="Select to add a new Survey" />

    </asp:Panel>

    <asp:Panel ID="pnlSurvey" runat="server">

        <asp:HiddenField ID="hideSurveyId" runat="server" />
        <asp:Table ID="tblSurveyInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblPatientName" runat="server" Text="Patient Name" AssociatedControlID="txtPatientName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:HiddenField ID="hidePatientId" runat="server" />
                    <asp:TextBox ID="txtPatientName" MaxLength="100" runat="server" Width="400" ToolTip="Patient Name" ReadOnly="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSurveyName" runat="server" Text="Survey" AssociatedControlID="listSurveyName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="listSurveyName" runat="server" Width="400" ToolTip="Select an available Survey" DataValueField="ID" DataTextField="NAME" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSurveyDate" runat="server" Text="Survey Date *" AssociatedControlID="txtSurveyDate" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell>
                        <asp:TextBox ID="txtSurveyDate" runat="server" Width="400" ToolTip="Enter a value for Survey Date" MaxLength="10" onkeypress="return CheckDate(event);" />
                        <ajax:TextBoxWatermarkExtender ID="wmSurveyDate" runat="server" TargetControlID="txtSurveyDate" WatermarkCssClass="watermark" />
                    <ajax:CalendarExtender runat="server" ID="calSurveyDate" Animated="false" TargetControlID="txtSurveyDate" />
                </asp:TableCell>
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

    <asp:Panel ID="pnlSelectPatient" runat="server" Visible="false">
        <asp:Label ID="lblSelectPatient" runat="server" Text="Please select a patient or referral to use this functionality." /><br /><br />
        <asp:Button ID="btnSelectPatient" runat="server" Text="Continue" OnClick="BtnSelectPatient_Click" ToolTip="Select to continue and choose a patient or referral" />
    </asp:Panel>
</asp:Content>
