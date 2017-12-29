CREATE TABLE [dbo].[Organization]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Organization_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,
    [Abbreviation] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [IsDeleted] BIT NOT NULL CONSTRAINT [DF_Organization_IsDeleted] DEFAULT (0),

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Organization_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Organization_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Organization] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE INDEX [IX_Organization_Name]
ON [dbo].[Organization] ([Name])

GO
CREATE INDEX [IX_Organization_IsDeleted]
ON [dbo].[Organization] ([IsDeleted])
