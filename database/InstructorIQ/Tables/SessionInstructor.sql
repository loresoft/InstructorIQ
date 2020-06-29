CREATE TABLE [IQ].[SessionInstructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SessionInstructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [SessionId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorRoleId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SessionInstructor_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_SessionInstructor_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL CONSTRAINT [DF_SessionInstructor_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL CONSTRAINT [DF_SessionInstructor_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'),
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_SessionInstructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionInstructor_Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [IQ].[Session]([Id]),
    CONSTRAINT [FK_SessionInstructor_Instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [Identity].[User]([Id]),
    CONSTRAINT [FK_SessionInstructor_InstructorRole_InstructorRoleId] FOREIGN KEY ([InstructorRoleId]) REFERENCES [IQ].[InstructorRole]([Id]),
)
WITH
(
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = [History].[SessionInstructor],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE CLUSTERED INDEX [IX_SessionInstructor_SessionId_InstructorId]
    ON [IQ].[SessionInstructor] ([SessionId] ASC, [InstructorId] ASC, InstructorRoleId ASC)
