USE CarRental
-- CREATE TABLE Categories (
--    Id INT PRIMARY KEY,
--    CategoryName NVARCHAR(50) NOT NULL,
--    DailyRate DECIMAL(7,2) NOT NULL,     -- Adjusted precision and scale
--    WeeklyRate DECIMAL(7,2) NOT NULL,    -- Adjusted precision and scale
--    MonthlyRate DECIMAL(7,2) NOT NULL,   -- Adjusted precision and scale
--    WeekendRate DECIMAL(7,2) NOT NULL   -- Adjusted precision and scale
--);

-- CREATE TABLE Cars (
--	Id INT PRIMARY KEY,
--	PlateNumber NVARCHAR(6) NOT NULL,
--	Manufacturer NVARCHAR(20) NOT NULL,
--	Model NVARCHAR(20) NOT NULL,
--	CarYear INT NOT  NULL,
--	CategoryId INT NOT NULL,
--	Doors INT,
--	Picture IMAGE,
--	Condition NVARCHAR(20) NOT NULL,
--	Available NVARCHAR(20) NOT NULL
--	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
--)
-- CREATE TABLE Employees (
--	Id INT PRIMARY KEY,
--	FirstName NVARCHAR(20) NOT NULL,
--	LastName NVARCHAR(20),
--	Title NVARCHAR(20) NOT NULL,
--	Notes TEXT
--) 
-- CREATE TABLE Customers (
--	Id INT PRIMARY KEY,
--	DriverLicenceNumber NVARCHAR(10) NOT NULL,
--	FullName NVARCHAR(50) NOT NULL,
--	Address NVARCHAR(100) NOT NULL,
--	City NVARCHAR(50) NOT NULL,
--	ZIPCode NVARCHAR(10) NOT NULL,
--	Notes TEXT
--)
-- CREATE TABLE RentalOrders (
--	Id INT PRIMARY KEY,
--	EmployeeId INT NOT NULL,
--	CustomerId INT NOT NULL,
--	CarId INT NOT NULL,
--	TankLevel DECIMAL(7,2) NOT NULL,
--	KilometrageStart DECIMAL(7,2) NOT NULL,
--	KilometrageEnd DECIMAL(7,2),
--	TotalKilometrage DECIMAL(7,2),
--	StartDate DATE NOT NULL,
--	EndDate DATE NOT NULL,
--	TotalDays INT NOT NULL,
--	RateApplied DECIMAL(7,2) NOT NULL,
--	TaxRate DECIMAL(7,2) NOT NULL,
--	OrderStatus NVARCHAR(10),
--	Notes TEXT,
--	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
--	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
--	FOREIGN KEY (CarId) REFERENCES Cars(Id)
--)

---- Populate Categories table
--INSERT INTO Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--VALUES
--    (1, 'Economy', 35.00, 210.00, 700.00, 40.00),
--    (2, 'Compact', 45.50, 275.00, 900.00, 55.00),
--    (3, 'Midsize', 55.75, 330.50, 1100.00, 65.25),
--    (4, 'Full-Size', 65.25, 390.00, 1300.00, 75.50),
--    (5, 'Luxury', 90.00, 540.00, 1800.00, 100.00);


---- Populate Cars table
--INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--VALUES
--    (1, 'ABC123', 'Toyota', 'Corolla', 2022, 2, 4, 'car1.jpg', 'Excellent', 1),
--    (2, 'XYZ789', 'Honda', 'Civic', 2021, 2, 4, 'car2.jpg', 'Good', 1),
--    (3, 'DEF456', 'Ford', 'Escape', 2020, 3, 4, 'car3.jpg', 'Excellent', 1);

---- Populate Employees table
--INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
--VALUES
--    (1, 'John', 'Doe', 'Manager', 'Manages the rental office'),
--    (2, 'Jane', 'Smith', 'Sales Agent', 'Assists customers with rentals'),
--    (3, 'Robert', 'Johnson', 'Mechanic', 'Maintains and repairs rental cars');

---- Populate Customers table
--INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--VALUES
--    (1, 'DL123456', 'Alice Johnson', '123 Main St', 'Anytown', '12345', 'Frequent renter'),
--    (2, 'DL789012', 'Bob Smith', '456 Elm St', 'Smallville', '54321', 'Corporate account'),
--    (3, 'DL345678', 'Charlie Brown', '789 Oak St', 'Metroville', '98765', 'VIP customer');

---- Populate RentalOrders table
--INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--VALUES
--    (1, 1, 1, 1, 95.0, 5000, 5250, 250, '2023-09-10', '2023-09-15', 5, 180.00, 0.08, 'Completed', 'Business trip'),
--    (2, 2, 2, 2, 90.0, 3000, 3200, 200, '2023-09-12', '2023-09-18', 6, 210.00, 0.08, 'Completed', 'Vacation rental'),
--    (3, 3, 3, 3, 100.0, 8000, 8200, 200, '2023-09-14', '2023-09-17', 3, 40.00, 0.08, 'Completed', 'Local rental');

--SELECT * FROM Categories
--SELECT * FROM Cars
--SELECT * FROM Employees
--SELECT * FROM Customers
--SELECT * FROM RentalOrders


-- Create Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
    DailyRate DECIMAL(7,2) NOT NULL,
    WeeklyRate DECIMAL(7,2) NOT NULL,
    MonthlyRate DECIMAL(7,2) NOT NULL,
    WeekendRate DECIMAL(7,2) NOT NULL
);

-- Create Cars table
CREATE TABLE Cars (
    Id INT PRIMARY KEY,
    PlateNumber NVARCHAR(20) NOT NULL,
    Manufacturer NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT NOT NULL,
    Doors INT NOT NULL,
    Picture NVARCHAR(255),
    Condition NVARCHAR(100) NOT NULL,
    Available BIT NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

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
    Id INT PRIMARY KEY,
    DriverLicenceNumber NVARCHAR(20) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    ZIPCode NVARCHAR(10) NOT NULL,
    Notes NVARCHAR(MAX)
);

-- Create RentalOrders table
CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    TankLevel DECIMAL(5,2) NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    RateApplied DECIMAL(7,2) NOT NULL,
    TaxRate DECIMAL(5,2) NOT NULL,
    OrderStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX),
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

-- Populate Categories table
INSERT INTO Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
    (1, 'Economy', 35.00, 210.00, 700.00, 40.00),
    (2, 'Compact', 45.50, 275.00, 900.00, 55.00),
    (3, 'Midsize', 55.75, 330.50, 1100.00, 65.25);

-- Populate Cars table
INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
    (1, 'ABC123', 'Toyota', 'Corolla', 2022, 2, 4, 'car1.jpg', 'Excellent', 1),
    (2, 'XYZ789', 'Honda', 'Civic', 2021, 2, 4, 'car2.jpg', 'Good', 1),
    (3, 'DEF456', 'Ford', 'Escape', 2020, 3, 4, 'car3.jpg', 'Excellent', 1);

-- Populate Employees table
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
    (1, 'John', 'Doe', 'Manager', 'Manages the rental office'),
    (2, 'Jane', 'Smith', 'Sales Agent', 'Assists customers with rentals'),
    (3, 'Robert', 'Johnson', 'Mechanic', 'Maintains and repairs rental cars');

-- Populate Customers table
INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
    (1, 'DL123456', 'Alice Johnson', '123 Main St', 'Anytown', '12345', 'Frequent renter'),
    (2, 'DL789012', 'Bob Smith', '456 Elm St', 'Smallville', '54321', 'Corporate account'),
    (3, 'DL345678', 'Charlie Brown', '789 Oak St', 'Metroville', '98765', 'VIP customer');

-- Populate RentalOrders table
INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
    (1, 1, 1, 1, 95.0, 5000, 5250, 250, '2023-09-10', '2023-09-15', 5, 180.00, 0.08, 'Completed', 'Business trip'),
    (2, 2, 2, 2, 90.0, 3000, 3200, 200, '2023-09-12', '2023-09-18', 6, 210.00, 0.08, 'Completed', 'Vacation rental'),
    (3, 3, 3, 3, 100.0, 8000, 8200, 200, '2023-09-14', '2023-09-17', 3, 40.00, 0.08, 'Completed', 'Local rental');
