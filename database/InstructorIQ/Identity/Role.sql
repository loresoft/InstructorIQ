CREATE TABLE [Identity].[Role]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Role_Id] DEFAULT (newsequentialid()),

    [Name] NVARCHAR(256) NULL,
    [NormalizedName] NVARCHAR(256) NULL,

    [Description] NVARCHAR(MAX) NULL,

    [ConcurrencyStamp] NVARCHAR(MAX) NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [Identity].[Role]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);
