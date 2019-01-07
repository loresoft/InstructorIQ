CREATE TABLE [IQ].[Session]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Session_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,

    [Note] NVARCHAR(MAX) NULL,

    [StartTime] DATETIMEOFFSET NULL,
    [EndTime] DATETIMEOFFSET NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,
    [TopicId] UNIQUEIDENTIFIER NOT NULL,
    [LocationId] UNIQUEIDENTIFIER NULL,
    [LeadInstructorId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Session] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_Session_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [IQ].[Topic]([Id]),
    CONSTRAINT [FK_Session_Location_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [IQ].[Location]([Id]),
    CONSTRAINT [FK_Session_Instructor_LeadInstructorId] FOREIGN KEY ([LeadInstructorId]) REFERENCES [IQ].[Instructor]([Id]),
)

GO
CREATE INDEX [IX_Session_Name]
ON [IQ].[Session] ([Name])

GO
CREATE INDEX [IX_Session_TenantId]
ON [IQ].[Session] ([TenantId])

GO
CREATE INDEX [IX_Session_TopicId]
ON [IQ].[Session] ([TopicId])
