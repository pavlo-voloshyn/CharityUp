CREATE OR ALTER PROCEDURE [dbo].[DeleteSubscriptionEnded]
                        AS
                        BEGIN
                            DELETE FROM Subscriptions
                            WHERE  SubscriptionEnded < GETDATE()
                        END