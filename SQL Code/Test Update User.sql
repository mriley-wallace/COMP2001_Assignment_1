DECLARE @RC int
DECLARE @Users_ID int
DECLARE @User_ForeName varchar(15)
DECLARE @User_LastName varchar(15)
DECLARE @User_Email varchar(40)
DECLARE @User_Password varchar(40)

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[UpdateUser] 
   @Users_ID = 1
  ,@User_ForeName = null
  ,@User_LastName = null
  ,@User_Email = null
  ,@User_Password = 'bigwerewolf23'
GO