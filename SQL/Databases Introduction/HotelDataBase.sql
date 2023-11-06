----CREATE DATABASE HotelDataBase
USE HotelDataBase
GO

-- Create Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(100),
    Notes NVARCHAR(MAX)
);

-- Create Customers table
CREATE TABLE Customers (
    AccountNumber NVARCHAR(20) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    EmergencyName NVARCHAR(100),
    EmergencyNumber NVARCHAR(20),
    Notes NVARCHAR(MAX)
);

-- Create RoomStatus table
CREATE TABLE RoomStatus (
    RoomStatus NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create RoomTypes table
CREATE TABLE RoomTypes (
    RoomType NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create BedTypes table
CREATE TABLE BedTypes (
    BedType NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create Rooms table
CREATE TABLE Rooms (
    RoomNumber NVARCHAR(10) PRIMARY KEY,
    RoomType NVARCHAR(50) NOT NULL,
    BedType NVARCHAR(50) NOT NULL,
    Rate DECIMAL(7,2) NOT NULL,
    RoomStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
);

-- Create Payments table
CREATE TABLE Payments (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    PaymentDate DATE NOT NULL,
    AccountNumber NVARCHAR(20) NOT NULL,
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(7,2) NOT NULL,
    TaxRate DECIMAL(7,2) NOT NULL,
    TaxAmount DECIMAL(7,2) NOT NULL,
    PaymentTotal DECIMAL(7,2) NOT NULL,
    Notes NVARCHAR(MAX)
);

-- Create Occupancies table
CREATE TABLE Occupancies (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    DateOccupied DATE NOT NULL,
    AccountNumber NVARCHAR(20) NOT NULL,
    RoomNumber NVARCHAR(10) NOT NULL,
    RateApplied DECIMAL(7,2) NOT NULL,
    PhoneCharge DECIMAL(7,2),
    Notes NVARCHAR(MAX)
);

-- Populate Employees table
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
    (1, 'John', 'Doe', 'Manager', 'Manages hotel operations'),
    (2, 'Jane', 'Smith', 'Front Desk Clerk', 'Assists customers with check-in/check-out'),
    (3, 'Robert', 'Johnson', 'Housekeeper', 'Cleans and maintains rooms');

-- Populate Customers table
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
    ('CUST001', 'Alice', 'Johnson', '123-456-7890', 'Bob Johnson', '987-654-3210', 'Frequent guest'),
    ('CUST002', 'Bob', 'Smith', '555-555-5555', 'Jane Smith', '111-111-1111', 'Corporate account'),
    ('CUST003', 'Charlie', 'Brown', '999-999-9999', 'Sally Brown', '888-888-8888', 'VIP customer');

-- Populate RoomStatus table
INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
    ('Available', 'Room is available for booking'),
    ('Occupied', 'Room is currently occupied'),
    ('Maintenance', 'Room is under maintenance');

-- Populate RoomTypes table
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
    ('Standard', 'Basic room type'),
    ('Deluxe', 'Upgraded room type with additional amenities'),
    ('Suite', 'Luxurious suite with separate living area');

-- Populate BedTypes table
INSERT INTO BedTypes (BedType, Notes)
VALUES
    ('Single', 'Single bed'),
    ('Double', 'Double bed'),
    ('King', 'King-sized bed');

-- Populate Rooms table
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
    ('101', 'Standard', 'Double', 75.00, 'Available', 'Room with a view'),
    ('202', 'Deluxe', 'King', 120.00, 'Occupied', 'Spacious and comfortable'),
    ('303', 'Suite', 'King', 200.00, 'Maintenance', 'Undergoing renovations');

-- Populate Payments table
INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
    (1, 1, '2023-09-10', 'CUST001', '2023-09-01', '2023-09-05', 5, 375.00, 8.00, 30.00, 405.00, 'Payment for room 101'),
    (2, 2, '2023-09-12', 'CUST002', '2023-09-02', '2023-09-07', 5, 600.00, 10.00, 60.00, 660.00, 'Payment for room 202'),
    (3, 3, '2023-09-14', 'CUST003', '2023-09-03', '2023-09-08', 5, 1000.00, 12.00, 120.00, 1120.00, 'Payment for room 303');

-- Populate Occupancies table
INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
    (1, 1, '2023-09-01', 'CUST001', '101', 75.00, 10.00, 'Room 101 check-in'),
    (2, 2, '2023-09-02', 'CUST002', '202', 120.00, 15.00, 'Room 202 check-in'),
    (3, 3, '2023-09-03', 'CUST003', '303', 200.00, 20.00, 'Room 303 check-in');


SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RoomStatus
SELECT * FROM RoomTypes
SELECT * FROM BedTypes
SELECT * FROM Rooms
SELECT * FROM Payments
SELECT * FROM Occupancies
UPDATE Payments
SET
	TaxRate = TaxRate - TaxRate*0.03
SELECT TaxRate FROM Payments