# <p align="center">Analysis</p>
### Interview
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
### Functions
These are things that the application must do to provide the bare minimum of functionality.  
The application must record set tasks for each employee. The tasks will need some additional information, such as;  
- task name/description
- pay (how much it is worth)
- deadline
- status (complete or not)
The application must also calculate the pay each employee is due, based on how many of the set tasks they have completed.

### Features
These are additional functionality, and are things the application should do to make it easier to use.  
###### Export and import data
The application should export the data as a format that can be used by a spreadsheet program such as Excel.
The format for importing was never specified, and as there will only be one instance of this application, importing seems unnecessary and so will not be in the application.
### Basic Design Choices
I made the decision to use a GUI rather than a command line interface for several reasons. Firstly, Most users are more comfortable using a GUI than a CLI, so it will the program easier to use.
Secondly, Visual Studio comes with many features that make it very easy to create a Windows Form, so I will not have to program everything from scratch.
Lastly, by using a Windows Form, the code will be clearer to other programmers than if I created a GUI from scratch, as it will use standard WinForm elements.
### Scope
While it is possible to create enterprise-level software to do what the client has requested (such as one with networking that utilises databases), I have neither the time nor resources to do so. Therefore, I will be limiting the scope of the application to something more manageable.
The program will be stand-alone, not requiring any external libraries or dependencies to run. It will not have networking, as the client has stated that only he will use it. It will not use a database management system, as I do not have the technical skill to implement such a feature. The program will also not have an installer - instead, it will run 'out of the box' (i.e, be a standalone .exe that can run without being installed). (See Appendix 1.2 for more on relative filepaths)
### Input/Output
The program will take input from the user, through the windows form. The form will have buttons and text boxes for entering information such as employee and task details. The output will also be presented via the form, largely through labels.
Another form of I/O that is not presented to the user is file reading & writing. The programs data must be saved to a file, and then read when the program is updated
### Sufficient Complexity
While the basic premise of this software is quite simple, the client has requested some features that make it more complex. While the actual calculation of pay is very simple, the complexity comes from the data management aspect of the problem. Firstly, the data needs to presented in an easily human-readable format. This will require selecting data and updating the output accordingly.
This leads to the next non-basic function - saving data. The program will require a way to store and retrieve data, in addition to using it in a variety of ways.
Thirdly, this will be an event-driven program - it responds to user input. Therefore, it must have more validation than a procedural program, to ensure that the user cannot break or crash the program by accident.
### Priorities
In order to complete this project within the deadline, it is important to prioritise which aspects of the software I will focus on first.
For the implementation of the software I will focus first on the functions I outlined above. Then, I will implement the features my client has requested. Lastly, I will worry about the feasibility of the features. This seems counter-intuitive, as logic dictates that a problem cannot be solved unless it is possible to solve. However, as almost any feature a client will request is possble to implement, it will save time to only worry about the feasibility of a function or feature if and when a problem with implementing it arises during the design stage of the software life cycle. This way I will not spend too long worrying about how to implement a feature before I need to.
