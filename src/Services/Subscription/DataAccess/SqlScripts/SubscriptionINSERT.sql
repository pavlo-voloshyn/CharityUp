USE SubscriptionDb
GO

CREATE OR ALTER TRIGGER SubscriptionINSERT
ON dbo.Subscriptions
AFTER INSERT
AS
INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'INSERTED A NEW SUBSCRIPTION '), GETDATE()
FROM INSERTED
GO