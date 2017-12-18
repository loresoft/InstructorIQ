CREATE TABLE [dbo].[Group]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Group_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Group_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Group_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Group] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Group_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),

)

GO
CREATE INDEX [IX_Group_Name]
ON [dbo].[Group] ([Name])

GO
CREATE INDEX [IX_Group_OrganizationId]
ON [dbo].[Group] ([OrganizationId])
