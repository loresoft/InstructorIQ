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

    [Latitude] decimal(20,10) NULL,
    [Longitude] decimal(20,10) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Location] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_Location_Name]
ON [IQ].[Location] ([Name])

GO
CREATE INDEX [IX_Location_TenantId]
ON [IQ].[Location] ([TenantId])
