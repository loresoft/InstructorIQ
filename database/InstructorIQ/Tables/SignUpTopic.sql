﻿CREATE TABLE [IQ].[SignUpTopic]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SignUpTopic_Id] DEFAULT (NEWSEQUENTIALID()),

    [SignUpId] UNIQUEIDENTIFIER NOT NULL,
    [TopicId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SignUpTopic_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SignUpTopic_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_SignUpTopic] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignUpTopic_SignUp_SignUpId] FOREIGN KEY ([SignUpId]) REFERENCES [IQ].[SignUp]([Id]),
    CONSTRAINT [FK_SignUpTopic_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [IQ].[Topic]([Id]),
)

GO
CREATE CLUSTERED INDEX [IX_SignUpTopic_SignUpId]
    ON [IQ].[SignUpTopic] ([SignUpId] ASC)