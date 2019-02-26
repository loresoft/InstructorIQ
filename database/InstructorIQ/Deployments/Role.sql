-- Table [Identity].[Role] data

MERGE INTO [Identity].[Role] AS t
USING
(
    VALUES
    (
        'd373fbb2-39eb-e711-87c1-708bcd56aa6d',
        'Member',
        'Member for organization'
    ),
    (
        '808c0ec0-39eb-e711-87c1-708bcd56aa6d',
        'Instructor',
        'Instructor for organization'
    ),
    (
        '8fa6aec8-39eb-e711-87c1-708bcd56aa6d',
        'Administrator',
        'Administrator for organization'
    )
)
AS s
(
    [Id],
    [Name],
    [Description]
)
ON
(
    t.[Id] = s.[Id]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Id],
        [Name],
        [NormalizedName],
        [Description]
    )
    VALUES
    (
        s.[Id],
        s.[Name],
        UPPER(s.[Name]),
        s.[Description]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[Name] = s.[Name],
        t.[NormalizedName] = UPPER(s.[Name]),
        t.[Description] = s.[Description]
OUTPUT $action as [Action];

