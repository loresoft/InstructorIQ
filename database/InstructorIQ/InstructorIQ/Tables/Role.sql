CREATE TABLE [dbo].[Role]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Role_Id] DEFAULT (newsequentialid()),
    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Role_Created] DEFAULT (sysutcdatetime()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Role_Updated] DEFAULT (sysutcdatetime()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE UNIQUE INDEX [UX_Role_Name]
ON [dbo].[Role] ([Name])