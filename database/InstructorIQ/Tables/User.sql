CREATE TABLE [IQ].[User]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_User_Id] DEFAULT (NEWSEQUENTIALID()),

    [EmailAddress] NVARCHAR(256) NOT NULL,
    [IsEmailAddressConfirmed] BIT NOT NULL CONSTRAINT [DF_User_IsEmailAddressConfirmed] DEFAULT (0),

    [DisplayName] NVARCHAR(256) NOT NULL,

    [PasswordHash] [NVARCHAR](MAX) NULL,
    [ResetHash] [NVARCHAR](MAX) NULL,
    [InviteHash] [NVARCHAR](MAX) NULL,

    [AccessFailedCount] [INT] NOT NULL CONSTRAINT [DF_User_AccessFailedCount] DEFAULT (0),
    [LockoutEnabled] [BIT] NOT NULL CONSTRAINT [DF_User_LockoutEnabled] DEFAULT (0),
    [LockoutEnd] [DATETIMEOFFSET](7) NULL,

    [LastLogin] DATETIMEOFFSET NULL,
    [LastTenantId] UNIQUEIDENTIFIER NULL,

    [IsDeleted] [BIT] NOT NULL CONSTRAINT [DF_User_IsDeleted] DEFAULT (0),
    [IsGlobalAdministrator] [BIT] NOT NULL CONSTRAINT [DF_User_IsGlobalAdministrator] DEFAULT (0),

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Tenant_LastTenantId] FOREIGN KEY ([LastTenantId]) REFERENCES [IQ].[Tenant]([Id]),
)
GO

CREATE UNIQUE INDEX [UX_User_EmailAddress]
ON [IQ].[User] ([EmailAddress])
