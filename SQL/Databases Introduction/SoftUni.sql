CREATE DATABASE SoftUni
USE SoftUni
GO
CREATE TABLE Towns (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)
CREATE TABLE Addresses (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AddressText TEXT NOT NULL,
	TownId INT NOT NULL,
	FOREIGN KEY (TownId) REFERENCES Towns(Id)	
)

CREATE TABLE Departments (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7,3) NOT NULL,
	AddressId INT NOT NULL,
	FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)
 --Insert sample data into the Towns table
INSERT INTO Towns (Name)
VALUES
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
	('Burgas');

 --Insert sample data into the Addresses table
INSERT INTO Addresses (AddressText, TownId)
VALUES
    ('123 Main St, Apt 101', 1), 
    ('456 Elm St, Suite 202', 2), 
    ('789 Oak St, Unit 303', 3);

 --Insert sample data into the Departments table
INSERT INTO Departments (Name)
VALUES
    ('Engineering'),
    ('Marketing'),
    ('Sales'),
	('Software Development'),
	('Quality Assurance');

 Insert sample data into the Employees table
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', '4', '2013-02-01', 3500.00,1),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', '1', '2004-03-02', 4000.00, 2),
	('Maria', 'Petrova', 'Ivanova', 'Intern', '5', '2016-08-28', 525.25, 3),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', '3', '2007-09-12', 3000.00, 1),
	('Peter', 'Pan', 'Pan', 'Intern', '2', '2016-08-28', 599.88, 2);

SELECT * FROM Towns 
ORDER BY Name;
SELECT * FROM Addresses
SELECT * FROM Departments
ORDER BY Name;
SELECT * FROM Employees
ORDER BY Salary DESC;

UPDATE Employees
SET
	Salary = Salary * 1.1
SELECT Salary FROM Employees
SELECT Name FROM Towns 
ORDER BY Name;
SELECT Name FROM Departments
ORDER BY Name;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;