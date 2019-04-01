CREATE TABLE [IQ].[Template]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Template_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255) NULL,

    [TemplateBody] NVARCHAR(MAX) NULL,
    [TemplateType] NVARCHAR(100) NOT NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Template_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Template_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Template] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Template_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_Template_Name]
ON [IQ].[Template] ([Name])

GO
CREATE INDEX [IX_Template_TemplateType]
ON [IQ].[Template] ([TemplateType])

GO
CREATE INDEX [IX_Template_TenantId]
ON [IQ].[Template] ([TenantId])

