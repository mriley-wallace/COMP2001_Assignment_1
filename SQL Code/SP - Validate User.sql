CREATE PROCEDURE dbo.Validate_User @User_Email VARCHAR(40), @User_Password VARCHAR(40)
AS
BEGIN TRY
        IF EXISTS (SELECT * FROM Users WHERE User_Email = @User_Email AND User_Password = @User_Password)
        BEGIN
        INSERT INTO dbo.Sessions (Users_ID, Login_Date)
            VALUES ((SELECT Users_ID FROM Users WHERE @User_Email = User_Email), (SELECT GETDATE()))
            RETURN (1)

        END
            ELSE
                BEGIN
                RETURN (0)
            END
END TRY
BEGIN CATCH
    ROLLBACK
END CATCH
