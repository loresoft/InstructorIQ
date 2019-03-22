-- Table [Identity].[User] data

MERGE INTO [Identity].[User] AS t
USING
(
    VALUES
    (
        '3ce68132-6617-4222-326e-08d697685e3a',
        'test@test.com',
        'TEST@TEST.COM',
        1,
        'test@test.com',
        'TEST@TEST.COM',
        'Test User',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d',
        0,
        'AQAAAAEAACcQAAAAEHPiqxm4sPUHn6Phip8f65AbBNSlFYcjppG1ettpFjA/b142jl2TV2IlS8fN9ZJMSw==',
        '6BO66WD72QR2NQIKLA2XX7WQT5NCGWOD',
        'b46d0372-f5ed-4eff-bbae-6c34abfa0a81'
    ),
    (
        'c1e86361-62d2-4ef9-4618-08d69773ffa9',
        'support@InstructorIQ.com',
        'SUPPORT@INSTRUCTORIQ.COM',
        1,
        'support@InstructorIQ.com',
        'SUPPORT@INSTRUCTORIQ.COM',
        'Support',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d',
        1,
        'AQAAAAEAACcQAAAAEP6QKFEOwETAN2lhOpllQ8c5na91FaYbdNRu+4byItVpD5bosn6qoGTmaXakyMCFug==',
        'HTD7C7YJ5D6UEULRG6ND5VDSCC37GS5I',
        '3bc48f6a-5087-4c74-b0b6-721f711c065e'
    )
)
AS s
(
    [Id],
    [Email],
    [NormalizedEmail],
    [EmailConfirmed],
    [UserName],
    [NormalizedUserName],
    [DisplayName],
    [LastTenantId],
    [IsGlobalAdministrator],
    [PasswordHash],
    [SecurityStamp],
    [ConcurrencyStamp]
)
ON
(
    t.[Id] = s.[Id]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Id],
        [Email],
        [NormalizedEmail],
        [EmailConfirmed],
        [UserName],
        [NormalizedUserName],
        [DisplayName],
        [LastTenantId],
        [IsGlobalAdministrator],
        [PasswordHash],
        [SecurityStamp],
        [ConcurrencyStamp]
    )
    VALUES
    (
        s.[Id],
        s.[Email],
        s.[NormalizedEmail],
        s.[EmailConfirmed],
        s.[UserName],
        s.[NormalizedUserName],
        s.[DisplayName],
        s.[LastTenantId],
        s.[IsGlobalAdministrator],
        s.[PasswordHash],
        s.[SecurityStamp],
        s.[ConcurrencyStamp]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[Email] = s.[Email],
        t.[NormalizedEmail] = s.[NormalizedEmail],
        t.[EmailConfirmed] = s.[EmailConfirmed],
        t.[UserName] = s.[UserName],
        t.[NormalizedUserName] = s.[NormalizedUserName],
        t.[DisplayName] = s.[DisplayName],
        t.[LastTenantId] = s.[LastTenantId],
        t.[IsGlobalAdministrator] = s.[IsGlobalAdministrator],
        t.[PasswordHash] = s.[PasswordHash],
        t.[SecurityStamp] = s.[SecurityStamp],
        t.[ConcurrencyStamp] = s.[ConcurrencyStamp]
OUTPUT $action as [Action];

