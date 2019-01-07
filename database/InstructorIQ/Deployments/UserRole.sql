-- Table [IQ].[UserRole] data

MERGE INTO [IQ].[UserRole] AS t
USING
(
    VALUES
    (
        '21f73a65-3ceb-e711-87c1-708bcd56aa6d',
        '2a31eec5-30eb-e711-87c1-708bcd56aa6d',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        '8fa6aec8-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        '86426651-a9ec-e711-87c2-708bcd56aa6d',
        '2a31eec5-30eb-e711-87c1-708bcd56aa6d',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        '808c0ec0-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        'cb51245b-a9ec-e711-87c2-708bcd56aa6d',
        '2a31eec5-30eb-e711-87c1-708bcd56aa6d',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'd373fbb2-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        '82328338-aaec-e711-87c2-708bcd56aa6d',
        '52ae0c20-c4de-e711-87bf-708bcd56aa6d',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        '8fa6aec8-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        '83328338-aaec-e711-87c2-708bcd56aa6d',
        '52ae0c20-c4de-e711-87bf-708bcd56aa6d',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        '808c0ec0-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        '84328338-aaec-e711-87c2-708bcd56aa6d',
        '52ae0c20-c4de-e711-87bf-708bcd56aa6d',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        'd373fbb2-39eb-e711-87c1-708bcd56aa6d'
    )
)
AS s
(
    [Id],
    [UserId],
    [TenantId],
    [RoleId]
)
ON
(
    t.[Id] = s.[Id]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Id],
        [UserId],
        [TenantId],
        [RoleId]
    )
    VALUES
    (
        s.[Id],
        s.[UserId],
        s.[TenantId],
        s.[RoleId]
    )
OUTPUT $action as [Action];

