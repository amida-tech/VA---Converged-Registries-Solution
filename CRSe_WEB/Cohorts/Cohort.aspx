<%@ Page Title="Cohort Criteria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cohort.aspx.cs" Inherits="CRSe_WEB.Cohorts.Cohort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Cohort Criteria" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:LinkButton ID="linkSchedule" runat="server" OnClick="LinkSchedule_Click" />
            <br /><br />

            <asp:Panel ID="pnlSchedule" runat="server"><%-- BorderWidth="1" BorderStyle="Solid" BorderColor="White">--%>

                <asp:Label ID="lblScheduleManual" runat="server" Text="Update schedule for manually added referrals" AssociatedControlID="rblScheduleManual" />
                <br />
                <asp:RadioButtonList ID="rblScheduleManual" runat="server">
                    <asp:ListItem Value="0" Text="No Schedule" />
                    <asp:ListItem Value="1" Text="Daily" />
                    <asp:ListItem Value="2" Text="Weekly" />
                </asp:RadioButtonList>
                <br /><br />

                <asp:Label ID="lblScheduleAuto" runat="server" Text="Update schedule for automatically added referrals" AssociatedControlID="rblScheduleAuto" />
                <br />
                <asp:RadioButtonList ID="rblScheduleAuto" runat="server" OnSelectedIndexChanged="RblScheduleAuto_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0" Text="No Schedule" />
                    <asp:ListItem Value="1" Text="Daily" />
                    <asp:ListItem Value="2" Text="Weekly" />
                </asp:RadioButtonList>
                <br />

                <asp:Label ID="lblScheduleAutoTime" runat="server" Text="Scheduled Time" AssociatedControlID="listScheduleAutoTime" />
                &nbsp;&nbsp;
                <asp:DropDownList ID="listScheduleAutoTime" runat="server">
                    <asp:ListItem Value="0" Text="No Preference" />
                    <asp:ListItem Value="1" Text="1:00 AM" />
                    <asp:ListItem Value="2" Text="2:00 AM" />
                    <asp:ListItem Value="3" Text="3:00 AM" />
                    <asp:ListItem Value="4" Text="4:00 AM" />
                    <asp:ListItem Value="5" Text="5:00 AM" />
                </asp:DropDownList>
                <br /><br />
                <br /><br />

            </asp:Panel>

            <asp:Label ID="lblDobMin" runat="server" Text="DOB Min *" AssociatedControlID="txtDobMin" />&nbsp;
            <asp:TextBox ID="txtDobMin" runat="server" ToolTip="Enter a minimum Date of Birth value for Cohort criteria" MaxLength="10" onkeypress="return CheckDate(event);" />
            <ajax:CalendarExtender runat="server" ID="calDobMin" Animated="false" TargetControlID="txtDobMin" />&nbsp;
            <asp:Label ID="lblDobMax" runat="server" Text="DOB Max *" AssociatedControlID="txtDobMax" />&nbsp;
            <asp:TextBox ID="txtDobMax" runat="server" ToolTip="Enter a maximum Date of Birth value for Cohort criteria" MaxLength="10" onkeypress="return CheckDate(event);" />
            <ajax:CalendarExtender runat="server" ID="calDobMax" Animated="false" TargetControlID="txtDobMax" />
            &nbsp;
            
            <ajax:TextBoxWatermarkExtender ID="wmDobMin" runat="server" TargetControlID="txtDobMin" WatermarkCssClass="watermark" />
            <ajax:TextBoxWatermarkExtender ID="wmDobMax" runat="server" TargetControlID="txtDobMax" WatermarkCssClass="watermark" />
            
            <br /><br />

            <asp:Table ID="tblCategories" runat="server">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">Available Categories</asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" Width="100"></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">Selected Categories</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ListBox ID="listSource" runat="server" Width="200px" Rows="10" SelectionMode="Multiple" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="100">
                        <asp:Button ID="btnAddAll" runat="server" Text="►►" ToolTip="Add All" Width="50" OnClick="BtnAddAll_Click" /><br /><br />
                        <asp:Button ID="btnAddOne" runat="server" Text="►" ToolTip="Add Selected" Width="50" OnClick="BtnAddOne_Click" /><br /><br />
                        <asp:Button ID="btnRemOne" runat="server" Text="◄" ToolTip="Remove Selected" Width="50" OnClick="BtnRemOne_Click" /><br /><br />
                        <asp:Button ID="btnRemAll" runat="server" Text="◄◄" ToolTip="Remove All" Width="50" OnClick="BtnRemAll_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ListBox ID="listDestination" runat="server" Width="200px" Rows="10" SelectionMode="Multiple" OnSelectedIndexChanged="ListDestination_SelectedIndexChanged" AutoPostBack="true" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <br /><br />

            <asp:Label ID="lblCategories" runat="server" Font-Bold="true" Font-Underline="true" />
            <br />
            <asp:CheckBox ID="chkAll" runat="server" Text="Toggle All" ToolTip="Select to toggle all check boxes" AutoPostBack="true" OnCheckedChanged="ChkAll_CheckedChanged" />
            <br />
            <asp:CheckBoxList ID="listCategories" runat="server" OnSelectedIndexChanged="ListCategories_SelectedIndexChanged" AutoPostBack="true" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <asp:Table ID="tblForm2" runat="server" style="width:100%; display:inline;">
        <asp:TableRow>
            <asp:TableCell Width="25%">
                <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Select to save and go back" OnClick="BtnBack_Click" />
            </asp:TableCell>
            <asp:TableCell Width="50%" HorizontalAlign="Center">
                <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="BtnPreview_Click" ToolTip="Select to preview Cohort results based on selected criteria" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSave1" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save selected Cohort criteria" />
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" ToolTip="Select to clear or undo changes made to Cohort criteria" />
            </asp:TableCell>
            <asp:TableCell Width="25%" HorizontalAlign="Right">
                <asp:Button ID="btnNext" runat="server" Text="Next" ToolTip="Select to save and continue" OnClick="BtnNext_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />

    <asp:Panel ID="pnlPreview" runat="server" CssClass="modalPopup" style="display:none;">
        <div class="modalPopupTitle">&nbsp;&nbsp;<asp:Label ID="lblCohortPreview" runat="server" Text="Preview" /></div>
        <br />
        <asp:Label ID="lblRecordCount" runat="server" />

        <br /><br />

        <asp:Table ID="tblForm" runat="server" style="width:100%;">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="btnSave2" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save selected Cohort criteria" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Close Preview" OnClick="BtnCancel_Click" ToolTip="Select to close preview and continue making changes to Cohort criteria" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
    </asp:Panel>

    <asp:Button ID="btnHide" runat="server" style="display:none;" />

    <ajax:ModalPopupExtender ID="mpePreview" runat="server" 
        BackgroundCssClass="modalBackground" CancelControlID="btnCancel" PopupControlID="pnlPreview" TargetControlID="btnHide"  />

</asp:Content>
