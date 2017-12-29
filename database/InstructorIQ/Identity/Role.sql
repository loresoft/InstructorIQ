CREATE TABLE [dbo].[Role]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Role_Id] DEFAULT (newsequentialid()),

    [Name] NVARCHAR(256) NULL,
    [NormalizedName] NVARCHAR(256) NULL,

    [ConcurrencyStamp] NVARCHAR(max) NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [UX_Role_Name]
ON [dbo].[Role] ([NormalizedName])

GO