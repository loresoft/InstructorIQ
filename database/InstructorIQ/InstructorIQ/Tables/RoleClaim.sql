CREATE TABLE [dbo].[RoleClaim]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_RoleClaim_Id] DEFAULT (newsequentialid()),

    [ClaimType] [NVARCHAR](MAX) NULL,
    [ClaimValue] [NVARCHAR](MAX) NULL,

    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_RoleClaim] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]),
)

GO
CREATE INDEX [IX_RoleClaim_RoleId]
ON [dbo].[RoleClaim] ([RoleId])

