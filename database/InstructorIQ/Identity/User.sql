CREATE TABLE [Identity].[User]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_User_Id] DEFAULT (newsequentialid()),

    [Email] NVARCHAR(256) NULL,
    [NormalizedEmail] NVARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL CONSTRAINT [DF_User_EmailConfirmed] DEFAULT (0),

    [UserName] NVARCHAR(256) NULL,
    [NormalizedUserName] NVARCHAR(256) NULL,

    [PhoneNumber] NVARCHAR(MAX) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL CONSTRAINT [DF_User_PhoneNumberConfirmed] DEFAULT (0),

    [DisplayName] NVARCHAR(256) NOT NULL,

    [PasswordHash] NVARCHAR(MAX) NULL,

    [TwoFactorEnabled] BIT NOT NULL CONSTRAINT [DF_User_TwoFactorEnabled] DEFAULT (0),

    [AccessFailedCount] INT NOT NULL CONSTRAINT [DF_User_AccessFailedCount] DEFAULT (0),
    [LockoutEnabled] BIT NOT NULL CONSTRAINT [DF_User_LockoutEnabled] DEFAULT (0),
    [LockoutEnd] DATETIMEOFFSET(7) NULL,

    [SecurityStamp] NVARCHAR(MAX) NULL,
    [ConcurrencyStamp] NVARCHAR(MAX) NULL,

    CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED ([Id] ASC)
)
GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [Identity].[User]([NormalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [Identity].[User]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);

