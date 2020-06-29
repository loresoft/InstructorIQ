-- Table [IQ].[TenantUserRole] data

MERGE INTO [IQ].[TenantUserRole] AS t
USING
(
    VALUES
    (
        '982769b6-5a4c-e911-aa78-1e872cb6cb93',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        '3ce68132-6617-4222-326e-08d697685e3a',
        'd373fbb2-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        'b34e13cb-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'c1e86361-62d2-4ef9-4618-08d69773ffa9',
        'd373fbb2-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        '15381fd7-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'c1e86361-62d2-4ef9-4618-08d69773ffa9',
        '808c0ec0-39eb-e711-87c1-708bcd56aa6d'
    ),
    (
        'ce0786e1-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'c1e86361-62d2-4ef9-4618-08d69773ffa9',
        '8fa6aec8-39eb-e711-87c1-708bcd56aa6d'
    )
)
AS s
(
    [Id],
    [TenantId],
    [UserId],
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
        [TenantId],
        [UserId],
        [RoleId]
    )
    VALUES
    (
        s.[Id],
        s.[TenantId],
        s.[UserId],
        s.[RoleId]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[TenantId] = s.[TenantId],
        t.[UserId] = s.[UserId],
        t.[RoleId] = s.[RoleId]
OUTPUT $action as [Action];

