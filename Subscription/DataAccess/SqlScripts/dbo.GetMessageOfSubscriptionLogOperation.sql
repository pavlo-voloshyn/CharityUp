CREATE OR ALTER FUNCTION dbo.GetMessageOfSubscriptionLogOperation(
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @FoundationId UNIQUEIDENTIFIER,
    @Amount DECIMAL(18,2),
    @SubscriptionEnded DATETIME2(7),
    @Message NVARCHAR(50)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN @Message + 'WITH ID:{' + CAST(@Id AS NVARCHAR(MAX))+ 
    '} For user: {' + CAST(@UserId AS NVARCHAR(MAX)) +
    '} For foundation: {' + CAST(@FoundationId AS NVARCHAR(MAX)) +
    '} With Amount: {' + CAST(@Amount AS NVARCHAR(MAX)) +
    '} Where ended: ' + CAST(@SubscriptionEnded AS NVARCHAR(MAX))
END;