<%@ Page Title="Registry Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistryInfo.aspx.cs" Inherits="CRSe_WEB.Common.RegistryInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblRegistryInfo" runat="server" Text="Registry Information" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:Table ID="tblRegistryInfo" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryName" runat="server" Text="Registry Name:" AssociatedControlID="lblRegistryNameValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryNameValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryCode" runat="server" Text="Abbreviation:" AssociatedControlID="lblRegistryCodeValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryCodeValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryDescription" runat="server" Text="Description:" AssociatedControlID="lblRegistryDescriptionValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryDescriptionValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryStatus" runat="server" Text="Status:" AssociatedControlID="lblRegistryStatusValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryStatusValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryDefault" runat="server" Text="Default:" AssociatedControlID="chkRegistryDefault" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:CheckBox ID="chkRegistryDefault" runat="server" Text="Set as default Registry" ToolTip="Select to set as default Registry" AutoPostBack="true" OnCheckedChanged="ChkRegistryDefault_CheckedChanged" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br /><br />
    <asp:Label ID="lblContactInfo" runat="server" Text="Contact Information" Font-Size="X-Large" />
    <br /><br />

    <asp:Table ID="tblContactInfo" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryOwner" runat="server" Text="Registry Owner:" AssociatedControlID="lblRegistryOwnerValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryOwnerValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblRegistryAdministrator" runat="server" Text="Registry Administrator:" AssociatedControlID="lblRegistryAdministratorValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblRegistryAdministratorValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSupportContact" runat="server" Text="Support Contact:" AssociatedControlID="lblSupportContactValue" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblSupportContactValue" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br /><br />
    <asp:Label ID="lblEtlInfo" runat="server" Text="ETL Dashboard" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
        <asp:ListItem Text="ID" Value="ID" />
        <asp:ListItem Text="CDW_Table_View_Name" Value="CDW_Table_View_Name" />
        <asp:ListItem Text="ExtractBatchID" Value="ExtractBatchID" />
        <asp:ListItem Text="ETLBatchID" Value="ETLBatchID" />
        <asp:ListItem Text="ExtractDateTime" Value="ExtractDateTime" />
        <asp:ListItem Text="Registry_ID" Value="Registry_ID" />
        <asp:ListItem Text="ETL_Name" Value="ETL_Name" />
        <asp:ListItem Text="ETL_StepName" Value="ETL_StepName" />
        <asp:ListItem Text="CountStage" Value="CountStage" />
        <asp:ListItem Text="CountFinal" Value="CountFinal" />
        <asp:ListItem Text="UserName" Value="UserName" />
    </asp:DropDownList>
    <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px"></asp:TextBox>
    <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
    <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
    <br /><br />
    <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry"
        EmptyDataText="Currently no ETL Information is available"
        CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
        AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ID" AccessibleHeaderText="ID" HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CDW_Table_View_Name" AccessibleHeaderText="CDW_Table_View_Name" HeaderText="CDW_Table_View_Name" DataField="CDW_Table_View_Name" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ExtractBatchID" AccessibleHeaderText="ExtractBatchID" HeaderText="ExtractBatchID" DataField="ExtractBatchID" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ETLBatchID" AccessibleHeaderText="ETLBatchID" HeaderText="ETLBatchID" DataField="ETLBatchID" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ExtractDateTime" AccessibleHeaderText="ExtractDateTime" HeaderText="ExtractDateTime" DataField="ExtractDateTime" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Registry_ID" AccessibleHeaderText="Registry_ID" HeaderText="Registry_ID" DataField="Registry_ID" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ETL_Name" AccessibleHeaderText="ETL_Name" HeaderText="ETL_Name" DataField="ETL_Name" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="ETL_StepName" AccessibleHeaderText="ETL_StepName" HeaderText="ETL_StepName" DataField="ETL_StepName" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CountStage" AccessibleHeaderText="CountStage" HeaderText="CountStage" DataField="CountStage" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="CountFinal" AccessibleHeaderText="CountFinal" HeaderText="CountFinal" DataField="CountFinal" />
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="UserName" AccessibleHeaderText="UserName" HeaderText="UserName" DataField="UserName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
</asp:Content>
