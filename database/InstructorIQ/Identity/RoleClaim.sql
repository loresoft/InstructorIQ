CREATE TABLE [Identity].[RoleClaim]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,

    [ClaimType] NVARCHAR(max) NULL,
    [ClaimValue] NVARCHAR(max) NULL,

    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_RoleClaim] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE
);

GO
CREATE CLUSTERED INDEX [IX_RoleClaim_RoleId]
    ON [Identity].[RoleClaim]([RoleId] ASC);

