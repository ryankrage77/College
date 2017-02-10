# <p align="center">Analysis</p>
### Interview
I asked a series of questions to establish the scope of the problem and to find out what my client wanted the application to do. The following is a summarization of the conversation we had over IM (it has been slightly edited for clarity);  

>Me: How many employees do you currently have?  
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

Based on this, I came up with a set of functions and features for the application, which I also used to make the design diagrams.  
### Functions
These are things that the application must do to provide a basic level of functionality.  
The application must record set tasks for each employee. The tasks will need some additional information, such as;  
- task name/description
- pay (how much it is worth)
- deadline
- status (complete or not)  

The application must also calculate the pay each employee is due, based on how many of the set tasks they have completed.

### Features
These are additional functionality, and are things the application should do to make it easier to use.  
##### Export and import data
The application should export the data as a format that can be used by a spreadsheet program such as Excel.
The format for importing was never specified, and as there will only be one instance of this application, importing seems unnecessary and so will not be in the application.
##### Employee information
Another feature that I added which the cliwent did not request is the option to add information about the employees, such as the date they were employed, contact information and thier role within the company.
##### Employee image
I also decided to add the option to include an image of the employee, which would make it easier to see which employee's profile was open. I decided to add this as it will be simple to implement and be a useful feature.
### Basic Design Choices
I made the decision to use a GUI rather than a command line interface for several reasons. Firstly, Most users are more comfortable using a GUI than a CLI, so it will the program easier to use. As most users are familiar with a GUI, less training would be required than if the program used a CLI.  
Secondly, Visual Studio comes with many features that make it very easy to create a Windows Form, so I will not have to program everything from scratch.
Lastly, by using a Windows Form, the code will be clearer to other programmers than if I created a GUI from scratch, as it will use standard WinForm elements.  
Another advantage of using a GUI rather than CLI is that program used to create one will use an event-driven model. Event-driven programs are generally simpler to code as the programmer only has to account for events they intend for the user to use, as it will be impossible for the program to do anything else.
### Scope
While it is possible to create enterprise-level software to do what the client has requested (such as one with networking that utilises database servers), however, this is not what the client needs or has requested and as such it is outside the scope of this project. Therefore, I will be limiting the scope of the application to something more manageable.
The program will be stand-alone, not requiring any external libraries or dependencies to run. It will not have networking, as the client has stated that only he will use it on one local machine. It will not use a database management system, as a fully-featured database would well exceed the requirements. Features such as multiple tables, relationships and querying large volumes of data will not be needed. Instead, the necessary data management can be done using text files, as updating and delting if records won't be required. Appending data can be easily implemented with text files, especially concerning the small number of records likely to be involved. Not using a DBMS will also reduce disk and memory usage, increasing performance.  
The program will also not have an installer - instead, it will run 'out of the box' (i.e, be a standalone .exe that can run without being installed). (See Appendix 1.2 for more on relative filepaths)
### Input/Output
The program will take input from the user, through the windows form. The form will have buttons and text boxes for entering information such as employee and task details. The output will also be presented via the form, largely through labels.
Another form of I/O that is not presented to the user is file reading & writing. The programs data must be saved to a file (output), and then read when the program is opened again (input).
### Sufficient Complexity
While the basic premise of this software is quite simple, the client has requested some features that make it more complex. While the actual calculation of pay is very simple, the complexity comes from the data management aspect of the problem. Firstly, the data needs to presented in an easily human-readable format. This will require selecting data and formatting the output accordingly.
This leads to the next non-basic function - saving data. [EXPLAIN WHY FILES ARE GOOD].  
Thirdly, this will be an event-driven program, so the user can input data in any order. Therefore, it must validate this data before passing it to other functions, to ensure that the user cannot break or crash the program by accident.
### Priorities
In order to complete this project within the deadline, it is important to prioritise which aspects of the software I will focus on first.
For the implementation of the software I will focus first on the functions I outlined above. Then, I will implement the features my client has requested. Lastly, I will worry about the feasibility of the features. This seems counter-intuitive, as logic dictates that a problem cannot be solved unless it is possible to solve. However, as almost any feature a client will request is possible to implement, it will save time to only worry about the feasibility of a function or feature if and when a problem with implementing it arises during the design stage of the software life cycle. This way I will not spend too long worrying about how to implement a feature before I need to.  
This would enable me to use a prototyping development model. The advantages of this include more flexibility with implementing features. For example, if I discover a function doesn't work as intended, I can spot this early on and an alternative approach.  
While prototyping is suitable for small projects such as this one, it does not scale well and would not be suitable for larger, more complex projects involving more developers. Prototyping also often results in projects exceeding deadlines and running over budget. Another problem with prototyping is 'project creep' - when the client sees the incomplete product and is inspired to request additional functions and features which were not part of the original specification.this is the main cause of the previous problem.
### IOPS
An Input Output Processing Storage diagram will help to understand the flow of data within the program and how the client interacts with the program. This will help in subsequent stages of the project, such as design.
| Input | Proccessing | Ouput | Storage |
| :---- | :---------- | :---- | :------ |
| Add employee | Create an employee object | Display the employee info | Save the employee details to file |
| Assign task to employee | Create a task object | format the task details and display them | Save the task details to file |
| edit employee details | update the details | refresh the output to reflect the changes | save the changes |
| edit task details | update the details | refresh the output to reflect the changes | save the changes |
| Add an image | add the filepath to the employee details | display the image | save the filepath in the employee details |
### Use-case Diagram
To help me better understand how the client will use the program, I made two use-case diagrams. One shows the client current workflow (using a spreadsheet), and the other shows what the improved workflow with the new software will look like.

<img src="as-is use case.PNG">
<img src="to-be use case.PNG">

### Class Diagram
I have created a class diagram to show the relationship between employees and tasks. While very simple, this could be considered a relational database, but the data set is small enough that a full-blown DBMS is not required (see Scope, above). It also makes it clear which attributes belong to which class.

<img src="class diagram.PNG">

### S.M.A.R.T objectives
In order to help with evaluating the success of this project, I have used the above information to create a set of Specific, Measurable, Achievable, Relevant, Time-Bound objectives to complete. The goals are things the program should do in order to fulfill the clients requests. The objectives must be S.M.A.R.T so that can be used as a measure of progress and success.
While the objectives themselves are not necessarily time-bound, I will follow the schedule in appendix 3.1, so all of these goals do have a deadline.
| Ensure that: | Specific | Measurable | Achievable | Relevant | Time-bound |
| :----------- | :------- | :--------- |:---------- | :------- | :--------- |
| User can add employees  | Y | Y | Y| Y | Y |
| User can edit employees | Y | Y | Y | Y | Y |
| Program correctly adds pay according to complete tasks | Y | Y | Y |Y | Y |
| Program saves data | Y | Y | Y | Y | Y |
| Program retrieves data correctly | Y | Y | Y | Y | Y |
