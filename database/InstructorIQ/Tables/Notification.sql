CREATE TABLE [IQ].[Notification]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Notification_Id] DEFAULT (NEWSEQUENTIALID()),

    [Type] NVARCHAR(256) NOT NULL,
    [Message] NVARCHAR(MAX) NULL,

    [CorrelationType] NVARCHAR(256) NULL,
    [CorrelationId] UNIQUEIDENTIFIER NULL,

    [TenantId] UNIQUEIDENTIFIER NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [EmailAddress] NVARCHAR(256) NULL,


    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Notification_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Notification_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Notification] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Notification_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),

)

GO
CREATE INDEX [IX_Notification_UserId_EmailAddress]
ON [IQ].[Notification] ([UserId], [EmailAddress], [TenantId])

