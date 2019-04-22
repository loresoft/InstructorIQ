CREATE TABLE [IQ].[Instructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Instructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [GivenName] nvarchar(256) NULL,
    [MiddleName] nvarchar(256) NULL,
    [FamilyName] nvarchar(256) NULL,

    [DisplayName] NVARCHAR(256) NOT NULL,

    [JobTitle] nvarchar(256) NULL,

    [EmailAddress] nvarchar(256) NULL,
    [MobilePhone] nvarchar(50) NULL,
    [BusinessPhone] nvarchar(50) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL CONSTRAINT [DF_Instructor_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL CONSTRAINT [DF_Instructor_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'), 
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Instructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Instructor_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)
WITH 
(
    SYSTEM_VERSIONING = ON 
    (
        HISTORY_TABLE = [History].[Instructor],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE INDEX [IX_Instructor_EmailAddress]
    ON [IQ].[Instructor] ([EmailAddress])

GO
CREATE INDEX [IX_Instructor_TenantId]
    ON [IQ].[Instructor] ([TenantId])
