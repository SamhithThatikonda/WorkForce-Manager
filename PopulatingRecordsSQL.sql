-- The Below Script is for populating 10 records in Department Table

-- Enable identity insert for DepartmentTable
SET IDENTITY_INSERT DepartmentTable ON;

-- Insert data into DepartmentTable with explicit values for the identity column
INSERT INTO DepartmentTable (Dept_Id, Dept_Name)
VALUES (1, 'Human Resources'),
       (2, 'Finance'),
       (3, 'IT'),
       (4, 'Marketing'),
       (5, 'Sales'),
       (6, 'Research and Development'),
       (7, 'Customer Service'),
       (8, 'Logistics'),
       (9, 'Procurement'),
       (10, 'Legal');

-- Disable identity insert for DepartmentTable
SET IDENTITY_INSERT DepartmentTable OFF;

SET IDENTITY_INSERT EmployeeTable ON;
--The Below Script is for populating 1000 records in Salary Table
DECLARE @Counter INT = 50;
DECLARE @MaxCount INT = 1050;

-- Sample names for random generation
DECLARE @FirstNames TABLE (Name NVARCHAR(50));
DECLARE @LastNames TABLE (Name NVARCHAR(50));

-- Inserting 50 sample first names
INSERT INTO @FirstNames (Name) VALUES 
('John'), ('Jane'), ('Michael'), ('Emily'), ('Chris'), ('Jessica'), 
('Matthew'), ('Sarah'), ('David'), ('Laura'), ('Daniel'), ('Olivia'),
('James'), ('Sophia'), ('Andrew'), ('Ava'), ('Joshua'), ('Isabella'),
('Ethan'), ('Mia'), ('Ryan'), ('Charlotte'), ('Jacob'), ('Amelia'),
('William'), ('Harper'), ('Alexander'), ('Ella'), ('Benjamin'), ('Grace'),
('Samuel'), ('Lily'), ('Nathan'), ('Aria'), ('Joseph'), ('Evelyn'),
('David'), ('Zoey'), ('Isaac'), ('Nora'), ('Gabriel'), ('Hannah'),
('Michael'), ('Addison'), ('Logan'), ('Lucy'), ('Lucas'), ('Stella'),
('Henry'), ('Zoe'), ('Owen'), ('Paisley'), ('Jack'), ('Riley');

-- Inserting 50 sample last names
INSERT INTO @LastNames (Name) VALUES 
('Smith'), ('Johnson'), ('Williams'), ('Jones'), ('Brown'), ('Davis'), 
('Miller'), ('Wilson'), ('Moore'), ('Taylor'), ('Anderson'), ('Thomas'),
('Jackson'), ('White'), ('Harris'), ('Martin'), ('Thompson'), ('Garcia'),
('Martinez'), ('Robinson'), ('Clark'), ('Rodriguez'), ('Lewis'), ('Lee'),
('Walker'), ('Hall'), ('Allen'), ('Young'), ('King'), ('Wright'),
('Scott'), ('Torres'), ('Nguyen'), ('Hill'), ('Adams'), ('Baker'),
('Nelson'), ('Carter'), ('Mitchell'), ('Perez'), ('Roberts'), ('Turner'),
('Phillips'), ('Campbell'), ('Parker'), ('Evans'), ('Edwards'), ('Collins'),
('Stewart'), ('Sanchez'), ('Morris'), ('Rogers'), ('Cook'), ('Morgan');

WHILE @Counter <= @MaxCount
BEGIN
    INSERT INTO EmployeeTable (Emp_id, First_Name, Last_Name, Dept_id)
    VALUES (
        @Counter, 
        (SELECT TOP 1 Name FROM @FirstNames ORDER BY NEWID()), 
        (SELECT TOP 1 Name FROM @LastNames ORDER BY NEWID()), 
        (ABS(CHECKSUM(NEWID())) % 10) + 1 -- Random Dept_id between 1 and 10
    );
    
    SET @Counter = @Counter + 1;
END
SET IDENTITY_INSERT EmployeeTable OFF;

-- The Below Script is for populating 1000 records in Salary Table
SET IDENTITY_INSERT SalaryTable ON;
-- Declare a variable to hold the incrementing Sal_Id
DECLARE @Sal_Id INT = 1;

-- Use a temporary table to store unique employee IDs
CREATE TABLE #EmployeeIDs (Emp_Id INT PRIMARY KEY);

-- Populate the temporary table with unique employee IDs
-- Ensure that Emp_Id is unique and does not overlap with Sal_Id
INSERT INTO #EmployeeIDs (Emp_Id)
SELECT TOP 1000 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + 50
FROM sys.columns AS c1
CROSS JOIN sys.columns AS c2;

-- Insert data into SalaryTable
WHILE @Sal_Id <= 1050
BEGIN
    DECLARE @Emp_Id INT;
    DECLARE @SalaryAmount INT;

    -- Get a random Employee ID from the temporary table
    SELECT TOP 1 @Emp_Id = Emp_Id
    FROM #EmployeeIDs
    WHERE Emp_Id != @Sal_Id
    ORDER BY NEWID();

    -- Generate a random SalaryAmount between 0 and 1,000,000
    SET @SalaryAmount = ABS(CHECKSUM(NEWID()) % 1000001);

    -- Insert the data into the SalaryTable
    INSERT INTO SalaryTable (Sal_Id, Emp_Id, SalaryAmount)
    VALUES (@Sal_Id, @Emp_Id, @SalaryAmount);

    -- Remove the used Employee ID from the temporary table
    DELETE FROM #EmployeeIDs WHERE Emp_Id = @Emp_Id;

    -- Increment the Sal_Id
    SET @Sal_Id = @Sal_Id + 1;
END

-- Clean up
DROP TABLE #EmployeeIDs;

SET IDENTITY_INSERT SalaryTable OFF;

SELECT * FROM EmployeeTable;
SELECT * FROM SalaryTable;
SELECT * FROM DepartmentTable;
