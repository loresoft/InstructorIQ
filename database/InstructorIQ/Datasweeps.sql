/*
-------------------------------------------------------------------------------------
Please follow the template below to include a single-run datasweep in the deployment:
-------------------------------------------------------------------------------------

IF NOT EXISTS (SELECT [Id] FROM [dbo].[Datasweep] WHERE [Id] = <new_guid>)
BEGIN
    PRINT 'Performing Datasweep: <new_guid>'

    <insert datasweep here>


    INSERT [dbo].[Datasweep] ([Id])
    VALUES (<new_guid>)
END
*/

IF NOT EXISTS (SELECT [Id] FROM [dbo].[Datasweep] WHERE [Id] = '0d011dd0-9de5-4b36-8969-3a1c0473ad55')
BEGIN
    PRINT 'Performing Datasweep: Removing Email Templates ...'

    DELETE FROM [IQ].[EmailTemplate]
    WHERE [Id] in ('855DAAC8-CBDF-E711-87BF-708BCD56AA6D', '02B4BEE4-C75B-E911-AA7C-5CF3708FF0FB')


    INSERT [dbo].[Datasweep] ([Id])
    VALUES ('0d011dd0-9de5-4b36-8969-3a1c0473ad55')
END

IF NOT EXISTS (SELECT [Id] FROM [dbo].[Datasweep] WHERE [Id] = '19f72c77-d546-42e2-8eab-9ec8df275dd3')
BEGIN
    PRINT 'Ensure Instrutor Role'

    MERGE [IQ].[TenantUserRole] WITH (ROWLOCK) AS D
    USING 
    (
        SELECT
            [EmailAddress] AS [UserName],
            [TenantId]
        FROM [IQ].[Instructor]
        WHERE [EmailAddress] IS NOT NULL
    )
    AS S
        ON D.[UserName] = S.[UserName] 
            AND D.[TenantId] = S.[TenantId]
            AND D.[RoleName] = 'Instructor'
    WHEN NOT MATCHED THEN
        INSERT
        (
            [TenantId],
            [UserName],
            [RoleName]
        )
        VALUES
        (
            S.[TenantId],
            S.[UserName],
            'Instructor'
        );

    INSERT [dbo].[Datasweep] ([Id])
    VALUES ('19f72c77-d546-42e2-8eab-9ec8df275dd3')
END

IF NOT EXISTS (SELECT [Id] FROM [dbo].[Datasweep] WHERE [Id] = 'f36bfb5e-4d73-471a-973d-2bc71f2de7b1')
BEGIN
    PRINT 'Performing Datasweep: Populate SortName'

    UPDATE [Identity].[User] SET
        [SortName] = [FamilyName] + ', ' + [GivenName]
    WHERe [FamilyName] IS NOT NULL 
        AND [GivenName] IS NOT NULL 
        AND [SortName] IS NULL;

    UPDATE [IQ].[Instructor] SET
        [SortName] = [FamilyName] + ', ' + [GivenName]
    WHERe [FamilyName] IS NOT NULL 
        AND [GivenName] IS NOT NULL 
        AND [SortName] IS NULL;
    
    INSERT [dbo].[Datasweep] ([Id])
    VALUES ('f36bfb5e-4d73-471a-973d-2bc71f2de7b1')
END



IF NOT EXISTS (SELECT [Id] FROM [dbo].[Datasweep] WHERE [Id] = 'b3285c86-46ab-4284-a3ef-74645fdc77db')
BEGIN
    PRINT 'Performing Datasweep: Fix attendance names'

    UPDATE [IQ].[Attendance] SET
        [AttendeeName] = u.[SortName]
    FROM [IQ].[Attendance] as a
    LEFT OUTER JOIN [Identity].[User] as u on u.[UserName] = a.[AttendeeEmail]
    WHERE a.[AttendeeName] IS NULL
    
    INSERT [dbo].[Datasweep] ([Id])
    VALUES ('b3285c86-46ab-4284-a3ef-74645fdc77db')
END