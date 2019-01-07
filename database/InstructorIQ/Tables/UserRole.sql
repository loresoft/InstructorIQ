﻿CREATE TABLE [IQ].[UserRole]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_UserRole_Id] DEFAULT (NEWSEQUENTIALID()),

    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [TenantId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [IQ].[User]([Id]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [IQ].[Role]([Id]),
    CONSTRAINT [FK_UserRole_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO

CREATE UNIQUE CLUSTERED INDEX [UX_UserRole_UserId_RoleId]
ON [IQ].[UserRole] ([UserId] ASC, [TenantId] ASC, [RoleId] ASC)

GO