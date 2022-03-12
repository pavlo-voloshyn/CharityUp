using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddDeleteEndedSubscriptionProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE [dbo].[DeleteSubscriptionEnded]
                        AS
                        BEGIN
                            DELETE FROM Subscriptions
                            WHERE  SubscriptionEnded < GETDATE()
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROC [dbo].[DeleteSubscriptionEnded]";

            migrationBuilder.Sql(sp);
        }
    }
}
