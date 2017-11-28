<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTasks.aspx.cs" Inherits="CRSe_WEB.Help.MyTasks" %>
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
            <th>My Tasks</th>
        </tr>
        <tr>
            <td><u>Purpose:</u>Location to view and modify registries.
            </td>
        </tr>
        <tr>
            <td><u>Functionality:</u></td>
        </tr>
        <tr>
            <td><b>Your Registries:</b>
                <ul>
                    <li>Registry Links – Opens the registry to be managed / edited. Links change based off the registry selected</li>
                    <li>Registry Info – Shows information for the registry.
                        <ul>
                            <li>Default – Checkbox to set the registry as the default registry</li>
                        </ul>
                    </li>
                    <li>Patients – List of registry patients
                        <ul>
                        <li>Add New Patient – opens fields to add new patient
                            <ul>
                                <li>Last Name – textbox for patient’s last name</li>
                                <li>First Name – textbox for patient’s first name</li>
                                <li>Search – button to search patients based off name criteria</li>
                                <li>Close Search – closes / hides the new patient fields</li>
                            </ul>
                        </li>
                        <li>Patients Table
                            <ul>
                                <li>Edit – Opens Patient Details. List of Read-Only Text Fields</li>
                                <li>Delete – Removes Patient from Patients List</li>
                                <li>Patient ID – Shows Patient Info and Referrals Listed to Patient
                                    <ul>
                                        <li>Referral ID – Opens Referral, Patient, and Provider Info
                                            <ul>
                                                <li>Patient View Details – Returns to Patient Table ID Selection</li>
                                                <li>Provider View Details – Returns to Provider Table ID Selection</li>
                                            </ul>
                                        </li>
                                        <li>Edit Patient – Opens Patient Details. List of Read-Only Text Fields</li>
                                    </ul>
                                </li>
                                <li>Referral ID – Opens Referral, Patient, and Provider Info
                                    <ul>
                                        <li>Activate – Activates Referral</li>
                                        <li>Disqualify – Disqualifies Referral</li>
                                        <li>Cancel – Returns to previous screen</li>
                                        <li>Duplicate – Creates copy of Referral</li>
                                        <li>Complete – Completes the Referral</li>
                                    </ul>
                                </li>
                                <li>Provider ID – Opens Provider Info with Referral Table List
                                    <ul>
                                        <li>Referral ID – Opens Referral, Patient, and 
                                            <ul>
                                                <li>Patient View Details – Returns to Patient Table ID Selection</li>
                                                <li>Provider View Details – Returns to Provider Table ID Selection</li>
                                            </ul>
                                        </li>
                                        <li>Edit Provider – Opens Provider Details. List of Read-Only Text Fields</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>
                <ul>
                    <li>Providers – List of registry providers
                    <ul>
                        <li>Add New Provider – Opens fields to add new provider
                            <ul>
                                <li>Last Name – textbox for the provider’s last name</li>
                                <li>First Name – textbox for the provider’s first name</li>
                                <li>Search – button to search providers based off provider name criteria</li>
                                <li>Close Search – closes / hides the new provider fields</li>
                            </ul>
                        </li>
                        <li>Edit – Opens Providers Details. List of Read-Only text fields</li>
                        <li>Delete – Removes provider from the provider table</li>
                        <li>Provider ID – Opens Provider Info with linked referrals
                            <ul>
                                <li>Referral ID – Opens Referral, Patient, Provider Info
                                    <ul>
                                        <li>Edit Provider – Opens Provider Details. List of Read-Only text fields</li>
                                        <li>Activate – Activates Referral</li>
                                        <li>Disqualify – Disqualifies Referral</li>
                                        <li>Cancel – Returns to Referral Screen</li>
                                        <li>Duplicate – Duplicates Referral</li>
                                        <li>Complete – Completes the Referral</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>
                <ul>
                    <li>Referrals – List of registry referrals
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
                    </li>
                    <li>Edit – Opens Referral Details. List of Read-Only text fields.</li>
                    <li>Delete – Removes referral from the table list.</li>
                    <li>Referral ID – Opens Referral, Patient, and Provider Info
                        <ul>
                            <li>Edit Referral – Opens Referral Details. List of read-only text fields.</li>
                            <li>Activate – Activates Referral</li>
                            <li>Disqualify – Disqualifies Referral</li>
                            <li>Cancel – Returns to Referral Screen</li>
                            <li>Duplicate – Duplicates Referral</li>
                            <li>Complete – Completes Referral</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>
                <ul>
                    <li>Work Stream – List of Work Streams
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
                            <li>Edit – Opens Work Streams Details
                                <ul>
                                    <li>Case Number – Text Field for Case Number</li>
                                    <li>All Other Fields Read-Only</li>
                                    <li>Save – Saves Work Stream</li>
                                    <li>Return To List – Returns to Work Stream Table</li>
                                </ul>
                            </li>
                            <li>Delete – Removes Work Stream from Table</li>
                            <li>Work Stream ID – Opens Work Stream, Referral, and Patient Info with associated Activities</li>
                            <li>Resume – Un-Pauses the Work Stream</li>
                            <li>Pause – Pauses the Work Stream</li>
                            <li>Terminate – Stops the Work Stream</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>
                <ul>
                    <li>Activities – List of Activities
                    <ul>
                        <li>
                            Add New Activity – Opens fields to add new activity
                            <ul>
                                <li>Work Stream – Selected Work Stream Activity is Added To</li>
                                <li>Activity – Drop Down to select activity</li>
                                <li>Contact Name – Text Field to add contact name</li>
                                <li>Contact Email – Text Field to add contact email</li>
                                <li>Contact Phone – Text Field to add contact Phone</li>
                                <li>Best Call Back Time – Text Field to add times for call back</li>
                                <li>Address Line 1 – Text Field to add standard address</li>
                                <li>Address Line 2 – Text Field to add additional address info</li>
                                <li>Address Line 3 – Text Field to add additional address info</li>
                                <li>City – Text Field to add City</li>
                                <li>State – Text Field to add State</li>
                                <li>Postal Code – Text Field to add Postal Code</li>
                                <li>Country – Text Field to add Country</li>
                                <li>Info Conveyed – Multi-Line Text Field to add Conveyed Info. </li>
                                <li>Info Received – Multi-Line Text Field to add Received Info</li>
                                <li>Save – Saves Activity</li>
                                <li>Return to List – Returns to Activity List without Saving</li>
                            </ul>
                        </li>
                        <li>Edit – Opens Activity Details
                            <ul>
                                <li>Work Stream – Read-Only Text Field of Work Stream Name</li>
                                <li>Activity – Read-Only Drop Down List of Activity Name</li>
                                <li>Contact Name – Text Field to add contact name</li>
                                <li>Contact Email – Text Field to add contact email</li>
                                <li>Contact Phone – Text Field to add contact Phone</li>
                                <li>Best Call Back Time – Text Field to add times for call back</li>
                                <li>Address Line 1 – Text Field to add standard address</li>
                                <li>Address Line 2 – Text Field to add additional address info</li>
                                <li>Address Line 3 – Text Field to add additional address info</li>
                                <li>City – Text Field to add City</li>
                                <li>State – Text Field to add State</li>
                                <li>Postal Code – Text Field to add Postal Code</li>
                                <li>Country – Text Field to add Country</li>
                                <li>Info Conveyed – Mutli-Line Text Field to add Conveyed Info. </li>
                                <li>Info Received – Multi-Line Text Field to add Received Info</li>
                                <li>Save – Saves changes to Activity</li>
                                <li>Return to List – Returns to Activity List without Saving</li>
                            </ul>
                        </li>
                        <li>Delete – Removes Activity from Activity Table</li>
                        <li>Activity ID – Opens Activity, Work Stream, Referral, Patient Info
                            <ul>
                                <li>Edit Activity Opens Activity Details </li> 
                                <li>Work Stream – Read-Only Text Field of Work Stream Name</li>
                                <li>Activity – Read-Only Drop Down List of Activity Name</li>
                                <li>Contact Name – Text Field to add contact name</li>
                                <li>Contact Email – Text Field to add contact email</li>
                                <li>Contact Phone – Text Field to add contact Phone</li>
                                <li>Best Call Back Time – Text Field to add times for call back</li>
                                <li>Address Line 1 – Text Field to add standard address</li>
                                <li>Address Line 2 – Text Field to add additional address info</li>
                                <li>Address Line 3 – Text Field to add additional address info</li>
                                <li>City – Text Field to add City</li>
                                <li>State – Text Field to add State</li>
                                <li>Postal Code – Text Field to add Postal Code</li>
                                <li>Country – Text Field to add Country</li>
                                <li>Info Conveyed – Mutli-Line Text Field to add Conveyed Info. </li>
                                <li>Info Received – Multi-Line Text Field to add Received Info</li>
                                <li>Save – Saves changes to Activity</li>
                                <li>Return to List – Returns to Activity List without Saving</li>
                            </ul>
                        </li>
                        <li>Start – Starts the Activity</li>
                        <li>Resume – Un-Pauses the Activity</li>
                        <li>Pause – Pauses the Activity</li>
                        <li>Complete – Completes the Activity</li>
                        <li>Terminate – Stops the Activity</li>
                    </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>
                <ul>
                    <li>Surveys – List of Surveys
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
                            <li>Edit – Opens Survey Details. Read-Only Text Fields.</li>
                            <li>Delete – Removes Survey from Survey List</li>
                            <li>Survey ID – Opens Survey Questionnaire
                                <ul>
                                    <li>Has options to select answer to each survey questionnaire</li>
                                    <li>Save – Saves Survey</li>
                                    <li>Save and Complete – Saves and Completes survey questionnaire</li>
                                    <li>Return to List – returns to survey list</li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
        <tr >
            <td>                
                <ul>
                    <li>User-Defined Fields:
                        <ul>
                            <li>Shows Text Fields Defined by User</li>
                            <li>Save – Saves the User Defined Fields</li>
                            <li>Return To List – Returns to Referrals List	</li>
                        </ul>
                    </li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>
