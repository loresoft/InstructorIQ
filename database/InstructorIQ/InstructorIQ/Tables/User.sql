CREATE TABLE [dbo].[User]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_User_Id] DEFAULT (newsequentialid()),

    [EmailAddress] NVARCHAR(256) NOT NULL,
    [IsEmailAddressConfirmed] BIT NOT NULL CONSTRAINT [DF_User_IsEmailAddressConfirmed] DEFAULT (0),

    [DisplayName] NVARCHAR(256) NOT NULL,

    [PasswordHash] [NVARCHAR](MAX) NULL,

    [PhoneNumber] [NVARCHAR](MAX) NULL,
    [IsPhoneNumberConfirmed] [BIT] NOT NULL CONSTRAINT [DF_User_IsPhoneNumberConfirmed] DEFAULT (0),

    [SecurityStamp] [NVARCHAR](MAX) NULL,

    [IsTwoFactorEnabled] [BIT] NOT NULL CONSTRAINT [DF_User_IsTwoFactorEnabled] DEFAULT (0),

    [AccessFailedCount] [INT] NOT NULL CONSTRAINT [DF_User_AccessFailedCount] DEFAULT (0),
    [LockoutEnabled] [BIT] NOT NULL CONSTRAINT [DF_User_LockoutEnabled] DEFAULT (0),
    [LockoutEnd] [DATETIMEOFFSET](7) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_Created] DEFAULT (sysutcdatetime()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_Updated] DEFAULT (sysutcdatetime()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE INDEX [UX_User_EmailAddress]
ON [dbo].[User] ([EmailAddress])
