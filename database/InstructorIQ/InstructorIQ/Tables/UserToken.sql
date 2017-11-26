CREATE TABLE [dbo].[UserToken]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_UserToken_Id] DEFAULT (newsequentialid()),

    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [LoginProvider] NVARCHAR(450) NOT NULL,
    [Name] NVARCHAR(450) NOT NULL,

    [Value] NVARCHAR(MAX) NULL,

    CONSTRAINT [PK_UserToken] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
)
GO

CREATE UNIQUE CLUSTERED INDEX [UX_UserToken_UserId_LoginProvider]
ON [dbo].[UserToken] ([UserId] ASC, [LoginProvider] ASC, [Name] ASC)
