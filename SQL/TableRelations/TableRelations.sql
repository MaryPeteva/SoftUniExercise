--USE RANDOM
--GO

--CREATE TABLE Passports(
--	PassportID INT PRIMARY KEY,
--	PassportNumber NVARCHAR(8) UNIQUE
--)

--CREATE TABLE Persons(
--	PersonID INT PRIMARY KEY IDENTITY(1,1),
--	FirstName NVARCHAR(50) NOT NULL,
--	Salary DECIMAL(8,2) NOT NULL,
--	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
--)

--INSERT INTO Passports(PassportID, PassportNumber)
--VALUES
--	(101, 'N34FG21B'),
--	(102, 'K65LO4R7'),
--	(103, 'ZE657QP2');

--INSERT INTO Persons(FirstName, Salary, PassportID)
--VALUES
--	('Roberto', 43300.00, 102),
--	('Tom', 56100.00, 103),
--	('Yana', 60200.00, 101);

--SELECT * FROM Passports
--SELECT * FROM Persons

--SELECT P.FirstName, PS.PassportNumber
--FROM Persons P
--JOIN Passports PS ON P.PassportID = PS.PassportID;

--CREATE TABLE Manufacturers(
--	ManufacturerID  INT PRIMARY KEY IDENTITY(1,1),
--	Name NVARCHAR(50) NOT NULL,
--	EstablishedOn DATE
--)

--CREATE TABLE Models(
--	ModelID INT PRIMARY KEY IDENTITY(101,1),
--	Name NVARCHAR(50) NOT NULL,
--	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
--)

--SELECT * FROM Manufacturers
--SELECT * FROM Models

--INSERT INTO Manufacturers(Name, EstablishedOn)
--VALUES
--	('BMW' ,'07/03/1916'), 
--	('Tesla','01/01/2003'), 
--	('Lada','01/05/1966');

--INSERT INTO Models(Name, ManufacturerID)
--VALUES
--	('X1', 1),
--	('i6', 1),
--	('Model S', 2),
--	('Model X', 2),
--	('Model 3', 2),
--	('Nova', 3);

--SELECT M.Name AS ModelName
--FROM Models M
--JOIN Manufacturers MF ON M.ManufacturerID = MF.ManufacturerID
--WHERE MF.Name = 'Tesla';

--CREATE TABLE Students(
--	StudentID INT PRIMARY KEY IDENTITY(1,1),
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Exams(
--	ExamID INT PRIMARY KEY IDENTITY(101,1),
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE StudentsExams(
--	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
--	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
--)

--INSERT INTO Students(Name)
--VALUES
--	('Mila'),
--	('Toni'),
--	('Ron');

--INSERT INTO Exams(Name)
--VALUES
--	('SpringMVC'),
--	('Neo4j'),
--	('Oracle 11g');

--INSERT INTO StudentsExams(StudentID, ExamID)
--VALUES
--	(1, 101),
--	(1, 102),
--	(2, 101);

--SELECT * FROM Students
--SELECT * FROM Exams
--SELECT * FROM StudentsExams

--SELECT ST.Name AS StudentName, E.Name AS Exams
--FROM StudentsExams SE
--JOIN Students ST ON SE.StudentID = ST.StudentID
--JOIN Exams E ON SE.ExamID = E.ExamID

--CREATE TABLE Teachers(
--	TeacherID INT PRIMARY KEY,
--	Name NVARCHAR(50) NOT NULL,
--	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
--)

--INSERT INTO Teachers(TeacherID, Name, ManagerID)
--VALUES
--	(101, 'John', NULL),
--	(102, 'Maya', 106),
--	(103, 'Silvia', 106),
--	(104, 'Ted', 105),
--	(105, 'Mark', 101),
--	(106, 'Greta', 101);

--SELECT * FROM Teachers

--CREATE TABLE Cities(
--	CityID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Customers(
--	CustomerID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL,
--	Birthday DATE NOT NULL,
--	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
--)

--CREATE TABLE Orders(
--	OrderID INT PRIMARY KEY,
--	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
--)

--CREATE TABLE ItemTypes(
--	ItemTypeID INT PRIMARY KEY,
--	Name VARCHAR(50)
--)

--CREATE TABLE Items(
--	ItemID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL,
--	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
--)

--CREATE TABLE OrderItems(
--	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
--	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
--)

--SELECT * FROM Cities
--SELECT * FROM Customers
--SELECT * FROM Orders
--SELECT * FROM ItemTypes
--SELECT * FROM Items
--SELECT * FROM OrderItems

--CREATE TABLE Subjects
--(
--	SubjectID INT PRIMARY KEY,
--	SubjectName VARCHAR(50) NOT NULL
--)

--CREATE TABLE Majors(
--	MajorID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Students(
--	StudentID INT PRIMARY KEY,
--	StudentNumber INT UNIQUE,
--	StudentName VARCHAR(50) NOT NULL,
--	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
--)

--CREATE TABLE Agenda(
--	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
--	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
--)

--CREATE TABLE Payments(
--	PaymentID INT PRIMARY KEY,
--	PaymentDate DATE NOT NULL,
--	PaymentAmount DECIMAL(8,2),
--	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
--)

USE Geography
GO

SELECT M.Id, P.PeakName, P.Elevation
FROM Mountains M
JOIN Peaks P ON M.Id = P.MountainId
WHERE M.MountainRange = 'Rila'
ORDER BY Elevation DESC; 

SELECT M.MountainRange, P.PeakName, P.Elevation
FROM Mountains M
JOIN Peaks P ON M.Id = P.MountainId
WHERE M.MountainRange = 'Rila'
ORDER BY P.Elevation DESC;
