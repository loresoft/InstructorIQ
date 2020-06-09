CREATE PROCEDURE [Log].[SearchLogs]
    @Date DATE,
    @Level NVARCHAR(20) = NULL,
    @Search NVARCHAR(256) = NULL,
    @Offset INT = 0,
    @Size INT = 100,
    @Total BIGINT OUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Total = (
        SELECT COUNT(t.[TimeStamp])
        FROM [Log].[LogEvent] AS t WITH (NOLOCK)
        WHERE CONVERT(DATE, t.[TimeStamp]) = @Date
            AND (@Level IS NULL OR t.[Level] = @Level)
            AND (@Search IS NULL OR t.[Message] LIKE @Search)
    );

    SELECT
        t.[TimeStamp],
        t.[Level],
        t.[Message],
        t.[Exception],
        t.[LogEvent]
    FROM [Log].[LogEvent] AS t WITH (NOLOCK)
        WHERE CONVERT(DATE, t.[TimeStamp]) = @Date
            AND (@Level IS NULL OR t.[Level] = @Level)
            AND (@Search IS NULL OR t.[Message] LIKE @Search)
    ORDER BY t.[TimeStamp] DESC
        OFFSET @Offset ROWS
        FETCH NEXT @Size ROWS ONLY;

    SET NOCOUNT OFF;
END