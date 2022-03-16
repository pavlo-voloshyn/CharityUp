USE SubscriptionDb
GO

CREATE OR ALTER TRIGGER SubscriptionUPDATE
ON dbo.Subscriptions
AFTER UPDATE
AS
INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'UPDATED SUBSCRIPTION '), GETDATE()
FROM INSERTED
GO