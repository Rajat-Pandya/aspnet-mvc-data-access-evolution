CREATE DATABASE PracticeDB;
GO

USE PracticeDB;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2),
    Quantity INT
);

INSERT INTO Products (ProductID, ProductName, Price, Quantity)
VALUES
    (1, 'Laptop', 55000.00, 10),
    (2, 'Mouse', 500.00, 50),
    (3, 'Keyboard', 1200.00, 25);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

INSERT INTO Employees (EmployeeID, EmployeeName, Department, Salary)
VALUES
    (101, 'Rahul Sharma', 'IT', 45000.00),
    (102, 'Priya Patel', 'HR', 40000.00),
    (103, 'Amit Verma', 'Finance', 50000.00);
