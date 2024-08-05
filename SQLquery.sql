set IDENTITY_INSERT DepartmentTable ON;

  Insert into DepartmentTable (Dept_Id, Dept_Name)
  VALUES (1,'HR');
set IDENTITY_INSERT DepartmentTable OFF;
  set IDENTITY_INSERT EmployeeTable ON;

  Insert into EmployeeTable (Emp_Id, First_Name, Last_Name, Dept_Id)
  VALUES (21, 'user', 'name', 1);
   set IDENTITY_INSERT EmployeeTable OFF;

   set IDENTITY_INSERT AuthTable ON;
     Insert into AuthTable (Emp_Id, [Password])
  VALUES (21, '123');
     set IDENTITY_INSERT AuthTable Off;

     set IDENTITY_INSERT SalaryTable ON;
     Insert into SalaryTable (Sal_Id, Emp_Id, SalaryAmount)
     VALUES (1, 21, 25000);
     set IDENTITY_INSERT SalaryTable Off;


SELECT * FROM [EmployeeTable];
SELECT * FROM [SalaryTable];
SELECT * FROM [DepartmentTable];
SELECT * FROM [AuthTable];