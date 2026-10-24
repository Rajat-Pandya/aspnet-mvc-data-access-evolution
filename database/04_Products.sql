-- ============================================================================
-- Database Script: 04_Products.sql
-- Database: ADO_CRUD_MVC
-- Consumed by:
--   - Project 6: ASP.NET Core Web App MVC (ProductController)
-- Description: Creates the Products table and populates initial sample inventory.
-- ============================================================================

USE ADO_CRUD_MVC;
GO

-- Create the Products table
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE Products
    (
        Id            INT IDENTITY(1,1) PRIMARY KEY,
        Name          NVARCHAR(100)  NOT NULL,
        Description   NVARCHAR(500)  NULL,
        Price         DECIMAL(18,2)  NOT NULL,
        Category      NVARCHAR(50)   NOT NULL,
        StockQuantity INT            NOT NULL DEFAULT 0,
        ImageUrl      NVARCHAR(500)  NULL,
        CreatedDate   DATETIME2      NOT NULL DEFAULT GETDATE(),
        IsActive      BIT            NOT NULL DEFAULT 1
    );
END
GO

-- Insert sample data
IF NOT EXISTS (SELECT 1 FROM Products)
BEGIN
    INSERT INTO Products (Name, Description, Price, Category, StockQuantity, ImageUrl, CreatedDate, IsActive)
    VALUES
    (
        'Laptop',
        'High performance laptop with 16GB RAM and 512GB SSD.',
        90000, 'Electronics', 15,
        'https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=600&q=80',
        DATEADD(MONTH, -3, GETDATE()), 1
    ),
    (
        'Smartphone',
        'Latest model smartphone with OLED display and great camera.',
        35000, 'Electronics', 40,
        'https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?auto=format&fit=crop&w=600&q=80',
        DATEADD(MONTH, -1, GETDATE()), 1
    ),
    (
        'Headphones',
        'Noise-cancelling over-ear headphones with Bluetooth connectivity.',
        7000, 'Accessories', 25,
        'https://images.unsplash.com/photo-1511367461989-f85a21fda167?auto=format&fit=crop&w=600&q=80',
        DATEADD(MONTH, -6, GETDATE()), 1
    );
END
GO

-- Verify
SELECT * FROM Products;
