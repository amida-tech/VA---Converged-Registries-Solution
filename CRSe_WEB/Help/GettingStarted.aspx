<%@ Page Title="Online Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GettingStarted.aspx.cs" Inherits="CRSe_WEB.Help.GettingStarted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        SPAN.searchword { background-color:yellow; }
        table tr {vertical-align: top;} 
        table th {text-align: left;} 

        table#t01 {
            width: 100%; 
             border:0px solid grey;
        } 
        table#t01 td {
            border:2px solid grey;
            padding:5px;
        }
        table#t01 th {
            border:2px solid grey;
            padding:8px;
        }

        table#t012 {
            width: 100%; 
             border:1px solid grey;
        } 
        table#t012 td {
            border:0px solid grey;
            padding:5px;
        }
        table#t012 th {
            border:0px solid grey;
            padding:8px;
        }
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
            <th>Getting Started</th>
        </tr>
        <tr>
            <td>
                <p>The table below contains each of the major components and functions of a CRSe Registry.  It provides questions one would ask a Registry Administrator or related Stakeholder to produce enough information to build such a registry.</p>
            </td>
        </tr>
    </table>
    <table style="width:95%">
        <tr>
            <th>Table 1 – Registry Configuration Worksheet</th>
        </tr>
        <tr>
            <td><p>The table below contains each of the major components and functions of the CRSe Registry.  It provides questions one would ask a Registry Administrator or related Stakeholder to produce enough information to build such a registry.</p></td>
        </tr>
        <tr>
            <td>
                <table id="t01">
                    <tr>
                        <th>Registry Data Elements</th>
                        <th>Survey Requirements (to be provided by the Registry Administrator)</th>
                        <th>Stakeholder Response Options</th>
                        <th>BCR Specific (Highlighted)</th>
                    </tr>
                    <tr>
                        <td>Registry Identification</td>
                        <td>
                            <ol>
                                <li>Provide display name</li>
                                <li>Provide formal acronym</li>
                                <li>Provide Administrator information</li>
                            </ol>
                        </td>
                        <td>
                            <ol>
                                <li>Registry Full Name </li>
                                <li>Registry Short/Abbreviated Name </li>
                                <li>Registry Administrator</li>
                            </ol>
                        </td>
                        <td>
                            <b>Registry Info Tab:</b>
                            <ol>
                                <li>Registry Full Name</li>
                                <li>Registry Short/Abbreviated Name</li>
                                <li>Registry Description</li>
                            </ol>
                            <br />
                            Contact Info Tab:
                            <ol>
                                <li>Registry Owner</li>
                                <li>Registry Admin</li>
                                <li>Support Contact</li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td>Cohort Criteria</td>
                        <td>Define patient data to be included in the specific registry </td>
                        <td>
                            <b>Available Fields:</b> 
                            <ol>
                                <li>DOB max/min</li>
                                <li>Schedule to add referrals</li>
                                <li>Select available categories</li>
                            </ol>
                        </td>
                        <td>
                            <b>Specific to BCR:  Select BCR Cohort by:</b>
                            <ol>
                                <li>Stop Codes (needs to be expanded to show all Codes for BCR)</li>
                                <li>Health Factors (need to be expanded to show all HF for BCR
                                    <ul>
                                        <li>All Women Health</li>
                                    </ul>
                                </li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td>Framework Data</td>
                        <td>User will have the ability to select from the 42 core data options </td>
                        <td>
                            <b>Available Options: </b>
                            <ol>
                                <li>Patient</li>
                                <li>Patient – Demographics </li>
                                <li>Patient – Eligibility </li>
                                <li>Patient – Eligibility </li>
                                <li>Patient – Enrollment </li>
                                <li>Patient – Ethnicity </li>
                                <li>Patient – Geo Coded Address </li>
                                <li>Patient – Insurance </li>
                                <li>Patient – Insurance </li>
                                <li>Patient - Laboratory (Embedded Fragments) </li>
                                <li>Patient - Laboratory (Embedded Fragments) </li>
                                <li>Patient - Military Service </li>
                                <li>Patient - Military Sexual Trauma </li>
                                <li>Patient - OEF/OIF </li>
                                <li>Patient - Period of Service </li>
                                <li>Patient – Race </li>
                                <li>Patient - Radium Exposure </li>
                                <li>Patient - Service Connected Condition </li>
                                <li>Patient - VA Rated Disability </li>
                                <li>Outpatient </li>
                                <li>Inpatient </li>
                                <li>Inpatient – Census </li>
                                <li>Laboratory </li>
                                <li>Patient- Pharmacy </li>
                                <li>Pharmacy – Inpatient </li>
                                <li>Pharmacy – Inpatient </li>
                                <li>Pharmacy - Inpatient Unit Dose </li>
                                <li>Pharmacy - Non-VA </li>
                                <li>Pharmacy – Outpatient </li>
                                <li>Problem List </li>
                                <li>Consult </li>
                                <li>Emergency Department </li>
                                <li>Progress Notes </li>
                                <li>Radiology </li>
                                <li>Radiology </li>
                                <li>Vital Sign </li>
                                <li>Audiology </li>
                                <li>Allergy </li>
                                <li>Health Factor </li>
                                <li>Immunization </li>
                                <li>Patient – Consult </li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR<br />custom tables from A06 </b></td>
                    </tr>
                    <tr>
                        <td>User Defined Fields</td>
                        <td>Free text information that is registry and patient specific </td>
                        <td>
                            <b>Available Fields</b>
                            <ol>
                                <li>Name</li>
                                <li>Code</li>
                                <li>Description</li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR</b></td>
                    </tr>
                    <tr>
                        <td>Work Streams </td>
                        <td>Free text information that is associated with activities </td>
                        <td>
                            <b>Available Fields</b>
                            <ol>
                                <li>Name</li>
                                <li>Code</li>
                                <li>Sort Order</li>
                                <li>Description</li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR</b></td>
                    </tr>
                    <tr>
                        <td>Activities </td>
                        <td>Free text information that can be added to a work stream</td>
                        <td>
                            <b>Available Fields</b>
                            <ol>
                                <li>Work stream</li>
                                <li>Name</li>
                                <li>Code</li>
                                <li>Sort Order</li>
                                <li>Description</li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR</b></td>
                    </tr>                    
                    <tr>
                        <td>Registry Users and User Roles (select Administration tab)</td>
                        <td>Found in the left Navigation Menu under <b>“User Administration”</b> tab. 
                            <ol>
                                <li>Will this registry utilize the Standard Users? </li>
                                <li>List additional users (if required) </li>
                            </ol>
                        </td>
                        <td>
                            <b>Standard Users:</b>
                            <table id="t012">
                                <tr>
                                    <td>System Administrator:  
                                        <ul>
                                            <li>Can initiate Registry Wizard to create and configure new registries as well as edit existing registry configurations. </li>
                                            <li>Can edit existing registry configurations </li>
                                            <li>Can create new datasets when framework datasets need to be </li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>Registry Administrator</b>: Can add and remove users into roles up to and including Registry Administrator; Can add and edit workflows; Can add and edit surveys  </td></tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>System Update</b>:  Can access administration section, but can access all other sections (reports, work streams, activities) </td></tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>System Read-only</b>: Can access administration section; Can view work streams and activities; Cannot enter patient information Authorized roles table in CRSe platform </td></tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>Registry Specific Admin/CRSe Admin</b>:   Can add users but cannot create registries; Can update all registry settings; Can only see users in assigned registry</td></tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>Registry Update</b>:   Can view information;  Can  update patient information v</tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr><td><b>Registry Read-only User</b>: Can only view registry information (patient list, work streams, activities) </td></tr>
                            </table>
                        </td>
                        <td>
                            <b>BCR USERS:</b>
                            <ol>
                                <li>VHA Health Services</li>
                                <li>Clinicians</li>
                                <li>BCR Local Admin</li>
                                <li>BCR System Admin</li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td>Define Survey Administration <i>(select Administration tab)</i></td>
                        <td>Free text to design registry specific surveys<br />Found in the left Navigation Menu under <b>“Survey Administration”</b> tab. </td>
                        <td>
                            <b>Available Fields</b>
                            <ol>
                                <li>Available Registries</li>
                                <li>Name</li>
                                <li>Code</li>
                                <li>Description</li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR</b></td>
                    </tr>
                    <tr>
                        <td>Navigation Hierarchy <i>(found under Administration tab)</i></td>
                        <td>Found in the left Navigation Menu under <b>“Menu Administration”</b> tab.
                            <ol>
                                <li>Will this registry use all of the Standard Navigation Hierarchy options?</li>
                                <li>List additional Navigation Hierarchy options (if required)</li>
                            </ol>
                        </td>
                        <td><b>Standard Navigation Hierarchy Options: </b>
                            <ol>
                                <li>Patients</li>
                                <li>Providers</li>
                                <li>Referrals</li>
                                <li>Work Stream</li>
                                <li>Activities</li>
                                <li>Surveys</li>
                                <li>User-Defined Fields</li>
                            </ol>
                        </td>
                        <td><b>Specific to BCR</b></td>
                    </tr>
                    <tr>
                        <td>Define Registry Reports</td>
                        <td>1)	Select Standard Reports</td>
                        <td>List available Standard Reports:
                            <ol>
                                <li>Number of users by role </li>
                                <li>How often a registry is accessed (frequency) </li>
                                <li>Audit log report </li>
                                <li>Average time to complete a work stream </li>
                                <li>Average time to complete an activity </li>
                                <li>Listing of registries a patient is in </li>
                                <li>Listing of registries a provider is in</li>
                                <li>Number of patients in each registry </li>
                                <li>Patients without activity within user defined period</li>
                            </ol>
                        </td>
                        <td>
                            <b>BCR Reports:</b>
                            <ol>
                                <li>BCR Standard Reports 
                                    <ol>
                                        <li>All Mammograms</li>
                                        <li>Due</li>
                                        <li>Ordered Pending</li>
                                        <li>Breast Biopsies/Surgeries</li>
                                        <li>Breast Cancer</li>
                                    </ol>
                                </li>
                                <li>BCR Aggregate Reports 
                                    <ol>
                                        <li>All Mammograms with Bi-Rads Distribution</li>
                                        <li>All Mammograms with Bi-Rads by Distribution</li>
                                        <li>Mammogram Compliance by Facility</li>
                                        <li>Mammogram Compliance by Age</li>
                                        <li>Mammogram Compliance by Race</li>
                                        <li>Breast Cancer</li>
                                        <li>Breast Cancer By Facility</li>
                                        <li>Mammogram Follow-up Compliance</li>
                                        <li>Mammogram Compliance by Facility </li>
                                    </ol>
                                </li>
                                <li>BCR Ad Hoc Reports</li>
                                <li>VISN/Facility Search</li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td>Define External Interfaces</td>
                        <td>
                            <ol>
                                <li>Systems</li>
                                <li>Databases</li>
                                <li>Web services</li>
                                <li>Other </li>
                            </ol>
                        </td>
                        <td>List any external systems or interfaces that would be interface with CRSe.</td>
                        <td>N/A</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="t02">
        <tr>
            <td>
                The CRSe System Administrator will enter the data from the worksheet into the Registry Wizard.  When all of the data are entered, the Registry Wizard software will proceed to populate the PII and PHI according to the parameters supplied.
                <br />
                CRSe Registry Administrator
                <br />
                The Registry Administrator will have the capability of assigning user roles within the registry, and also creating and modifying Workflows.  
                <br />
                CRSe Registry Developer
                <br />
                This role will write code, as needed, integrating the existing web pages, existing services, existing databases, with new pages, services, and databases, as required for registry deployment that is outside the scope of the CRSe platform.
            </td>
        </tr>
    </table>

    <table id="t03">
        <tr>
            <th>Logging On</th>
        </tr>
        <tr>
            <td>CRSe is a Web-based intranet portal that allows access to authenticated VA users. No separate login procedure is required once the user has access to the CRSe site.</td>
        </tr>
    </table>

    <table id="t04">
        <tr>
            <th>System Menu</th>
        </tr>
        <tr>
            <td>The CRSe administration menu consists of a User Administration and Registry Administration menus:
                <ol>
                    <li>Registries and Cohorts </li>
                    <li>Reports</li>
                    <li>Administration</li>
                    <li>My Tasks</li>
                    <li>Help</li>
                </ol>
            </td>
        </tr>
    </table>

    <table id="t05">
        <tr>
            <th>Overview of Registry Functions</th>
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
    </table>

    <table id="t06">
        <tr>
            <th>Changing User ID and Password</th>
        </tr>
        <tr>
            <td>As a Web-based VA intranet application, users log in with their VA network credentials. CRSe does not administer user IDs and passwords, and thus no specific procedures for changing the User IDs and passwords are required.</td>
        </tr>
    </table>

    <table id="t07">
        <tr>
            <th>Exit System</th>
        </tr>
        <tr>
            <td>To exit the system, simply close the browser window.</td>
        </tr>
    </table>

    <table id="t08">
        <tr>
            <th>Caveats and Exceptions</th>
        </tr>
        <tr>
            <td>Increment 1 delivers the functionality outlined in Section 2, System Summary, with no caveats or exceptions.</td>
        </tr>
    </table>

</asp:Content>
