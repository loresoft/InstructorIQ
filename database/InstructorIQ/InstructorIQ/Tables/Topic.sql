CREATE TABLE [dbo].[Topic]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Topic_Id] DEFAULT (newsequentialid()),
    [Title] NVARCHAR(256) NOT NULL,

    [Description] NVARCHAR(MAX) NULL,
    [Objectives] NVARCHAR(MAX) NULL,

    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,
    [LeadInstructorId] UNIQUEIDENTIFIER NULL,

    [CalendarYear] SMALLINT NOT NULL DEFAULT year(getdate()),

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Topic_Created] DEFAULT (sysutcdatetime()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Topic_Updated] DEFAULT (sysutcdatetime()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Topic] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Topic_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),
    CONSTRAINT [FK_Topic_Instructor_LeadInstructorId] FOREIGN KEY ([LeadInstructorId]) REFERENCES [Instructor]([Id]),
)

GO
CREATE INDEX [IX_Topic_Title]
ON [dbo].[Topic] ([Title])

GO
CREATE INDEX [IX_Topic_OrganizationId]
ON [dbo].[Topic] ([OrganizationId])

GO
CREATE INDEX [IX_Topic_CalendarYear]
ON [dbo].[Topic] ([CalendarYear])
