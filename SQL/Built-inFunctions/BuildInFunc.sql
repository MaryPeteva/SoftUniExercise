USE SoftUni
GO

--SELECT FirstName, LastName
--FROM Employees
--WHERE FirstName LIKE 'Sa%';

--SELECT FirstName, LastName
--FROM Employees
--WHERE LastName LIKE '%ei%';

--SELECT FirstName
--FROM Employees
--WHERE (DepartmentID	IN(3, 10)) 
--	AND (YEAR(HireDate) BETWEEN 1995 AND 2005);

--SELECT FirstName, LastName
--FROM Employees
--WHERE JobTitle NOT LIKE '%engineer%';

--SELECT Name 
--FROM Towns
--WHERE DATALENGTH(Name) = 5 OR DATALENGTH(Name) = 6
--ORDER BY Name

--SELECT TownID,Name
--FROM Towns
--WHERE Name LIKE 'M%' OR Name LIKE 'K%' OR Name LIKE 'B%' OR Name LIKE 'E%'
--ORDER BY Name

--SELECT TownID, Name
--FROM Towns
--WHERE LEFT(Name, 1) NOT IN ('R', 'B', 'D')
--ORDER BY Name;

--CREATE VIEW V_EmployeesHiredAfter2000 AS
--SELECT FirstName, LastName
--FROM Employees
--WHERE (YEAR(HireDate) > 2000)

--SELECT FirstName, LastName
--FROM Employees
--WHERE DATALENGTH(LastName) = 5

--SELECT EmployeeID, FirstName, LastName, Salary,
--       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
--FROM Employees
--WHERE Salary BETWEEN 10000 AND 50000
--ORDER BY Salary DESC;


