CREATE TABLE [IQ].[Session]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Session_Id] DEFAULT (NEWSEQUENTIALID()),

    [Note] NVARCHAR(MAX) NULL,

    [StartDate] DATE NULL,
    [StartTime] TIME(1) NULL,
    [EndDate] DATE NULL,
    [EndTime] TIME(1) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,
    [TopicId] UNIQUEIDENTIFIER NOT NULL,
    [LocationId] UNIQUEIDENTIFIER NULL,
    [GroupId] UNIQUEIDENTIFIER NULL,
    [LeadInstructorId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL CONSTRAINT [DF_Session_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL CONSTRAINT [DF_Session_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'),
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Session] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_Session_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [IQ].[Topic]([Id]),
    CONSTRAINT [FK_Session_Location_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [IQ].[Location]([Id]),
    CONSTRAINT [FK_Session_Group_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [IQ].[Group]([Id]),
    CONSTRAINT [FK_Session_Instructor_LeadInstructorId] FOREIGN KEY ([LeadInstructorId]) REFERENCES [Identity].[User]([Id]),
)
WITH
(
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = [History].[Session],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE INDEX [IX_Session_TenantId]
    ON [IQ].[Session] ([TenantId])

GO
CREATE INDEX [IX_Session_StartDate]
    ON [IQ].[Session] ([StartDate])

GO
CREATE INDEX [IX_Session_TopicId]
    ON [IQ].[Session] ([TopicId])
