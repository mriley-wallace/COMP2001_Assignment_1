DECLARE @RC int
DECLARE @User_ForeName varchar(15)
DECLARE @User_LastName varchar(15)
DECLARE @User_Email varchar(40)
DECLARE @User_Password varchar(40)

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[Register_User] 
   @User_ForeName = 'Thanos'
  ,@User_LastName = 'Sgouros'
  ,@User_Email = 'bigchongas12@gmail.com'
  ,@User_Password = 'greekcorfu1'
GO