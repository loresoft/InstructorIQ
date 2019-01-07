CREATE TABLE [IQ].[EmailDelivery]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_EmailDelivery_Id] DEFAULT (NEWSEQUENTIALID()),

    [IsProcessing] BIT NOT NULL CONSTRAINT [DF_EmailDelivery_IsProcessing] DEFAULT (0),

    [IsDelivered] BIT NOT NULL CONSTRAINT [DF_EmailDelivery_IsDelivered] DEFAULT (0),
    [Delivered] DATETIMEOFFSET NULL,

    [Attempts] INT NOT NULL CONSTRAINT [DF_EmailDelivery_Attempts] DEFAULT (0),
    [LastAttempt] DATETIMEOFFSET NULL,
    [NextAttempt] DATETIMEOFFSET NULL,

    [SmtpLog] NVARCHAR(MAX) NULL,
    [Error] NVARCHAR(MAX) NULL,

    [From] NVARCHAR(265) NULL,
    [To] NVARCHAR(265) NULL,
    [Subject] NVARCHAR(265) NULL,

    [MimeMessage] VARBINARY(MAX) NULL,

    [TenantId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_EmailDelivery_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_EmailDelivery_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_EmailDelivery] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmailDelivery_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_EmailDelivery_Next]
ON [IQ].[EmailDelivery] ([IsProcessing], [IsDelivered], [NextAttempt])

GO
CREATE INDEX [IX_EmailDelivery_TenantId]
ON [IQ].[EmailDelivery] ([TenantId])

