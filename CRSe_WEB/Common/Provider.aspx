<%@ Page Title="Provider" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Provider.aspx.cs" Inherits="CRSe_WEB.Common.Provider" %>

<%@ Register Src="~/Controls/ViewProvider.ascx" TagPrefix="uc" TagName="ViewProvider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Provider" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />
    
    <asp:Table ID="tblLayout" runat="server" CssClass="tblForm">
        <asp:TableRow>
            <asp:TableCell><uc:ViewProvider ID="viewProvider" runat="server" ShowViewDetails="false" />&nbsp;</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:LinkButton ID="linkEdit" runat="server" Text="Edit Provider" ToolTip="Select to edit this Provider" OnClick="LinkEdit_Click" />
    <br /><br />

    <asp:Label ID="lblSubTitle" runat="server" Text="Referrals" Font-Size="Large" />
    <br /><br />
    <asp:Label ID="lblSearchFilter" runat="server" Text="Search By" AssociatedControlID="ddlSearch" />&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSearch" runat="server" ToolTip="Select to filter column view results" AutoPostBack="false">
        <asp:ListItem Text="Referral ID" Value="REFERRAL_ID" />
        <asp:ListItem Text="Registry" Value="REGISTRY_NAME" />
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
    <asp:TextBox runat="server" ToolTip="Enter Search Text" ID="txtSearch" Width="120px" />
    <asp:Button runat="server" ToolTip="Click to Search" ID="btnSearch" OnClick="BtnSearch_Click" Text="Search" />
    <asp:Button runat="server" ToolTip="Click to Clear Search" ID="btnClear" OnClick="BtnClear_Click" Text="Clear" />
    <br /><br />
    <asp:GridView ID="gridRegistry" runat="server" DataSourceID="dsRegistry" EmptyDataText="Currently no Referrals are available" 
        CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
        AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:TemplateField HeaderStyle-ForeColor="White" SortExpression="REFERRAL_ID" AccessibleHeaderText="REFERRAL_ID" HeaderText="REFERRAL_ID">
                <ItemTemplate>
                    <asp:LinkButton ID="linkSelect" runat="server" Text='<%# Eval("REFERRAL_ID") %>' OnClick="LinkSelect_Click" CommandArgument='<%# Eval("REFERRAL_ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="REGISTRY_NAME" AccessibleHeaderText="REGISTRY" HeaderText="REGISTRY" DataField="REGISTRY_NAME" />
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
    <asp:ObjectDataSource ID="dsRegistry" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="REFERRAL_GET_COMMON_BY_PROVIDER" OnSelecting="Ds_Selecting" SortParameterName="SORT_EXPRESSION" />
</asp:Content>
