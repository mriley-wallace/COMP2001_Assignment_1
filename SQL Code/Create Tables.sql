-- If table already exists, don't make another one --
IF OBJECT_ID(N'dbo.Users', N'U') IS NOT NULL
BEGIN
DROP TABLE dbo.Users;
END

--Creating the 'Users' table --
CREATE TABLE dbo.Users
(
    Users_ID INT NOT NULL IDENTITY (1,1),
    User_ForeName VARCHAR(15),
    User_LastName VARCHAR(15),
    User_Email VARCHAR(40),
    User_Password VARCHAR(40),

    PRIMARY KEY (Users_ID),
);

IF OBJECT_ID(N'dbo.Passwords', N'U') IS NOT NULL
BEGIN
DROP TABLE dbo.Passwords;
END

--Creating the passwords table--
CREATE TABLE dbo.Passwords
(
    Users_ID INT NOT NULL, 
    Old_Password VARCHAR(40),
    P_Changed DATETIME NOT NULL,

    FOREIGN KEY (Users_ID) REFERENCES Users (Users_ID)
);

IF OBJECT_ID(N'dbo.Sessions', N'U') IS NOT NULL
BEGIN
DROP TABLE dbo.Sessions;
END

--Creating the Sessions table--
CREATE TABLE dbo.Sessions
(
    Users_ID INT NOT NULL,
    Sessions_ID INT NOT NULL IDENTITY (1,1),
    Login_Date DATETIME NOT NULL,

    FOREIGN KEY (Users_ID) REFERENCES Users (Users_ID)
);


--Inserting dummy values in to test tables--
SET IDENTITY_INSERT dbo.Users ON
INSERT INTO dbo.Users (Users_ID, User_ForeName, User_LastName, User_Email, User_Password)
VALUES (1, 'Michael', 'Riley', 'midgento@live.co.uk', 'tenpin1010');
SET IDENTITY_INSERT dbo.Users OFF

INSERT INTO dbo.Passwords (Users_ID, Old_Password, P_Changed)
VALUES (1, 'bulldog4242', '2021-10-01 19:47:00');



INSERT INTO dbo.Sessions (Users_ID, Login_Date)
VALUES (1, '2021-01-01 16:45:38');
