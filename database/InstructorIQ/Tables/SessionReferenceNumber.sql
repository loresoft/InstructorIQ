CREATE TABLE [IQ].[SessionReferenceNumber]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SessionReferenceNumber_Id] DEFAULT (NEWSEQUENTIALID()),

    [ReferenceNumber] NVARCHAR(255) NOT NULL,
    [ReferenceType] NVARCHAR(100) NOT NULL,

    [SessionId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SessionReferenceNumber_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SessionReferenceNumber_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_SessionReferenceNumber] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionReferenceNumber_Session_[SessionId] FOREIGN KEY ([SessionId]) REFERENCES [IQ].[Session]([Id]),
)

GO
CREATE INDEX [IX_SessionReferenceNumber_Type]
ON [IQ].[SessionReferenceNumber] ([ReferenceType])

GO
CREATE INDEX [IX_SessionReferenceNumber_SessionId]
ON [IQ].[SessionReferenceNumber] ([SessionId])

