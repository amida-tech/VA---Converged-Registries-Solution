<%@ Page Title="Online Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructions.aspx.cs" Inherits="CRSe_WEB.Help.Instructions" %>
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
            <th>Using the Software</th>
        </tr>
        <tr>
            <td>This section describes the user interface only as it illustrates the back end functionality of Increment 1.</td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Registries and Cohorts</th>
        </tr>
        <tr>
            <td>
                <table>
                    <tr><td>This page will list all registries currently available within the application, dependent upon the administrators specific roles and permissions.  A CRS administrator will be able to view and manage any/all registries where as a Registry specific administrator will only be able to view and manage registries that they have access to.  CRS administrators will also have the ability to Create/Add new registries.</td></tr>
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
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Reports</th>
        </tr>
        <tr>
            <td>
            <table>
                <tr>
                    <td>
                        This page lists all generated common reports available and will provide the ability to edit, delete and generate common reports for reporting registry metrics and other general registry information. These reports include but are not limited to the following:
                    </td>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>Number of users by role</li>
                            <li>How often a registry is accessed (frequency)</li>
                            <li>Audit log report</li>
                            <li>Average time to complete a work stream</li>
                            <li>Average time to complete an activity</li>
                            <li>Listing of registries a patient is in</li>
                            <li>Listing of registries a provider is in</li>
                            <li>Number of patients in each registry</li>
                            <li>Patients without activity within user defined period</li>
                            <li>Edit hyperlink – used to edit details for specific generated common report.</li>
                            <li>Delete hyperlink – used to delete the specific generated common report from reports screen.</li>
                            <li>Add New Report hyperlink – used to create/add a new common report using SQL report builder tool.</li>
                        </ul>
                    </td>
                </tr>
            </table>
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
                                <td colspan="2">1.	Survey Administration </td>
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
                                <td colspan="2">2.	User Administration </td>
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
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <th>My Tasks</th>
        </tr>
        <tr>
            <td>
                My task page features the options to view and modify registries	
            </td>
        </tr>
        <tr>
            <td>•	Registry Links – Opens the registry to be managed / edited. Links change based off the registry selected</td>
        </tr>
        <tr>
            <td>
                •	Registry Info – Shows information for the registry.
                <ul>
                    <li>Default – Checkbox to set the registry as the default registry</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Patients – List of registry patients
                <ul>
                    <li>Add New Patient – opens fields to add new patient
                        <ul>
                            <li>Last Name – textbox for patient’s last name</li>
                            <li>First Name – textbox for patient’s first name</li>
                            <li>Search – button to search patients based off name criteria</li>
                            <li>Close Search – closes / hides the new patient fields</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Providers – List of registry providers
                <ul>
                    <li>Add New Provider – Opens fields to add new provider
                        <ul>
                            <li>Last Name – textbox for the provider’s last name</li>
                            <li>First Name – textbox for the provider’s first name</li>
                            <li>Search – button to search providers based off provider name criteria</li>
                            <li>Close Search – closes / hides the new provider fields</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Referrals – List of registry referrals
                <ul>
                    <li>Add New Referral – Opens fields to add new referral 
                        <ul>
                            <li>Last Name – textbox for the referral last name</li>
                            <li>First Name – textbox for the referral first name</li>
                            <li>Search – button to search referral based off referral name criteria</li>
                            <li>Close Search – closes / hides the new referral fields</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Work Stream – List of Work Streams
                <ul>
                    <li>Add New Work Stream – Opens fields to add new work stream
                        <ul>
                            <li>Continue – Returns user to Referrals</li>
                            <li>Patient Name – Textbox for patient name</li>
                            <li>Referral Date – Textbox for Referral Date</li>
                            <li>Work Stream – workstream dropdown list to select workstream</li>
                            <li>Case Number – textbox for case number</li>
                            <li>Case Start Date – textbox for case start date</li>
                            <li>Case Due Date – textbox for case due date</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Activities – List of Activities
                <ul>
                    <li>
                        Add New Activity – Opens fields to add new activity
                        <ul>
                            <li>Continue – Returns user to Work Stream</li>
                            <li>Unable To Delve Further</li>
                        </ul>
                    </li>                    
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	Surveys – List of Surveys
                <ul>
                    <li>Add New Survey – Opens fields to add new survey
                        <ul>
                            <li>Continue – Returns user to Referrals</li>
                            <li>Patient Name – Textbox for patient name</li>
                            <li>Survey – survey dropdown list to select survey</li>
                            <li>Survey Date – textbox to enter survey date</li>
                            <li>Save – saves information to add to survey menu list</li>
                            <li>Return to List – returns to survey menu list without saving</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                •	User-Defined Fields:
                <ul>
                    <li>“No User-Defined Fields Exist for this Registry”</li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>
