<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CRSe_WEB.Help.Reports" %>
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
                <tr>
                    <td>
                        General Report features include:
                        <ul>
                            <li>Edit Report – used to edit details for specific generated common report.</li>
                            <li>Delete Report – used to delete the specific generated common report from reports screen.</li>
                            <li>Add New Report – used to create/add a new common report using SQL report builder tool.</li>
                        </ul>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
    <table>
        <tr><th>Ad Hoc Reporting</th></tr>
        <tr>
            <td>This section is intended to provide an overview of how to use ReportBuilder</td>
        </tr>
        <tr>
            <td>
                <ol>
                    <li>STEP 1: Click on the the ReportBuilder Link from the main Report s page. <br /> The Design View for your new report will open a blank template</li>
                    <li>STEP 2: Close out the ‘Getting Started’ window by clicking the Red ‘X’ By doing so, you will be left with an empty report template. At this point you can stretch the report size out and add a unique title. You will notice all of the editing is identical in nature to Microsoft Word so customizing reports can be endless.</li>
                    <li>STEP 3: The next step is to add a dataset to your empty report template. We have provided the datasets with the data properties that are used in your registry. In the left window pane, right-click the Datasets folder</li>
                    <li>STEP 4: The following screen will open and allow you to browse to your Registry Folder, and select a dataset to create your report with. Note that you can add multiple datasets, and use in the same report. On this screen you will click the Browse button.</li>
                    <li>Step 5: After clicking the browse button above you can now navigate to select your Dataset from your Registry Folder. Double-click the Reports Folder, which will display the folders for the Registries you belong to, as well as, your VA user account folder.</li>
                    <li>Step 6: Double-Click the Registry folder and select the dataset you wish to use to build your report. You will access the content (datasets and existing reports) from the common CRS folder. Once you double click your Registry folder the window below will open with the datasets that are available to you. Note that your registry may have many datasets.</li>
                    <li>Step 7: Once you have selected your dataset the Dataset Properties window will appear. It is recommended to replace the name field to actual name of the dataset you chose. The name will be defaulted to Dataset1. NOTE: The renaming is optional. Click OK to add the dataset to your report design view.</li>
                    <li>Step 8: Now you will see that the new Dataset has been added to your blank report template. The dataset will default to be expanded and you will notice all of the data fields available</li>
                    <li>Step 9: Start building your report! If you require additional datasets, you can add them with the same process you just added for the first dataset. <br />
                        To begin creating a report you will want to right click within the body of the report template, and select INSERT Table. This initial table will be first three columns of your report <br />
                        The report display can be changed by using the same functions you would use like MS WORD.
                    </li>
                    <li>Step 10: Adding Columns to your Report<br />
                        After finding the data field in the dataset you want to display in your report, simply click the field and DRAG it into the first table column and cell in the empty table below.</li>
                    <li>Step 11: Table Properties Window<br />
Click on the empty table until a grey background surrounds the entire table. This is the table in design view. Right click on the top left corner and select Tablix Properties and the properties window will appear. You will want to check the bottom two checkboxes for column headers and also make sure the dataset you chose is selected in the Dataset name dropdown for this table. Click OK.<br />
                        NOTE: There are other tabs here for filters and sorting for more advanced features involving report parameters. We will discuss report parameters later in this document.
                    </li>
                    <li>Step 12: Customizing Columns in your Report<br />
By simply right clicking inside a column within your table after dragging in data fields, you will receive the column and the property window as displayed in the illustration below. There are many functions available for customizing the column or cells look, data type, alignment, visibility, expression building and for sorting.</li>
                    <li>Step 13: Cell Properties Window<br />
By right clicking inside the data cell for your report, you will receive the cells’ properties window. In SSRS these cells are called textboxes. However, the cells behave similar to cells in MS EXCEL or MS WORD. In the properties you can format and change the way the data will be displayed when the report is executed.</li>
                    <li>Step 14: Creating Additional Report Columns<br />
Click on the empty table until a grey background surrounds the entire table as you did before to get the Tablix properties window. Except this time to add additional columns right click any column and the options to insert and delete columns inside your report appear. Note that you can also get to the Tablix properties by following this process. Once you have new columns you can add data elements from your dataset as in STEP 10. To re-iterate, expand the dataset in the left windowpane, find the data field you need, click on it and drag into your newly created column.</li>
                    <li>Step 15: Formatting Data Columns<br />
Additional columns have been added to the report. I have dragged in a date field and I would like to have that formatted in run-time for the user. To do so, simply right-click inside the data cell (not column) of the field and select ‘Textbox Properties’. From this property window, go to the number tab and selecting the ‘date’ option now that you are in the Referral Date Cell’s property window. There are many variations of how you want your date data to be displayed. Choose the appropriate type and click ok.</li>
                    <li>Step 16: Inserting Report Header and Footer<br />
To insert a table header, or footer, to your report, simply right click the body of the report, go to insert, then click on Page Header ( or page footer to add page footer ). Once you have the table header in place, simply drag your title into the header. To drag the title, simply click it until you see the universal Microsoft ‘move’ symbol. Select the title and drag into your Report Header. This is important for reports for more than one page. The title will disappear after page 1, in runtime, without performing this action.</li>
                    <li>Step 17: Customizing Header and Footer<br />
You may want to customize the header and footer. We suggest you change the color of your report background to which ever color you choose in your body properties. Your body property color defaults to white. To change your header or footer properties, right click inside the header, and select Header Properties<br />
                        Next select the Fill tab, select a background color. Note you will want your header, body, and footer FILL property to be the same most likely for an easy visual report flow.
                    </li>
                    <li>Step 18: SSRS Built-In Fields – Optional functionality<br />
                        SSRS provides built in field parameters that you can drag on your report and have displayed at runtime. You will most likely want to drag these into a new textbox that you create in your header and footer to display the report metrics that each field provides. To place a built in field on your report, right click anywhere in your report template and a chose Insert>>Textbox. Then simply click on the Built-in Field and drag it into the newly created textbox. This textbox is customizable just like everything else by right clicking the textbox, and going to TextBox Properties.<br />
                    </li>
                    <li>Step 19: Creating Custom Report Parameters<br />
                        <ul>
                        <li>You may want to add a parameter for date ranges, text comparisons, dropdowns, and more. To do so, simply right click on the Parameter icon in the left windowpane</li>
                        <li>After Clicking Add Parameter, this window will be displayed for the creation and customizing of your parameter. In this example, I am going to create a textbox parameter for the user to input a last name before running the report.</li>
                        <li>How to add a new parameter<br /> From the dropdown, you can see that other parameter types are available. In this example, adding text will be demonstrated.</li>
                        <li>Click OK to create the textbox parameter and you will see your new parameter under the Parameters folder</li>
                        <li>Next Right Click your report table at the top left corner and select Tablix Properties as illustrated below.</li>
                        <li>When the Tablix property window opens choose the Filters tab so we can setup our Last Name Parameter to work correctly in runtime. Click the Add Button.</li>
                        <li>Now Click on the Filters tab. This is where we are going to setup the Last Name Parameter to filter the data with the user-inputted data. The first thing to do is to select the Parameter into the Expression textbox below. Press the FX button.</li>
                        <li>Which will open the Expression window:</li>
                        <li>Now click on the Parameters option in the Category section illustrated below. Then, on the right in the values section, double click the parameter you are filtering. In this case, select the text box last name equals parameter. Click OK.</li>
                        <li>After clicking OK, the next step is to select an operator for the parameter to base what data it pulls from. There are many built-in options for operators</li>
                        <li>Lastly, to complete the filter setup for Last Name Parameter you will need to choose a value. Simply Click the Fx button next to the Value textbox, select Fields (CRS) from the Category section and find the last name field from your dataset. Click Ok.</li>
                        <li>After clicking ok, you will be presented with the Tablix Properties screen. Click OK to finish your parameter filter creation.</li>
                        <li>Next, click the RUN button at the very left top corner of your report within design view. This executes the report into runtime. The parameter is now available for the report. After a user enters a value and clicks view report, the data will be filtered by the parameter value.</li>
                        <li>In this example, ‘VTSVRRWTV’was entered into the Last Name Equals parameter textbox and only Patients with said name returns. To return to Design mode, simply click the Design button at the top left of ReportBuilder.</li>
                        </ul>
                    </li>
                    <li>Step 20: How to Create Date Parameter<br />
                        <ul>
                        <li>You will follow the exact same steps to create a new parameter for your report, except this time we want to create a date range parameter. After Clicking on the Parameter folder in the top left window pane and select ‘new parameter’ you’ll see the Report Parameter Properties screen. This time though we want the Date/Time Data Type</li>
                        <li>Also, in the window, you can set default or available values for your parameter. The example below, set the default value of 1/1/2000 for the new Date Picker Parameter.</li>
                        <li>Click OK once you are finished and the new parameter will show up in your parameter list as illustrated below.</li>
                        <li>Next, we need to add a filter to the Parameter in order to filter the data returned from the report. As above, in design mode, right click on the report and go to Tablix properties. Click on the filters tab as illustrated below. Click Add.</li>
                        <li>Next, select the parameter you want to base the filter on by clicking the Fx next to the expression textbox. The Expression window will appear where you will choose Parameters from the Category section, and then double-click the ReportParameterDatePicker. Click OK.</li>
                        <li>Next, select the Fx next to the Value textbox to select the column field from your report to filter on. The Expression window will allow you to choose Fields (CRS) from the Category section, and then double-click the field you want to filter by. In this case, select the REFERRAL_DATE field for our date column and date parameter. Click OK.</li>
                        <li>Notice below that the LastName parameter has been deleted in order to demonstrate only showing just the date parameter. Also, notice that un-like the textbox parameter the type below is Date/Time. The operator is set to Less Than or Equal to the Referral Date selected by the user before running the report.</li>
                        <li>Click OK.</li>
                        <li>In the main design view, the referral dates is centered in the report column. To do this, simply right click the Referral Date cell (textbox), go to Alignment, and edit as you wish then click ok.</li>
                        <li>Next click Run in the top left corner of ReportBuilder. The new date picker parameter will display on the report.</li>
                        <li>After selecting ‘6/1/2016’ from the Date Picker Parameter and clicking ‘View Report’ on the far right in runtime mode you will see that all referrals were returned on or after 6/1/2016</li>
                        </ul>
                    </li>
                    <li>Step 20: How to Create Radio Button Parameter<br />
                        <ul>
                        <li>Follow the exact same steps to create a new parameter for the report, except in this example, a radio button parameter will be created. After clicking on the Parameter folder in the top left window pane and select ‘new parameter’ you will ll see thr Report Parameter Properties screen. This time the Boolean Type will be displayed. Additionaly, a new column was added and a Referral Duplicate flag field in the column.</li>
                        <li>As demonstration above, with the textbox parameter and the date picker parameter we need to add a filter for this new parameter’s column linking. Another parameter will be added, as well as, an expression parameter. Select the Equals operator and then the Column data value for the value textbox. Click OK to finish creating the radio button filter for the new parameter.</li>
                        <li>Click Run from design mode, choose a date, and a radio button option, and execute the report.</li>
                        <li>By switch the radio button to False, and click View Report again, the results of the report will be modified to reflect the change in parameters</li>
                        </ul>
                    </li>
                    <li>Step 21: How to Create DropDown Parameter<br />
                        <ul>
                        <li>Follow the same steps above to create a new parameter for your report, except this time we want to create a dropdown parameter. After Clicking on the Parameter folder in the top left window pane and select ‘new parameter’ you will see the Report Parameter Properties screen. This time though we want the Text Data Type selectedpane and select ‘new parameter’ you will see this familiar screen. This time though we want the Text Type as illustarted below.</li>
                        <li>There are several ways to load your new Dropdown parameter. You can input available values on the Available Values tab or you can load the Dropdown parameter from a dataset. Since this is a state dropdown, use a dataset to load this parameter with State values. After right clicking the Dataset’s folder below, and navigating to your Registry dataset (STEP 4 and 5 above), you will see the second dataset is loaded.</li>
                        <li>Next, load the new Dropdown Parameter with the values from our new dataset. Simply right click the parameter from your parameters folder and go to the available values tab. Choose the ‘Get values from query’ option. Next, select the new dataset and the Value and Label field.</li>
                        <li>Next is to add the filter for the dropdown parameter. Follow the same steps as before and you will see the below screen. Dropdowns will be of type ‘text’ and the operator is up to you based on what data you have in your dropdown parameter. With a state dropdown I obviously chose ‘=’. Click OK to finish creating the dropdown parameter filter.</li>
                        <li>Click Run at the top left of ReportBuilder to view your new and existing parameters. The state dropdown has been loaded at this time.</li>
                        <li>However, at this point I want all of the dropdown values to be UPPERCASE for readability and because the data in the database is Uppercase and I used an Equals filter expression. ReportBuilder is also case sensitive so I need to make my dropdown values uppercase. So to do this, click the design button. Then right click the report table and choose Tablix Properties. I then chose the filters tab, clicked on our new dropdown value ‘Fx’ button and proceeded to use one of the Common Functions available to you for manipulating data.</li>
                        <li>In this case I want all dropdown values to be Uppercase. In the Expression window, I will use the bultin function UCASE() to have all state information displayed in Upper Case context. Once complete click OK.</li>
                        <li>Now you can Run the report with all three parameters</li>
                        <li>Also, dropdown lists can be setup to allow the user to select multiple value.</li>
                        <li>To make this change you will need to go back into design mode by clicking Design, right clicking on the Dropdown Parameter and change the parameter to allow the selection of multiple values.</li>
                        <li>Then you will want to change the operator for the filter for this parameter to "IN" and click ok.</li>
                        <li>Click Run from Design mode and you can see below that the dropdown now has the multi-select option. We do not encourage the use of this function as it may cause latency and/or database performance issues with returning too much data.</li>
                        </ul>
                    </li>
                    <li>Step 22: How to Create Text Box Expressions for Runtime<br />
                        <ul>
                        <li>First, in your header or footer, right click and insert a textbox. Then right click inside the textbox and select expression</li>
                        <li>When the report runs this will be displayed in the footer. Click OK to create. You can also alter the visual effects of this textbox by right clicking and going to Text Box Properties.</li>
                        <li>I also created an expression for my header in the same way as explained above. Click OK to create this second expression.</li>
                        <li>Lastly, I dragged the Exection Time over from the Built-In Fields and placed it in my footer and made it bold. All three expressions are illustrated below in design mode.</li>
                        <li>Lastly, I dragged the Exection Time over from the Built-In Fields and placed it in my footer and made it bold. All three expressions are illustrated below in design mode.</li>
                        </ul>
                    </li>
                    <li>Step 24: How to Create Interactive Sorting on your Report Columns<br />
                        <ul>
                        <li>In design mode, right click the column name and select Text Box Properties. Click on the Interactive Sorting</li>
                        <li>Check the ‘Enable interactive sorting on this text box’ checkbox. The Sort by Dropdown will become enabled. Choose the Data Field for the column you are adding the sorting feature to. I chose the first column which is the registry id in this example. Click OK. You can repeat this for any column in your report that you would want to sort on.</li>
                        <li>You will see that the Registry ID column now has a sorting icon for ascending and descending sorting when report </li>
                        </ul>
                    </li>
                    <li>Step 25: How to Keep the Header and Report Columns Visible when paging<br />
                        <ul>
                        <li>First, click the little down arrow where it says column groups and select advanced mode.</li>
                        <li>Secondly, Click on the static member in the Row Group. To the right you will see the properties window for this static row ( column row ).</li>
                        <li>Lastly, change the ‘Repeat On New Page’ to True from False</li>
                        <li>Save report.</li>
                        </ul>
                    </li>
                </ol>
            </td>
        </tr>
        <tr>
            <td>For learning more advanced functionality in ReportBuilder you can access the Microsoft tutorials from here: 
                <a href="https://msdn.microsoft.com/en-us/library/dd239338(v=sql.110).aspx" target="_blank">Microsoft Tutorial</a>                
            </td>
        </tr>
    </table>
</asp:Content>
