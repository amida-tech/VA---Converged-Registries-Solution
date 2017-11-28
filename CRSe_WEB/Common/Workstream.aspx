<%@ Page Title="Work Stream" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workstream.aspx.cs" Inherits="CRSe_WEB.Common.Workstream" %>

<%@ Register Src="~/Controls/ViewWorkstream.ascx" TagPrefix="uc" TagName="ViewWorkstream" %>
<%@ Register Src="~/Controls/ViewReferral.ascx" TagPrefix="uc" TagName="ViewReferral" %>
<%@ Register Src="~/Controls/ViewPatient.ascx" TagPrefix="uc" TagName="ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Work Stream" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
        <asp:TableRow>
            <asp:TableCell><uc:ViewWorkstream ID="viewWorkstream" runat="server" ShowViewDetails="false" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewReferral ID="viewReferral" runat="server" />&nbsp;</asp:TableCell>
            <asp:TableCell><uc:ViewPatient ID="viewPatient" runat="server" />&nbsp;</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:LinkButton ID="linkEdit" runat="server" Text="Edit Work Stream" ToolTip="Select to edit this Work Stream" OnClick="LinkEdit_Click" />
    <br /><br />

    <asp:Button ID="btnResume" runat="server" Text="Resume" ToolTip="Select to Resume this Work Stream" OnClick="BtnResume_Click" />&nbsp;
    <asp:Button ID="btnPause" runat="server" Text="Pause" ToolTip="Select to Pause this Work Stream" OnClick="BtnPause_Click" />&nbsp;
    <asp:Button ID="btnTerminate" runat="server" Text="Terminate" ToolTip="Select to Terminate this Work Stream" OnClick="BtnTerminate_Click" OnClientClick='return confirm("Are you sure you want to terminate this Work Stream?");' />
    <br /><br />

    <asp:Label ID="lblSubTitle" runat="server" Text="Activities" Font-Size="Large" />
    <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
        <asp:ListItem Text="Activity ID" Value="WKF_CASE_ACTIVITY_ID" />
        <asp:ListItem Text="Activity Name" Value="STD_WKFACTIVITYTYPE.NAME" />
        <asp:ListItem Text="Status" Value="STD_WKFACTIVITYSTS.NAME" />
        <asp:ListItem Text="Contact Name" Value="CONTACT_NAME" />
        <asp:ListItem Text="Contact Email" Value="CONTACT_EMAIL" />
        <asp:ListItem Text="Contact Phone" Value="CONTACT_PHONE" />
        <asp:ListItem Text="Best Call Back Time" Value="BEST_CALL_BACK_TIME" />
        <asp:ListItem Text="Info Conveyed Text" Value="INFO_CONVEYED_TEXT" />
        <asp:ListItem Text="Info Received Text" Value="INFO_RECEIVED_TEXT" />
    </asp:DropDownList>
    <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
    <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
    <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
    <br /><br />
    <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Activities are available" 
        CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
        AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10">
        <Columns>
            <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="WKF_CASE_ACTIVITY_ID" AccessibleHeaderText="ACTIVITY_ID" HeaderText="ACTIVITY_ID">
                <ItemTemplate>
                    <asp:LinkButton ID="linkSelectActivity" runat="server" Text='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' OnClick="LinkSelectActivity_Click" CommandArgument='<%# Eval("WKF_CASE_ACTIVITY_ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFACTIVITYTYPE.NAME" AccessibleHeaderText="ACTIVITY_NAME" HeaderText="ACTIVITY_NAME" DataField="STD_WKFACTIVITYTYPE.NAME" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="STD_WKFACTIVITYSTS.NAME" AccessibleHeaderText="STATUS" HeaderText="STATUS" DataField="STD_WKFACTIVITYSTS.NAME" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_NAME" AccessibleHeaderText="CONTACT_NAME" HeaderText="CONTACT_NAME" DataField="CONTACT_NAME" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_EMAIL" AccessibleHeaderText="CONTACT_EMAIL" HeaderText="CONTACT_EMAIL" DataField="CONTACT_EMAIL" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CONTACT_PHONE" AccessibleHeaderText="CONTACT_PHONE" HeaderText="CONTACT_PHONE" DataField="CONTACT_PHONE" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="BEST_CALL_BACK_TIME" AccessibleHeaderText="BEST_CALL_BACK_TIME" HeaderText="BEST_CALL_BACK_TIME" DataField="BEST_CALL_BACK_TIME" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="INFO_CONVEYED_TEXT" AccessibleHeaderText="INFO_CONVEYED" HeaderText="INFO_CONVEYED_TEXT" DataField="INFO_CONVEYED_TEXT" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="INFO_RECEIVED_TEXT" AccessibleHeaderText="INFO_RECEIVED" HeaderText="INFO_RECEIVED_TEXT" DataField="INFO_RECEIVED_TEXT" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
</asp:Content>
