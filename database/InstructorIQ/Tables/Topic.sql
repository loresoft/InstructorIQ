CREATE TABLE [IQ].[Topic]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Topic_Id] DEFAULT (NEWSEQUENTIALID()),
    [Title] NVARCHAR(256) NOT NULL,

    [Description] NVARCHAR(MAX) NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [LeadInstructorId] UNIQUEIDENTIFIER NULL,

    [LessonPlan] NVARCHAR(MAX) NULL,
    [Notes] NVARCHAR(MAX) NULL,

    [IsRequired] BIT NOT NULL CONSTRAINT [DF_Topic_IsRequired] DEFAULT (0),
    [IsPublished] BIT NOT NULL CONSTRAINT [DF_Topic_IsPublished] DEFAULT (0),

    [CalendarYear] SMALLINT NOT NULL CONSTRAINT [DF_Topic_CalendarYear] DEFAULT YEAR(GETDATE()),
    [TargetMonth] SMALLINT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Topic_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Topic_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    [PeriodStart] DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL CONSTRAINT [DF_Topic_PeriodStart] DEFAULT (SYSUTCDATETIME()),
    [PeriodEnd] DATETIME2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL CONSTRAINT [DF_Topic_PeriodEnd] DEFAULT ('9999-12-31 23:59:59.9999999'), 
    PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd]),

    CONSTRAINT [PK_Topic] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Topic_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_Topic_Instructor_LeadInstructorId] FOREIGN KEY ([LeadInstructorId]) REFERENCES [IQ].[Instructor]([Id]),
)
WITH 
(
    SYSTEM_VERSIONING = ON 
    (
        HISTORY_TABLE = [History].[Topic],
        HISTORY_RETENTION_PERIOD = 1 YEARS,
        DATA_CONSISTENCY_CHECK = ON
    )
);

GO
CREATE INDEX [IX_Topic_Title]
    ON [IQ].[Topic] ([Title])

GO
CREATE INDEX [IX_Topic_TenantId]
    ON [IQ].[Topic] ([TenantId])

GO
CREATE INDEX [IX_Topic_CalendarYear]
    ON [IQ].[Topic] ([CalendarYear])
