### System Details 
1. Framework: ASPNET Core -  6
2. Database: Microsoft SQL Server 
3. ORM: Entity Framework Core - 6, Code First approach 
4. IDE: Visual studio 2022
5. Repository Patterns 

### How to run in Visual Studio 
1. Create a database named `TeacherAppDb` in the sql server 
1. Clone the project using the command: `git clone https://github.com/sohid-ullah/TeacherApp` or directly download it as a zip file
2. Open it using visual studio 2022 
3. Change the Connection String 
4. Goto Project manager console and run the command: 
```
dotnet ef database update --context AppDbContext --project TeacherApp.Web
```
5. This command will create the necessary table then the project will be ready to operate.
6. Run the porject using Visual Studio 2022

Projecdt snapshots: 

### Teacher List 
![plot](https://github.com/sohid-ullah/TeacherApp/blob/master/docs/list.png)
### Create Teacher
![plot](https://github.com/sohid-ullah/TeacherApp/blob/master/docs/create.png)
### Edit Teacher 
![plot](https://github.com/sohid-ullah/TeacherApp/blob/master/docs/edit.png)
### Delete Teacher
![plot](https://github.com/sohid-ullah/TeacherApp/blob/master/docs/delete-popup.png)
### Delete message
![plot](https://github.com/sohid-ullah/TeacherApp/blob/master/docs/delete-message.png)
