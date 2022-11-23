# DatabaseGUI
This GUI was created for CSCI 3432 Database Systems. It connects to a MySQL instance hosted on AWS and retrieves data regarding student organizations. In order to run this solution, the nuget packages "MySQL.Data" and "CommunityToolkit.WinUI.UI.Controls.DataGrid" must be installed. 

When the application is started, all buttons are disabled except the login button. 

![1.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/1.png?raw=true)

Upon clicking the login button, a flyout window is displayed where they can enter their username and password. Upon pressing enter or clicking ‘login’ in the flyout window, the information in both username and password text fields disappears to improve security. 

![2.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/2.png?raw=true)

Once the user is successfully logged in, the login button is disabled, the table on the currently selected tab is populated with the appropriate data, and all other buttons and textfields are enabled. Each tab has buttons for ‘add’, ‘modify’, and ‘delete’, as well as a search feature that allows the user to search by individual or multiple fields. 

![3.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/3.png?raw=true)

The ‘add’ button displays a content dialog window that allows the user to input data for each field. This data is then used to add a row to the table through the use of stored procedures. 

![4.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/4.png?raw=true)

The ‘modify’ button displays a content dialog window that is populated by the currently selected row. The user may change the data in these fields. This data is then used to update the row through stored procedures. 

![5.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/5.png?raw=true)

The ‘delete’ button displays a content dialog window asking the user to confirm their choice. If it is confirmed, the row is deleted through the use of stored procedures. 

![6.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/6.png?raw=true)

The search feature allows the user to search the data in the displayed table. The user may input search terms into a single field or multiple fields simultaneously. The search term does not have to match the entire field to return results. Below, the user searches for ‘develop’ in the About field of the CLUB table and returns all rows with ‘develop’ in their about column. 

![7.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/7.png?raw=true)

Below, the user searches for ‘IT’ in the Location of the BOOKABLE_LOCATION table and returns all rows containing locations in the IT building. 

![8.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/8.png?raw=true)

Below, the user searches for ‘IT’ in the Location field and ‘classroom’ in the Type field of the BOOKABLE_LOCATION table and returns all rows containing locations in the IT building that are classrooms.

![9.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/9.png?raw=true)

Search fields that refer to numeric data allow the user to search by exact number or by using a comparison operator. Below, the user searches for ‘> 100’ in the Capacity field of the BOOKABLE_LOCATION table and returns all rows with a capacity greater than 100. 

![10.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/10.png?raw=true)

The tab titled ‘Details’ gives the user access to commonly requested information including Org Advisor, Org Roster, Org Projects, Org Budget, and Org Events.  A drop-down menu allows the user to select a club and buttons allow the user to choose what to display in the table. Each of these buttons will populate the table through the use of stored procedures.

![11.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/11.png?raw=true)

Below, the user has selected ‘Association for Computing Machinery’ in the drop-down menu and clicked the ‘Org Advisor’ button. The text above the table also changes accordingly. ‘Org Advisor’ provides data from the CLUB and FACULTY tables. 

![12.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/12.png?raw=true)

Below, the user has selected ‘Association for Computing Machinery’ and clicked the ‘Org Roster’ button. ‘Org Roster’ provides data from the CLUB and STUDENT tables. 

![13.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/13.png?raw=true)

Below, the user has selected ‘Robotics Club’ in the drop-down menu and clicked the ‘Org Projects’ button. ‘Org Projects’ provides data from the CLUB and PROJECT tables. 

![14.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/14.png?raw=true)

Below, the user has selected ‘Tech Developers Association’ in the drop-down menu and clicked the ‘Org Budget’ button. ‘Org Budget’ provides data from the CLUB and BUDGET tables. 

![15.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/15.png?raw=true)

Below, the user has selected ‘Women in Technology’ in the drop-down menu and clicked the ‘Org Events’ button. ‘Org Events’ provides data from the CLUB, CLUB_EVENT, and BOOKABLE_LOCATION tables. 

![16.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/16.png?raw=true)

Upon clicking the logout button, a flyout window is displayed asking the user to confirm their choice to log out of the application. 

![17.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/17.png?raw=true)

Once the user has confirmed their choice to log out, all buttons and text fields are disabled and all tables are cleared to improve security. The login button is enabled. 

![18.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/18.png?raw=true)

A significant amount of error checking is included in this application. Below, a user attempts to add a row with a duplicate primary key to the CLUB table. The data is rejected and a console dialog window with an error message is displayed. 

![19.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/19.png?raw=true)
![20.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/20.png?raw=true)

Below, a user attempts to add a row with a null primary key to the FACULTY table. The data is rejected and a console dialog with an error message is displayed. 

![21.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/21.png?raw=true)
![22.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/22.png?raw=true)

Add, Modify, Delete, and Search functionality exists for all tables on their respective tab. Each time a tab is selected, the data for that tab is populated. 

CLUB tab:

![23.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/23.png?raw=true)

STUDENT tab:

![24.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/24.png?raw=true)

FACULTY tab:

![25.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/25.png?raw=true)

DEPARTMENT tab:

![26.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/26.png?raw=true)

CLUB_EVENT tab:

![27.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/27.png?raw=true)

WINGS_POINTS_EVENT tab:

![28.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/28.png?raw=true)

BOOKABLE_LOCATION tab:

![29.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/29.png?raw=true)

BUDGET tab:

![30.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/30.png?raw=true)

PROJECT tab:

![31.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/31.png?raw=true)

SOCIAL_MEDIA tab:

![32.png](https://github.com/howardks/DatabaseGUI/blob/master/Screenshots/32.png?raw=true)
