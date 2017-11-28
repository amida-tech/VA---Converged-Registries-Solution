<%@ Page Title="Online Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="CRSe_WEB.Help.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        SPAN.searchword { background-color:yellow; }
        table tr {vertical-align: top;} 
        table th {text-align: left;} 
    </style>
    <script src="../Scripts/TextHighlite.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <input type="button" value="Search text in current page" onclick="searchPrompt('Search Text', true, 'green', 'pink');" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <th>Administration </th>
        </tr>
        <tr>
            <td>
            <table>
                <tr>
                    <td>This page will list different items on the left – hand menu in which each item has its own administrator. The admin for that specific item will be presented with fields so that he can add, edit or delete them.</td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td colspan="2"><b>1.	Survey Administration</b></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    The administrator is presented with a list of existing surveys for the registry and has the option to add, edit, or delete surveys.  When adding a new survey, the user will enter a name, description, and will also be able to add new questions or prompts.  When editing a survey, the user is allowed to edit the name and description and will also see a list of existing questions or prompts that can each be
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Drop down list -  presents all available registries surveys </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Edit hyperlink - used to edit details for the specific survey such as Name, Code and Description of the survey.</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Delete hyperlink - used to delete the specific  survey  from the Survey Administration screen</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Add New Survey hyperlink - used to create/add a new survey by entering Name, Description and Code for the survey.</td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td colspan="2"><b>2.	User Administration</b></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    This page will list all available users within the application. The user administrator then can add/create, edit or delete specific users.  
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    Edit hyperlink - used to edit details of a specific user such as basic user information and user roles.<br />
                                    <table>
                                        <tr>
                                            <td>
                                                User Info – displays basic user information for that specific user for editing.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Role Info – displays system roles in a check box to select for that specific user and when selecting a specific registry from a drop down list, displays registry specific user roles to select for the user. 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Delete hyperlink - used to delete the specific user from the User Administration screen.  </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Add New User hyperlink - used to create/add a new user to the application.</td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <th><b>3.	Menu Administration</b></th>
                            </tr>
                            <tr>
                                <td>The Registry Administrator has the ability to add/create, edit or delete menu pages for available registries.  The core menu items will populate this section as follows:  Registry Home, Registry, Info, Patients, Providers, Referrals, Work Streams, Activities, Surveys, and User-Defined Fields.  Additional menu items can be added as necessary.  The Registry Administrator may also select the following available roles to be associated with the selected registry:  Administrator, Update and Read.</td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <th><b>4.	Settings</b></th>
                            </tr>
                            <tr>
                                <td>The user administrator has the ability to add/create, edit or delete the following settings:  SQL Command Timeout, Log File Size, Log File Archive, Log Errors, Log Information, Log Timing, Database Log Enabled, Event Log Enabled; File Log Path, Report Server URL, Report Service Path, and Report Builder Path.  </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
