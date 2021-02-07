CREATE PROCEDURE dbo.Update_User @Users_ID INT, @User_ForeName VARCHAR(15), @User_LastName VARCHAR(15), @User_Email VARCHAR(40), @User_Password VARCHAR(40)
AS
BEGIN TRY

        IF (@User_ForeName IS NULL)
         SELECT @User_ForeName = User_ForeName FROM Users WHERE @Users_ID = Users_ID

        ELSE
        UPDATE dbo.Users
        SET User_ForeName = @User_ForeName WHERE @Users_ID = Users_ID

        IF (@User_LastName IS NULL)
            SELECT @User_LastName = User_LastName FROM Users WHERE @Users_ID = Users_ID

        ELSE
            UPDATE dbo.Users
            SET User_LastName = @User_LastName WHERE @Users_ID = Users_ID

        IF (@User_Email IS NULL)
            SELECT @User_Email = User_Email FROM Users WHERE @Users_ID = Users_ID

        ELSE 
            UPDATE dbo.Users
            SET User_Email = @User_Email WHERE @Users_ID = Users_ID

        IF(@User_Password IS NULL)
            SELECT @User_Password = User_Password FROM Users WHERE @Users_ID = Users_ID
        ELSE
            UPDATE dbo.Users
            SET User_Password = @User_Password WHERE @Users_ID = Users_ID

END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
DECLARE @ReturnValue INT
EXEC @ReturnValue = Validate_User 'midgento@live.co.uk','bigwerewolf23'
PRINT @ReturnValue