<%@ Page Title="BCR Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRSe_WEB.Custom.BCR.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="BCR Search" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />
    
    <asp:Panel ID="pnlSearch" runat="server">
        <asp:Label ID="lblFacilities" runat="server" Text="Select Facility:" AssociatedControlID="listFacilities" />&nbsp;&nbsp;
        <asp:DropDownList ID="listFacilities" runat="server" ToolTip="Select a Facility" 
            DataSourceID="dsFacilities" DataValueField="FACID" DataTextField="FACTEXT" 
            AutoPostBack="true" OnDataBound="ListFacilities_DataBound" OnSelectedIndexChanged="ListFacilities_SelectedIndexChanged" />
        <asp:ObjectDataSource ID="dsFacilities" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="STD_INSTITUTION_GET_FACS" OnSelecting="DsFacilities_Selecting" />
        <br /><br />
        <asp:Label ID="lblPatient" runat="server" Text="Search for Patient:" AssociatedControlID="txtPatient" />&nbsp;&nbsp;
        <asp:TextBox ID="txtPatient" runat="server" />&nbsp;&nbsp;
        <asp:Button ID="btnPatient" runat="server" Text="Search" ToolTip="Select to Search for Patient" OnClick="BtnPatient_Click" />
        <ajax:TextBoxWatermarkExtender ID="wmPatient" runat="server" TargetControlID="txtPatient" WatermarkCssClass="watermark" />
    </asp:Panel>
    <asp:Panel ID="pnlFacility" runat="server">
        <br /><br />
        <asp:Label ID="lblFacilityNameLabel" runat="server" Font-Bold="true" Text="Facility Name:" AssociatedControlID="lblFacilityName" />&nbsp;&nbsp;
        <asp:Label ID="lblFacilityName" runat="server" />
        <br /><br />
        <asp:Label ID="lblFacilityCodeLabel" runat="server" Font-Bold="true" Text="Facility Code:" AssociatedControlID="lblFacilityCode" />&nbsp;&nbsp;
        <asp:Label ID="lblFacilityCode" runat="server" />
        <br /><br />
        <asp:Label ID="lblVistaNameLabel" runat="server" Font-Bold="true" Text="VISTA Name:" AssociatedControlID="lblVistaName" />&nbsp;&nbsp;
        <asp:Label ID="lblVistaName" runat="server" />
        <br /><br />
        <asp:Label ID="lblVisnLabel" runat="server" Font-Bold="true" Text="VISN:" AssociatedControlID="lblVisn" />&nbsp;&nbsp;
        <asp:Label ID="lblVisn" runat="server" />
        <br /><br />
        <asp:Label ID="lblAddressLabel" runat="server" Font-Bold="true" Text="Address:" AssociatedControlID="lblAddress" />&nbsp;&nbsp;<br />
        <asp:Label ID="lblAddress" runat="server" />
        <br /><br />
        <asp:Label ID="lblFacilityTypeLabel" runat="server" Font-Bold="true" Text="Facility Type:" AssociatedControlID="lblFacilityType" />&nbsp;&nbsp;
        <asp:Label ID="lblFacilityType" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnlPatients" runat="server">
        <br /><br />
        <asp:GridView ID="gridPatients" runat="server" DataSourceID="dsPatients" EmptyDataText="Currently no Patients are available" 
            CssClass="gridRegistry" PagerStyle-CssClass="pager" EmptyDataRowStyle-CssClass="gridRegistryEmpty"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10" Width="800px">
            <Columns>
                <asp:TemplateField ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkSelect" runat="server" Text="Select" OnClick="LinkSelect_Click" CommandArgument='<%# Eval("PatientSID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="VAID" AccessibleHeaderText="VAID" HeaderText="VAID" DataField="VAID" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="PatientName" AccessibleHeaderText="PatientName" HeaderText="PatientName" DataField="PatientName" />
                <asp:BoundField HeaderStyle-ForeColor="White" SortExpression="Sta3n" AccessibleHeaderText="Facility" HeaderText="Facility" DataField="Sta3n" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="dsPatients" runat="server" TypeName="CRSe_WEB.BaseCode.ServiceInterfaceManager" SelectMethod="BCCCR_BCR_ALL_GET_ALL_BY_SEARCH" OnSelecting="DsPatients_Selecting" SortParameterName="SORT_EXPRESSION" />
    </asp:Panel>
</asp:Content>
