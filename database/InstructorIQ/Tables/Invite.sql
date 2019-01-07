CREATE TABLE [IQ].[Invite]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Invite_Id] DEFAULT (NEWSEQUENTIALID()),

    [DisplayName] NVARCHAR(256) NULL,
    [EmailAddress] NVARCHAR(256) NULL,

    [UserId] UNIQUEIDENTIFIER NULL,
    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [InviteHash] NVARCHAR(MAX) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Invite_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Invite_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Invite] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invite_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [IQ].[User]([Id]),
    CONSTRAINT [FK_Invite_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_Invite_EmailAddress]
ON [IQ].[Invite] ([EmailAddress])

GO
CREATE INDEX [IX_Invite_UserId]
ON [IQ].[Invite] ([UserId])

GO
CREATE INDEX [IX_Invite_TenantId]
ON [IQ].[Invite] ([TenantId])
