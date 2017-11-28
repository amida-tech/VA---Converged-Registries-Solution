<%@ Page Title="Survey Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveyFields.aspx.cs" Inherits="CRSe_WEB.Admin.SurveyFields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Survey Field Administration" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Panel ID="pnlSurveyFields" runat="server">
         <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Question Number" Value="QUESTION_NUMBER"></asp:ListItem>
            <asp:ListItem Text="Sort Order" Value="SORT_ORDER"></asp:ListItem>
            <asp:ListItem Text="Question Text" Value="QUESTION_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" ToolTip="Click to Search" OnClick="BtnSearch_Click" Text="Search" />
        <asp:Button runat="server" ID="btnClear" ToolTip="Click to Clear Search" OnClick="BtnClear_Click" Text="Clear" />
         <br /><br />
        <asp:GridView ID="gridSurveyFields" runat="server"  CssClass="gridWizard" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"  
            EmptyDataText="Currently no existing survey fields are available" DataSourceID="dsSurveyFields" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" OnClick="LinkEdit_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to edit Survey Field information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" OnClick="LinkDelete_Click" CommandArgument='<%# Eval("ID") %>' ToolTip="Select to delete Survey Field" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="QUESTION_NUMBER" AccessibleHeaderText="Question Number" HeaderText="Question Number" DataField="QUESTION_NUMBER" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="SORT_ORDER" AccessibleHeaderText="Sort Order" HeaderText="Sort Order" DataField="SORT_ORDER" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="QUESTION_TEXT" AccessibleHeaderText="Question Text" HeaderText="Question Text" DataField="QUESTION_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsSurveyFields" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_QUESTION_GET_ALL_BY_SURVEY" OnSelecting="DsSurveyFields_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkSurveyFieldAdd" runat="server" Text="Add New Survey Field" OnClick="LinkSurveyFieldAdd_Click" ToolTip="Select to add a new Survey Field" />
        
        <br /><br />

        <asp:Table ID="tblSaveForm1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel ID="pnlSurveyField" runat="server">
        <asp:HiddenField ID="hideSurveyFieldId" runat="server" />
        <asp:Table ID="tblSurveyFieldInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblQuestionNumber" runat="server" Text="Question Number *" AssociatedControlID="txtQuestionNumber" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtQuestionNumber" runat="server" MaxLength="50" Width="400" ToolTip="Enter a value for Question Number" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblSortOrder" runat="server" Text="Sort Order *" AssociatedControlID="txtSortOrder" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSortOrder" runat="server" Width="400" ToolTip="Enter a value for Sort Order" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>

                <asp:TableCell><asp:Label ID="lblQuestionText" runat="server" Text="Question Text *" ToolTip="txtQuestionText" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtQuestionText" runat="server" MaxLength="950" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Question Text" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveForm2" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Survey Question/Choice values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Return to List" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes and return to Survey Question list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />
    </asp:Panel>

    <asp:Panel ID="pnlFieldChoices" runat="server">
        <asp:Label ID="lblFieldChoices" runat="server" Text="Search By" AssociatedControlID="ddlFilter" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlFilter" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
            <asp:ListItem Text="Choice Name" Value="CHOICE_NAME"></asp:ListItem>
            <asp:ListItem Text="Sort Order" Value="CHOICE_SORT_ORDER"></asp:ListItem>
            <asp:ListItem Text="Choice Text" Value="CHOICE_TEXT"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="txtFilterChoices" Width="120px"></asp:TextBox>
        <asp:Button runat="server" ID="btnFilter" OnClick="BtnFilter_Click" Text="Search" />
        <asp:Button runat="server" ID="btnClearFieldChoices" OnClick="BtnClearFieldChoices_Click" Text="Clear" />
        <br /><br />
        <asp:GridView ID="gridFieldChoices" runat="server" CssClass="gridWizard" 
            EmptyDataText="Currently no existing field choices are available"
            DataSourceID="dsFieldChoices" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
            <Columns>
                <asp:TemplateField SortExpression="ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEditChoice" runat="server" Text="Edit" OnClick="LinkEditChoice_Click" CommandArgument='<%# Eval("STD_QUESTION_CHOICE_ID") %>' ToolTip="Select to edit Field Choice information" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="linkDeleteChoice" runat="server" Text="Delete" OnClick="LinkDeleteChoice_Click" CommandArgument='<%# Eval("STD_QUESTION_CHOICE_ID") %>' ToolTip="Select to delete Field Choice" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField SortExpression="CHOICE_NAME" AccessibleHeaderText="Choice Name" HeaderText="Choice Name" DataField="CHOICE_NAME" />
                <asp:BoundField SortExpression="CHOICE_SORT_ORDER" AccessibleHeaderText="Sort Order" HeaderText="Sort Order" DataField="CHOICE_SORT_ORDER" />
                <asp:BoundField SortExpression="CHOICE_TEXT" AccessibleHeaderText="Choice Text" HeaderText="Choice Text" DataField="CHOICE_TEXT" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsFieldChoices" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION" OnSelecting="DsFieldChoices_Selecting" SortParameterName="SORT_EXPRESSION" />
        <br />
        <asp:LinkButton ID="linkFieldChoiceAdd" runat="server" Text="Add New Field Choice" OnClick="LinkFieldChoiceAdd_Click" ToolTip="Select to add a new Field Choice" />
    </asp:Panel>

    <asp:Panel ID="pnlFieldChoice" runat="server">
        <asp:HiddenField ID="hideFieldChoiceId" runat="server" />
        <asp:Table ID="tblFieldChoiceInfo" runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblChoiceName" runat="server" Text="Choice Name *" AssociatedControlID="txtChoiceName" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtChoiceName" runat="server" MaxLength="100" Width="400" ToolTip="Enter a value for Choice Namer" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblChoiceSortOrder" runat="server" Text="Sort Order *" AssociatedControlID="txtChoiceSortOrder" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtChoiceSortOrder" runat="server" Width="400" ToolTip="Enter a value for Sort Order" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblChoiceText" runat="server" Text="Choice Text *" ToolTip="txtChoiceText" />&nbsp;&nbsp;</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtChoiceText" runat="server" MaxLength="4000" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Choice Text" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="tblSaveChoice" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnSaveChoice" runat="server" Text="Save" OnClick="BtnSaveChoice_Click" ToolTip="Select to save all Choice values" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelChoice" runat="server" Text="Return to List" OnClick="BtnCancelChoice_Click" ToolTip="Select to cancel changes and return to Survey Field list" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
