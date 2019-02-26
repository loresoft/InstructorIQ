CREATE TABLE [IQ].[HistoryRecord]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_HistoryRecord_Id] DEFAULT (NEWSEQUENTIALID()),

    [Key] UNIQUEIDENTIFIER NOT NULL,
    [Entity] NVARCHAR(100) NOT NULL,

    [ParentKey] UNIQUEIDENTIFIER NULL,
    [ParentEntity] NVARCHAR(100) NULL,

    [Changed] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_HistoryRecord_Changed] DEFAULT (SYSUTCDATETIME()),
    [ChangedBy] NVARCHAR(100) NULL,

    [PropertyName] NVARCHAR(256) NULL,
    [DisplayName] NVARCHAR(256) NULL,
    [Path] NVARCHAR(256) NULL,
    [Operation] NVARCHAR(100) NULL,

    [OriginalValue] NVARCHAR(MAX) NULL,
    [OriginalFormated] NVARCHAR(256) NULL,
    [OriginalType] NVARCHAR(256) NULL,

    [CurrentValue] NVARCHAR(MAX) NULL,
    [CurrentFormated] NVARCHAR(256) NULL,
    [CurrentType] NVARCHAR(256) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_HistoryRecord_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_HistoryRecord_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_HistoryRecord] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE INDEX [IX_HistoryRecord_Entity]
    ON [IQ].[HistoryRecord] ([Key], [Entity])

