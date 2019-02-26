-- Table [Identity].[UserClaim] data

MERGE INTO [Identity].[UserClaim] AS t
USING
(
    VALUES
    (
        'tenant_id',
        '2A3080D2-A9EC-E711-87C2-708BCD56AA6D',
        '3ce68132-6617-4222-326e-08d697685e3a'
    ),
    (
        'tenant_id',
        'E8A8DB6E-2FEB-E711-87C1-708BCD56AA6D',
        'c1e86361-62d2-4ef9-4618-08d69773ffa9'
    )
)
AS s
(
    [ClaimType],
    [ClaimValue],
    [UserId]
)
ON
(
    t.[UserId] = s.[UserId] and t.[ClaimType] = s.[ClaimType] and  t.[ClaimValue] = s.[ClaimValue]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [ClaimType],
        [ClaimValue],
        [UserId]
    )
    VALUES
    (
        s.[ClaimType],
        s.[ClaimValue],
        s.[UserId]
    )

OUTPUT $action as [Action];

