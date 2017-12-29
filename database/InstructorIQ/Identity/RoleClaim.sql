CREATE TABLE [dbo].[RoleClaim]
(
    [Id] INT NOT NULL IDENTITY,

    [ClaimType] NVARCHAR(max) NULL,
    [ClaimValue] NVARCHAR(max) NULL,

    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_RoleClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
);

GO
CREATE INDEX [IX_RoleClaim_RoleId]
ON [dbo].[RoleClaim] ([RoleId])

