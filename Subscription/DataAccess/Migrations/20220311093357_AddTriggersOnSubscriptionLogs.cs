using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddTriggersOnSubscriptionLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER FUNCTION dbo.GetMessageOfSubscriptionLogOperation(
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
                                END;");

            migrationBuilder.Sql(@" USE SubscriptionDb
                                    GO

                                    CREATE OR ALTER TRIGGER SubscriptionDELETE
                                    ON dbo.Subscriptions
                                    AFTER UPDATE
                                    AS
                                    INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
                                    SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'DELETED SUBSCRIPTION '), GETDATE()
                                    FROM DELETED
                                    GO");

            migrationBuilder.Sql(@" USE SubscriptionDb
                                    GO

                                    CREATE OR ALTER TRIGGER SubscriptionINSERT
                                    ON dbo.Subscriptions
                                    AFTER INSERT
                                    AS
                                    INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
                                    SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'INSERTED A NEW SUBSCRIPTION '), GETDATE()
                                    FROM INSERTED
                                    GO");

            migrationBuilder.Sql(@" USE SubscriptionDb
                                    GO

                                    CREATE OR ALTER TRIGGER SubscriptionUPDATE
                                    ON dbo.Subscriptions
                                    AFTER UPDATE
                                    AS
                                    INSERT INTO SubscriptionLogs (Id, SubscriptionId, [Message], CreatedAt)
                                    SELECT NEWID(), Id, dbo.GetMessageOfSubscriptionLogOperation(Id, UserId, FoundationId, Amount, SubscriptionEnded, 'UPDATED SUBSCRIPTION '), GETDATE()
                                    FROM INSERTED
                                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER SubscriptionUPDATE");
            migrationBuilder.Sql(@"DROP TRIGGER SubscriptionDELETE");
            migrationBuilder.Sql(@"DROP TRIGGER SubscriptionINSERT");
        }
    }
}
