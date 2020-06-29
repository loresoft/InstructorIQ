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

