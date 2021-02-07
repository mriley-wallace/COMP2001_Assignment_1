CREATE VIEW UserLogs
AS
SELECT Sessions.Users_ID, COUNT(*) AS Login_Count
FROM Sessions
GROUP BY Users_ID;
GO