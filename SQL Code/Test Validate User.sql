DECLARE @RC int
DECLARE @User_Email varchar(40)
DECLARE @User_Password varchar(40)

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[Validate_User] 
   @User_Email = 'midgento@live.co.uk'
  ,@User_Password = 'tenpin1010'
GO