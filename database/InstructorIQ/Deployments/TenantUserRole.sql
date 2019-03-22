-- Table [IQ].[TenantUserRole] data

MERGE INTO [IQ].[TenantUserRole] AS t
USING
(
    VALUES
    (
        '982769b6-5a4c-e911-aa78-1e872cb6cb93',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        'test@test.com',
        'Member'
    ),
    (
        'b34e13cb-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'support@InstructorIQ.com',
        'Member'
    ),
    (
        '15381fd7-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'support@InstructorIQ.com',
        'Instructor'
    ),
    (
        'ce0786e1-5a4c-e911-aa78-1e872cb6cb93',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        'support@InstructorIQ.com',
        'Administrator'
    )
)
AS s
(
    [Id],
    [TenantId],
    [UserName],
    [RoleName]
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
        [UserName],
        [RoleName]
    )
    VALUES
    (
        s.[Id],
        s.[TenantId],
        s.[UserName],
        s.[RoleName]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[TenantId] = s.[TenantId],
        t.[UserName] = s.[UserName],
        t.[RoleName] = s.[RoleName]
OUTPUT $action as [Action];

