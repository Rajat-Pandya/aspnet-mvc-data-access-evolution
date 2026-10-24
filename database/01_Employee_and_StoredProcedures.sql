-- ============================================================================
-- Database Script: 01_Employee_and_StoredProcedures.sql
-- Database: ADO_CRUD_MVC
-- Consumed by:
--   - Project 1: MVC CRUD Operations Using Entity Framework
--   - Project 3: BusinessLayer (Class Library)
--   - Project 4: CRUD Operation in MVC Using Business Layer and Scaffolding
-- Description: Creates the Employee table, inserts sample seed records, and
--              defines stored procedures for CRUD operations.
-- ============================================================================

CREATE TABLE [dbo].[Employee] (
[EmployeeID] INT IDENTITY (1, 1) NOT NULL,
[EmployeeName] NVARCHAR (50) NULL,
[EmployeeGender] NVARCHAR (10) NULL,
[EmployeeDesignation] NVARCHAR (50) NULL,
PRIMARY KEY CLUSTERED ([EmployeeID] ASC));

INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Anna', N'Female', N'Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Barace', N'Male', N'Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Cathy', N'Female', N'Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Downey', N'Male', N'Senior Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Eric', N'Male', N'Senior Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Foster', N'Male', N'Senior Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Genee', N'Female', N'Senior Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Howard', N'Male', N'Senior Software Engineer')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Instana', N'Female', N'Project Manager')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Joe', N'Male', N'Project Manager')
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeGender], [EmployeeDesignation]) VALUES (N'Kristen', N'Male', N'Senior Manager')

Select * from Employee

GO
CREATE PROCEDURE spGetAllEmployees
AS
BEGIN
SELECT emp.*
FROM dbo.Employee emp;
END;
GO

GO
CREATE PROCEDURE spInsertEmployeeDetails
@EmployeeName NVARCHAR(50),
@EmployeeGender NVARCHAR(10),
@EmployeeDesignation NVARCHAR(50)
AS
BEGIN
INSERT dbo.Employee
(
--EmployeeID - this column value is auto-generated
EmployeeName,
EmployeeGender,
EmployeeDesignation
)
VALUES
(
-- EmployeeID - int
N'',
-- EmployeeName - nvarchar
N'',
-- EmployeeGender - nvarchar
N''
-- EmployeeDesignation - nvarchar
)
END
GO

GO
CREATE PROCEDURE spUpdateEmployee
@EmployeeID int,
@EmployeeName nvarchar(100),
@EmployeeGender nvarchar(10),
@EmployeeDesignation nvarchar(100)
AS
BEGIN
UPDATE dbo.Employee
SET
--EmployeeID - this column value is auto-generated
dbo.Employee.EmployeeName = @EmployeeName,
-- nvarchar
dbo.Employee.EmployeeGender = @EmployeeGender,
-- nvarchar
dbo.Employee.EmployeeDesignation = @EmployeeDesignation
-- nvarchar
WHERE
dbo.Employee.EmployeeID = @EmployeeID
END
GO

GO
CREATE PROCEDURE spDeleteEmployee
@EmployeeID INT
AS
BEGIN
DELETE dbo.Employee
WHERE dbo.Employee.EmployeeID = @EmployeeID;
END;
GO
