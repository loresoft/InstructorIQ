CREATE TABLE [dbo].[UserClaim]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_UserClaim_Id] DEFAULT (newsequentialid()),

    [ClaimType] [NVARCHAR](MAX) NULL,
    [ClaimValue] [NVARCHAR](MAX) NULL,

    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserClaim] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
)

GO
CREATE INDEX [IX_UserClaim_UserId]
ON [dbo].[UserClaim] ([UserId])

