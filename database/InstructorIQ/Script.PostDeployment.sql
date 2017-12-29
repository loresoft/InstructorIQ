/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/
:r .\Deployments\EmailTemplate.sql
:r .\Deployments\Organization.sql
:r .\Deployments\User.sql
:r .\Deployments\Role.sql
:r .\Deployments\UserRole.sql

/* Must Be Last */
:r .\Datasweeps.sql