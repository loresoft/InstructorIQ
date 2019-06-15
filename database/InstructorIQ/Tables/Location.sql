CREATE TABLE [IQ].[Location]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Location_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [AddressLine1] nvarchar(256) NULL,
    [AddressLine2] nvarchar(256) NULL,
    [AddressLine3] nvarchar(256) NULL,
    [City] nvarchar(150) NULL,
    [StateProvince]  nvarchar(150) NULL,
    [PostalCode] nvarchar(50) NULL,

    [ContactName] NVARCHAR(256) NULL,
    [ContactEmail] nvarchar(256) NULL,
    [ContactPhone] nvarchar(50) NULL,

    [Latitude] decimal(20,10) NULL,
    [Longitude] decimal(20,10) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL CONSTRAINT [DF_Location_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL CONSTRAINT [DF_Location_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'), 
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Location] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)
WITH 
(
    SYSTEM_VERSIONING = ON 
    (
        HISTORY_TABLE = [History].[Location],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE INDEX [IX_Location_Name]
    ON [IQ].[Location] ([Name])

GO
CREATE INDEX [IX_Location_TenantId]
    ON [IQ].[Location] ([TenantId])
