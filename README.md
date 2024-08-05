# WorkForce-Manager

## Overview
WorkForce-Manager is a comprehensive application designed to manage employees, salaries, and departments within an organization. It provides a user-friendly interface for authenticated users to view and manage data efficiently.

## Tech Stack
- **Backend**: ASP.NET Core 6.0
- **Frontend**: Razor Pages, Bootstrap 5.1.3
- **Database**: SQL Server (hosted on Azure Data Studio, in Docker using Image Container Instance)
- **Tools**: Visual Studio Code, .NET CLI, Azure Data Studio, Docker

## Libraries and Versions
- **ASP.NET Core**: 6.0
- **Bootstrap**: 5.1.3
- **Microsoft.AspNetCore.Authentication.Cookies**: 2.2.0
- **Microsoft.AspNetCore.Authorization**: 8.0.7
- **Microsoft.jQuery.Unobtrusive.Validation**: 3.2.12
- **Microsoft.jQuery.Unobtrusive.Ajax**: 3.2.6

## Features
1. **Cookie Authentication for Login**: Secure login mechanism using cookies.
2. **CRUD Operations**: Create, Read, Update, and Delete operations for Department, Employee, and Salary tables.
3. **Role-Based Access Control**: Different access levels for different types of users.
4. **Responsive Design**: Mobile-friendly interface using Bootstrap.
5. **Data Validation**: Client-side and server-side validation using jQuery Unobtrusive Validation.
6. **Ajax Support**: Asynchronous operations using jQuery Unobtrusive Ajax.

## Project Demonstration
For a detailed demonstration of the WorkForce-Manager application, please visit the following link:

[Project Demo](https://drive.google.com/drive/folders/1Hnvwv8LaH3ZH0Q4WVEKuHNJFq1wdUvvS?usp=sharing)

## Installation

### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/get-started)

### Steps
1. **Clone the repository**:
    ```sh
    gh repo clone SamhithThatikonda/WorkForce-Manager
    cd your-repo
    ```

2. **Restore dependencies**:
    ```sh
    dotnet restore
    ```

3. **Add required packages**:
    ```sh
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Authentication.Cookies
    dotnet add package Microsoft.AspNetCore.Authorization
    dotnet add package Microsoft.Data.SqlClient
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.jQuery.Unobtrusive.Validation
    dotnet add package Microsoft.jQuery.Unobtrusive.Ajax
    ```

4. **Update the database connection string**:
    Update the connection string in `appsettings.json` to point to your SQL Server instance.

5. **Apply migrations and update the database**:
    ```sh
    dotnet tool install --global dotnet-ef
    dotnet ef database update "AuthMigrationFinal" 
    dotnet ef database update
    ```
6. **For First Time Users (Optional)**:
    Run the given `sqlquery.sql` file against the database on SQL-SERVER.

7. **Run the application**:
    ```sh
    dotnet build
    dotnet run
    ```
8. **Default credentials**:
    - Username: `21`
    - Password: `123`

## Usage
- Navigate to `http://localhost:5000` in your web browser.
- Log in with your credentials.
- Use the navigation bar to access different sections of the application.

## Key Highlights

### Controllers and Features

#### AuthController
- **Login**: Handles user authentication using cookies.
- **Logout**: Manages user logout and session termination.

#### EmployeeController
- **ListEmployee**: Displays a list of all employees.
- **AddEmployee**: Allows adding a new employee.
- **EditEmployee**: Enables editing existing employee details.
- **DeleteEmployee**: Employee Deletion with Cascading Effect

The `DeleteEmployee` feature facilitates the removal of an employee. This action also triggers a cascading delete effect, ensuring that all related data in associated tables is removed. Specifically:

- **Employee Deletion**: The specified employee is deleted from the `EmployeeTable`.
- **Salary Deletion**: All salary records associated with the deleted employee are removed from the `SalaryTable`.
- **Authorization Deletion**: All authorizations linked to the deleted employee are removed from the `AuthTable`.

This cascading delete functionality maintains data integrity by ensuring that no orphaned records remain in the related tables.

#### SalaryController
- **ListSalary**: Shows a list of all salaries.
<!-- - **AddSalary**: Allows adding a new salary record. -->
- **EditSalary**: Enables editing existing salary details.
<!-- - **DeleteSalary**: Facilitates the deletion of a salary record. -->

#### DeptController
- **ListDept**: Displays a list of all departments.
- **AddDept**: Allows adding a new department.
- **EditDept**: Enables editing existing department details.
- **DeleteDept**:Department Deletion with Cascading Effect

The `DeleteDept` feature facilitates the removal of a department from the `DepartmentTable`. This action triggers a cascading delete effect, ensuring that all related data in associated tables is also removed. Specifically:

- **Department Deletion**: The specified department is deleted from the `DepartmentTable`.
- **Employee Deletion**: All employees associated with the deleted department are removed from the `EmployeeTable`.
- **Salary Deletion**: All salary records linked to the deleted employees are removed from the `SalaryTable`.

This cascading delete functionality maintains data integrity by ensuring that no orphaned records remain in the related tables.

## Use Case
WorkForce-Manager is used for storing and retrieving employee information, managing salaries, and organizing departments within an organization. It provides a secure and efficient way to handle HR-related tasks.

## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.
