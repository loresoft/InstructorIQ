CREATE TABLE [IQ].[Instructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Instructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [GivenName] nvarchar(256) NOT NULL,
    [MiddleName] nvarchar(256) NULL,
    [FamilyName] nvarchar(256) NOT NULL,

    [DisplayName] NVARCHAR(256) NOT NULL,

    [JobTitle] nvarchar(256) NULL,

    [EmailAddress] nvarchar(256) NOT NULL,
    [MobilePhone] nvarchar(50) NOT NULL,
    [BusinessPhone] nvarchar(50) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Instructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Instructor_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_Instructor_EmailAddress]
    ON [IQ].[Instructor] ([EmailAddress])

GO
CREATE INDEX [IX_Instructor_TenantId]
    ON [IQ].[Instructor] ([TenantId])
