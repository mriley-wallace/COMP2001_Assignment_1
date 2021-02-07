DECLARE @RC int
DECLARE @Users_ID int

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[Delete_User] 
   @Users_ID = 1;
GO