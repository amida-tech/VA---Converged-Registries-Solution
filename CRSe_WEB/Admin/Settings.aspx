<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="CRSe_WEB.Admin.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPageTitle" runat="server" Text="Settings" Font-Size="X-Large" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />
    
    <asp:Table ID="tblSettings" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSqlCommandTimeout" runat="server" Text="Sql Command Timeout (In Seconds)" AssociatedControlID="txtSqlCommandTimeout" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtSqlCommandTimeout" runat="server" Width="400" ToolTip="Enter a value for Sql Command Timeout" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblLogFileSize" runat="server" Text="Log File Size (In Bytes)" AssociatedControlID="txtLogFileSize" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtLogFileSize" runat="server" Width="400" ToolTip="Enter a value for Log File Size" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblLogFileArchive" runat="server" Text="Log File Archive (In Days)" AssociatedControlID="txtLogFileArchive" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtLogFileArchive" runat="server" Width="400" ToolTip="Enter a value for Log File Archive" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblLogErrors" runat="server" Text="Log Errors" AssociatedControlID="listLogErrors" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listLogErrors" runat="server" Width="404" ToolTip="Select a value for Log Errors"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblLogInformation" runat="server" Text="Log Information" AssociatedControlID="listLogInformation" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listLogInformation" runat="server" Width="404" ToolTip="Select a value for Log Information"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblLogTiming" runat="server" Text="Log Timing" AssociatedControlID="listLogTiming" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listLogTiming" runat="server" Width="404" ToolTip="Select a value for Log Timing"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblDatabaseLogEnabled" runat="server" Text="Database Log Enabled" AssociatedControlID="listDatabaseLogEnabled" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listDatabaseLogEnabled" runat="server" Width="404" ToolTip="Select a value for Database Log Enabled"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
<%--        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblEventLogEnabled" runat="server" Text="Event Log Enabled" AssociatedControlID="listEventLogEnabled" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listEventLogEnabled" runat="server" Width="404" ToolTip="Select a value for Event Log Enabled"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>--%>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblFileLogEnabled" runat="server" Text="File Log Enabled" AssociatedControlID="listFileLogEnabled" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listFileLogEnabled" runat="server" Width="404" ToolTip="Select a value for File Log Enabled"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblFileLogPath" runat="server" Text="File Log Path" AssociatedControlID="txtFileLogPath" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFileLogPath" runat="server" Width="400" ToolTip="Enter a value for File Log Path" />&nbsp;&nbsp;
                <asp:HyperLink runat="server" ID="hypLnkFileLogPathView" Text="View File Log" ToolTip="Select to View File Log" NavigateUrl="~/Admin/SettingsLogView.aspx?query=1" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMviEnabled" runat="server" Text="MVI Enabled" AssociatedControlID="listMviEnabled" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listMviEnabled" runat="server" Width="404" ToolTip="Select a value for MVI Enabled"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMviProcessingCode" runat="server" Text="MVI Processing Code" AssociatedControlID="listMviProcessingCode" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="listMviProcessingCode" runat="server" Width="404" ToolTip="Select a value for MVI Processing Code"><asp:ListItem Text="False" Value="false" /><asp:ListItem Text="True" Value="true" /></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMviCertName" runat="server" Text="MVI Cert Name" AssociatedControlID="txtMviCertName" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtMviCertName" runat="server" Width="400" ToolTip="Enter a value for MVI Cert Name" />&nbsp;&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMviServiceUrl" runat="server" Text="MVI Service URL" AssociatedControlID="txtMviServiceUrl" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtMviServiceUrl" runat="server" Width="400" ToolTip="Enter a value for MVI Service URL" />&nbsp;&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblReportServerUrl" runat="server" Text="Report Server Url" AssociatedControlID="txtReportServerUrl" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtReportServerUrl" runat="server" Width="400" ToolTip="Enter a value for Report Server Url" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblReportServicePath" runat="server" Text="Report Service Path" AssociatedControlID="txtReportServicePath" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtReportServicePath" runat="server" Width="400" ToolTip="Enter a value for Report Service Path" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblReportBuilderPath" runat="server" Text="Report Builder Path" AssociatedControlID="txtReportBuilderPath" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtReportBuilderPath" runat="server" Width="400" ToolTip="Enter a value for Report Builder Path" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblEtlSchedule" runat="server" Text="Default ETL Schedule (Default Time)" AssociatedControlID="txtEtlSchedule" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEtlSchedule" runat="server" Width="400" ToolTip="Enter a value for Default ETL Schedule" />
                <ajax:TextBoxWatermarkExtender ID="wmEtlSchedule" runat="server" TargetControlID="txtEtlSchedule" WatermarkCssClass="watermark" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblEtlRetryAttempts" runat="server" Text="Number of ETL Retry Attempts" AssociatedControlID="txtEtlRetryAttempts" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtEtlRetryAttempts" runat="server" Width="400" ToolTip="Enter a value for Number of ETL Retry Attempts" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblEtlTimeBetweenAttempts" runat="server" Text="Time Between ETL Retry Attempts (In Minutes)" AssociatedControlID="txtEtlTimeBetweenAttempts" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtEtlTimeBetweenAttempts" runat="server" Width="400" ToolTip="Enter a value for Time Between ETL Retry Attempts" onkeypress="return CheckNumeric(event);" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblHomePageText" runat="server" Text="Home Page Text" AssociatedControlID="txtHomePageText" />&nbsp;&nbsp;</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtHomePageText" runat="server" MaxLength="2000" Width="400" TextMode="MultiLine" Rows="5" ToolTip="Enter a value for Home Page Text" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />

    <asp:Table ID="tblSaveForm" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" ToolTip="Select to save all Settings" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" ToolTip="Select to cancel changes" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />

    <asp:Literal runat="server" ID="litViewXML" />
    <asp:Label runat="server" ID="lblViewXML" />
</asp:Content>
