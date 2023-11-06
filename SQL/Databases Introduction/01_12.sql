USE Minions

GO
SELECT * FROM Minions
SELECT * FROM Towns
SELECT * FROM People 
SELECT * FROM Users
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	Name VARCHAR(200) NOT NULL
)

ALTER TABLE Minions
	ADD TownId INT,
	FOREIGN KEY(TownId) REFERENCES Towns(Id);

INSERT INTO Towns(Id, Name)
VALUES
	(1, 'Sofia'),
	(2,'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(30) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(10,2),
	Weight DECIMAL(10, 2),
	Gender CHAR(1) NOT NULL,
	CHECK (Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Pesho', NULL, 1.50, 45, 'm', '2000/09/21', 'primary student,wants to be astronaut'),
('Gosho', NULL, 1.95, 100, 'm', '1991/07/15', 'atlete, plays basketball'),
('Ivan', NULL, 1.60, 75, 'm', '1988/03/08', 'flips burgers for living and is happy with that'),
('Maria', NULL, 1.80, 80, 'f', '1997/06/03', 'artist, chaos goblin'),
('Gergana', NULL, 1.45, 60, 'f', '2001/12/24', 'just existing')

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password NVARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(8000),
	LastLoginTime TIME,
	IsDeleted BIT
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime,IsDeleted)
VALUES
	('u$eR1', 'pa$$word1', NULL, '2023-09-28 10:00:00', 0),
    ('Us3r2', 'p@sswWord2', NULL, '2023-09-27 15:30:00', 1),
    ('uSer3', 'passw0Oord3', NULL, '2023-09-26 08:45:00', 0),
    ('us3R4', 'p@ssworD4', NULL, '2023-09-25 12:20:00', 0),
    ('user5', 'password5', NULL, '2023-09-24 19:15:00', 1);

ALTER TABLE Users
	DROP CONSTRAINT PK__Users__3214EC07509C2638

ALTER TABLE Users
	ADD CONSTRAINT PK_Users_Complex
		PRIMARY KEY(Id, Username)

ALTER TABLE Users
	ADD CONSTRAINT Check_Password_Length CHECK (LEN(Password) >= 5);

SELECT * FROM sys.check_constraints

ALTER TABLE Users
DROP COLUMN LastLoginTime;

ALTER TABLE Users
ADD LastLoginTimeWithDefault DATETIME DEFAULT GETDATE();

UPDATE Users
SET LastLoginTimeWithDefault = GETDATE();

ALTER TABLE Users
DROP CONSTRAINT PK_Users_Complex

ALTER TABLE Users
ADD CONSTRAINT PK_UsersId
	 PRIMARY KEY (Id);

ALTER TABLE Users
	ADD CONSTRAINT Username_Lenght_CHECK CHECK (LEN(Username) >= 3)

