CREATE TABLE [IQ].[Tenant]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Tenant_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,
    [Slug] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [City] nvarchar(150) NULL,
    [StateProvince]  nvarchar(150) NULL,
    [TimeZone] NVARCHAR(150) NOT NULL CONSTRAINT [DF_Tenant_TimeZone] DEFAULT 'Central Standard Time',

    [DomainName] nvarchar(150) NULL,

    [IsDeleted] BIT NOT NULL CONSTRAINT [DF_Tenant_IsDeleted] DEFAULT (0),

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Tenant_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Tenant_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL CONSTRAINT [DF_Tenant_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL CONSTRAINT [DF_Tenant_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'), 
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Tenant] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)
WITH 
(
    SYSTEM_VERSIONING = ON 
    (
        HISTORY_TABLE = [History].[Tenant],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);


GO
CREATE INDEX [IX_Tenant_Name]
    ON [IQ].[Tenant] ([Name])

GO
CREATE UNIQUE INDEX [UX_Tenant_Slug]
    ON [IQ].[Tenant] ([Slug])

GO
CREATE INDEX [IX_Tenant_IsDeleted]
    ON [IQ].[Tenant] ([IsDeleted])
