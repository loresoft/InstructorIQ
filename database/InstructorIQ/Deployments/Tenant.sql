-- Table [dbo].[Tenant] data

MERGE INTO [dbo].[Tenant] AS t
USING
(
    VALUES
    (
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'Demo Tenant',
        'DEMO',
        'Demo Tenant',
        0
    ),
    (
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        'Test Tenant',
        'TEST',
        'Test Tenant',
        0
    )
)
AS s
(
    [Id],
    [Name],
    [Abbreviation],
    [Description],
    [IsDeleted]
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
        [Abbreviation],
        [Description],
        [IsDeleted]
    )
    VALUES
    (
        s.[Id],
        s.[Name],
        s.[Abbreviation],
        s.[Description],
        s.[IsDeleted]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[Name] = s.[Name],
        t.[Abbreviation] = s.[Abbreviation],
        t.[Description] = s.[Description],
        t.[IsDeleted] = s.[IsDeleted]
OUTPUT $action as [Action];

