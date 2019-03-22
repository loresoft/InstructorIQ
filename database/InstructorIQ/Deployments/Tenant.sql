-- Table [IQ].[Tenant] data

MERGE INTO [IQ].[Tenant] AS t
USING
(
    VALUES
    (
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'Demo Tenant',
        'Demo',
        'Demo Tenant',
        NULL,
        'MN',
        'Central Standard Time',
        'InstructorIQ.com',
        0
    ),
    (
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        'Test Tenant',
        'Test',
        'Test Tenant',
        NULL,
        'MN',
        'Central Standard Time',
        'mailinator.com',
        0
    )
)
AS s
(
    [Id],
    [Name],
    [Slug],
    [Description],
    [City],
    [StateProvince],
    [TimeZone],
    [DomainName],
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
        [Slug],
        [Description],
        [City],
        [StateProvince],
        [TimeZone],
        [DomainName],
        [IsDeleted]
    )
    VALUES
    (
        s.[Id],
        s.[Name],
        s.[Slug],
        s.[Description],
        s.[City],
        s.[StateProvince],
        s.[TimeZone],
        s.[DomainName],
        s.[IsDeleted]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[Name] = s.[Name],
        t.[Slug] = s.[Slug],
        t.[Description] = s.[Description],
        t.[City] = s.[City],
        t.[StateProvince] = s.[StateProvince],
        t.[TimeZone] = s.[TimeZone],
        t.[DomainName] = s.[DomainName],
        t.[IsDeleted] = s.[IsDeleted]
OUTPUT $action as [Action];

