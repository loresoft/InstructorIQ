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
:r .\Deployments\User.sql
:r .\Deployments\Role.sql
:r .\Deployments\Tenant.sql
:r .\Deployments\TenantUserRole.sql

/* Must Be Last */
:r .\Datasweeps.sql