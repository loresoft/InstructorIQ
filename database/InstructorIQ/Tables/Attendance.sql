CREATE TABLE [IQ].[Attendance]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Attendance_Id] DEFAULT (NEWSEQUENTIALID()),
        
    [SessionId] UNIQUEIDENTIFIER NOT NULL,
    
    [Attended] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Attendance_Attended] DEFAULT (SYSUTCDATETIME()),
    [AttendeeEmail] NVARCHAR(256) NOT NULL,
    [AttendeeName] NVARCHAR(256) NULL,

    [Signature] NVARCHAR(MAX) NULL,
    [SignatureType] NVARCHAR(256) NULL,
    
    [TenantId] UNIQUEIDENTIFIER NOT NULL,
   
    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Attendance_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Attendance_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Attendance] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attendance_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
    CONSTRAINT [FK_Attendance_Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [IQ].[Session]([Id]),
)

GO
CREATE INDEX [IX_Attendance_TenantId]
    ON [IQ].[Attendance] ([TenantId])

GO
CREATE INDEX [IX_Attendance_SessionId]
    ON [IQ].[Attendance] ([SessionId])

GO
CREATE INDEX [IX_Attendance_AttendedBy]
    ON [IQ].[Attendance] ([AttendeeEmail])