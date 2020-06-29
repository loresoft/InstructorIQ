CREATE TABLE [IQ].[TenantUserRole]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_TenantUserRole_Id] DEFAULT (NEWSEQUENTIALID()),

    [TenantId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [RoleId] UNIQUEIDENTIFIER NULL,


    [UserName] NVARCHAR(100) NULL,
    [RoleName] NVARCHAR(100) NULL,

    CONSTRAINT [PK_TenantUserRole] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TenantUserRole_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_TenantUserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User]([Id]),
    CONSTRAINT [FK_TenantUserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role]([Id]),
)

GO
CREATE NONCLUSTERED INDEX [IX_TenantUserRole_TenantId_UserId]
    ON [IQ].[TenantUserRole] ([TenantId] ASC, [UserId] ASC)