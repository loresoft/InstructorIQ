CREATE TABLE [IQ].[InstructorRole]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_InstructorRole_Id] DEFAULT (NEWSEQUENTIALID()),

    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_InstructorRole_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_InstructorRole_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_InstructorRole] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InstructorRole_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_InstructorRole_Name]
    ON [IQ].[InstructorRole] ([Name])

GO
CREATE INDEX [IX_InstructorRole_TenantId]
    ON [IQ].[InstructorRole] ([TenantId])
