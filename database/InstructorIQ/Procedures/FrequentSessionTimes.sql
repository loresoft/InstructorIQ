CREATE PROCEDURE [IQ].[FrequentSessionTimes]
	@tenantId UNIQUEIDENTIFIER,
	@minimum INT = 2,
	@months INT = 6
AS
BEGIN
	DECLARE @age DATE

	SET @age = DATEADD(month, @months * -1, getdate())

	SELECT
		[StartTime],
		[EndTime],
		COUNT(*) AS [Count]
	FROM [IQ].[Session]
	WHERE [TenantId] = @tenantId
		AND [StartTime] IS NOT NULL
		AND [EndTime] IS NOT NULL
		AND [StartDate] >= @age
	GROUP BY [StartTime], [EndTime]
	HAVING COUNT(*) > @minimum

END
