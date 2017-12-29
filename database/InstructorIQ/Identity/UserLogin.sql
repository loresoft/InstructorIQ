CREATE TABLE [dbo].[UserLogin]
(
    [LoginProvider] NVARCHAR(450) NOT NULL,
    [ProviderKey] NVARCHAR(450) NOT NULL,

    [ProviderDisplayName] NVARCHAR(max) NULL,

    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_UserLogin_UserId]
ON [dbo].[UserLogin] ([UserId])
