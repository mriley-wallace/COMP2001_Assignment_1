CREATE PROCEDURE dbo.Delete_User @Users_ID INT
AS
BEGIN TRY
        IF EXISTS (SELECT Users_ID FROM Users WHERE Users_ID = @Users_ID)
        DELETE FROM Passwords WHERE Users_ID = @Users_ID;
        DELETE FROM Sessions WHERE Users_ID = @Users_ID;
        DELETE FROM Users WHERE Users_ID = @Users_ID;
END TRY

BEGIN CATCH
    ROLLBACK
END CATCH