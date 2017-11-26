CREATE TABLE [dbo].[UserLogin]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_UserLogin_Id] DEFAULT (newsequentialid()),

    [LoginProvider] NVARCHAR(450) NOT NULL,
    [ProviderKey] NVARCHAR(450) NOT NULL,

    [ProviderDisplayName] [nvarchar](max) NULL,

    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserLogin] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
)
GO

CREATE UNIQUE INDEX [UX_UserLogin_LoginProvider_ProviderKey]
ON [dbo].[UserLogin] ([LoginProvider] ASC, [ProviderKey] ASC)
GO

CREATE INDEX [IX_UserLogin_UserId]
ON [dbo].[UserLogin] ([UserId])
