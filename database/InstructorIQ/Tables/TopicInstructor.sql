CREATE TABLE [IQ].[TopicInstructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_TopicInstructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [TopicId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorRoleId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_TopicInstructor_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_TopicInstructor_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL CONSTRAINT [DF_TopicInstructor_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL CONSTRAINT [DF_TopicInstructor_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'),
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_TopicInstructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TopicInstructor_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [IQ].[Topic]([Id]),
    CONSTRAINT [FK_TopicInstructor_Instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [Identity].[User]([Id]),
    CONSTRAINT [FK_TopicInstructor_InstructorRole_InstructorRoleId] FOREIGN KEY ([InstructorRoleId]) REFERENCES [IQ].[InstructorRole]([Id]),
)
WITH
(
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = [History].[TopicInstructor],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE CLUSTERED INDEX [IX_TopicInstructor_TopicId_InstructorId]
    ON [IQ].[TopicInstructor] ([TopicId] ASC, [InstructorId] ASC, [InstructorRoleId] ASC)