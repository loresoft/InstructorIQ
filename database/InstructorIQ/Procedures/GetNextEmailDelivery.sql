CREATE PROCEDURE [IQ].[GetNextEmailDelivery]
AS
BEGIN
	SET NOCOUNT ON;

	WITH q AS
	(
		SELECT TOP 1 *
		FROM [IQ].[EmailDelivery] ed
		WHERE ed.[IsProcessing] = 0
			AND ed.[IsDelivered] = 0
			AND ed.[NextAttempt] IS NOT NULL
			AND ed.[NextAttempt] <= SYSUTCDATETIME()
		ORDER BY ed.[NextAttempt]
	)
	UPDATE q WITH (READPAST, UPDLOCK, ROWLOCK) SET
		[IsProcessing] = 1
	OUTPUT inserted.*;

	RETURN 0;
END