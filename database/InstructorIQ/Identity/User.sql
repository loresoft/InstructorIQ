CREATE TABLE [dbo].[User]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_User_Id] DEFAULT (newsequentialid()),

    [Email] NVARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL CONSTRAINT [DF_User_EmailConfirmed] DEFAULT (0),
    [NormalizedEmail] NVARCHAR(256) NULL,

    [UserName] NVARCHAR(256) NULL,
    [NormalizedUserName] NVARCHAR(256) NULL,

    [PhoneNumber] NVARCHAR(max) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL,

    [PasswordHash] NVARCHAR(max) NULL,

    [TwoFactorEnabled] BIT NOT NULL CONSTRAINT [DF_User_TwoFactorEnabled] DEFAULT (0),

    [AccessFailedCount] INT NOT NULL CONSTRAINT [DF_User_AccessFailedCount] DEFAULT (0),
    [LockoutEnabled] BIT NOT NULL CONSTRAINT [DF_User_LockoutEnabled] DEFAULT (0),
    [LockoutEnd] DATETIMEOFFSET NULL,

    [SecurityStamp] NVARCHAR(max) NULL,
    [ConcurrencyStamp] NVARCHAR(max) NULL,

    CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE INDEX [UX_User_UserName]
ON [dbo].[User] ([NormalizedUserName])
GO

CREATE UNIQUE INDEX [UX_User_EmailAddress]
ON [dbo].[User] ([NormalizedEmail])
GO
