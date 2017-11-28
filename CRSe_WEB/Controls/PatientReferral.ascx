<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PatientReferral.ascx.cs" Inherits="CRSe_WEB.Controls.PatientReferral" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSearch" />
        <asp:PostBackTrigger ControlID="btnSearchCancel" />
    </Triggers>
    <ContentTemplate>

        <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

        <asp:HiddenField ID="hideSearchType" runat="server" />
        <asp:Panel ID="pnlSearch" runat="server">
            <asp:Table ID="tblSearch" runat="server">
                <asp:TableRow><asp:TableCell ColumnSpan="2"><asp:Label ID="lblSearchInstructions" runat="server" /></asp:TableCell></asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="lblSearchLastName" runat="server" Text="Last Name" AssociatedControlID="txtSearchLastName" />&nbsp;&nbsp;</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSearchLastName" runat="server" Width="400" ToolTip="Enter a value to include Last Name in search" onkeypress="return CheckAlpha(event);" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="lblSearchFirstName" runat="server" Text="First Name" AssociatedControlID="txtSearchFirstName" />&nbsp;&nbsp;</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSearchFirstName" runat="server" Width="400" ToolTip="Enter a value to include First Name in search" onkeypress="return CheckAlpha(event);" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" style="text-align:center;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" ToolTip="Select to begin Search" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearchCancel" runat="server" Text="Close Search" OnClick="BtnSearchCancel_Click" ToolTip="Select to close Search" />
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
                <asp:ListItem Text="Last Four" Value="LastFour"></asp:ListItem>
                <asp:ListItem Text="Last Name" Value="LastName"></asp:ListItem>
                <asp:ListItem Text="First Name" Value="FirstName"></asp:ListItem>
                <asp:ListItem Text="Birth Date" Value="BirthDate"></asp:ListItem>
                <asp:ListItem Text="Gender" Value="Gender"></asp:ListItem>
                <asp:ListItem Text="City" Value="City"></asp:ListItem>
                <asp:ListItem Text="State" Value="State"></asp:ListItem>
                <asp:ListItem Text="Postal Code" Value="State"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ToolTip="Enter Search Text"  ID="txtSearch" Width="120px"></asp:TextBox>
            <asp:Button runat="server" ToolTip="Click to Search" ID="btnFilter" OnClick="BtnFilter_Click" Text="Search" />
            <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
            <br /><br />
            <asp:GridView ID="gridResults" runat="server" DataSourceID="dsResults" OnRowDataBound="GridResults_RowDataBound" EmptyDataText="Currently no results are available that match search criteria" 
                CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
                AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
                <Columns>
                    <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="ResultId" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkSelect" runat="server" Text="Select" OnClick="LinkSelect_Click" CommandArgument='<%# Eval("ResultId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="LastFour" AccessibleHeaderText="LAST_FOUR" HeaderText="LAST_FOUR" DataField="LastFour" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="LastName" AccessibleHeaderText="LAST_NAME" HeaderText="LAST_NAME" DataField="LastName" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="FirstName" AccessibleHeaderText="FIRST_NAME" HeaderText="FIRST_NAME" DataField="FirstName" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="BirthDate" AccessibleHeaderText="BIRTH_DATE" HeaderText="BIRTH_DATE" DataField="BirthDate" DataFormatString="{0:d}" HtmlEncode="false" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Gender" AccessibleHeaderText="GENDER" HeaderText="GENDER" DataField="Gender" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="City" AccessibleHeaderText="CITY" HeaderText="CITY" DataField="City" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="State" AccessibleHeaderText="STATE" HeaderText="STATE" DataField="State" />
                    <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PostalCode" AccessibleHeaderText="POSTAL_CODE" HeaderText="POSTAL_CODE" DataField="PostalCode" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="dsResults" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="RESULTS_GET_ALL_BY_NAME" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
            <br />
        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>