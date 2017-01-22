# <p align="center">Analysis</p>
My client owns a small company, with several employees on a zero-hour contract. He is currently tracking each employee’s salary in a spreadsheet, but this is cumbersome and unprofessional. He would prefer to have a bespoke application to more easily manage each employee’s salary.  
I asked some questions to find out what my client wanted the application to do. The following is a summarization of the conversation we had over IM (it has been slightly edited for clarity);  
```
Me: How many employees do you currently have?
Client: Currently we have six employees.
M: Will the program need to be able to scale up to accommodate more employees in the future?
C: Yes, it will need to scale up in the future.
M: How exactly does the zero-hour contract work?
C: Employees are paid according to how much work they have completed, not how many hours they have worked.
M: Who will use the application? Just yourself, or employees too?
C: Just myself.
M: Should the data be exportable? If so, in what format?
C: Yes, to a spreadsheet.
M: What are the things the application must be able to do?
C: Have an input for the number of tasks completed, the pay per task, employee name, total amount paid and how much is due.
M: What features would be nice to have?
C: Save, export and import.
```
Based on this, I came up with a set of functions and features for the application.  
#### Functions
These are things that the application must do to provide the bare minimum of functionality.  
The application must record set tasks for each employee. The tasks will need some additional information, such as;  
- task name/description
- pay (how much it is worth)
- deadline
- status (complete or not)
The application must also calculate the pay each employee is due, based on how many of the set tasks they have completed.

#### Features
These are additional functionality, and are things the application should do to make it easier to use.  
###### Export and import data
The application should export the data as a format that can be used by a spreadsheet program such as Excel.
The format for importing was never specified, and as there will only be one instance of this application, importing seems unnecessary and so will not be in the application.
