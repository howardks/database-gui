# DatabaseGUI
This GUI was created for CSCI 3432 Database Systems. It connects to a MySQL instance hosted on AWS and retrieves data regarding student organizations. Screenshots have not been included in this readme yet. In order to run this solution, the nuget packages "MySQL.Data" and "CommunityToolkit.WinUI.UI.Controls.DataGrid" must be installed. 

When the application is started, all buttons are disabled except the login button. 

Upon clicking the login button, a flyout window is displayed where they can enter their username and password. Upon pressing enter or clicking ‘login’ in the flyout window, the information in both username and password text fields disappears to improve security. 

Once the user is successfully logged in, the login button is disabled, the table on the currently selected tab is populated with the appropriate data, and all other buttons and textfields are enabled. Each tab has buttons for ‘add’, ‘modify’, and ‘delete’, as well as a search feature that allows the user to search by individual or multiple fields. 

The ‘add’ button displays a content dialog window that allows the user to input data for each field. This data is then used to add a row to the table through the use of stored procedures. 

The ‘modify’ button displays a content dialog window that is populated by the currently selected row. The user may change the data in these fields. This data is then used to update the row through stored procedures. 

The ‘delete’ button displays a content dialog window asking the user to confirm their choice. If it is confirmed, the row is deleted through the use of stored procedures. 

The search feature allows the user to search the data in the displayed table. The user may input search terms into a single field or multiple fields simultaneously. The search term does not have to match the entire field to return results. Below, the user searches for ‘develop’ in the About field of the CLUB table and returns all rows with ‘develop’ in their about column. 

Below, the user searches for ‘IT’ in the Location of the BOOKABLE_LOCATION table and returns all rows containing locations in the IT building. 

Below, the user searches for ‘IT’ in the Location field and ‘classroom’ in the Type field of the BOOKABLE_LOCATION table and returns all rows containing locations in the IT building that are classrooms.

Search fields that refer to numeric data allow the user to search by exact number or by using a comparison operator. Below, the user searches for ‘> 100’ in the Capacity field of the BOOKABLE_LOCATION table and returns all rows with a capacity greater than 100. 

The tab titled ‘Details’ gives the user access to commonly requested information including Org Advisor, Org Roster, Org Projects, Org Budget, and Org Events.  A drop-down menu allows the user to select a club and buttons allow the user to choose what to display in the table. Each of these buttons will populate the table through the use of stored procedures.

Below, the user has selected ‘Association for Computing Machinery’ in the drop-down menu and clicked the ‘Org Advisor’ button. The text above the table also changes accordingly. ‘Org Advisor’ provides data from the CLUB and FACULTY tables. 

Below, the user has selected ‘Association for Computing Machinery’ and clicked the ‘Org Roster’ button. ‘Org Roster’ provides data from the CLUB and STUDENT tables. 

Below, the user has selected ‘Robotics Club’ in the drop-down menu and clicked the ‘Org Projects’ button. ‘Org Projects’ provides data from the CLUB and PROJECT tables. 

Below, the user has selected ‘Tech Developers Association’ in the drop-down menu and clicked the ‘Org Budget’ button. ‘Org Budget’ provides data from the CLUB and BUDGET tables. 

Below, the user has selected ‘Women in Technology’ in the drop-down menu and clicked the ‘Org Events’ button. ‘Org Events’ provides data from the CLUB, CLUB_EVENT, and BOOKABLE_LOCATION tables. 

Upon clicking the logout button, a flyout window is displayed asking the user to confirm their choice to log out of the application. 

Once the user has confirmed their choice to log out, all buttons and text fields are disabled and all tables are cleared to improve security. The login button is enabled. 

A significant amount of error checking is included in this application. Below, a user attempts to add a row with a duplicate primary key to the CLUB table. The data is rejected and a console dialog window with an error message is displayed. 


Below, a user attempts to add a row with a null primary key to the FACULTY table. The data is rejected and a console dialog with an error message is displayed. 


Add, Modify, Delete, and Search functionality exists for all tables on their respective tab. Each time a tab is selected, the data for that tab is populated. 
CLUB tab:




STUDENT tab:

FACULTY tab:





DEPARTMENT tab:

CLUB_EVENT tab:





WINGS_POINTS_EVENT tab:

BOOKABLE_LOCATION tab:





BUDGET tab:

PROJECT tab:





SOCIAL_MEDIA tab:

