CREATE TABLE [Identity].[UserLogin]
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey] NVARCHAR (128) NOT NULL,

    [ProviderDisplayName] NVARCHAR(max) NULL,

    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserLogin_UserId]
    ON [Identity].[UserLogin]([UserId] ASC);

