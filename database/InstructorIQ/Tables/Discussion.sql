CREATE TABLE [IQ].[Discussion]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Discussion_Id] DEFAULT (NEWSEQUENTIALID()),
    
    [TopicId] UNIQUEIDENTIFIER NOT NULL,
    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Message] NVARCHAR(MAX) NULL,
    [MessageDate] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Discussion_MessageDate] DEFAULT (SYSUTCDATETIME()),

    [EmailAddress] NVARCHAR(256) NOT NULL,
    [DisplayName] NVARCHAR(256) NOT NULL,

    [UserAgent] NVARCHAR(MAX) NULL,
    [Browser] NVARCHAR(256) NULL,
    [OperatingSystem] NVARCHAR(256) NULL,
    [DeviceFamily] NVARCHAR(256) NULL,
    [DeviceBrand] NVARCHAR(256) NULL,
    [DeviceModel] NVARCHAR(256) NULL,

    [IpAddress] NVARCHAR(50) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Discussion_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Discussion_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL CONSTRAINT [DF_Discussion_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL CONSTRAINT [DF_Discussion_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'), 
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Discussion] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Discussion_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_Discussion_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [IQ].[Topic]([Id]),
)
WITH 
(
    SYSTEM_VERSIONING = ON 
    (
        HISTORY_TABLE = [History].[Discussion],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);


GO
CREATE INDEX [IX_Discussion_TenantId]
ON [IQ].[Discussion] ([TenantId])

GO
CREATE INDEX [IX_Discussion_TopicId]
ON [IQ].[Discussion] ([TopicId])
