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
