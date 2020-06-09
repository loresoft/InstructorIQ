CREATE PROCEDURE [IQ].[PurgeEmailDelivery]
	@daysToKeep INT = 90
AS
BEGIN
	DECLARE @trimDate AS DATETIME2 = DATEADD(day, (@daysToKeep * -1), CURRENT_TIMESTAMP);

	-- This DECLARE assignment sets @@ROWCOUNT to 1
	WHILE @@ROWCOUNT > 0
	BEGIN
		-- prevent lock escalation by deleting in batches
		DELETE TOP(1000) FROM [IQ].[EmailDelivery]
		WHERE [IsDelivered] = 1
			AND [Delivered] IS NOT NULL
			AND [Delivered] < @trimDate;
	END

END
