USE SubscriptionDb
GO

CREATE OR ALTER TRIGGER SubscriptionDELETE
ON dbo.Subscriptions
AFTER UPDATE
AS
INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'DELETED SUBSCRIPTION '), GETDATE()
FROM DELETED
GO