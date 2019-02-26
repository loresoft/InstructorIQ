CREATE TABLE [Identity].[UserClaim]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,

    [ClaimType] [NVARCHAR](MAX) NULL,
    [ClaimValue] [NVARCHAR](MAX) NULL,

    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserClaim] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User]([Id]) ON DELETE CASCADE
)

GO
CREATE CLUSTERED INDEX [IX_UserClaim_UserId]
    ON [Identity].[UserClaim]([UserId] ASC);

