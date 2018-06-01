CREATE TABLE [dbo].[UserRole]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_UserRole_Id] DEFAULT (NEWSEQUENTIALID()),

    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]),
    CONSTRAINT [FK_UserRole_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),
)

GO

CREATE UNIQUE CLUSTERED INDEX [UX_UserRole_UserId_RoleId]
ON [dbo].[UserRole] ([UserId] ASC, [OrganizationId] ASC, [RoleId] ASC)

GO