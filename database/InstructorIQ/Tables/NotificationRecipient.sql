CREATE TABLE [IQ].[NotificationRecipient]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_NotificationRecipient_Id] DEFAULT (NEWSEQUENTIALID()),

    [NotificationId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,

    [Read] DATETIMEOFFSET NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_NotificationRecipient_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_NotificationRecipient_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_NotificationRecipient] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_NotificationRecipient_Notification_NotificationId] FOREIGN KEY ([NotificationId]) REFERENCES [IQ].[Notification]([Id]),
    CONSTRAINT [FK_NotificationRecipient_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [IQ].[User]([Id]),
)


GO
CREATE INDEX [IX_NotificationRecipient_NotificationId]
ON [IQ].[NotificationRecipient] ([NotificationId])

GO
CREATE INDEX [IX_NotificationRecipient_UserId]
ON [IQ].[NotificationRecipient] ([UserId])
