-- ============================================================================
-- Database Script: 03_Emp.sql
-- Database: ADO_CRUD_MVC
-- Consumed by:
--   - Project 1: MVC CRUD Operations Using Entity Framework (EmpsController)
-- Description: Creates the Emp table used by Project 1's EF6 EmpsController.
-- ============================================================================

USE ADO_CRUD_MVC;
GO

CREATE TABLE [dbo].[Emp](
    [EmployeeId] [int] PRIMARY KEY IDENTITY(1,1),
    [FirstName] [nvarchar](50) NULL,
    [LastName] [nvarchar](50) NULL,
    [Address1] [nvarchar](50) NULL,
    [Address2] [nvarchar](50) NULL,
    [EmailID] [nvarchar](50) NULL
);
GO
