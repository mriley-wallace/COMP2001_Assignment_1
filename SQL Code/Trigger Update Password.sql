CREATE TRIGGER TUpdatedPassword
ON Users
AFTER UPDATE
AS
BEGIN
    IF UPDATE (User_Password)
        BEGIN
            DECLARE @Current_UserID INT;
            DECLARE @Old_Password VARCHAR(40);
            DECLARE @Current_Date DATETIME;
                SELECT @Old_Password = User_Password FROM DELETED;
                SELECT @Current_UserID = Users_ID FROM INSERTED;
                SELECT @Current_Date = GETDATE();

            INSERT INTO Passwords (Users_ID, Old_Password, P_Changed) VALUES (@Current_UserID, @Old_Password, @Current_Date)

        END
END
--GO
--ALTER TABLE dbo.Passwords ENABLE TRIGGER [TUpdatedPassword]
--GO
