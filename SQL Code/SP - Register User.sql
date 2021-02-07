CREATE PROCEDURE dbo.Register_User @User_ForeName VARCHAR(15), @User_LastName VARCHAR(15), @User_Email VARCHAR (40), @User_Password VARCHAR(40)
AS
BEGIN TRY
IF NOT EXISTS (SELECT * FROM Users WHERE User_ForeName = @User_ForeName AND User_LastName = @User_LastName AND User_Email = @User_Email AND User_Password = @User_Password) 
                INSERT INTO dbo.Users (User_ForeName, User_LastName, User_Email, User_Password)
        VALUES (@User_ForeName, @User_LastName, @User_Email, @User_Password)
    RETURN (200)
    RETURN ((SELECT Users_ID FROM Users WHERE @User_ForeName = User_ForeName))
END TRY
BEGIN CATCH
RETURN (208)
ROLLBACK
END CATCH
