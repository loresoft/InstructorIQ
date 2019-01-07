-- Table [IQ].[User] data

MERGE INTO [IQ].[User] AS t
USING
(
    VALUES
    (
        '2a31eec5-30eb-e711-87c1-708bcd56aa6d',
        'support@InstructorIQ.com',
        1,
        'InstructorIQ Support',
        'AQAAAAEAACcQAAAAEAXUuNkUYofVK26eJqdE4gxaxbjVGlj67l7cruoqSZYhGvb2c8EWkKXE8x7C2S6aBQ==',
        'e8a8db6e-2feb-e711-87c1-708bcd56aa6d'
    ),
    (
        '52ae0c20-c4de-e711-87bf-708bcd56aa6d',
        'test@mailinator.com',
        1,
        'Test User',
        'AQAAAAEAACcQAAAAEP8GauthVFLL/l5N/QeA3TmZLo0kQ/QwLAJnkjv4/Mtb8XT7H3iWSOoFZBIj+dJqEw==',
        '2a3080d2-a9ec-e711-87c2-708bcd56aa6d'
    )
)
AS s
(
    [Id],
    [EmailAddress],
    [IsEmailAddressConfirmed],
    [DisplayName],
    [PasswordHash],
    [LastTenantId]
)
ON
(
    t.[Id] = s.[Id]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Id],
        [EmailAddress],
        [IsEmailAddressConfirmed],
        [DisplayName],
        [PasswordHash],
        [LastTenantId]
    )
    VALUES
    (
        s.[Id],
        s.[EmailAddress],
        s.[IsEmailAddressConfirmed],
        s.[DisplayName],
        s.[PasswordHash],
        s.[LastTenantId]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[EmailAddress] = s.[EmailAddress],
        t.[IsEmailAddressConfirmed] = s.[IsEmailAddressConfirmed],
        t.[DisplayName] = s.[DisplayName],
        t.[PasswordHash] = s.[PasswordHash],
        t.[LastTenantId] = s.[LastTenantId]
OUTPUT $action as [Action];

