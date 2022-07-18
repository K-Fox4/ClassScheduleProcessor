# Class Schedule Processor

Class Schedule Processor is a windows-based GUI application, which takes a CBM 004 class schedule file 
as an input and process each and every line of that class schedule file and saves the information to a
database, for viewing the data.

This application has 2 functionalities. They are -
- Take a CBM 004 file as input. Process the records in the file and upload the data to DB.
- Display the data from DB in the application, based on the user selected filters and further calculated 
information pertaining to specific class data record

---

## Technical details

Programming language used for developing the application is *Visual C# (.Net framework)* and IDE used for 
development is *Visual Studio 2019*.

Database used for this project is *Microsoft Access DB*.

**_Note:_** Visual Studio 2019 Community version is available for Students/Individual software development.

---

## Source code details

Code base folder structure is as shown in the below image.

![Main_Folder](./data/images/Folder_Structure.PNG)

Directly click on the solution (.sln) file to open the code of the application.

All program files pertaining to the application are present in the *ClassScheduleProcessor* folder.

Folder structure of ClassScheduleProcessor is as shown in the below image.

![Code_Folder](./data/images/Code_Folder_Structure.PNG)

Explanation of important files and folders present in the above folder structure -
- **data:** This folder contains the static files like images, icons and other media, used in the application.
- **structure:** This folder is the backend implementation of the application.
- **windows:** This folder is the frontend implementation of the application.
- **CS_DB.accdb:** This is the Microsoft Access DB file we are using in the application.
- **Main_Window(.xaml & .xaml.cs):** Program for UI and UI controls of the main window of the application.
- **README.md:** File which describes the application's source code.

All other files and folders are created by the development environment, based on the programs created in the 
source code and compile/build of the application to make the windows executable.

Backend is further divided as shown below,

![Structure_Folder](./data/images/Structure_Folder_Structure.PNG)

where,
- **constants:** Contains program files which are class implementation for constants used in the application.
- **functional:** Contains program files which perform the computations.

---