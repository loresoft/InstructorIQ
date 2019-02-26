CREATE TABLE [IQ].[InviteRole]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_InviteRole_Id] DEFAULT (NEWSEQUENTIALID()),

    [InviteId] UNIQUEIDENTIFIER NOT NULL,
    [RoleName] NVARCHAR(256) NOT NULL,

    CONSTRAINT [PK_InviteRole] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InviteRole_Invite_InviteId] FOREIGN KEY ([InviteId]) REFERENCES [IQ].[Invite]([Id]),
)

GO
CREATE INDEX [UX_InviteRole_InviteId]
    ON [IQ].[InviteRole] ([InviteId])
