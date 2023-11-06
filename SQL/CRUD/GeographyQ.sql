USE Geography
GO

SELECT PeakName FROM Peaks
ORDER BY PeakName ASC

SELECT TOP 30 CountryName, Population FROM Countries
WHERE ContinentCode IN(
	SELECT ContinentCode FROM Continents
	WHERE ContinentName = 'Europe'
)
ORDER BY Population DESC, CountryName ASC

SELECT CountryName, CountryCode,
       CASE
           WHEN CurrencyCode = 'EUR' THEN 'Euro'
           ELSE 'Not Euro'
       END AS Currency
FROM Countries
ORDER BY CountryName ASC;
