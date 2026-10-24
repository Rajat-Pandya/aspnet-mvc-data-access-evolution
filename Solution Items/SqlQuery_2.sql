use ADO_CRUD_MVC
CREATE TABLE [dbo].[Emp](
[EmployeeId] [int] primary key identity(1,1),
[FirstName] [nvarchar](50) NULL,
[LastName] [nvarchar](50) NULL,
[Address1] [nvarchar](50) NULL,
[Address2] [nvarchar](50) NULL,
[EmailID] [nvarchar](50) NULL,)