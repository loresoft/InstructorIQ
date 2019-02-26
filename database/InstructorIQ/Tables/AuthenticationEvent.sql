CREATE TABLE [IQ].[AuthenticationEvent]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_AuthenticationEvent_Id] DEFAULT (NEWSEQUENTIALID()),

    [EmailAddress] NVARCHAR(256) NOT NULL,
    [UserName] NVARCHAR(256) NOT NULL,

    [UserAgent] NVARCHAR(MAX) NULL,
    [Browser] NVARCHAR(256) NULL,
    [OperatingSystem] NVARCHAR(256) NULL,
    [DeviceFamily] NVARCHAR(256) NULL,
    [DeviceBrand] NVARCHAR(256) NULL,
    [DeviceModel] NVARCHAR(256) NULL,

    [IpAddress] NVARCHAR(50) NULL,

    [IsSuccessful] [BIT] NOT NULL CONSTRAINT [DF_AuthenticationEvent_IsSuccessful] DEFAULT (0),
    [FailureMessage] NVARCHAR(256) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_AuthenticationEvent_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_AuthenticationEvent_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_AuthenticationEvent] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE INDEX [IX_AuthenticationEvent_EmailAddress]
    ON [IQ].[AuthenticationEvent] ([EmailAddress])

GO
CREATE INDEX [IX_AuthenticationEvent_UserName]
    ON [IQ].[AuthenticationEvent] ([UserName])

