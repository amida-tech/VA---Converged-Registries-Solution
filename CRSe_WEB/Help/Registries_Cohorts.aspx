<%@ Page Title="Online Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registries_Cohorts.aspx.cs" Inherits="CRSe_WEB.Help.Registries_Cohorts" %>
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
            <th>Registries and Cohorts</th>
        </tr>
        <tr>
            <td>
                <table>
                    <tr><td><u>Purpose:</u> Manage, Edit, and Create new Registries and Cohorts using an initial paginated table. Access is restricted based on User Role and Permissions.</td></tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Edit hyperlink – used to edit details for the associated registry</li>
                                <li>Delete hyperlink – used to delete the associated registry from all CRSe screens</li>
                                <li>Name hyperlink – shortcut used to continue and/or update Registry Wizard details or Registry specific settings</li>
                                <li>Paging hyperlink – only ten registries will display at a time and so the paging hyperlinks can be used to navigate through the list of registries</li>
                                <li>Add New Registry hyperlink – used to start the Registry Wizard process and create/add a new Registry</li>
                            </ul>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <th><u>Functionality: </u></th>
                    </tr>
                    <tr>
                        <td><b>ALL PAGES:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Save Button – Saves information to the registry, allowing it to be viewable on the Main Page menu</li>
                                <li>Return To List – Returns to Main Page menu, without saving</li>
                                <li>Back – Takes the user one screen back</li>
                                <li>Next – Takes the user one screen forward</li>
                                <li>Reset – Returns page to pre-edited version</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>MAIN PAGE:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Edit – Edit Record Details</li>
                                <li>Delete – Removes record from Menu / application viewables</li>
                                <li>Name – Edit Cohort Criteria Menu to define the Registry / Cohort</li>
                                <li>Pagination – Moves through the pages of the menu at intervals of 10</li>
                                <li>Create New – creates a new record</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>EDIT & CREATE NEW:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Registry Info Tab:
                                    <ul>
                                        <li>Tab Button – Takes you to the registry tab</li>
                                        <li>Registry Name – Textbox for entering registry name</li>
                                        <li>Abbreviation – Textbox for setting registry abbreviation</li>
                                        <li>Description – Multi-Line Textbox for setting Registry Description</li>
                                    </ul>
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Contact Info Tab:
                                    <ul>
                                        <li>Tab Button – Takes you to the Contact Info tab</li>
                                        <li>Registry Owner - user drop down to select registry owner</li>
                                        <li>Registry Administrator – user drop down to select registry administrator </li>
                                        <li>Support Contact – user drop down to select registry support contact</li>
                                        <li>New User – Opens Add New User Popup</li>
                                    </ul>
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Contact Info Tab:
                                    <ul>
                                        <li>Tab Button – Takes you to the Contact Info tab</li>
                                        <li>Registry Owner - user drop down to select registry owner</li>
                                        <li>Registry Administrator – user drop down to select registry administrator </li>
                                        <li>Support Contact – user drop down to select registry support contact</li>
                                        <li>New User – Opens Add New User Popup
                                            <ul>
                                                <li>Last Name – Textbox for searching last name</li>
                                                <li>First Name – Textbox for searching first name</li>
                                                <li>Search – Searches textbox criteria</li>
                                                <li>Close Search – Closes Search popup</li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>COHORT DEFINITIONS MENU:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Cohort Criteria – Opens Corresponding Page</li>
                                <li>Framework Data – Opens Corresponding Page</li>
                                <li>User-Defined Fields – Opens Corresponding Page</li>
                                <li>Work Streams – Opens Corresponding Page</li>
                                <li>Activities – Opens Corresponding Page</li>
                                <li>Registries and Cohorts – Returns to main page menu</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>COHORT CRITERIA:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Show/Hide Schedule – shows or hides the schedule parameters</li>
                                <li>Manual Schedule Radio Button List – Selects when to manually add referrals to schedule</li>
                                <li>Automatic Schedule Radio Button List – Selects when to automatically add referrals to schedule</li>
                                <li>Schedule Time – dropdown list holding 5 times to select when updates occur</li>
                                <li>DOB Min – Textbox for minimum birthdate for filtering</li>
                                <li>DOB Max – Textbox for maximum birthdate for filtering</li>
                                <li>Available / Selected Categories – Selectable Menu for setting categories</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>FRAMEWORK DATA:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Available / Selected Categories – Selectable Menu for setting categories</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>USER-DEFINED FIELDS:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Add New Field – Shows new fields to add a new field
                                    <ul>
                                        <li>Name – textbox for the name of user-defined field</li>
                                        <li>Code – textbox for the code of user-defined field</li>
                                        <li>Description – multi-line textbox for the description of user-defined field</li>
                                    </ul>
                                </li>
                                <li>Edit – Opens the fields for editing a user-defined field</li>
                                <li>Delete – Removes the user-defined field from view / use</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>WORK STREAMS:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Add New Workstream – Shows new fields to add a new work stream
                                    <ul>
                                        <li>Name – textbox for the name of work stream</li>
                                        <li>Code – textbox for the code of work stream</li>
                                        <li>Sort Order – textbox to set number to order work streams</li>
                                        <li>Description – multi-line textbox to insert a work stream description</li>
                                        <li>Automatically Created – Checkbox to automatically create a work stream when a referral is created in system</li>
                                    </ul>
                                </li>
                                <li>Edit – Opens the fields for editing a work stream</li>
                                <li>Delete – Removes the work stream from view / use</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td><b>ACTIVITIES:</b></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>Add New Activity – Shows new fields to add a new activity
                                    <ul>
                                        <li>Workstream – work stream drop down to set for the activity</li>
                                        <li>Name – textbox for the name of the activity</li>
                                        <li>Code – textbox for the code of the activity</li>
                                        <li>Sort Order – textbox to set number to order activities</li>
                                        <li>Description – multi-line textbox to set activity description</li>
                                        <li>Automatically Created – Checkbox to automatically create activity when workstream is created in system</li>
                                    </ul>
                                </li>
                                <li>Edit – Opens the fields for editing an activity</li>
                                <li>Delete – Removes the activity from view / use</li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
