CREATE PROCEDURE [Log].[PurgeLogs]
	@daysToKeep INT = 30
AS
BEGIN
	DECLARE @trimDate AS DATETIME2 = DATEADD(day, (@daysToKeep * -1), CURRENT_TIMESTAMP);

	-- This DECLARE assignment sets @@ROWCOUNT to 1
	WHILE @@ROWCOUNT > 0
	BEGIN
		-- prevent lock escalation by deleting in batches
		DELETE TOP(1000) FROM [Log].[LogEvent]
		WHERE [TimeStamp] < @trimDate;
	END
END
